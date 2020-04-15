using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ANWO;
using ANewWebOrder;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CommonBaseMaster
/// </summary>
public abstract class CommonBaseMaster : MasterPage
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GenerateMetaData();
    }

    private void GenerateMetaData()
    {
        Data data = new Data();
        string header = string.Empty;
        tblPageContent pageContent = null;
        string filename = System.IO.Path.GetFileName(Request.PhysicalPath);
        tlkpPage page = data.NWODC.tlkpPages.Where(a => a.Name.ToLower() == filename.ToLower()).SingleOrDefault<tlkpPage>();
        if (page != null)
        {
            List<tblPageContent> pageContents = page.tblPageContents.ToList();

            GenerateMetaTags(pageContents);

            pageContent = pageContents.Where(a => a.PageContentTypeID == 2).SingleOrDefault();

            if (pageContent != null)
                if (!string.IsNullOrEmpty(pageContent.PageContent))
                    CommonBaseMaster_Load(pageContent.PageContent);
        }

    }

    private void GenerateMetaTags(List<tblPageContent> pageContents)
    {
        HtmlMeta meta = null;

        if (pageContents != null && pageContents.Count > 0)
        {
            tblPageContent title = pageContents.Where(a => a.PageContentTypeID == 1).SingleOrDefault();
            tblPageContent keywords = pageContents.Where(a => a.PageContentTypeID == 3).SingleOrDefault();
            tblPageContent description = pageContents.Where(a => a.PageContentTypeID == 4).SingleOrDefault();

            if (title != null)
                Page.Title = title.PageContent;

            if (keywords != null)
            {
                meta = new HtmlMeta();
                meta.HttpEquiv = "keywords";
                meta.Content = keywords.PageContent;
                Page.Header.Controls.Add(meta);
            }
            if (description != null)
            {
                meta = new HtmlMeta();
                meta.HttpEquiv = "description";
                meta.Content = description.PageContent;
                Page.Header.Controls.Add(meta);
            }
        }

        meta = new HtmlMeta();
        meta.HttpEquiv = "robots";
        meta.Content = "all";
        Page.Header.Controls.Add(meta);
    }

    public abstract void CommonBaseMaster_Load(string param);
}