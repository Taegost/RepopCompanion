using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ComponentGateway
/// </summary>
public class ComponentGateway
{
    public static List<Crafting_Components> GetAllComponents()
    {
        string cacheKey = "AllComponents";
        List<Crafting_Components> returnObject = HttpContext.Current.Cache[cacheKey] as List<Crafting_Components>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Crafting_Components
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllComponents

    public static Crafting_Components GetCraftingComponentByComponentID(long objectID)
    {
        string cacheKey = "CraftingComponentByComponentID_" + objectID;
        Crafting_Components returnObject = HttpContext.Current.Cache[cacheKey] as Crafting_Components;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Crafting_Components
                                where item.componentID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetCraftingComponentByComponentID

    public static List<Crafting_Components> GetComponentsByItemID(long objectID)
    {
        return GetComponentsByItemID(Convert.ToInt32(objectID));
    }

    public static List<Crafting_Components> GetComponentsByItemID(Int32 objectID)
    {
        string cacheKey = "ComponentsByItemID_" + objectID;
        List<Crafting_Components> returnObject = HttpContext.Current.Cache[cacheKey] as List<Crafting_Components>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Crafting_Components
                              join itemComponents in myEntities.Item_Crafting_Components on item.componentID equals itemComponents.componentID
                              where itemComponents.itemID == objectID
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllComponents
} // class ComponentGateway