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
    public static List<CraftingRecipe> RecipesGetBySkillID(long objectID)
    {
        string cacheKey = "RecipesInSkill_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntitities = new RepopdataEntities())
            {
                var results = (from recipe in myEntitities.Recipes
                                  where recipe.skillID == objectID
                                  select recipe).OrderBy(x => x.displayName);
                if (results == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe recipe in results.ToList()) { returnObject.Add(new CraftingRecipe(recipe.recipeID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if (returnList == null)
        return returnObject;
    } // method RecipesGetBySkillID

    public static Recipe RecipeGetById(long objectID)
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
    } // method RecipeGetById

    public static List<Recipe_Skill_Range> SkillRangeGetByRecipeID(long objectID)
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

    public static List<Recipe_Ingredients> IngredientsGetByRecipeID(long objectID)
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
    } // method IngredientsGetByRecipeID

    public static List<Recipe_Agents> AgentsGetByRecipeID(long objectID)
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
    } // method AgentsGetByRecipeID

    public static List<Recipe_Results> RecipeResultsGetByRecipeID(long objectID)
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
    } // method RecipeResultsGetByRecipeID

    public static List<CraftingRecipe> RecipesThatCreateItem(long objectID)
    {
        string cacheKey = "RecipesThatCreateItem_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                              join itemResults in myEntities.Items on recipeResults.resultID equals itemResults.itemID
                              where recipeResults.type == (long)ItemTypeEnum.Item && itemResults.itemID == objectID
                              select item).OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe recipe in result.ToList()) { returnObject.Add(new CraftingRecipe(recipe.recipeID)); }
            } // using
        } // if (returnObject == null)
        return returnObject;
    } // method RecipesThatCreateItem

    public static List<CraftingRecipe> RecipesThatCreateFitting(long objectID)
    {
        string cacheKey = "RecipesThatCreateFitting_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                              join itemResults in myEntities.Items on recipeResults.resultID equals itemResults.itemID
                              where recipeResults.type == (long)ItemTypeEnum.Fitting && itemResults.itemID == objectID
                              select item).OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe recipe in result.ToList()) { returnObject.Add(new CraftingRecipe(recipe.recipeID)); }
            } // using
        } // if (returnObject == null)
        return returnObject;
    } // method RecipesThatCreateItem

    public static List<CraftingRecipe> RecipesThatCreateBlueprint(long objectID)
    {
        string cacheKey = "RecipesThatCreateBlueprint_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                              join itemResults in myEntities.Items on recipeResults.resultID equals itemResults.itemID
                              where recipeResults.type == (long)ItemTypeEnum.Blueprint && itemResults.itemID == objectID
                              select item).OrderBy(x => x.displayName);
                if (result == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe recipe in result.ToList()) { returnObject.Add(new CraftingRecipe(recipe.recipeID)); }
            } // using
        } // if (returnObject == null)
        return returnObject;
    } // method RecipesThatCreateBlueprint

    public static List<CraftingRecipe> RecipesGrantedByRecipeBookID(long objectID)
    {
        string cacheKey = "AllRecipesGrantedByRecipeBookID_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join recipeBooks in myEntities.Recipe_Books on item.recipeID equals recipeBooks.recipeID
                              join items in myEntities.Items on recipeBooks.itemID equals items.itemID
                              where items.itemID == objectID
                              select item);
                if (result == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe recipe in result.ToList()) { returnObject.Add(new CraftingRecipe(recipe.recipeID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method RecipesGrantedByRecipeBookID

    public static List<Recipe> GetAllRecipesThatUseComponentAsIngredient(long objectID)
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

    public static List<Recipe> GetAllRecipesThatUseItemAsAgent(long objectID)
    {
        return GetAllRecipesThatUseItemAsAgent(Convert.ToInt32(objectID));
    }

    public static List<Recipe> GetAllRecipesThatUseItemAsAgent(Int32 objectID)
    {
        string cacheKey = "AllRecipesThatUseItemAsAgent_" + objectID;
        List<Recipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join agents in myEntities.Recipe_Agents on item.recipeID equals agents.recipeID
                              join itemComponents in myEntities.Item_Crafting_Components on agents.componentID equals itemComponents.componentID
                              join items in myEntities.Items on itemComponents.itemID equals items.itemID
                              where items.itemID == objectID
                              select item).OrderBy(x => x.skillID).Distinct();
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllRecipesThatUseItemAsAgent

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
                    List<Recipe_Results> recipeResults = RecipeResultsGetByRecipeID(recipe.recipeID);

                    // We only need the Recipe_Ingredients for the current recipe that use one of the item components
                    List<Recipe_Ingredients> componentIngredients = (from item in IngredientsGetByRecipeID(recipe.recipeID)
                                                join components in ComponentGateway.GetComponentsByItemID(objectID) on item.componentID equals components.componentID
                                                select item).ToList();
                    foreach (Recipe_Ingredients recipeIngredient in componentIngredients)
                    {
                        switch (recipeIngredient.ingSlot)
                        {
                            case 1:
                                foreach (Recipe_Results recipeResult in recipeResults)
                                {
                                    if ((recipeResult.filter1ID == 0 || recipeResult.filter1ID == (long)FilterGateway.GetCraftingFilterByItemID(objectID).filterID) && !returnObject.Contains(recipe))
                                    { returnObject.Add(recipe); break; } // Don't need to continue if it matches
                                } // foreach (Recipe_Results recipeResult in recipeResults)
                                break;
                            case 2:
                                foreach (Recipe_Results recipeResult in recipeResults)
                                {
                                    if ((recipeResult.filter2ID == 0 || recipeResult.filter2ID == (long)FilterGateway.GetCraftingFilterByItemID(objectID).filterID) && !returnObject.Contains(recipe))
                                    { returnObject.Add(recipe); break; } // Don't need to continue if it matches
                                } // foreach (Recipe_Results recipeResult in recipeResults)
                                break;
                            case 3:
                                foreach (Recipe_Results recipeResult in recipeResults)
                                {
                                    if ((recipeResult.filter3ID == 0 || recipeResult.filter3ID == (long)FilterGateway.GetCraftingFilterByItemID(objectID).filterID) && !returnObject.Contains(recipe))
                                    { returnObject.Add(recipe); break; } // Don't need to continue if it matches
                                } // foreach (Recipe_Results recipeResult in recipeResults)
                                break;
                            case 4:
                                foreach (Recipe_Results recipeResult in recipeResults)
                                {
                                    if ((recipeResult.filter4ID == 0 || recipeResult.filter4ID == (long)FilterGateway.GetCraftingFilterByItemID(objectID).filterID) && !returnObject.Contains(recipe))
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
            List<Recipe_Results> allResults = RecipeResultsGetByRecipeID(recipeID);
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

    public static List<Recipe> GetAllRecipesThatUseFilter(long objectID)
    {
        string cacheKey = "AllRecipesThatUseFilter_" + objectID;
        List<Recipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<Recipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join results in myEntities.Recipe_Results on item.recipeID equals results.recipeID
                              where results.filter1ID == objectID || results.filter2ID == objectID || 
                              results.filter3ID == objectID || results.filter4ID == objectID
                              select item).OrderBy(x => x.skillID).Distinct();
                if (result == null) { return null; }
                returnObject = result.ToList();
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method GetAllRecipesThatUseFilter

} // class RecipeLists