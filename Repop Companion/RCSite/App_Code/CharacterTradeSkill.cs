using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CharacterSkill
/// </summary>
public class CharacterTradeSkill
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsTradeSkill
    {
        get
        {
            return SkillGateway.TradeSkillsGetAll().Contains(this);
        }
    } // property IsTradeSkill
    public string URL
    {
        get
        {
            return LinkGenerator.GenerateTradeskillLink(ID);
        } // get
    } // property URL
    private List<CraftingRecipe> _recipes = null;
    public List<CraftingRecipe> Recipes
    {
        get
        {
            if (_recipes == null)
            {
                _recipes = RecipeGateway.RecipesGetBySkillID(ID);
            }
            return _recipes;
        } // get
    } // property Recipes

    private List<ItemBase> _items = null;
    public List<ItemBase> Items
    {
        get
        {
            if (_items == null)
            {
                _items = ItemGateway.ItemsGetAllCreatedByTradeskillID(ID);
            }
            return _items;
        } // get
    } // property Items

    private List<FittingBase> _fittings = null;
    public List<FittingBase> Fittings
    {
        get
        {
            if (_fittings == null)
            {
                _fittings = ItemGateway.FittingsGetAllCreatedByTradeskillID(ID);
            }
            return _fittings;
        } // get
    } // property Fittings

    private List<BlueprintBase> _blueprints = null;
    public List<BlueprintBase> Blueprints
    {
        get
        {
            if (_blueprints == null)
            {
                _blueprints = ItemGateway.BlueprintsGetAllCreatedByTradeskillID(ID);
            }
            return _blueprints;
        } // get
    } // property Blueprints

    public CharacterTradeSkill(long skillID)
    {
        ID = skillID;
        Skill skillRecord = SkillGateway.SkillGetById(ID);
        if (skillRecord == null)
        {
            Name = "n/a";
            Description = "n/a";
        }
        else
        {
            Name = skillRecord.displayName;
            Description = skillRecord.displayDescription;
        }
    } // constructor
} // class CharacterTradeSkill