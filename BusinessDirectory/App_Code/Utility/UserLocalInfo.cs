using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using GoProGo.Data.GeoIP;
using System.Net;

namespace GoProGo.Utility
{
    /// <summary>
    /// This class is initialized and being put in session from Global.asax.cs Start_Session method
    /// </summary>
    public class UserLocalInfo
    {
        HttpRequest Request = HttpContext.Current.Request;
        string _BinaryDBFile = string.Empty;

        public UserLocalInfo(string binaryDBFile)
        {
            _BinaryDBFile = binaryDBFile;
            Initialize();
        }
        public string IP { get; set; }
        public IPAddress IPAdd { get; set; }

        public bool IsLocationFound { get; set; }
        public bool IsKilometer { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PostalCode { get; set; }
        public int MetroCode { get; set; }
        public int AreadCode { get; set; }


        public string CultureCode { get; set; }
        public string BrowserType { get; set; }
        public bool IsMobileDevice { get; set; }

        private void Initialize()
        {
            SetCulture();
            if (SetIP())
                SetRegionalInfo();
        }

        private bool SetIP()
        {
            bool success = false;
            try
            {
                //http://bytes.com/groups/asp/532376-http_x_forwarded_for
                //http://weblogs.asp.net/james_crowley/archive/2007/06/19/gotcha-http-x-forwarded-for-returns-multiple-ip-addresses.aspx
                if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    //First IP address in comma seperated list should be clients orignal address
                    string[] ips = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',');
                    IP = ips[0];
                }
                else
                {
                    IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                }
                IPAdd = IPAddress.Parse(IP);

#if DEBUG
                IPAdd = IPAddress.Parse("99.234.218.224");
#endif

                success = true;
            }
            catch (Exception ex)
            {
                //TODO: Handle Log it with severity 2
                IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
                success = false;
            }
            return success;
        }

        private void SetRegionalInfo()
        {
            try
            {
                LookupService ls = new LookupService(_BinaryDBFile, LookupService.GEOIP_MEMORY_CACHE);

                GoProGo.Data.GeoIP.Location loc = ls.getLocation(IPAdd);
                Country = loc.countryName;
                CountryCode = loc.countryCode;
                Region = loc.region;
                RegionName = loc.regionName;
                City = loc.city;
                Latitude = loc.latitude;
                Longitude = loc.longitude;
                PostalCode = loc.postalCode;
                MetroCode = loc.metro_code;
                AreadCode = loc.area_code;

                IsLocationFound = true;
            }
            catch (Exception ex)
            {
                //TODO: Handle Severity 1
                //Ask user for his location on main page.
                IsLocationFound = false;
                Country = "Canada";
                RegionName = "Ontario";
                City = "North York";
                Region = "ON";
                CountryCode = "CA";
            }
        }

        private void SetCulture()
        {
            if (Request.UserLanguages == null)
            {
                //TODO: Severity 3
                return;  
            } 
            string Lang = Request.UserLanguages[0];
            if (Lang != null)
            {
                if (Lang.Length < 3)
                    Lang = Lang + "-" + Lang.ToUpper();
                try
                {
                    //Dates and stuff should be displayed according to clients culture.
                    System.Threading.Thread.CurrentThread.CurrentCulture =
                                       new System.Globalization.CultureInfo(Lang);
                    System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol =
                        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol;

                    //en-us, en-gb, en-uk will cause IsKilometer equal false
                    if (Lang.ToLower().EndsWith("us") || Lang.ToLower().EndsWith("gb") || Lang.ToLower().EndsWith("uk"))
                        IsKilometer = false;
                    else
                        IsKilometer = true;

                    CultureCode = Lang;

                    BrowserType = Request.Browser.Browser;
                    IsMobileDevice = Request.Browser.IsMobileDevice;

                }
                catch (Exception ex)
                {
                    //TODO: Logging here severity 2
                    CultureCode = "en-ca";

                    throw ex;
                }
            }
        }
    }
}