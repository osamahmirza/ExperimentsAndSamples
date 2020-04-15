using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AppSettings
/// </summary>
namespace ANWO.Utility
{
    public class AppSettings
    {
        public AppSettings()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int RecentlyAddedNumber 
        {
            get
            {
                int ran = 0;
                Int32.TryParse(ConfigurationManager.AppSettings["RecentlyAddedNumber"], out ran);
                return ran;
            }
        }

        public static int RecentlyUpdatedNumber
        {
            get
            {
                int ran = 0;
                Int32.TryParse(ConfigurationManager.AppSettings["RecentlyUpdatedNumber"], out ran);
                return ran;
            }
        }

        public static string PayPalMode
        {
            get
            {
                return ConfigurationManager.AppSettings["PayPalMode"].ToString();
            }
        }
    }
}