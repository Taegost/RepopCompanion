using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingRecipe
/// </summary>
public class CraftingRecipe
{
    public long ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public long Steps { get; private set; }
    public long IngredientWeight { get; private set; }
    public long AgentWeight { get; private set; }

    List<CraftingRecipeResult> _results = null;
    public List<CraftingRecipeResult> Results
    {
        get
        {
            if (_results == null) { _results = RecipeGateway.RecipeResultsGetByRecipeID(ID); } 
            return _results;
        } // get
    } // property Results

    public string URL
    {
        get { return LinkGenerator.GenerateRecipeLink(ID); } 
    } // property URL

    private long parentSkillID;
    private CharacterTradeSkill _parentSkill = null;
    public CharacterTradeSkill ParentSkill
    {
        get
        {
            if (_parentSkill == null) { _parentSkill = new CharacterTradeSkill(parentSkillID); } 
            return _parentSkill;
        } // get
    } // property ParentSkill

    private List<CraftingRecipeSkillRange> _skillRange = null;
    public List<CraftingRecipeSkillRange> SkillRange
    {
        get
        {
            if (_skillRange == null) { _skillRange = RecipeGateway.SkillRangeGetByRecipeID(ID); }
            return _skillRange;
        } // get
    } // property SkillRange

    private RecipeBook _recipeBook = null;
    public RecipeBook RecipeBook
    {
        get
        {
            if (_recipeBook == null)
            {
                _recipeBook = ItemGateway.BookGetByRecipeID(ID);
                if (_recipeBook == null)
                { _recipeBook = new RecipeBook(0); }
                else
                { _recipeBook = new RecipeBook(_recipeBook.ID); }
            }
            return _recipeBook;
        } // get
    } // property RecipeBook

    private List<CraftingRecipeIngredient> _ingredients = null;
    public List<CraftingRecipeIngredient> Ingredients
    {
        get
        {
            if (_ingredients == null) { _ingredients = RecipeGateway.IngredientsGetByRecipeID(ID); }
            return _ingredients;
        } // get
    } // property Ingredients

    private List<CraftingRecipeAgent> _agents = null;
    public List<CraftingRecipeAgent> Agents
    {
        get
        {
            if (_agents == null) { _agents = RecipeGateway.AgentsGetByRecipeID(ID); }
            return _agents;
        } // get
    } // property Agents

    public CraftingRecipe(long recipeId)
    {
        ID = recipeId;
        Recipe recipeRecord = RecipeGateway.RecipeGetById(ID);
        if (recipeRecord == null)
        {
            Name = "n/a";
            Description = "n/a";
            Steps = -1;
            IngredientWeight = -1;
            AgentWeight = -1;
            parentSkillID = -1;
        }
        else
        {
            Name = recipeRecord.displayName;
            Description = recipeRecord.displayDescription;
            Steps = recipeRecord.steps;
            IngredientWeight = recipeRecord.ingredientWeight;
            AgentWeight = recipeRecord.agentWeight;
            parentSkillID = recipeRecord.skillID;
        }
    } // constructor
} // class CraftingRecipe