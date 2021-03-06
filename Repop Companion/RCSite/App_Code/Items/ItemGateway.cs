﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ItemGateway
/// </summary>
public class ItemGateway
{
    // This method is used by the ItemBase constructor
    public static Item ItemGetByID(long objectID)
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
    } // method ItemGetByID

    // This method is used by the FittingBase constructor
    public static Fitting FittingGetByID(long objectID)
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
    } // method FittingGetByID

    // This method is used by the BlueprintBase constructor
    public static Structure BlueprintGetByID(long objectID)
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
    } // method BlueprintGetByID

    public static RecipeBook BookGetByRecipeID(long objectID)
    {
        string cacheKey = "BookByRecipeID_" + objectID;
        RecipeBook returnObject = HttpContext.Current.Cache[cacheKey] as RecipeBook;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipe_Books
                                where item.recipeID == objectID
                                select item).FirstOrDefault();
                if (result == null) { return null; }
                returnObject = new RecipeBook(result.itemID);
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method BookGetByRecipeID

    public static List<ItemBase> ItemsGetByComponentID(long objectID)
    {
        string cacheKey = "ItemsByComponentID_" + objectID;
        List<ItemBase> returnObject = HttpContext.Current.Cache[cacheKey] as List<ItemBase>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Items
                              join components in myEntities.Item_Crafting_Components on item.itemID equals components.itemID
                                where components.componentID == objectID
                                select item).OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<ItemBase>();
                foreach (Item item in result.ToList()) { returnObject.Add(new ItemBase(item.itemID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // GetCraftingComponentsByComponentID

    public static List<ItemBase> ItemsGetAllByFilterID(long objectID)
    {
        string cacheKey = "ItemsByFilterID_" + objectID;
        List<ItemBase> returnObject = HttpContext.Current.Cache[cacheKey] as List<ItemBase>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Items
                              join filters in myEntities.Item_Crafting_Filters on item.itemID equals filters.itemID
                              where filters.filterID == objectID
                              select item).OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<ItemBase>();
                foreach (Item item in result.ToList()) { returnObject.Add(new ItemBase(item.itemID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method ItemsGetAllByFilterID

    public static List<ItemBase> ItemsGetAllCreatedByTradeskillID(long objectID)
    {
        string cacheKey = "AllItemsCreatedByTradeskillID_" + objectID;
        List<ItemBase> returnObject = HttpContext.Current.Cache[cacheKey] as List<ItemBase>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Items
                              join recipeResults in myEntities.Recipe_Results on item.itemID equals recipeResults.resultID  
                              join recipesinSkill in myEntities.Recipes on recipeResults.recipeID equals recipesinSkill.recipeID
                              where recipeResults.type == (long)ItemTypeEnum.Item && recipesinSkill.skillID == objectID
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<ItemBase>();
                foreach (Item item in result.ToList()) { returnObject.Add(new ItemBase(item.itemID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method ItemsGetAllCreatedByTradeskillID

    public static List<FittingBase> FittingsGetAllCreatedByTradeskillID(long objectID)
    {
        string cacheKey = "AllFittingsCreatedByTradeskillID_" + objectID;
        List<FittingBase> returnObject = HttpContext.Current.Cache[cacheKey] as List<FittingBase>;
        
        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Fittings
                              join recipeResults in myEntities.Recipe_Results on item.fittingID equals recipeResults.resultID
                              join recipesinSkill in myEntities.Recipes on recipeResults.recipeID equals recipesinSkill.recipeID
                              where recipeResults.type == (long)ItemTypeEnum.Fitting && recipesinSkill.skillID == objectID
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<FittingBase>();
                foreach (Fitting item in result.ToList()) { returnObject.Add(new FittingBase(item.fittingID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method FittingsGetAllCreatedByTradeskillID

    public static List<BlueprintBase> BlueprintsGetAllCreatedByTradeskillID(long objectID)
    {
        string cacheKey = "AllBlueprintsCreatedByTradeskillID_" + objectID;
        List<BlueprintBase> returnObject = HttpContext.Current.Cache[cacheKey] as List<BlueprintBase>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Structures
                              join recipeResults in myEntities.Recipe_Results on item.structureID equals recipeResults.resultID
                              join recipesinSkill in myEntities.Recipes on recipeResults.recipeID equals recipesinSkill.recipeID
                              where recipeResults.type == (long)ItemTypeEnum.Blueprint && recipesinSkill.skillID == objectID
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<BlueprintBase>();
                foreach (Structure item in result.ToList()) { returnObject.Add(new BlueprintBase(item.structureID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllBlueprintsCreatedByTradeskillID

    public static ItemGroupEnum DetermineItemGroupByItemID(long objectID)
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
                // This method definitely needs refactoring
               
                var recipeResult = RecipeGateway.RecipesGrantedByRecipeBookID(objectID);
                if (recipeResult.Count > 0)
                {
                    returnObject = ItemGroupEnum.RecipeBook;
                    AppCaching.AddToCache(cacheKey, returnObject);
                    return returnObject;
                }
                var rawMatResult = SpeciesGateway.AllSpeciesInfoForItem(objectID);
                if (rawMatResult.Count > 0)
                {
                    returnObject = ItemGroupEnum.RawMaterial;
                    AppCaching.AddToCache(cacheKey, returnObject);
                    return returnObject;
                }
                var componentResult = ComponentGateway.ComponentsGetByItemID(objectID);
                if (componentResult.Count > 0)
                    {
                    returnObject = ItemGroupEnum.CraftingComponent;
                    AppCaching.AddToCache(cacheKey, returnObject);
                    return returnObject;
                }
            } // using
        return returnObject;
    } // DetermineItemGroupByItemID

    public static Item_Value ValueGetByItemID(long objectID)
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
    } // ValueGetByItemID

    public static List<ItemBase> GetAllItems()
    {
        string cacheKey = "AllItems";
        List<ItemBase> returnObject = HttpContext.Current.Cache[cacheKey] as List<ItemBase>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Items
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<ItemBase>();
                foreach (Item item in result.ToList()) { returnObject.Add(new ItemBase(item.itemID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllItems
    
    public static List<FittingBase> GetAllFittings()
    {
        string cacheKey = "AllFittings";
        List<FittingBase> returnObject = HttpContext.Current.Cache[cacheKey] as List<FittingBase>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Fittings
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<FittingBase>();
                foreach (Fitting item in result.ToList()) { returnObject.Add(new global::FittingBase(item.fittingID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllFittings

    public static List<BlueprintBase> GetAllBlueprints()
    {
        string cacheKey = "AllBlueprints";
        List<BlueprintBase> returnObject = HttpContext.Current.Cache[cacheKey] as List<BlueprintBase>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Structures
                              select item).Distinct().OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<BlueprintBase>();
                foreach (Structure item in result.ToList()) { returnObject.Add(new BlueprintBase(item.structureID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllBlueprints

    public static Item_Stackable ItemStackInfoGetByItemID(long objectID)
    {
        string cacheKey = "ItemStackInfoByItemID_" + objectID;
        Item_Stackable returnObject = HttpContext.Current.Cache[cacheKey] as Item_Stackable;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Item_Stackable
                                where item.itemID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method ItemStackInfoGetByItemID

    public static Item_Power_Source PowerSourceInfoGetByItemID(long objectID)
    {
        string cacheKey = "ItemPowerSourceInfoByItemID_" + objectID;
        Item_Power_Source returnObject = HttpContext.Current.Cache[cacheKey] as Item_Power_Source;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Item_Power_Source
                                where item.itemID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method PowerSourceInfoGetByItemID

    public static Item_Stores_Power PowerStorageInfoGetByItemID(long objectID)
    {
        string cacheKey = "ItemPowerStorageInfoByItemID_" + objectID;
        Item_Stores_Power returnObject = HttpContext.Current.Cache[cacheKey] as Item_Stores_Power;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Item_Stores_Power
                                where item.itemID == objectID
                                select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method PowerStorageInfoGetByItemID
} // class ItemGateway