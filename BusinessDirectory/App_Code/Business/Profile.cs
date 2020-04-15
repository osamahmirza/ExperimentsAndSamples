using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoProGo.Data.Entity.Profile;
using System.Web.Security;
using GoProGo.Data;

namespace GoProGo.Business.Entities
{
    public class Profile
    {
        public static tblProfile GetProfileByUser(MembershipUser user)
        {
            tblProfile prof = null;

            try
            {
                prof = GoProGoDC.ProfileDC.GetProfileByUserID(new Guid(user.ProviderUserKey.ToString())).SingleOrDefault<tblProfile>();
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
            }
            return prof;
        }

        public static tblProfile GetProfileByID(int id)
        {
            tblProfile prof = null;

            try
            {
                prof = GoProGoDC.ProfileDC.GetProfileByID(id).SingleOrDefault<tblProfile>();
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
            }
            return prof;

        }

        public static List<vwFavourite> GetFavouritesByProfileID(int id)
        {
            List<vwFavourite> favList = new List<vwFavourite>();
            try
            {
                favList = GoProGoDC.ProfileDC.GetFavourites(id).ToList<vwFavourite>();
            }
            catch
            {
                favList = new List<vwFavourite>();
            }
            return favList;
        }
    }

    public enum MemberShipType
    {
        Standard = 1,
        Diamond = 2
    }
}