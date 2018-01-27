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
    private long parentRecipeID;
    private CraftingRecipe _parentRecipe = null;
    public CraftingRecipe ParentRecipe
    {
        get
        {
            if (_parentRecipe == null) { _parentRecipe = new CraftingRecipe(parentRecipeID); }
            return _parentRecipe;
        }
    } // property ParentRecipe
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
        parentRecipeID = ingredient.recipeID;
        Count = ingredient.count;
        Weight = ingredient.weight;
        Slot = ingredient.ingSlot;
        craftingComponentID = ingredient.componentID;
    } // constructor
} // class CraftingRecipeIngredient