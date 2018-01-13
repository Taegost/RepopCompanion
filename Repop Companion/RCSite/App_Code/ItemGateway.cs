using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ItemGateway
/// </summary>
public class ItemGateway
{
    public static Item GetItemByID(long objectID)
    {
        return GetItemByID(Convert.ToInt32(objectID));
    }

    public static Item GetItemByID(Int32 objectID)
    {
        string cacheKey = "Item_" + objectID;
        Item returnObject = HttpContext.Current.Cache[cacheKey] as Item;

        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Items
                                where item.itemID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (returnObject == null)
        return returnObject;
    } // method GetItemByID

    public static Fitting GetFittingByID(long objectID)
    {
        return GetFittingByID(Convert.ToInt32(objectID));
    }

    public static Fitting GetFittingByID(Int32 objectID)
    {
        string cacheKey = "Fitting_" + objectID;
        Fitting returnObject = HttpContext.Current.Cache[cacheKey] as Fitting;

        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Fittings
                                where item.fittingID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (returnObject == null)
        return returnObject;
    } // method GetFittingByID

    public static Structure GetBlueprintByID(long objectID)
    {
        return GetBlueprintByID(Convert.ToInt32(objectID));
    }

    public static Structure GetBlueprintByID(Int32 objectID)
    {
        string cacheKey = "Blueprint_" + objectID;
        Structure returnObject = HttpContext.Current.Cache[cacheKey] as Structure;

        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Structures
                                where item.structureID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (returnObject == null)
        return returnObject;
    } // method GetFittingByID

    public static Item GetBookByRecipeID(long objectID)
    {
        return GetBookByRecipeID(Convert.ToInt32(objectID));
    }

    public static Item GetBookByRecipeID(Int32 objectID)
    {
        string cacheKey = "BookByRecipeID_" + objectID;
        Recipe_Books returnObject = HttpContext.Current.Cache[cacheKey] as Recipe_Books;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Recipe_Books
                                where item.recipeID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return GetItemByID(returnObject.itemID);
    } // method GetBookByRecipeID

    public static List<Item> GetItemsByComponentID(long objectID)
    {
        return GetItemsByComponentID(Convert.ToInt32(objectID));
    }

    public static List<Item> GetItemsByComponentID(Int32 objectID)
    {
        string cacheKey = "ItemsByComponentID_" + objectID;
        List<Item> returnObject = HttpContext.Current.Cache[cacheKey] as List<Item>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Items
                              join components in myEntities.Item_Crafting_Components on item.itemID equals components.itemID
                                where components.componentID == objectID
                                select item).OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // GetCraftingComponentsByComponentID

    public static List<Item> GetAllItemsCreatedByTradeskillID(Int32 objectID)
    {
        string cacheKey = "AllItemsCreatedByTradeskillID_" + objectID;
        List<Item> returnObject = HttpContext.Current.Cache[cacheKey] as List<Item>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Items
                              join recipeResults in myEntities.Recipe_Results on item.itemID equals recipeResults.resultID  
                              join recipesinSkill in myEntities.Recipes on recipeResults.recipeID equals recipesinSkill.recipeID
                              where recipeResults.type == (long)ItemTypeEnum.Item && recipesinSkill.skillID == objectID
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllItemsCreatedByTradeskillID

    public static List<Fitting> GetAllFittingsCreatedByTradeskillID(Int32 objectID)
    {
        string cacheKey = "AllFittingsCreatedByTradeskillID_" + objectID;
        List<Fitting> returnObject = HttpContext.Current.Cache[cacheKey] as List<Fitting>;
        
        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Fittings
                              join recipeResults in myEntities.Recipe_Results on item.fittingID equals recipeResults.resultID
                              join recipesinSkill in myEntities.Recipes on recipeResults.recipeID equals recipesinSkill.recipeID
                              where recipeResults.type == (long)ItemTypeEnum.Fitting && recipesinSkill.skillID == objectID
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllFittingsCreatedByTradeskillID

    public static List<Structure> GetAllBlueprintsCreatedByTradeskillID(Int32 objectID)
    {
        string cacheKey = "AllBlueprintsCreatedByTradeskillID_" + objectID;
        List<Structure> returnObject = HttpContext.Current.Cache[cacheKey] as List<Structure>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Structures
                              join recipeResults in myEntities.Recipe_Results on item.structureID equals recipeResults.resultID
                              join recipesinSkill in myEntities.Recipes on recipeResults.recipeID equals recipesinSkill.recipeID
                              where recipeResults.type == (long)ItemTypeEnum.Blueprint && recipesinSkill.skillID == objectID
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllBlueprintsCreatedByTradeskillID

    public static ItemGroupEnum DetermineItemGroupByItemID(long objectID)
    {
        return DetermineItemGroupByItemID(Convert.ToInt32(objectID));
    }

    public static ItemGroupEnum DetermineItemGroupByItemID(Int32 objectID)
    {
        string cacheKey = "ItemGroupByItemID_" + objectID;
        ItemGroupEnum returnObject;
        if (HttpContext.Current.Cache[cacheKey] == null)
        {
            returnObject = ItemGroupEnum.Unknown;
        }
        else
        {
            returnObject = (ItemGroupEnum)HttpContext.Current.Cache[cacheKey];
        }
        
        if (returnObject == ItemGroupEnum.Unknown)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                // There's no easy way to determine the item "group" (recipe book, crafting component, etc.)

                var recipeResult = RecipeGateway.GetAllRecipesGrantedByRecipeBookID(objectID);
                if (!(recipeResult == null))
                {
                    returnObject = ItemGroupEnum.RecipeBook;
                    AppCaching.AddToCache(cacheKey, returnObject);
                    return returnObject;
                }
            } // using
        return returnObject;
    } // DetermineItemGroupByItemID

    public static Item_Value GetItemValueByItemID(long objectID)
    {
        return GetItemValueByItemID(Convert.ToInt32(objectID));
    }

    public static Item_Value GetItemValueByItemID(Int32 objectID)
    {
        string cacheKey = "ItemValueByItemID_" + objectID;
        Item_Value returnObject = HttpContext.Current.Cache[cacheKey] as Item_Value;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Item_Value
                              where item.itemID == objectID
                              select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                    AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // DetermineItemGroupByItemID

    public static List<Item> GetAllItems()
    {
        string cacheKey = "AllItems";
        List<Item> returnObject = HttpContext.Current.Cache[cacheKey] as List<Item>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Items
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllItems

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

    public static Crafting_Components GetCraftingComponentByComponentID(Int32 objectID)
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

    public static List<Fitting> GetAllFittings()
    {
        string cacheKey = "AllFittings";
        List<Fitting> returnObject = HttpContext.Current.Cache[cacheKey] as List<Fitting>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Fittings
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllFittings

    public static List<Structure> GetAllBlueprints()
    {
        string cacheKey = "AllBlueprints";
        List<Structure> returnObject = HttpContext.Current.Cache[cacheKey] as List<Structure>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Structures
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllBlueprints
} // class ItemGateway