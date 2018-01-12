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

    public static Crafting_Filters GetCraftingFilterByFilterID(long objectID)
    {
        return GetCraftingFilterByFilterID(Convert.ToInt32(objectID));
    }

    public static Crafting_Filters GetCraftingFilterByFilterID(Int32 objectID)
    {
        string cacheKey = "CraftingCraftingFilterByFilterID_" + objectID;
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
    } // method GetCraftingFilterByFilterID

    public static Recipe GetRecipeByItemIDAndType(long objectID, ItemTypeEnum itemType)
    {
        return GetRecipeByItemIDAndType(Convert.ToInt32(objectID), itemType);
    }

    public static Recipe GetRecipeByItemIDAndType(Int32 objectID, ItemTypeEnum itemType )
    {
        string cacheKey = "RecipeByItemIDAndType_" + objectID + "_" + itemType;
        Recipe returnObject = HttpContext.Current.Cache[cacheKey] as Recipe;
        if (returnObject == null)
        {
            using (RepopdataEntities myEntities = new RepopdataEntities())
            {
                switch (itemType)
                {
                    case ItemTypeEnum.Item:
                        returnObject = (from item in myEntities.Recipes
                                        join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                                        join itemResults in myEntities.Items on recipeResults.resultID equals itemResults.itemID
                                        where recipeResults.type == (long)itemType && itemResults.itemID == objectID
                                        select item).FirstOrDefault();
                        break;
                    case ItemTypeEnum.Fitting:
                        returnObject = (from item in myEntities.Recipes
                                        join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                                        join itemResults in myEntities.Fittings on recipeResults.resultID equals itemResults.fittingID
                                        where recipeResults.type == (long)itemType && itemResults.fittingID == objectID
                                        select item).FirstOrDefault();
                        break;
                    case ItemTypeEnum.Blueprint:
                        returnObject = (from item in myEntities.Recipes
                                        join recipeResults in myEntities.Recipe_Results on item.recipeID equals recipeResults.recipeID
                                        join itemResults in myEntities.Structures on recipeResults.resultID equals itemResults.structureID
                                        where recipeResults.type == (long)itemType && itemResults.structureID == objectID
                                        select item).FirstOrDefault();
                        break;
                }
                if (returnObject == null) { return null; }
                AppCaching.AddToCache(cacheKey, returnObject);
            } // using
        }// if
        return returnObject;
    } // method GetCraftingFilterByFilterID

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

    #endregion // Public Methods
} // class RecipeLists