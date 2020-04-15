using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANWO.Biz.Entities
{
    public class ProductOrService
    {
        public int ID { get; set; }

        public int CampaignID { get; set; }

        public string ProductOrServiceText { get; set; }

        public string SearchPhraseForProductOrService { get; set; }
    } 
}
