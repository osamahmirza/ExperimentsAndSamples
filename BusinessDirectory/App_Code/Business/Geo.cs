using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoProGo.Data.Entity.Profile;
using System.Web.Security;
using GoProGo.Data;
using GoProGo.Data.Entity.Geo;

namespace GoProGo.Business.Entities
{
    public class Geo
    {
        public static tblCountry GetCountryByID(int id)
        {
            tblCountry country = null;

            try
            {
                country = GoProGoDC.GeoDC.GetCountryByID(id).SingleOrDefault<tblCountry>();
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
            }
            return country;
        }

        public static bool IsCountryKM(tblCountry country)
        {
            if (country.ISO2.ToLower().Equals("us") || country.ISO2.ToLower().Equals("gb"))
                return false;
            
            return true;
        }
	}
}
