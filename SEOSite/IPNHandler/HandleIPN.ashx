<%@ WebHandler Language="C#" Class="HandleIPN" %>

using System;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using ANWO.Utility;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;

public class HandleIPN : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{
    ANWO.Data _Data = new ANWO.Data();
    ANewWebOrder.tblInvoice _InvoiceInDB;
    string _PayPalAddress = string.Empty;
    string _ReceiverEmail = string.Empty;
    string _PayPalMode = string.Empty;

    public void ProcessRequest(HttpContext context)
    {
        _PayPalMode = ConfigurationManager.AppSettings["PayPalMode"].ToString();

        context.Response.ContentType = "text/plain";

        ProcessPayPalIPNNotification(context);
    }

    /// <summary>
    /// Process an incoming Instant Payment Notification (IPN)
    /// from PayPal, at conclusion of a received payment from a
    /// customer
    /// </summary>
    private void ProcessPayPalIPNNotification(HttpContext context)
    {
        try
        {
            // receive PayPal ipn data

            #region RQS - Do Handshake with paypal and get response

            ANWOLogger.WriteSimpleLog("BEFORE HANDSHAKE", context.Request.UserHostAddress, LogCategory.Payment, 6);

            // extract ipn data into a string
            byte[] param = context.Request.BinaryRead(context.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);

            // append PayPal verification code to end of string
            strRequest += "&cmd=_notify-validate";

            if (_PayPalMode == "dev")
                _PayPalAddress = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "buynow_sandbox").Setting;
            else
                _PayPalAddress = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "buynow").Setting;

            // create an HttpRequest channel to perform handshake with PayPal
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_PayPalAddress);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = strRequest.Length;

            // send data back to PayPal to request verification
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();

            // receive response from PayPal
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            #endregion

            //ANWOLogger.WriteSimpleLog("BEFORE Verification", context.Request.UserHostAddress);
            // if PayPal response is successful / verified
            if (strResponse.Equals("VERIFIED"))
            {
                ANewWebOrder.tblInvoice invoice = ParseVariables(context);

                if (_PayPalMode == "dev")
                    _ReceiverEmail = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "receiver_email_sandbox").Setting;
                else
                    _ReceiverEmail = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "receiver_email").Setting;

                // if the payment status is complete
                if (invoice.PaymentStatus.Equals("Completed") && invoice.TxnType.ToLower() != "reversal") //this will cover echeck completion aswell
                {
                    if (IsInvoiceIDCorrect(invoice))
                    {
                        // if the seller email is us (we don't want anyone else getting our payment!)
                        if (invoice.ReceiverEmail.ToLower().Equals(_ReceiverEmail.ToLower()))
                        {
                            // if the amount received is as expected
                            if (IsOrderAmountCorrect(invoice))
                            {
                                if (IsBusinessInfoCorrect(invoice))
                                {
                                    if (IsItemInfoCorrect(invoice))
                                    {
                                        ANWOLogger.WritePaymentLog("All Verification Done.", invoice, _InvoiceInDB, LogCategory.Payment, 4);

                                        _InvoiceInDB = FillInvoiceInDB(invoice, _InvoiceInDB);
                                        ANewWebOrder.tblCampaign camp = _InvoiceInDB.tblCampaign;

                                        camp.LastPaymentDate = DateTime.Now;
                                        camp.LastUpdated = DateTime.Now;
                                        camp.IsPendingSetup = false;
                                        camp.IsLive = true;

                                        ANewWebOrder.tblPlan plan = _InvoiceInDB.tblPlan;

                                        if (plan.PlanDurationUnitTypeID == 1)
                                            camp.ExpiryDate = DateTime.Now.AddYears(_InvoiceInDB.tblPlan.Units);
                                        else if (plan.PlanDurationUnitTypeID == 2)
                                            camp.ExpiryDate = DateTime.Now.AddMonths(_InvoiceInDB.tblPlan.Units);
                                        else if (plan.PlanDurationUnitTypeID == 3)
                                            camp.ExpiryDate = DateTime.Now.AddDays(_InvoiceInDB.tblPlan.Units * 7);
                                        else if (plan.PlanDurationUnitTypeID == 4)
                                            camp.ExpiryDate = DateTime.Now.AddDays(_InvoiceInDB.tblPlan.Units);

                                        _Data.NWODC.SubmitChanges();

                                        ANWOLogger.WritePaymentLog("Payment Completed.", invoice, _InvoiceInDB, LogCategory.Payment, 4);

                                        ANWO.Biz.Entities.EmailMessage message = ANWO.Biz.EmailMessageFactory.GetPaymentInvoice("PAYMENTINVOICE", invoice.ID);

                                        ANWO.Utility.EmailSender.SendEmail(message.FromEmail, message.ToEmail, message.Title, message.Message, MailPriority.High, MailSendContext.PaypalHandler);

                                        ANWOLogger.WritePaymentLog("Payment Completed, Email Sent to Payer!", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                                    }
                                    else
                                    {
                                        //Don't process the order, invalid amount
                                        ANWOLogger.WritePaymentLog("Invalid Item Info", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                                    }
                                }
                                else
                                {
                                    //Don't process the order, invalid amount
                                    ANWOLogger.WritePaymentLog("Invalid Business Info", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                                }
                            }
                            else
                            {
                                //Don't process the order, invalid amount
                                ANWOLogger.WritePaymentLog("Invalid Amount", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                            }
                        }
                        else
                        {
                            // don't process the order, invalid seller
                            ANWOLogger.WritePaymentLog("Invalid Seller", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                        }
                    }
                    else
                    {
                        // don't process the order, invalid invoice id, probably a hack attempt
                        ANWOLogger.WritePaymentLog("Invalid InvoiceID", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                    }
                }
                else if (invoice.PaymentStatus.ToLower().Equals("refunded") || invoice.TxnType.ToLower() == "reversal") //For refund txn_type = null
                {

                    if (_PayPalMode == "dev")
                        _ReceiverEmail = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "receiver_email_sandbox").Setting;
                    else
                        _ReceiverEmail = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "receiver_email").Setting;

                    if (invoice.ReceiverEmail.ToLower().Equals(_ReceiverEmail.ToLower()))
                    {
                        if (IsParentTransactionCorrect(invoice))
                        {
                            if (IsInvoiceRefundable(invoice))
                            {
                                if (IsRefundAmountCorrect(invoice))
                                {
                                    if (IsBusinessInfoCorrect(invoice))
                                    {
                                        invoice.ID = Guid.NewGuid().ToString("N") + "-" + context.Session.SessionID;
                                        invoice.ProfileID = _InvoiceInDB.ProfileID;
                                        invoice.CampaignID = _InvoiceInDB.CampaignID;
                                        invoice.PlanID = _InvoiceInDB.PlanID;
                                        invoice.CreatedDate = DateTime.Now;

                                        invoice.MCFee = invoice.MCFee;
                                        invoice.MCGross = invoice.MCGross;
                                        invoice.MCGross1 = invoice.MCGross1;
                                        invoice.ReasonCode = invoice.ReasonCode;
                                        invoice.TxnType = invoice.TxnType;
                                        invoice.TxnID = invoice.TxnID;
                                        invoice.ParentTxnId = invoice.ParentTxnId;
                                        invoice.PaymentStatus = invoice.PaymentStatus;

                                        _Data.NWODC.tblInvoices.InsertOnSubmit(invoice);
                                        _Data.NWODC.SubmitChanges();

                                        ANewWebOrder.tblCampaign camp = _InvoiceInDB.tblCampaign;

                                        camp.LastPaymentDate = null;
                                        camp.LastUpdated = DateTime.Now;
                                        camp.IsPendingSetup = true;
                                        camp.IsLive = false;

                                        //subtract amount of time from plan
                                        if (_InvoiceInDB.tblPlan.PlanDurationUnitTypeID == 1)
                                            camp.ExpiryDate = camp.ExpiryDate.Value.AddDays(((_InvoiceInDB.tblPlan.Units * 365) * -1));
                                        if (_InvoiceInDB.tblPlan.PlanDurationUnitTypeID == 2)
                                            camp.ExpiryDate = camp.ExpiryDate.Value.AddMonths(((_InvoiceInDB.tblPlan.Units) * -1));
                                        if (_InvoiceInDB.tblPlan.PlanDurationUnitTypeID == 3)
                                            camp.ExpiryDate = camp.ExpiryDate.Value.AddDays(((_InvoiceInDB.tblPlan.Units * 7) * -1));
                                        if (_InvoiceInDB.tblPlan.PlanDurationUnitTypeID == 4)
                                            camp.ExpiryDate = camp.ExpiryDate.Value.AddDays(((_InvoiceInDB.tblPlan.Units) * -1));

                                        _Data.NWODC.SubmitChanges();

                                        ANWOLogger.WritePaymentLog("Payment Refunded.", invoice, _InvoiceInDB, LogCategory.Payment, 4);

                                        ANWOLogger.WritePaymentLog("Payment Completed.", invoice, _InvoiceInDB, LogCategory.Payment, 4);

                                        ANWO.Biz.Entities.EmailMessage message = ANWO.Biz.EmailMessageFactory.GetPaymentInvoice("PAYMENTINVOICE", invoice.ID);

                                        ANWO.Utility.EmailSender.SendEmail(message.FromEmail, message.ToEmail, message.Title, message.Message, MailPriority.High, MailSendContext.PaypalHandler);

                                        ANWOLogger.WritePaymentLog("Payment Refunded, Email Sent to Receiver!", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                                    }
                                    else
                                    {
                                        //Don't process the order, invalid amount
                                        ANWOLogger.WritePaymentLog("Refund-Invalid Business Info", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                                    }
                                }
                                else
                                {
                                    //Don't process the order, invalid amount
                                    ANWOLogger.WritePaymentLog("Refund-Invalid Amount", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                                }
                            }
                            else
                            {
                                //Don't process the order, Already refunded
                                ANWOLogger.WritePaymentLog("Already Refunded", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                            }
                        }
                        else
                        {
                            //Don't process the order, invalid Parent Transaction
                            ANWOLogger.WritePaymentLog("Refund-Invalid Parent Transaction", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                        }
                    }
                    else
                    {
                        //Don't process the order, invalid seller
                        ANWOLogger.WritePaymentLog("Refund-Invalid Seller", invoice, _InvoiceInDB, LogCategory.HighAlert, 1);
                    }
                }
                else
                {
                    // payment not complete yet, may be undergoing additional verification or processing
                    // do nothing - wait for paypal to send another IPN when payment is complete
                }
            }
        }
        catch (Exception ex)
        {
            ANWOLogger.WriteExceptionLog("General Paypal Handler ", ex, LogCategory.HighAlert, 1);
        }
    }

    private static ANewWebOrder.tblInvoice ParseVariables(HttpContext context)
    {
        ANWOLogger.WriteSimpleLog("VERIFIED", string.Empty);
        // paypal has verified the data, it is safe for us to perform processing now
        //Payment information
        string paymentType = context.Request.Form["payment_type"];
        string paymentDate = context.Request.Form["payment_date"];
        string paymentStatus = context.Request.Form["payment_status"];
        string pendingReason = context.Request.Form["pending_reason"];
        //Buyer information
        string addressStatus = context.Request.Form["address_status"];
        string payerStatus = context.Request.Form["payer_status"];
        string firstName = context.Request.Form["first_name"];
        string lastName = context.Request.Form["last_name"];
        string payerEmail = context.Request.Form["payer_email"];
        string payerId = context.Request.Form["payer_id"];
        string addressName = context.Request.Form["address_name"];
        string addressCountry = context.Request.Form["address_country"];
        string addressCountryCode = context.Request.Form["address_country_code"];
        string addressZip = context.Request.Form["address_zip"];
        string addressState = context.Request.Form["address_state"];
        string addressCity = context.Request.Form["address_city"];
        string addressStreet = context.Request.Form["address_street"];
        //Basic information
        string business = context.Request.Form["business"];
        string receiverEmail = context.Request.Form["receiver_email"];
        string receiverId = context.Request.Form["receiver_id"];
        string residenceCountry = context.Request.Form["residence_country"];
        string itemName = context.Request.Form["item_name"];
        string itemNumber = context.Request.Form["item_number"];
        string quantity = context.Request.Form["quantity"];
        string shipping = context.Request.Form["shipping"];
        string tax = context.Request.Form["tax"];
        //Currency and Currency Exchange
        string mcCurrency = context.Request.Form["mc_currency"];
        string mcFee = context.Request.Form["mc_fee"];
        string mcGross = context.Request.Form["mc_gross"];
        string mcGross1 = context.Request.Form["mc_gross_1"];
        //Transaction fields
        string txnType = context.Request.Form["txn_type"];
        string txnId = context.Request.Form["txn_id"];
        string parentTxnId = context.Request.Form["parent_txn_id"];
        string notifyVersion = context.Request.Form["notify_version"];
        //The receipt_id is a unique id that is generated by PayPal when someone pays 
        //directly with their credit card without logging into an account and is always 
        //formatted like this: "receipt_id="XXXX-XXXX-XXXX-XXXX"
        string receiptID = context.Request.Form["receipt_ID"];
        //Advanced and custom information
        string custom = context.Request.Form["custom"];//This will be carrying tblInvoice.ID
        //Refund Reversal
        string reasonCode = context.Request.Form["reason_code"];
        //Miscellenous
        string protectionEligibility = context.Request.Form["protection_eligibility"];
        string fraudManagmentPendingFilters = context.Request.Form["fraud_managment_pending_filters"];

        ANewWebOrder.tblInvoice inv = new ANewWebOrder.tblInvoice();

        inv.ID = custom;

        inv.AddressCity = addressCity;
        inv.AddressCountry = addressCountry;
        inv.AddressCountryCode = addressCountryCode;
        inv.AddressName = addressName;
        inv.AddressState = addressState;
        inv.AddressStatus = addressStatus;
        inv.AddressStreet = addressStreet;
        inv.AddressZip = addressZip;
        inv.Business = business;
        inv.FirstName = firstName;
        inv.ItemName = itemName;
        inv.ItemNumber = itemNumber;
        inv.LastName = lastName;
        inv.MCCurrency = mcCurrency;
        inv.MCFee = mcFee;
        inv.MCGross = mcGross;
        inv.MCGross1 = mcGross1;
        inv.NotifyVersion = notifyVersion;
        inv.PayerEmail = payerEmail;
        inv.PayerID = payerId;
        inv.PayerStatus = payerStatus;
        inv.PaymentStatus = paymentStatus;
        inv.PaymentType = paymentType;
        inv.PendingReason = pendingReason;
        inv.ProtectionEligibility = protectionEligibility;
        inv.Quantity = quantity;
        inv.ReasonCode = reasonCode;
        inv.ReceiverEmail = receiverEmail;
        inv.ReceiverID = receiverId;
        inv.ResidenceCountry = residenceCountry;
        inv.Shipping = shipping;
        inv.Tax = tax;
        inv.TxnID = txnId;
        inv.TxnType = txnType;
        inv.ParentTxnId = parentTxnId;
        inv.PaymentDate = paymentDate;
        inv.FraudManagementPendingFilter = fraudManagmentPendingFilters;
        inv.ReceiptID = receiptID;
        inv.PaypalIP = context.Request.UserHostAddress;

        return inv;
    }

    private bool IsInvoiceIDCorrect(ANewWebOrder.tblInvoice invoice)
    {
        _InvoiceInDB = _Data.NWODC.tblInvoices.Where(a => a.ID == invoice.ID && a.PaymentStatus == null).SingleOrDefault();
        if (_InvoiceInDB != null)
            return true;
        return false;
    }

    private bool IsParentTransactionCorrect(ANewWebOrder.tblInvoice invoice)
    {
        _InvoiceInDB = _Data.NWODC.tblInvoices.Where(a => a.TxnID == invoice.ParentTxnId && a.PaymentStatus.ToLower() == "completed").SingleOrDefault();
        if (_InvoiceInDB != null)
            return true;
        return false;
    }

    private bool IsInvoiceRefundable(ANewWebOrder.tblInvoice invoice)
    {
        var inv = _Data.NWODC.tblInvoices.Where(a => a.ParentTxnId == invoice.ParentTxnId && a.PaymentStatus.ToLower() == "refunded" || a.TxnType.ToLower() == "reversal").SingleOrDefault();

        if (inv == null)
            return true;

        return false;
    }

    private bool IsRefundAmountCorrect(ANewWebOrder.tblInvoice invoice)
    {
        if (_InvoiceInDB.MCGross == invoice.MCGross.Replace("-", string.Empty))
            return true;

        return false;
    }

    private bool IsOrderAmountCorrect(ANewWebOrder.tblInvoice invoice)
    {
        if (_InvoiceInDB.MCGross == invoice.MCGross)
            return true;

        return false;
    }

    private bool IsBusinessInfoCorrect(ANewWebOrder.tblInvoice invoice)
    {
        bool isOk = true;

        string business = string.Empty;
        if (_PayPalMode == "dev")
            business = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "business_sandbox").Setting;
        else
            business = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "business").Setting;

        if (invoice.Business.ToLower().Equals(business.ToLower()))
            isOk = true;
        else
            return false;

        string receiver_id = string.Empty;
        if (_PayPalMode == "dev")
            receiver_id = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "receiver_id_sandbox").Setting;
        else
            receiver_id = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "receiver_id").Setting;
        if (invoice.ReceiverID.ToLower().Equals(receiver_id.ToLower()))
            isOk = true;
        else
            return false;

        string residence_country = string.Empty;
        if (_PayPalMode == "dev")
            residence_country = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "residence_country_sandbox").Setting;
        else
            residence_country = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "residence_country").Setting;
        if (invoice.ResidenceCountry.ToLower().Equals(residence_country.ToLower()))
            isOk = true;
        else
            return false;

        string mc_currency = string.Empty;
        if (_PayPalMode == "dev")
            mc_currency = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "mc_currency_sandbox").Setting;
        else
            mc_currency = _Data.NWODC.tblSettings.Single<ANewWebOrder.tblSetting>(a => a.SettingKey == "mc_currency").Setting;
        if (invoice.MCCurrency.ToLower().Equals(mc_currency.ToLower()))
            isOk = true;
        else
            return false;

        return isOk;
    }

    private bool IsItemInfoCorrect(ANewWebOrder.tblInvoice invoice)
    {
        if (_InvoiceInDB != null && _InvoiceInDB.ItemName.Equals(invoice.ItemName) && _InvoiceInDB.ItemNumber.Equals(invoice.ItemNumber))
            return true;
        return false;
    }

    private ANewWebOrder.tblInvoice FillInvoiceInDB(ANewWebOrder.tblInvoice inv, ANewWebOrder.tblInvoice invInDB)
    {
        invInDB.AddressCity = inv.AddressCity;
        invInDB.AddressCountry = inv.AddressCountry;
        invInDB.AddressCountryCode = inv.AddressCountryCode;
        invInDB.AddressName = inv.AddressName;
        invInDB.AddressState = inv.AddressState;
        invInDB.AddressStatus = inv.AddressStatus;
        invInDB.AddressStreet = inv.AddressStreet;
        invInDB.AddressZip = inv.AddressZip;
        invInDB.Business = inv.Business;
        invInDB.FirstName = inv.FirstName;
        invInDB.FraudManagementPendingFilter = inv.FraudManagementPendingFilter;
        invInDB.ItemName = inv.ItemName;
        invInDB.ItemNumber = inv.ItemNumber;
        invInDB.LastName = inv.LastName;
        invInDB.MCCurrency = inv.MCCurrency;
        invInDB.MCFee = inv.MCFee;
        invInDB.MCGross = inv.MCGross;
        invInDB.MCGross1 = inv.MCGross1;
        invInDB.NotifyVersion = inv.NotifyVersion;
        invInDB.ParentTxnId = inv.ParentTxnId;
        invInDB.PayerEmail = inv.PayerEmail;
        invInDB.PayerID = inv.PayerID;
        invInDB.PayerStatus = inv.PayerStatus;
        invInDB.PaymentDate = inv.PaymentDate;
        invInDB.PaymentStatus = inv.PaymentStatus;
        invInDB.PaymentType = inv.PaymentType;
        invInDB.PaypalIP = inv.PaypalIP;
        invInDB.PendingReason = inv.PendingReason;
        invInDB.ProtectionEligibility = inv.ProtectionEligibility;
        invInDB.Quantity = inv.Quantity;
        invInDB.ReasonCode = inv.ReasonCode;
        invInDB.ReceiptID = inv.ReceiptID;
        invInDB.ReceiverEmail = inv.ReceiverEmail;
        invInDB.ReceiverID = inv.ReceiverID;
        invInDB.ResidenceCountry = inv.ResidenceCountry;
        invInDB.Shipping = inv.Shipping;
        invInDB.Tax = inv.Tax;
        invInDB.TxnID = inv.TxnID;
        invInDB.TxnType = inv.TxnType;

        return invInDB;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}