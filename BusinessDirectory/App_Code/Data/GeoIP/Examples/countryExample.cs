// an example of how to lookup the country of a ip address

// This only works with the GeoIP Country database
// See regionExample.cs, cityExample.cs, and orgExample.cs
// for the Region database, city database, and ISP/Organization databases

using System;
using System.IO;
namespace GoProGo.Data.GeoIP
{
    public class CountryExample
    {
        public static void Main()
        {
            //open the database
            LookupService ls = new LookupService("/usr/local/share/GeoIP/GeoIP.dat", LookupService.GEOIP_MEMORY_CACHE);
            //get country of the ip address
            Country c = ls.getCountry("24.24.24.24");
            Console.Write(" code: " + c.getCode() + "\n");
            Console.Write(" name: " + c.getName() + "\n");
        }
    }
}
