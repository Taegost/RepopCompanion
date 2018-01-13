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
    public static List<Crafting_Filters> GetAllFilterss()
    {
        string cacheKey = "AllFilterss";
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

    public static Crafting_Filters GetFilterByFilterID(long objectID)
    { 
        return GetFilterByFilterID(Convert.ToInt32(objectID));
    }

    public static Crafting_Filters GetFilterByFilterID(Int32 objectID)
    {
        string cacheKey = "FilterByFilterID_" + objectID;
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
        } // if (currentSkill == null)
        return returnObject;
    } // method GetFilterByFilterID

    public static List<Crafting_Filters> GetFiltersByItemID(long objectID)
    {
        return GetFiltersByItemID(Convert.ToInt32(objectID));
    }

    public static List<Crafting_Filters> GetFiltersByItemID(Int32 objectID)
    {
        string cacheKey = "FilterByItemID_" + objectID;
        List<Crafting_Filters> returnObject = HttpContext.Current.Cache[cacheKey] as List<Crafting_Filters>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Crafting_Filters
                                join itemCraftingFilter in myEntities.Item_Crafting_Filters on item.filterID equals itemCraftingFilter.filterID
                                where itemCraftingFilter.itemID == objectID
                                select item).OrderBy(x => x.displayName);
                if (results == null) { return null; }
                returnObject = results.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (currentSkill == null)
        return returnObject;
    } // method GetFilterByItemID

} // class FilterGateway