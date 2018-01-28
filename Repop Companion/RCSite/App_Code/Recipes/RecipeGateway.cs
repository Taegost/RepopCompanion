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

    // This method is used by the constructor for CraftingRecipe
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

    public static List<CraftingRecipeSkillRange> SkillRangeGetByRecipeID(long objectID)
    {
        string cacheKey = "SkillRangeByRecipeID_" + objectID;
        List<CraftingRecipeSkillRange> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipeSkillRange>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Recipe_Skill_Range
                               where item.recipeID == objectID
                               select item).OrderBy(x => x.level);
                if (results == null) { return null; }
                returnObject = new List<CraftingRecipeSkillRange>();
                foreach (Recipe_Skill_Range item in results.ToList()) { returnObject.Add(new CraftingRecipeSkillRange(item)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        } // if
        return returnObject;
    } // method GetSkillRangByRecipeID

    public static List<CraftingRecipeIngredient> IngredientsGetByRecipeID(long objectID)
    {
        string cacheKey = "RecipeIngredientsByRecipeID_" + objectID;
        List<CraftingRecipeIngredient> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipeIngredient>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Recipe_Ingredients
                               where item.recipeID == objectID
                               select item).OrderBy(x => x.ingSlot);
                if (results == null) { return null; }
                returnObject = new List<CraftingRecipeIngredient>();
                foreach (Recipe_Ingredients item in results.ToList()) { returnObject.Add(new CraftingRecipeIngredient(item)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method IngredientsGetByRecipeID

    public static List<CraftingRecipeAgent> AgentsGetByRecipeID(long objectID)
    {
        string cacheKey = "RecipeAgentsByRecipeID_" + objectID;
        List<CraftingRecipeAgent> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipeAgent>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Recipe_Agents
                               where item.recipeID == objectID
                               select item);
                if (results == null) { return null; }
                returnObject = new List<CraftingRecipeAgent>();
                foreach (Recipe_Agents item in results.ToList()) { returnObject.Add(new CraftingRecipeAgent(item)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method AgentsGetByRecipeID

    public static List<CraftingRecipeResult> RecipeResultsGetByRecipeID(long objectID)
    {
        string cacheKey = "RecipeResultsByRecipeID_" + objectID;
        List<CraftingRecipeResult> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipeResult>;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var results = (from item in myEntities.Recipe_Results
                               where item.recipeID == objectID
                               select item);
                if (results == null) { return null; }
                returnObject = new List<CraftingRecipeResult>();
                foreach (Recipe_Results item in results.ToList()) { returnObject.Add(new CraftingRecipeResult(item)); }
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
                              where recipeResults.type == (long)ItemTypeEnum.Blueprint && recipeResults.resultID == objectID
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

    public static List<CraftingRecipe> RecipesGetAllThatUseComponentAsIngredient(long objectID)
    {
        string cacheKey = "AllRecipesThatUseComponentAsIngredient_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join ingredients in myEntities.Recipe_Ingredients on item.recipeID equals ingredients.recipeID
                              where ingredients.componentID == objectID
                              select item).OrderBy(x => x.skillID);
                if (result == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe item in result.ToList()) { returnObject.Add(new CraftingRecipe(item.recipeID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method RecipesGetAllThatUseComponentAsIngredient

    public static List<CraftingRecipe> RecipesGetAllThatUseComponentAsAgent(long objectID)
    {
        string cacheKey = "AllRecipesThatUseComponentAsAgent_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join agents in myEntities.Recipe_Agents on item.recipeID equals agents.recipeID
                              where agents.componentID == objectID
                              select item);
                if (result == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe item in result.ToList()) { returnObject.Add(new CraftingRecipe(item.recipeID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method RecipesGetAllThatUseComponentAsAgent

    public static List<CraftingRecipe> RecipesGetAllThatUseItemAsAgent(long objectID)
    {
        string cacheKey = "AllRecipesThatUseItemAsAgent_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join agents in myEntities.Recipe_Agents on item.recipeID equals agents.recipeID
                              join itemComponents in myEntities.Item_Crafting_Components on agents.componentID equals itemComponents.componentID
                              join items in myEntities.Items on itemComponents.itemID equals items.itemID
                              where items.itemID == objectID
                              select item).Distinct().OrderBy(x => x.skillID);
                if (result == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe item in result.ToList()) { returnObject.Add(new CraftingRecipe(item.recipeID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method RecipesGetAllThatUseItemAsAgent

    // All of this logic needs to be completely re-written from scratch due to the refactoring
    //public static List<CraftingRecipe> RecipesGetAllThatUseItemAsIngredient(long objectID)
    //{
    //    string cacheKey = "AllRecipesThatUseItemAsIngredient_" + objectID;
    //    List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;

    //    if (returnObject == null)
    //        using (RepopdataEntities myEntities = new RepopdataEntities())
    //        {
    //            returnObject = new List<CraftingRecipe>();
    //            var recipeList = (from item in myEntities.Recipes
    //                              join ingredients in myEntities.Recipe_Ingredients on item.recipeID equals ingredients.recipeID
    //                              join itemCraftingComponents in myEntities.Item_Crafting_Components on ingredients.componentID equals itemCraftingComponents.componentID
    //                              join actualItems in myEntities.Items on itemCraftingComponents.itemID equals actualItems.itemID
    //                              where actualItems.itemID == objectID
    //                              select item).OrderBy(x => x.skillID);
    //            if (recipeList == null) { return null; }
    //            foreach (Recipe recipe in recipeList)
    //            {
    //                List<CraftingRecipeResult> recipeResults = RecipeResultsGetByRecipeID(recipe.recipeID);

    //                // We only need the Recipe_Ingredients for the current recipe that use one of the item components
    //                List<CraftingRecipeIngredient> componentIngredients = (from item in IngredientsGetByRecipeID(recipe.recipeID)
    //                                                                 join components in ComponentGateway.ComponentsGetByItemID(objectID) on item.CraftingComponent.ID equals components.ID
    //                                                                 select item).ToList();

    //                // This is a terrible hack to make this work while I refactor.  It needs to be taken out back and buried
    //                CraftingFilter itemFilter = FilterGateway.CraftingFilterGetByItemID(objectID);
    //                if (itemFilter == null) { itemFilter = new CraftingFilter(null); }
    //                foreach (CraftingRecipeIngredient recipeIngredient in componentIngredients)
    //                {
    //                    switch (recipeIngredient.Slot)
    //                    {
    //                        case 1:
    //                            foreach (CraftingRecipeResult recipeResult in recipeResults)
    //                            {
    //                                if ((recipeResult.Filters[0].Ingredient.ID == 0 || recipeResult.filter1ID == itemFilter.ID) && !returnObject.Contains(new CraftingRecipe(recipe.recipeID)))
    //                                { returnObject.Add(new CraftingRecipe(recipe.recipeID)); break; } // Don't need to continue if it matches
    //                            } // foreach (Recipe_Results recipeResult in recipeResults)
    //                            break;
    //                        case 2:
    //                            foreach (CraftingRecipeResult recipeResult in recipeResults)
    //                            {
    //                                if ((recipeResult.Filters[1].Ingredient.ID == 0 || recipeResult.filter2ID == itemFilter.ID) && !returnObject.Contains(new CraftingRecipe(recipe.recipeID)))
    //                                { returnObject.Add(new CraftingRecipe(recipe.recipeID)); break; } // Don't need to continue if it matches
    //                            } // foreach (Recipe_Results recipeResult in recipeResults)
    //                            break;
    //                        case 3:
    //                            foreach (CraftingRecipeResult recipeResult in recipeResults)
    //                            {
    //                                if ((recipeResult.Filters[2].Ingredient.ID == 0 || recipeResult.filter3ID == itemFilter.ID) && !returnObject.Contains(new CraftingRecipe(recipe.recipeID)))
    //                                { returnObject.Add(new CraftingRecipe(recipe.recipeID)); break; } // Don't need to continue if it matches
    //                            } // foreach (Recipe_Results recipeResult in recipeResults)
    //                            break;
    //                        case 4:
    //                            foreach (CraftingRecipeResult recipeResult in recipeResults)
    //                            {
    //                                if ((recipeResult.Filters[3].Ingredient.ID == 0 || recipeResult.filter4ID == itemFilter.ID) && !returnObject.Contains(new CraftingRecipe(recipe.recipeID)))
    //                                { returnObject.Add(new CraftingRecipe(recipe.recipeID)); break; } // Don't need to continue if it matches
    //                            } // foreach (Recipe_Results recipeResult in recipeResults)
    //                            break;
    //                    } // switch (recipeIngredient.ingSlot)
    //                } // foreach (Recipe_Ingredients recipeIngredient in componentIngredients)
    //            } // foreach (Recipe recipe in recipeList)
    //            if (returnObject == null) { return null; }
    //            AppCaching.AddToCache(cacheKey, returnObject);
    //        } // using
    //    return returnObject;
    //} // method RecipesGetAllThatUseItemAsIngredient

    public static List<CraftingRecipe> RecipesGetAllThatUseFilter(long objectID)
    {
        string cacheKey = "AllRecipesThatUseFilter_" + objectID;
        List<CraftingRecipe> returnObject = HttpContext.Current.Cache[cacheKey] as List<CraftingRecipe>;

        if (returnObject == null)
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                var result = (from item in myEntities.Recipes
                              join results in myEntities.Recipe_Results on item.recipeID equals results.recipeID
                              where results.filter1ID == objectID || results.filter2ID == objectID ||
                              results.filter3ID == objectID || results.filter4ID == objectID
                              select item).OrderBy(x => x.skillID).Distinct();
                if (result == null) { return null; }
                returnObject = new List<CraftingRecipe>();
                foreach (Recipe item in result.ToList()) { returnObject.Add(new CraftingRecipe(item.recipeID)); }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        return returnObject;
    } // method RecipesGetAllThatUseFilter

} // class RecipeLists