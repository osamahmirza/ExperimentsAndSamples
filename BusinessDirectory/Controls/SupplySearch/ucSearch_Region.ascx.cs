using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data;
using GoProGo.Data.Entity.Geo;
using Telerik.Web.UI;

public partial class Controls_ucSearch_Region : UserControlBase
{
    string _CountryID = string.Empty;
    public string CategoryID = string.Empty;
    int _ID = 0;
    int _CatID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        _CountryID = Request.QueryString["ID"];
        CategoryID = Request.QueryString["CategoryID"];

        GetRegions();
    }

    private void GetRegions()
    {
        try
        {
            if (int.TryParse(_CountryID, out _ID) && int.TryParse(CategoryID, out _CatID))
            {
                DataList1.DataSource = GoProGo.Business.Lookup.Geo.GetRegionsByCountryID(_ID);
                DataList1.DataBind();
            }
            else
                throw new Exception(string.Format("CountryID={0} or ID={1} Can not be parsed.",_CountryID, CategoryID));
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Invalid arguments.", Severity = 3 });
        }
    }

    private void GetCategories()
    {
        DataList1.DataSource = GoProGo.Business.Lookup.Profile.GetAllCategories();
        DataList1.DataBind();
    }

    private const int ItemsPerRequest = 10;

    protected void RadComboBox1_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        List<tblRegion> data = GetData(e.Text);

        int itemOffset = e.NumberOfItems;
        int endOffset = Math.Min(itemOffset + ItemsPerRequest, data.Count);
        e.EndOfItems = endOffset == data.Count;

        for (int i = itemOffset; i < endOffset; i++)
        {
            RadComboBox1.Items.Add(new RadComboBoxItem(data[i].Region, data[i].ID.ToString()));
        }

        e.Message = GetStatusMessage(endOffset, data.Count);
    }

    private string GetStatusMessage(int offset, int total)
    {
        if (total <= 0)
            return "No matches";

        return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
    }
    private List<tblRegion> GetData(string text)
    {
        return GoProGo.Business.Lookup.Geo.GetRegionsByNameAndCountryID(text, _ID);
    }

    protected void RadComboBox1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        int id = 0;
        try
        {
            if (int.TryParse(e.Value, out id))
            {
                btnGo.Visible = true;
                btnGo.PostBackUrl = "~/City.aspx?ID=" + id.ToString() + "&CategoryID=" + CategoryID;
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });
            btnGo.Visible = false;
        }
    }
}
