using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANWO.Biz.Entities
{
    public class Invoice
    {
        public int ID { get; set; }
        public int CampaignID { get; set; }
        public int PlanID { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public bool Refunded { get; set; }
        public string TransactionNumber { get; set; }
    }

}