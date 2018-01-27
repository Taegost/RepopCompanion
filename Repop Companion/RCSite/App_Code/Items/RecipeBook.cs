using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for RecipeBook
/// </summary>
public class RecipeBook : ItemBase
{
    private List<CraftingRecipe> _recipesTaught = null;
    public List<CraftingRecipe> RecipesTaught
    {
        get
        {
            if (_recipesTaught == null) { _recipesTaught = RecipeGateway.RecipesGrantedByRecipeBookID(ID); }
            return _recipesTaught;
        } // get
    } // property RecipesTaught

    public RecipeBook(long itemID) : base(itemID)
    {
    } // constructor
} // class RecipeBook