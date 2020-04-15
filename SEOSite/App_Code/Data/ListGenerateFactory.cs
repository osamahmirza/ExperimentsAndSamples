using ANewWebOrder;
using ANWO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ListGenerator
/// </summary>
public class ListGenerateFactory 
{
	public ListGenerateFactory()
	{
	}

    public static List<tlkpCategory> GetAllParentCategories()
    {
        Data data = new Data();

        return data.NWODC.tlkpCategories.Where(a => a.ParentID == null).ToList();       
    }

    public static List<tlkpCategory> GetCategory(int catID)
    {
        Data data = new Data();

        return data.NWODC.tlkpCategories.Where(a => a.ID == catID).ToList();
    }

    public static List<tlkpCategory> GetSubCategory(int parentID)
    {
        Data data = new Data();

        return data.NWODC.tlkpCategories.Where(a => a.ParentID == parentID).ToList();
    }

    public static List<vwCampaign> GetHawkList(int categoryId)
    {
        Data data = new Data();

        return data.NWODC.vwCampaigns.Where(a => a.CategoryID == categoryId).ToList();
    }

    public static List<vwCampaign> GetHawk(int siteID)
    {
        Data data = new Data();

        return data.NWODC.vwCampaigns.Where(a => a.ID == siteID).ToList();
    }

    public static List<vwCampaign> GetRecentlyAddedCampaign(int numberOfRecords)
    {
        Data data = new Data();

        return data.NWODC.vwCampaigns.OrderBy(a => a.Created).Take(numberOfRecords).ToList();
    }

    public static List<vwCampaign> GetRecentlyUpdatedCampaign(int numberOfRecords)
    {
        Data data = new Data();

        return data.NWODC.vwCampaigns.OrderBy(a => a.LastUpdated).Take(numberOfRecords).ToList();
    }
}