using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoProGo.Presentation;
using GoProGo.Data;
using System.ComponentModel;
using System.Data;
using GoProGo.Data.Entity.Profile;
using Telerik.Web.UI;

public partial class Controls_ucSearch_Category : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCategories();
    }

    private void GetCategories()
    {
        try
        {
            DataList1.DataSource = GoProGo.Business.Lookup.Profile.GetAllCategories();
            DataList1.DataBind();
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() { InnerException = ex, Message = "Categories are not available.", Severity = 1 });
        }

    }
    private const int ItemsPerRequest = 10;

    protected void RadComboBox1_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        List<tlkpCategory> data = GetData(e.Text);

        int itemOffset = e.NumberOfItems;
        int endOffset = Math.Min(itemOffset + ItemsPerRequest, data.Count);
        e.EndOfItems = endOffset == data.Count;

        for (int i = itemOffset; i < endOffset; i++)
        {
            RadComboBox1.Items.Add(new RadComboBoxItem(data[i].Name, data[i].ID.ToString()));
        }

        e.Message = GetStatusMessage(endOffset, data.Count);
    }

    private string GetStatusMessage(int offset, int total)
    {
        if (total <= 0)
            return "No matches";

        return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
    }
    private List<tlkpCategory> GetData(string text)
    {
        return GoProGo.Business.Lookup.Profile.GetCategoriesByName(text);
    }

    protected void RadComboBox1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        int id = 0;
        try
        {
            if (int.TryParse(e.Value, out id))
            {
                btnGo.Visible = true;
                btnGo.PostBackUrl = "~/DemandBrowsing/Country.aspx?CategoryID=" + id.ToString();
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ControlErrorArgs() {InnerException = ex, Message = ex.Message, Severity = 3 });
            btnGo.Visible = false;
        }
    }
}
