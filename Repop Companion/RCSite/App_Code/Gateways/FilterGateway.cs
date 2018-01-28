using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for FilterGateway
/// </summary>
public class FilterGateway
{
    public static List<CraftingFilter> GetAllCraftingFilters()
    {
        string cacheKey = "AllCraftingFilters";
        List<CraftingFilter> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingFilter>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Crafting_Filters
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<CraftingFilter>();
                foreach (Crafting_Filters item in result.ToList()) { returnObject.Add(new CraftingFilter(item)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllBlueprints

    public static CraftingFilter CraftingFilterGetByItemID(long objectID)
    {
        // Currently, there can only be 1 crafting filter per item
        string cacheKey = "CraftingFiltersByItemID_" + objectID;
        CraftingFilter returnObject = HttpContext.Current.Cache[cacheKey] as CraftingFilter;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Crafting_Filters
                                join itemCraftingFilter in myEntities.Item_Crafting_Filters on item.filterID equals itemCraftingFilter.filterID
                                where itemCraftingFilter.itemID == objectID
                                select item).FirstOrDefault();
                if (result == null) { return null; }
                returnObject = new CraftingFilter(result);
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (currentSkill == null)
        return returnObject;
    } // method GetFilterByItemID

    public static CraftingFilter CraftingFilterGetByFilterID(long objectID)
    {
        string cacheKey = "CraftingFilterByFilterID_" + objectID;
        CraftingFilter returnObject = HttpContext.Current.Cache[cacheKey] as CraftingFilter;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Crafting_Filters
                                where item.filterID == objectID
                                select item).FirstOrDefault();
                if (result == null) { return null; }
                returnObject = new CraftingFilter(result);
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method CraftingFilterGetByFilterID

} // class FilterGateway