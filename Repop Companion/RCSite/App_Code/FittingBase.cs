using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ItemBase
/// </summary>
public class FittingBase : IRecipeResultItem
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string URL
    {
        get
        {
            if (ID > 0) { return LinkGenerator.GenerateFittingLink(ID); }
            return "";
        } // get
    } // property URL
    private List<CraftingRecipe> _recipes = null;
    public List<CraftingRecipe> Recipes
    {
        get
        {
            if (_recipes == null)
            {
                _recipes = RecipeGateway.RecipesThatCreateFitting(ID);
            }
            return _recipes;
        } // get
    } // property Recipes


    public FittingBase(long itemID)
    {
        ID = itemID;
        if (ID > 0)
        {
            Fitting itemRecord = ItemGateway.FittingGetByID(itemID);
            Name = itemRecord.displayName;
            Description = itemRecord.displayDescription;
        } // if (ID > 0)
        else
        {
            Name = "n/a";
            Description = "n/a";
        }
    } // constructor
} // Class FittingBase