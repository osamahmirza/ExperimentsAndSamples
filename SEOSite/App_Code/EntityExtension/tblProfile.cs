using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANewWebOrder
{
    public partial class tblProfile
    {
        public PlanType GetConsumedDiscountedPlanTypes()
        {
            PlanType planType = PlanType.Undefined;

            var campaigns = this.tblCampaigns;
            ANWO.Data data = new ANWO.Data();

            bool promotionApplied = false;

            if (campaigns != null && campaigns.Count() > 0)
            {
                foreach (var item in campaigns)
                {
                    var invoices = item.tblInvoices.Where(a => a.PaymentStatus == "Completed");
                    if (invoices != null && invoices.Count() > 0)
                        foreach (var invoice in invoices)
                        {
                            if (invoice.tblPlan.PlanTypeID == 1)
                            {
                                promotionApplied = true;
                                break;
                            }
                        }
                }
            }

            if (promotionApplied)
                planType = PlanType.Regular;
            else
                planType = PlanType.Promotional;

            return planType;
        }
    }
}