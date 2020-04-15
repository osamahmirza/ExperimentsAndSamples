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

public partial class Controls_ucSearch_Country : UserControlBase
{
    public string CategoryID = string.Empty;
    int _CatID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CategoryID = Request.QueryString["CategoryID"];

        GetCountries();
    }

    private void GetCountries()
    {
        try
        {
            if (int.TryParse(CategoryID, out _CatID))
            {
                DataList1.DataSource = GoProGo.Business.Lookup.Geo.GetEnabledCountries();
                DataList1.DataBind();
            }
            else
                throw new Exception(string.Format("CategoryID={0} Can not be parsed.", CategoryID));
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Invalid arguments.", Severity = 1 });
        }
    }
    private const int ItemsPerRequest = 10;

    protected void RadComboBox1_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        List<tblCountry> data = GetData(e.Text);

        int itemOffset = e.NumberOfItems;
        int endOffset = Math.Min(itemOffset + ItemsPerRequest, data.Count);
        e.EndOfItems = endOffset == data.Count;

        for (int i = itemOffset; i < endOffset; i++)
        {
            RadComboBox1.Items.Add(new RadComboBoxItem(data[i].Country, data[i].ID.ToString()));
        }

        e.Message = GetStatusMessage(endOffset, data.Count);
    }

    private string GetStatusMessage(int offset, int total)
    {
        if (total <= 0)
            return "No matches";

        return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
    }
    private List<tblCountry> GetData(string text)
    {
        return GoProGo.Business.Lookup.Geo.GetEnabledCountriesByName(text);
    }

    protected void RadComboBox1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        int id = 0;
        try
        {
            if (int.TryParse(e.Value, out id))
            {
                btnGo.Visible = true;
                btnGo.PostBackUrl = "~/Region.aspx?ID=" + id.ToString() + "&CategoryID=" + CategoryID;
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = ex.Message, Severity = 3 });
            btnGo.Visible = false;
        }
    }
}
