using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANWO.Utility;

namespace ANewWebOrder
{
    public partial class tblInvoice
    {
        public static IEnumerable<tblInvoice> Select()
        {
            ANWO.Data data = new ANWO.Data();
            SessionStateBag session = new SessionStateBag();
            int profID = session.Profile.ID;
            return data.NWODC.tblInvoices.Where(a => a.ProfileID == profID).OrderByDescending(a => a.CreatedDate);
        }

        public static IEnumerable<tblInvoice> SelectPage(int startRowIndex, int maximumRows)
        {
            return Select().Skip(startRowIndex).Take(maximumRows);
        }

        public static int SelectCount()
        {
            return Select().Count();
        }

        public static void Delete(string ID)
        {
            ANWO.Data data = new ANWO.Data();
            data.NWODC.tblInvoices.DeleteOnSubmit(data.NWODC.tblInvoices.Where(a => a.ID == ID).SingleOrDefault());
            data.NWODC.SubmitChanges();
        }

        public string FormattedCreatedDate
        {
            get
            {
                return CreatedDate.ToString("dd/MMM/yyyy");
            }
        }

        public string FormattedMCGross
        {
            get
            {
                return string.Format("{0:C}", MCGross);
            }
        }
    }
}