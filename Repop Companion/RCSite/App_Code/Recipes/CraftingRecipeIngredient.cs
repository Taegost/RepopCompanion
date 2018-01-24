using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingRecipeIngredient
/// </summary>
public class CraftingRecipeIngredient
{
    public CraftingRecipe ParentRecipe { get; private set; }
    public long Count { get; private set; }
    public long Weight { get; private set; }
    public long Slot { get; private set; }

    private long craftingComponentID;
    private CraftingComponent _craftingComponent = null;
    public CraftingComponent CraftingComponent
    {
        get
        {
            if (_craftingComponent == null)
            {
                _craftingComponent = new CraftingComponent(craftingComponentID);
            }
            return _craftingComponent;
        } // get
    } // property CraftingComponent
    public string URL
    {
        get
        {
            return LinkGenerator.GenerateComponentLink(CraftingComponent.ID);
        } // get
    } // property URL


    public CraftingRecipeIngredient(Recipe_Ingredients ingredient)
    {
        ParentRecipe = new CraftingRecipe(ingredient.recipeID);
        Count = ingredient.count;
        Weight = ingredient.weight;
        Slot = ingredient.ingSlot;
        craftingComponentID = ingredient.componentID;
    } // constructor
} // class CraftingRecipeIngredient