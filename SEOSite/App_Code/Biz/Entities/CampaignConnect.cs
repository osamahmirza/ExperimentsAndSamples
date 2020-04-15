using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANWO.Biz.Entities
{
    public class CampaignConnect
    {
        public int ID { get; set; }
        public int CampaignID { get; set; }
        public int ConnectID { get; set; }
        public string Link { get; set; }
    } 
}
