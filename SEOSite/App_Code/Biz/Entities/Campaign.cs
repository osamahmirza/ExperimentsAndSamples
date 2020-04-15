using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Campaign
/// </summary>
namespace ANWO.Biz.Entities
{
    public class Campaign
    {
        //Default constructor
        public Campaign()
        {
        }

        public int ID { get; set; }
        public int ProfileID { get; set; }
        public int CategoryID { get; set; }
        public int GeographicScopeID { get; set; }
        public string Website { get; set; }
        public string TargetAudiance { get; set; }
        public string LongDescription { get; set; }
        public string MissionStatement { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string SitemapPath { get; set; }
        public string CampaignEmail { get; set; }
        public string CampaignPhone { get; set; }
        public string CampaignFax { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? LastReviewDate { get; set; }
        public bool IsPendingSetup { get; set; }
        public bool IsLive { get; set; }
        public string GeographicScope { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public System.DateTime Created { get; set; }
        public int AgreementID { get; set; }
        public string Keywords { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string LinkCategoryName { get; set; }
        public string ProductCategoryName { get; set; }

        private List<CampaignConnect> _CampaignConnects;
        public List<CampaignConnect> CampaignConnects
        {
            get
            {
                if (_CampaignConnects == null)
                    _CampaignConnects = new List<CampaignConnect>();
                return _CampaignConnects;
            }
            set
            {
                _CampaignConnects = value;
            }
        }

        private List<Invoice> _Invoices;
        public List<Invoice> Invoices
        {
            get
            {
                if (_Invoices == null)
                    _Invoices = new List<Invoice>();
                return _Invoices;
            }
            set
            {
                _Invoices = value;
            }
        }

        private List<Link> _Links;
        public List<Link> Links
        {
            get
            {
                if (_Links == null)
                    _Links = new List<Link>();
                return _Links;
            }
            set
            {
                _Links = value;
            }
        }

        private List<ProductOrService> _ProductOrServices;
        public List<ProductOrService> ProductOrServices
        {
            get
            {
                if (_ProductOrServices == null)
                    _ProductOrServices = new List<ProductOrService>();
                return _ProductOrServices;
            }
            set
            {
                _ProductOrServices = value;
            }
        }

        private List<Agreement> _Agreement;
        public List<Agreement> Agreement
        {
            get
            {
                if (_Agreement == null)
                    _Agreement = new List<Agreement>();
                return _Agreement;
            }
            set
            {
                _Agreement = value;
            }
        }

        private List<Profile> _Profile;
        public List<Profile> Profile
        {
            get
            {
                if (_Profile == null)
                    _Profile = new List<Profile>();
                return _Profile;
            }
            set
            {
                _Profile = value;
            }
        }

        private List<Category> _ParentCategory;
        public List<Category> ParentCategory
        {
            get
            {
                if (_ParentCategory == null)
                    _ParentCategory = new List<Category>();
                return _ParentCategory;
            }
            set
            {
                _ParentCategory = value;
            }
        }

        private List<Category> _SubCategory;
        public List<Category> SubCategory
        {
            get
            {
                if (_SubCategory == null)
                    _SubCategory = new List<Category>();
                return _SubCategory;
            }
            set
            {
                _SubCategory = value;
            }
        }

        private List<GeographicScope> _GeographicScopeList;
        public List<GeographicScope> GeographicScopeList
        {
            get
            {
                if (_GeographicScopeList == null)
                    _GeographicScopeList = new List<GeographicScope>();
                return _GeographicScopeList;
            }
            set
            {
                _GeographicScopeList = value;
            }
        }
    }
}