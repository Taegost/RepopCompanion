using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingComponent
/// </summary>
public class CraftingFilter : IRecipeIngredient
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string URL
    {
        get
        {
            return LinkGenerator.GenerateFilterLink(ID);
        } // get
    } // property URL

    private List<CraftingRecipe> _recipesUsedAsIngredient = null;
    public List<CraftingRecipe> RecipesUsedAsIngredient
    {
        get
        {
            if (_recipesUsedAsIngredient == null) { _recipesUsedAsIngredient = RecipeGateway.RecipesGetAllThatUseFilter(ID); }
            return _recipesUsedAsIngredient;
        } // get
    } // property RecipesUsedAsIngredient

    private List<ItemBase> _items = null;
    public List<ItemBase> Items
    {
        get
        {
            if (_items == null) { _items = ItemGateway.ItemsGetAllByFilterID(ID); }
            return _items;
        } // get
    } // property Items


    public CraftingFilter(Crafting_Filters filter)
    {
        if (filter == null)
        {
            ID = 0;
            Name = "n/a";
            Description = "n/a";
        }
        else
        {
            ID = filter.filterID;
            Name = filter.displayName;
            Description = filter.displayDescription;
        }
    } // constructor

    public CraftingFilter(long filterID) 
    {
        CraftingFilter filter = FilterGateway.CraftingFilterGetByFilterID(filterID);
        if (filter == null)
        {
            ID = 0;
            Name = "n/a";
            Description = "n/a";
        }
        else
        {
            ID = filter.ID;
            Name = filter.Name;
            Description = filter.Description;
        }
    } // constructor
} // class CraftingFilter