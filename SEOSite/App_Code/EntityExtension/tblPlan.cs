using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblPlan
/// </summary>
namespace ANewWebOrder
{
    public partial class tblPlan
    {

        public string PlanDisplayName
        {
            get
            {
                return Name + " - " + string.Format("{0:C}", Rate) + " / Month";
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return Math.Round((Rate * Units), 2);
            }
        }

        public static List<tblPlan> GetPlansAfterFilter(PlanType expectedPlans)
        {
            List<tblPlan> listToReturn = new List<tblPlan>();

            ANWO.Data data = new ANWO.Data();
            if (expectedPlans == PlanType.Regular)
                listToReturn = data.NWODC.tblPlans.Where(a => a.PlanTypeID == 2).ToList();
            else if (expectedPlans == PlanType.Promotional)
                listToReturn = data.NWODC.tblPlans.Where(a => a.PlanTypeID == 1).ToList();

            return listToReturn;
        }
    }

    public enum PlanType
    {
        Undefined,
        Promotional,
        Regular
    }
}