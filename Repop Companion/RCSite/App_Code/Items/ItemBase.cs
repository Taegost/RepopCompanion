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
    private ItemGroupEnum[] ItemGroupsUsedInCrafting = { ItemGroupEnum.CraftingComponent, ItemGroupEnum.RawMaterial };
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
    public bool IsUsedInCrafting()
    {
        return ItemGroupsUsedInCrafting.Contains(Group);        
    } // IsUsedInCrafting

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

    private List<CraftingComponent> _components = null;
    public List<CraftingComponent> Components
    {
        get
        {
            if (_components == null && IsUsedInCrafting()) { _components = ComponentGateway.ComponentsGetByItemID(ID); }
            return _components;
        } // get
    } // property Components

    private CraftingFilter _filter = null;
    public CraftingFilter Filter
    {
        get
        {
            if (_filter == null && IsUsedInCrafting()) { _filter = FilterGateway.CraftingFilterGetByItemID(ID); }
            return _filter;
        } // get
    } // property Filter

    private List<CraftingRecipe> _recipesUsedAsAgent = null;
    public List<CraftingRecipe> RecipesUsedAsAgent
    {
        get
        {
            if (_recipesUsedAsAgent == null && IsUsedInCrafting()) { _recipesUsedAsAgent = RecipeGateway.RecipesGetAllThatUseItemAsAgent(ID); }
            return _recipesUsedAsAgent;
        } // get
    } // property RecipesUsedAsAgent

    private List<CraftingRecipe> _recipesUsedAsIngredient = null;
    public List<CraftingRecipe> RecipesUsedAsIngredient
    {
        get
        {
            // This method needs to be refactored before it'll work
            // if (_recipesUsedAsIngredient == null && IsUsedInCrafting()) { _recipesUsedAsIngredient = RecipeGateway.RecipesGetAllThatUseItemAsIngredient(ID); }
            return _recipesUsedAsIngredient;
        } // get
    } // property RecipesUsedAsIngredient

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