using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for RecipeLists
/// </summary>
public class RecipeGateway
{
    #region "Public Methods"

    public static List<Recipe> RecipesInSkill(Int32 objectID)
    {
        string cacheKey = "RecipesInSkill_" + objectID;
        List<Recipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntitities = new RepopdataEntities())
            {
                var results = (from recipe in myEntitities.Recipes
                                  where recipe.skillID == objectID
                                  select recipe).OrderBy(x => x.displayName);
                if (results == null) { return null; }
                returnObject = results.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (returnList == null)
        return returnObject;
    } // method RecipesInSkill

    public static Recipe GetRecipeById(Int32 objectID)
    {
        string cacheKey = "Recipe_" + objectID;
        Recipe returnObject = HttpContext.Current.Cache[cacheKey] as Recipe;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from recipe in myEntities.Recipes
                                where recipe.recipeID == objectID
                                select recipe).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (currentRecipe == null)
        return returnObject;
    } // method GetRecipeById

    public static List<Recipe_Skill_Range> GetSkillRangeByRecipeID(Int32 objectID)
    {
        string cacheKey = "SkillRangeByRecipeID_" + objectID;
        List<Recipe_Skill_Range> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe_Skill_Range>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Recipe_Skill_Range
                               where item.recipeID == objectID
                               select item).OrderBy(x => x.level);
                if (results == null) { return null; }
                returnObject = results.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if
        return returnObject;
    } // method GetSkillRangByRecipeID

    public static List<Recipe_Ingredients> GetRecipeIngredientsByRecipeID(long objectID)
    {
        return GetRecipeIngredientsByRecipeID(Convert.ToInt32(objectID));
    }

    public static List<Recipe_Ingredients> GetRecipeIngredientsByRecipeID(Int32 objectID)
    {
        string cacheKey = "RecipeIngredientsByRecipeID_" + objectID;
        List<Recipe_Ingredients> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe_Ingredients>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Recipe_Ingredients
                               where item.recipeID == objectID
                               select item).OrderBy(x => x.ingSlot);
                if (results == null) { return null; }
                returnObject = results.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method GetRecipeIngredientsByRecipeID

    public static List<Recipe_Agents> GetRecipeAgentsByRecipeID(Int32 objectID)
    {
        string cacheKey = "RecipeAgentsByRecipeID_" + objectID;
        List<Recipe_Agents> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe_Agents>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Recipe_Agents
                               where item.recipeID == objectID
                               select item);
                if (results == null) { return null; }
                returnObject = results.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method GetRecipeAgentsByRecipeID

    public static List<Recipe_Results> GetRecipeResultsByRecipeID(long objectID)
    {
        return GetRecipeResultsByRecipeID(Convert.ToInt32(objectID));
    }

    public static List<Recipe_Results> GetRecipeResultsByRecipeID(Int32 objectID)
    {
        string cacheKey = "RecipeResultsByRecipeID_" + objectID;
        List<Recipe_Results> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe_Results>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Recipe_Results
                               where item.recipeID == objectID
                               select item);
                if (results == null) { return null; }
                returnObject = results.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method GetRecipeResultsByRecipeID

    public static Crafting_Components GetCraftingComponentByComponentID(long objectID)
    {
        return GetCraftingComponentByComponentID(Convert.ToInt32(objectID));
    }

    public static Crafting_Components GetCraftingComponentByComponentID(Int32 objectID)
    {
        string cacheKey = "CraftingComponentByComponentID_" + objectID;
        Crafting_Components returnObject = HttpContext.Current.Cache[cacheKey] as Crafting_Components;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = (from item in myEntities.Crafting_Components
                               where item.componentID == objectID
                               select item).FirstOrDefault();
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method GetRecipeIngredientsByRecipeID

    public static List<Recipe> GetRecipesByResultItemIDAndType(long objectID, ItemTypeEnum itemType)
    {
        return GetRecipesByResultItemIDAndType(Convert.ToInt32(objectID), itemType);
    }

    public static List<Recipe> GetRecipesByResultItemIDAndType(Int32 objectID, ItemTypeEnum itemType )
    {
        string cacheKey = "RecipesByResultItemIDAndType_" + objectID + "_" + itemType;
        List<Recipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                switch (itemType)
                {
                    case ItemTypeEnum.Item:
                        var result = (from item in myEntities.Recipes
                                        join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                                        join itemResults in myEntities.Items on recipeResults.resultID equals itemResults.itemID
                                        where recipeResults.type == (long)itemType && itemResults.itemID == objectID
                                        select item).OrderBy(x => x.displayName);
                        if (result == null) { return null; }
                        returnObject = result.ToList();
                        break;
                    case ItemTypeEnum.Fitting:
                        var result2 = (from item in myEntities.Recipes
                                        join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                                        join itemResults in myEntities.Fittings on recipeResults.resultID equals itemResults.fittingID
                                        where recipeResults.type == (long)itemType && itemResults.fittingID == objectID
                                        select item).OrderBy(x => x.displayName);
                        if (result2 == null) { return null; }
                        returnObject = result2.ToList();
                        break;
                    case ItemTypeEnum.Blueprint:
                        var result3 = (from item in myEntities.Recipes
                                        join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                                        join itemResults in myEntities.Structures on recipeResults.resultID equals itemResults.structureID
                                        where recipeResults.type == (long)itemType && itemResults.structureID == objectID
                                        select item).OrderBy(x => x.displayName);
                        if (result3 == null) { return null; }
                        returnObject = result3.ToList();
                        break;
                }
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method GetRecipesByResultItemIDAndType

    public static List<Recipe> GetAllRecipesGrantedByRecipeBookID(long objectID)
    {
        return GetAllRecipesGrantedByRecipeBookID(Convert.ToInt32(objectID));
    }

    public static List<Recipe> GetAllRecipesGrantedByRecipeBookID(Int32 objectID)
    {
        string cacheKey = "AllRecipesGrantedByRecipeBookID_" + objectID;
        List<Recipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join recipeBooks in myEntities.Recipe_Books on item.recipeID equals recipeBooks.recipeID
                              join items in myEntities.Items on recipeBooks.itemID equals items.itemID
                              where items.itemID == objectID
                              select item);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllRecipesGrantedByRecipeBookID

    public static List<Recipe> GetAllRecipesThatUseComponentAsIngredient(long objectID)
    {
        return GetAllRecipesThatUseComponentAsIngredient(Convert.ToInt32(objectID));
    }

    public static List<Recipe> GetAllRecipesThatUseComponentAsIngredient(Int32 objectID)
    {
        string cacheKey = "AllRecipesThatUseComponentAsIngredient_" + objectID;
        List<Recipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join ingredients in myEntities.Recipe_Ingredients on item.recipeID equals ingredients.recipeID
                              where ingredients.componentID == objectID
                              select item);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllRecipesThatUseComponentAsIngredient

    public static List<Recipe> GetAllRecipesThatUseComponentAsAgent(long objectID)
    {
        return GetAllRecipesThatUseComponentAsAgent(Convert.ToInt32(objectID));
    }
    
    public static List<Recipe> GetAllRecipesThatUseComponentAsAgent(Int32 objectID)
    {
        string cacheKey = "AllRecipesThatUseComponentAsAgent_" + objectID;
        List<Recipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join agents in myEntities.Recipe_Agents on item.recipeID equals agents.recipeID
                              where agents.componentID == objectID
                              select item);
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllRecipesThatUseComponentAsAgent

    public static List<Recipe> GetAllRecipesThatUseItemAsIngredient(long objectID)
    {
        return GetAllRecipesThatUseItemAsIngredient(Convert.ToInt32(objectID));
    }

    public static List<Recipe> GetAllRecipesThatUseItemAsIngredient(Int32 objectID)
    {
        string cacheKey = "AllRecipesThatUseItemAsIngredient_" + objectID;
        List<Recipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                returnObject = new List<Recipe>();
                var recipeList = (from item in myEntities.Recipes
                              join ingredients in myEntities.Recipe_Ingredients on item.recipeID equals ingredients.recipeID
                              join itemCraftingComponents in myEntities.Item_Crafting_Components on ingredients.componentID equals itemCraftingComponents.componentID
                              join actualItems in myEntities.Items on itemCraftingComponents.itemID equals actualItems.itemID
                              where actualItems.itemID == objectID
                              select item).OrderBy(x => x.skillID);
                if (recipeList == null) { return null; }
                foreach (Recipe recipe in recipeList)
                {
                    List<Recipe_Results> recipeResults = GetRecipeResultsByRecipeID(recipe.recipeID);

                    // We only need the Recipe_Ingredients for the current recipe that use one of the item components
                    List<Recipe_Ingredients> componentIngredients = (from item in GetRecipeIngredientsByRecipeID(recipe.recipeID)
                                                join components in ComponentGateway.GetComponentsByItemID(objectID) on item.componentID equals components.componentID
                                                select item).ToList();
                    foreach (Recipe_Ingredients recipeIngredient in componentIngredients)
                    {
                        switch (recipeIngredient.ingSlot)
                        {
                            case 1:
                                foreach (Recipe_Results recipeResult in recipeResults)
                                {
                                    if (recipeResult.filter1ID == 0 || recipeResult.filter1ID == (long)FilterGateway.GetCraftingFilterByItemID(objectID).filterID)
                                    { returnObject.Add(recipe); break; } // Don't need to continue if it matches
                                } // foreach (Recipe_Results recipeResult in recipeResults)
                                break;
                            case 2:
                                foreach (Recipe_Results recipeResult in recipeResults)
                                {
                                    if (recipeResult.filter2ID == 0 || recipeResult.filter2ID == (long)FilterGateway.GetCraftingFilterByItemID(objectID).filterID)
                                    { returnObject.Add(recipe); break; } // Don't need to continue if it matches
                                } // foreach (Recipe_Results recipeResult in recipeResults)
                                break;
                            case 3:
                                foreach (Recipe_Results recipeResult in recipeResults)
                                {
                                    if (recipeResult.filter3ID == 0 || recipeResult.filter3ID == (long)FilterGateway.GetCraftingFilterByItemID(objectID).filterID)
                                    { returnObject.Add(recipe); break; } // Don't need to continue if it matches
                                } // foreach (Recipe_Results recipeResult in recipeResults)
                                break;
                            case 4:
                                foreach (Recipe_Results recipeResult in recipeResults)
                                {
                                    if (recipeResult.filter4ID == 0 || recipeResult.filter4ID == (long)FilterGateway.GetCraftingFilterByItemID(objectID).filterID)
                                    { returnObject.Add(recipe); break; } // Don't need to continue if it matches
                                } // foreach (Recipe_Results recipeResult in recipeResults)
                                break;
                        } // switch (recipeIngredient.ingSlot)
                    } // foreach (Recipe_Ingredients recipeIngredient in componentIngredients)
                } // foreach (Recipe recipe in recipeList)
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllRecipesThatUseComponentAsIngredient



    public static Recipe_Results GetRecipeResultByRecipeIdAndFilterId(long recipeID, long filterID)
    {
        string cacheKey = "RecipeResultByRecipeIdAndFilterId_" + recipeID + "_" + filterID;
        Recipe_Results returnObject = HttpContext.Current.Cache[cacheKey] as Recipe_Results;

        if (returnObject == null)
        {
            List<Recipe_Results> allResults = GetRecipeResultsByRecipeID(recipeID);
            foreach (Recipe_Results recipeResult in allResults)
            {
                // We want to break out of the loop if we get a match of any kind
                if (recipeResult.filter1ID == filterID) { returnObject = recipeResult; break; }
                if (recipeResult.filter2ID == filterID) { returnObject = recipeResult; break; }
                if (recipeResult.filter3ID == filterID) { returnObject = recipeResult; break; }
                if (recipeResult.filter4ID == filterID) { returnObject = recipeResult; break; }
            } // foreach (Recipe_Results recipeResult in allResults)
            if (returnObject == null) { return null; }
            AppCaching.AddToCache(cacheKey, returnObject);
        } // f (returnObject == null)
        return returnObject;
    } // GetRecipeResultByRecipeIdAndFilterId

    #endregion // Public Methods
} // class RecipeLists