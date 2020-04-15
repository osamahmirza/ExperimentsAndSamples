using ANewWebOrder;
using ANWO.Biz.Entities;
using ANWO.Presentation;
using ANWO.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ucCategories : UserControlBase
{
    private const string _CATEGORIESPAGENAME = "~/CyberHawks/ANewWebOrder-Categories.aspx?CatID={0}";
    private const string _HAWKPAGENAME = "~/CyberHawks/ANewWebOrder-Hawks.aspx?ID={0}";
    private string _CatIdStr = string.Empty;
    private int _CatIdInt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
    }
    private void Initialize()
    {
        if (!Page.IsPostBack)
        {
            _CatIdStr = Request.QueryString["CatId"];
            if (string.IsNullOrEmpty(_CatIdStr))
            {
                BindDataToRepeater();
            }
            else
            {
                if (UtilityFunctions.IsInt(_CatIdStr))
                {
                    _CatIdInt = Int32.Parse(_CatIdStr);
                    if (_CatIdInt > 0)
                    {
                        BindDataToRepeater();
                    }
                    else
                    {
                        ThrowError(this, new ANWO.Common.ControlErrorArgs() { Message = "Invalid Category", Severity = 3 });
                    }
                }
                else
                {
                    ThrowError(this, new ANWO.Common.ControlErrorArgs() { Message = "Invalid Category", Severity = 3 });
                }
            }
        }
    }

    private void BindDataToRepeater()
    {
        rptCategories.DataSource = GetCategories();
        rptCategories.DataBind();
    }

    private List<MultiColumn<tlkpCategory>> GetCategories()
    {
        if (_CatIdInt > 0)
            return MatrixCreateFactory<tlkpCategory>.GenerateMultiColumn(ListGenerateFactory.GetSubCategory(_CatIdInt), 2);
        else
            return MatrixCreateFactory<tlkpCategory>.GenerateMultiColumn(ListGenerateFactory.GetAllParentCategories(), 2);
    }

    protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        bool flipflop = true;
        string pageName = string.Empty;

        if (_CatIdInt > 0)
            pageName = _HAWKPAGENAME;
        else
            pageName = _CATEGORIESPAGENAME;

        try
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Panel pnl1 = e.Item.FindControl("pnlContent1") as Panel;
                Panel pnl2 = e.Item.FindControl("pnlContent2") as Panel;

                MultiColumn<tlkpCategory> row = e.Item.DataItem as MultiColumn<tlkpCategory>;
                if (row != null)
                {

                    foreach (var item in row.Columns)
                    {
                        if (flipflop)
                        {
                            pnl1.Controls.Add(new HyperLink() { Text = item.Name, NavigateUrl = string.Format(pageName, item.ID) });
                            flipflop = false;
                        }
                        else
                        {
                            pnl2.Controls.Add(new HyperLink() { Text = item.Name, NavigateUrl = string.Format(pageName, item.ID) });
                            flipflop = true;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ThrowError(this, new ANWO.Common.ControlErrorArgs() { Message = ex.Message, Severity = 1 });
        }
    }
}