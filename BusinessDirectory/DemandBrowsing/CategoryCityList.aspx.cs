using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Data.Entity.Profile;
using GoProGo.Data.Entity.Geo;
using GoProGo.Data;
using GoProGo.Presentation;

public partial class ServiceProviderList : BasePage
{
    string _Header = string.Empty;
    string _CityID = string.Empty;
    string _CategoryID = string.Empty;

    int _CtyID = 0;
    int _CatID = 0;



    protected void Page_Load(object sender, EventArgs e)
    {
        _CityID = Request.QueryString["CityID"];
        _CategoryID = Request.QueryString["CategoryID"];
    }

    public override void Load_Events()
    {
        //throw new NotImplementedException();
    }

    public override void Load_Header()
    {

        try
        {
            if (_CtyID > 0 && _CatID > 0)
            {
                //Setting Header property to be used in Header
                tlkpCategory cat = GoProGoDC.ProfileDC.GetCategoryByID(_CatID).SingleOrDefault<tlkpCategory>();
                tblCity cit = GoProGoDC.GeoDC.GetCityByID(_CtyID).SingleOrDefault<tblCity>();
                _Header = "Service providers in " + cat.Name + " from " + cit.City;
                //TODO: Set this as header
                //((ICommon)Master).SetHeader(Header, MyAccountType.None);
            }
        }
        catch (Exception ex)
        {
            //TODO: logging here
        }
    }
}
