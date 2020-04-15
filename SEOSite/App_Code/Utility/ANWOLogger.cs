using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using ANewWebOrder;
using System.Text;

/// <summary>
/// Summary description for Logger
/// </summary>
namespace ANWO.Utility
{
    public class ANWOLogger
    {
        public ANWOLogger()
        {

        }

        public static void WritePaymentLog(string title, tblInvoice invoice, tblInvoice savedOne = null, LogCategory cat = LogCategory.General, int logPriority = 3)
        {
            string message = getInvoiceMessageTemplate(invoice, savedOne);

            LogWriter writer = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

            LogEntry log = new LogEntry();
            log.Title = title;
            log.Message = message;
            log.Categories.Add(cat.ToString());
            log.Priority = logPriority;
            log.Severity = System.Diagnostics.TraceEventType.Information;
            writer.Write(log);
        }

        public static void WriteSimpleLog(string title, string message, LogCategory cat = LogCategory.General, int logPriority = 3)
        {
            LogWriter writer = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

            LogEntry log = new LogEntry();
            log.Title = title;
            log.Message = message;
            log.Categories.Add(cat.ToString());
            log.Priority = logPriority;
            log.Severity = System.Diagnostics.TraceEventType.Information;
            writer.Write(log);
        }

        public static void WriteExceptionLog(string title, Exception ex, LogCategory cat = LogCategory.General, int logPriority = 3, System.Diagnostics.TraceEventType severity = System.Diagnostics.TraceEventType.Error)
        {
            LogWriter writer = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();

            LogEntry log = new LogEntry();
            log.Title = title;
            if (ex != null)
                log.Message = ex.Message + " Last Line: " + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(" at "));
            log.Categories.Add(cat.ToString());
            log.Priority = logPriority;
            log.Severity = severity;
            writer.Write(log);
        }


        private static string getInvoiceMessageTemplate(tblInvoice tempInvoice, tblInvoice savedOne = null)
        {

            if (savedOne != null)
            {
                tempInvoice.ID = savedOne.ID;
                tempInvoice.ProfileID = savedOne.ProfileID;
                tempInvoice.PlanID = savedOne.PlanID;
                tempInvoice.ProfileID = savedOne.ProfileID;
                tempInvoice.CampaignID = savedOne.CampaignID;
                tempInvoice.CreatedDate = savedOne.CreatedDate;
                tempInvoice.CustomerIP = savedOne.CustomerIP;
            }

            string messageTemp = @"
ID:                                                
#ID#;
Campaign:
#CampaignID#;
PlanID:
#PlanID#;
ProfileID:
#ProfileID#;
PaymentStatus:
#PaymentStatus#;
PaymentType:
#PaymentType#;
AddressStatus:
#AddressStatus#;
PayerStatus:
#PayerStatus#;
FirstName:
#FirstName#;
LastName:
#LastName#;
PayerEmail:
#PayerEmail#;
PayerID:
#PayerID#;
AddressName:
#AddressName#;
AddressCountry:
#AddressCountry#;
AddressCountryCode:
#AddressCountryCode#;
AddressZip:
#AddressZip#;
AddressState:
#AddressState#;
AddressCity:
#AddressCity#;
AddressStreet:
#AddressStreet#;
Business:
#Business#;
ReceiverEmail:
#ReceiverEmail#;
ResidenceCountry:
#ResidenceCountry#;
ItemName:
#ItemName#;
ItemNumber:
#ItemNumber#;
Quantity:
#Quantity#;
Shipping:
#Shipping#;
Tax:
#Tax#;
MCCurrency:
#MCCurrency#;
MCFee:
#MCFee#;
MCGross:
#MCGross#;
MCGross1:
#MCGross1#;
TxnType:
#TxnType#;
TxnID:
#TxnID#;
NotifyVersion:
#NotifyVersion#;
FraudManagementPendingFilter:
#FraudManagementPendingFilter#;
PendingReason:
#PendingReason#;
ProtectionEligibility:
#ProtectionEligibility#;
ReasonCode:
#ReasonCode#;
CreatedDate:
#CreatedDate#;
ParentTxnId:
#ParentTxnId#;
PaymentDate:
#PaymentDate#;
Invoice:
#Invoice#;
PaypalIP:
#PaypalIP#;
CustomerIP:
#CustomerIP#;
PromotionCode:
#PromotionCode#;
ReceiverID:
#ReceiverID#;";

            messageTemp = messageTemp.Replace("#ID#", tempInvoice.ID.ToString());
            messageTemp = messageTemp.Replace("#CampaignID#", tempInvoice.CampaignID.ToString());
            messageTemp = messageTemp.Replace("#PlanID#", tempInvoice.PlanID.ToString());
            messageTemp = messageTemp.Replace("#ProfileID#", tempInvoice.ProfileID.ToString());
            messageTemp = messageTemp.Replace("#PaymentStatus#", tempInvoice.PaymentStatus);
            messageTemp = messageTemp.Replace("#PaymentType#", tempInvoice.PaymentType);
            messageTemp = messageTemp.Replace("#AddressStatus#", tempInvoice.AddressStatus);
            messageTemp = messageTemp.Replace("#PayerStatus#", tempInvoice.PayerStatus);
            messageTemp = messageTemp.Replace("#FirstName#", tempInvoice.FirstName);
            messageTemp = messageTemp.Replace("#LastName#", tempInvoice.LastName);
            messageTemp = messageTemp.Replace("#PayerEmail#", tempInvoice.PayerEmail);
            messageTemp = messageTemp.Replace("#PayerID#", tempInvoice.PayerID);
            messageTemp = messageTemp.Replace("#AddressName#", tempInvoice.AddressName);
            messageTemp = messageTemp.Replace("#AddressCountry#", tempInvoice.AddressCountry);
            messageTemp = messageTemp.Replace("#AddressCountryCode#", tempInvoice.AddressCountryCode);
            messageTemp = messageTemp.Replace("#AddressZip#", tempInvoice.AddressZip);
            messageTemp = messageTemp.Replace("#AddressState#", tempInvoice.AddressState);
            messageTemp = messageTemp.Replace("#AddressCity#", tempInvoice.AddressCity);
            messageTemp = messageTemp.Replace("#AddressStreet#", tempInvoice.AddressStreet);
            messageTemp = messageTemp.Replace("#Business#", tempInvoice.Business);
            messageTemp = messageTemp.Replace("#ReceiverEmail#", tempInvoice.ReceiverEmail);
            messageTemp = messageTemp.Replace("#ResidenceCountry#", tempInvoice.ResidenceCountry);
            messageTemp = messageTemp.Replace("#ItemName#", tempInvoice.ItemName);
            messageTemp = messageTemp.Replace("#Quantity#", tempInvoice.Quantity);
            messageTemp = messageTemp.Replace("#Shipping#", tempInvoice.Shipping);
            messageTemp = messageTemp.Replace("#Tax#", tempInvoice.Tax);
            messageTemp = messageTemp.Replace("#MCCurrency#", tempInvoice.MCCurrency);
            messageTemp = messageTemp.Replace("#MCFee#", tempInvoice.MCFee);
            messageTemp = messageTemp.Replace("#MCGross#", tempInvoice.MCGross);
            messageTemp = messageTemp.Replace("#TxnType#", tempInvoice.TxnType);
            messageTemp = messageTemp.Replace("#TxnID#", tempInvoice.TxnID);
            messageTemp = messageTemp.Replace("#NotifyVersion#", tempInvoice.NotifyVersion);
            messageTemp = messageTemp.Replace("#FraudManagementPendingFilter#", tempInvoice.FraudManagementPendingFilter);
            messageTemp = messageTemp.Replace("#PendingReason#", tempInvoice.PendingReason);
            messageTemp = messageTemp.Replace("#ProtectionEligibility#", tempInvoice.ProtectionEligibility);
            messageTemp = messageTemp.Replace("#ReasonCode#", tempInvoice.ReasonCode);
            messageTemp = messageTemp.Replace("#ParentTxnId#", tempInvoice.ParentTxnId);
            messageTemp = messageTemp.Replace("#PaypalIP#", tempInvoice.PaypalIP);
            if (tempInvoice.PaymentDate != null)
                messageTemp = messageTemp.Replace("#PaymentDate#", tempInvoice.PaymentDate.ToString());
            messageTemp = messageTemp.Replace("#CreatedDate#", tempInvoice.CreatedDate.ToString());

            if (tempInvoice.Invoice != null)
                messageTemp = messageTemp.Replace("#Invoice#", tempInvoice.Invoice.ToString());

            messageTemp = messageTemp.Replace("#CustomerIP#", tempInvoice.CustomerIP);
            messageTemp = messageTemp.Replace("#PromotionCode#", tempInvoice.PromotionCode);
            messageTemp = messageTemp.Replace("#ReceiverID#", tempInvoice.ReceiverID);

            return messageTemp;
        }

    }

    public enum LogCategory
    {
        General,
        Payment,
        AccountActivation,
        User,
        Campaign,
        Registration,
        Contact,
        HighAlert
    }
}