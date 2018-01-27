using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for ItemBase
/// </summary>
public class ItemBase : IRecipeResultItem
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ItemTypeEnum Type = ItemTypeEnum.Item;
    public string URL
    {
        get
        {
            if (ID > 0) { return LinkGenerator.GenerateItemLink(ID); }
            return "";
        } // get
    } // property URL

    private ItemGroupEnum _group = ItemGroupEnum.Unknown;
    public ItemGroupEnum Group
    {
        get
        {
            if (_group == ItemGroupEnum.Unknown && ID > 0) { _group = ItemGateway.DetermineItemGroupByItemID(ID); }
            return _group;
        } // get
    } // property Group

    private List<CraftingRecipe> _recipes = null;
    public List<CraftingRecipe> Recipes
    {
        get
        {
            if (_recipes == null) { _recipes = RecipeGateway.RecipesThatCreateItem(ID); }
            return _recipes;
        } // get
    } // property Recipes

    private long _value = -1;
    public long Value
    {
        get
        {
            if (_value == -1) { _value = (long)ItemGateway.ValueGetByItemID(ID).value; }
            return _value;
        } // get
    } // property Value

    private ItemStackInfo _stackInfo = null;
    public ItemStackInfo StackInfo
    {
        get
        {
            if (_stackInfo == null) { _stackInfo = new ItemStackInfo(ID); }
            return _stackInfo;
        } // get
    } // property StackInfo

    private ItemPowerSource _powerSource = null;
    public ItemPowerSource PowerSource
    {
        get
        {
            if (_powerSource == null) {  _powerSource = new ItemPowerSource(ID); }
            return _powerSource;
        } // get
    } // property PowerSource

    public ItemBase(long itemID)
    {
        ID = itemID;
        if (ID > 0)
        {
            Item itemRecord = ItemGateway.ItemGetByID(itemID);
            Name = itemRecord.displayName;
            Description = itemRecord.displayDescription;
        } // if (ID > 0)
        else
        {
            Name = "n/a";
            Description = "n/a";
        }
    } // constructor
} // Class ItemBase