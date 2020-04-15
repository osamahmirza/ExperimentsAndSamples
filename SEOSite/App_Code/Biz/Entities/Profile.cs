using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANWO.Biz.Entities
{
    public class Profile
    {
        public int ID { get; set; }

        public System.Guid UserID { get; set; }

        public string FirstName { get; set; }

        public string MiddleInitials { get; set; }

        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public string Apartment { get; set; }

        public string POBox { get; set; }

        public int CityID { get; set; }

        public int RegionID { get; set; }

        public int CountryID { get; set; }

        public string PostalCode { get; set; }

        public string Phone1 { get; set; }

        public string Phone1Ext { get; set; }

        public string Phone2 { get; set; }

        public string Phone2Ext { get; set; }

        public string Fax { get; set; }
    } 
}
