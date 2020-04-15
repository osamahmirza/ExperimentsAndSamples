using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANWO.Biz.Entities;

/// <summary>
/// Summary description for tblLink
/// </summary>
namespace ANewWebOrder
{
    public partial class tblCampaign
    {
        public static Campaign TranslateToLocalCampaign(tblCampaign camp)
        {
            ANWODataContext DataContext = new ANWODataContext();

            Campaign ca = new Campaign()
                            {
                                ExpiryDate = camp.ExpiryDate,
                                AgreementID = camp.AgreementID,
                                CampaignEmail = camp.CompaignEmail,
                                CampaignFax = camp.CompaignFax,
                                CampaignPhone = camp.CompaignPhone,
                                CategoryID = camp.CategoryID,
                                GeographicScopeID = camp.GeographicScopeID,
                                GeographicScope = camp.GeographicScope,
                                Header = camp.Header,
                                ID = camp.ID,
                                IsLive = camp.IsLive,
                                IsPendingSetup = camp.IsPendingSetup,
                                Keywords = camp.Keywords,
                                LastPaymentDate = camp.LastPaymentDate,
                                LastReviewDate = camp.LastReviewDate,
                                LastUpdated = camp.LastUpdated,
                                LongDescription = camp.LongDescription,
                                MissionStatement = camp.MissionStatement,
                                ProfileID = camp.ProfileID,
                                TargetAudiance = camp.TargetAudiance,
                                Title = camp.Title,
                                Website = camp.Website,
                                Name = camp.Name,
                                CompanyName = camp.CompanyName,
                                //LinkCategoryName = camp.LinkCategoryName,
                                //ProductCategoryName = camp.ProductCategoryName
                            };
            
            //CampaignConnects
            if (camp.tblCampaignConnects != null && camp.tblCampaignConnects.Count > 0)
            {
                foreach (var item in camp.tblCampaignConnects)
                {
                    ca.CampaignConnects.Add(new CampaignConnect() 
                                            { 
                                                CampaignID = item.CampaignID,
                                                ConnectID = item.ConnectID,
                                                ID = item.ID,
                                                Link = item.Link
                                            });
                }
            }
            
            //Links
            if (camp.tblLinks != null && camp.tblLinks.Count > 0)
            {
                foreach (var item in camp.tblLinks)
                {
                    ca.Links.Add(new Link() 
                                 { 
                                    CampaignID = item.CampaignID,
                                    Description = item.Description,
                                    ID = item.ID,
                                    LinkText = item.Link
                                 });
                }
            }

            //ProductOrServices
            if (camp.tblProductOrServices != null && camp.tblProductOrServices.Count > 0)
            {
                foreach (var item in camp.tblProductOrServices)
                {
                    ca.ProductOrServices.Add(new ProductOrService()
                                             {
                                                CampaignID = item.CampaignID,
                                                ID = item.ID,
                                                ProductOrServiceText = item.ProductOrService,
                                                SearchPhraseForProductOrService = item.SearchPhraseForProductOrService
                                             });
                }
            }

            return ca;
        }
    }
}