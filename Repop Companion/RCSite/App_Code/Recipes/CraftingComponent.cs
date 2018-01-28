using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingComponent
/// </summary>
public class CraftingComponent : IRecipeIngredient
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string URL
    {
        get
        {
            return LinkGenerator.GenerateComponentLink(ID);
        } // get
    } // property URL

    private List<ItemBase> _items = null;
    public List<ItemBase> Items
    {
        get
        {
            if (_items == null)
            {
                _items = ItemGateway.ItemsGetByComponentID(ID);
            }
            return _items;
        } // get
    } // property Items

    private List<CraftingRecipe> _recipesUsedAsAgent = null;
    public List<CraftingRecipe> RecipesUsedAsAgent
    {
        get
        {
            if (_recipesUsedAsAgent == null) { _recipesUsedAsAgent = RecipeGateway.RecipesGetAllThatUseComponentAsAgent(ID); }
            return _recipesUsedAsAgent;
        } // get
    } // property RecipesUsedAsAgent

    private List<CraftingRecipe> _recipesUsedAsIngredient = null;
    public List<CraftingRecipe> RecipesUsedAsIngredient
    {
        get
        {
            if (_recipesUsedAsIngredient == null) { _recipesUsedAsIngredient = RecipeGateway.RecipesGetAllThatUseComponentAsIngredient(ID); }
            return _recipesUsedAsIngredient;
        } // get
    } // property RecipesUsedAsIngredient

    public CraftingComponent(long componentID)
    {
        ID = componentID;
        Crafting_Components component = ComponentGateway.CraftingComponentGetByComponentID(ID);
        if (component == null)
        {
            Name = "n/a";
            Description = "n/a";
        }
        else
        {
            Name = component.displayName;
            Description = component.displayDescription;
        }
    } // constructor
} // class CraftingComponent