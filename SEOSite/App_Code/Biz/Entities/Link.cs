using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANWO.Biz.Entities
{
    public class Link
    {
        public int ID { get; set; }

        public int CampaignID { get; set; }

        public string LinkText { get; set; }

        public string Description { get; set; }
    } 
}
