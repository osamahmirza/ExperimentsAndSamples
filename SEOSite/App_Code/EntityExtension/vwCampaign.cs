using System.Linq;
using System.Collections.Generic;
using ANWO.Utility;

namespace ANewWebOrder
{
    /// <summary>
    /// Extension class for vwCampaign.dbml
    /// </summary>
    public partial class vwCampaign
    {
        public static IEnumerable<vwCampaign> Select()
        {
            ANWO.Data data = new ANWO.Data();
            SessionStateBag session = new SessionStateBag();
            int profID = session.Profile.ID;
            return data.NWODC.vwCampaigns.Where(a => a.ProfileID == profID);
        }

        public static IEnumerable<vwCampaign> SelectPage(int startRowIndex, int maximumRows)
        {
            return Select().Skip(startRowIndex).Take(maximumRows);
        }

        public static int SelectCount()
        {
            return Select().Count();
        }
    }
}