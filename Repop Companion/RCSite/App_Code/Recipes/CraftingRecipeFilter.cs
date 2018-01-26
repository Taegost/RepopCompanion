using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingRecipeFilter
/// </summary>
public class CraftingRecipeFilter
{
    private long parentRecipeID;
    private CraftingRecipe _parentRecipe = null;
    public CraftingRecipe ParentRecipe
    {
        get
        {
            if (_parentRecipe == null) { _parentRecipe = new CraftingRecipe(parentRecipeID); }
            return _parentRecipe;
        } // get
    } // property ParentRecipe
    public IRecipeIngredient Ingredient { get; private set; }
    public long Slot { get; private set; }
    public long Count { get; private set; }
    private string _ingredientFullName = "";
    public string IngredientFullName
    {
        get
        {
            if (Count > 1) _ingredientFullName += " (" + Count + ")";
            return _ingredientFullName;
        }
    } // property IngredientFullName

    public CraftingRecipeFilter(long recipeID, long filterID, long ingCount, long slot)
    {
        parentRecipeID = recipeID;
        Slot = slot;
        Count = ingCount;

        // In this case, the filter is a Crafting Component
        if (filterID == 0 && ingCount == -1)
        {
            List<Recipe_Ingredients> ingredients = RecipeGateway.IngredientsGetByRecipeID(parentRecipeID);
            var ingredient = (from item in ingredients
                              where item.ingSlot == Slot
                              select item).FirstOrDefault();
            if (ingredient == null)
            {
                Ingredient = null;
            }
            else
            {
                Ingredient = new CraftingComponent(ingredient.componentID);
                Count = ingredient.count;
                _ingredientFullName = Ingredient.Name;
                return;
            } // if (ingredient == null)
        } // if (filterID == 0 && ingCount == -1)

        // If the ingredient count is 0, then there can't be anything in this slot
        if (ingCount == 0)
        {
            _ingredientFullName = "None";
            return;
        }

        // Use the actual filter information
        if (filterID > 0)
        {
            Ingredient = new CraftingFilter(filterID);
            _ingredientFullName = Ingredient.Name;
            return;
        } // if (ingredientCount == 0)

    } // constructor
} // class CraftingRecipeFilter