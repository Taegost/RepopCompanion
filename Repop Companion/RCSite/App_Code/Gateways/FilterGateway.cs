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
    public static List<Crafting_Filters> GetAllCraftingFilters()
    {
        string cacheKey = "AllCraftingFilters";
        List<Crafting_Filters> returnObject = HttpContext.Current.Cache[cacheKey] as List<Crafting_Filters>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Crafting_Filters
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllBlueprints

    public static Crafting_Filters GetCraftingFilterByItemID(long objectID)
    {
        return GetCraftingFilterByItemID(Convert.ToInt32(objectID));
    }

    public static Crafting_Filters GetCraftingFilterByItemID(Int32 objectID)
    {
        // Currently, there can only be 1 crafting filter per item
        string cacheKey = "CraftingFiltersByItemID_" + objectID;
        Crafting_Filters returnObject = HttpContext.Current.Cache[cacheKey] as Crafting_Filters;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Crafting_Filters
                                join itemCraftingFilter in myEntities.Item_Crafting_Filters on item.filterID equals itemCraftingFilter.filterID
                                where itemCraftingFilter.itemID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (currentSkill == null)
        return returnObject;
    } // method GetFilterByItemID

    public static Crafting_Filters CraftingFilterGetByFilterID(long objectID)
    {
        string cacheKey = "CraftingFilterByFilterID_" + objectID;
        Crafting_Filters returnObject = HttpContext.Current.Cache[cacheKey] as Crafting_Filters;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Crafting_Filters
                                where item.filterID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method CraftingFilterGetByFilterID

} // class FilterGateway