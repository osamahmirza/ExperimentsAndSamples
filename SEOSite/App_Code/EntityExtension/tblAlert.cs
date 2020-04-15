using System.Linq;
using System.Collections.Generic;
using ANWO.Utility;

namespace ANewWebOrder
{
    public partial class tblAlert
    {
        public static IEnumerable<tblAlert> Select()
        {
            ANWO.Data data = new ANWO.Data();
            SessionStateBag session = new SessionStateBag();
            int profID = session.Profile.ID;
            return data.NWODC.tblAlerts.Where(a => a.ProfileID == profID).OrderByDescending(a => a.DateCreated);
        }

        public static IEnumerable<tblAlert> SelectPage(int startRowIndex, int maximumRows)
        {
            return Select().Skip(startRowIndex).Take(maximumRows);
        }

        public static int SelectCount()
        {
            return Select().Count();
        }

        public static void Delete(int ID)
        {
            ANWO.Data data = new ANWO.Data();
            data.NWODC.tblAlerts.DeleteOnSubmit(data.NWODC.tblAlerts.Where(a => a.ID == ID).SingleOrDefault());
            data.NWODC.SubmitChanges();
        }

        public string FormattedDateCreated 
        {
            get 
            {
                return DateCreated.ToString("dd/MMM/yyyy");
            }
       }
    }
}