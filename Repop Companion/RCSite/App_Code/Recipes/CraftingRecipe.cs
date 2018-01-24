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

    public string URL
    {
        get
        {
            return LinkGenerator.GenerateRecipeLink(ID);
        } // get
    } // property URL

    private long parentSkillID;
    private CharacterSkill _parentSkill = null;
    public CharacterSkill ParentSkill
    {
        get
        {
            if (_parentSkill == null)
            {
                _parentSkill = new CharacterSkill(parentSkillID);
            } // if (_parentSkill == null)
            return _parentSkill;
        } // get
    } // property ParentSkill

    private List<CraftingRecipeSkillRange> _skillRange = null;
    public List<CraftingRecipeSkillRange> SkillRange
    {
        get
        {
            if (_skillRange == null)
            {
                List<Recipe_Skill_Range> skillRanges = RecipeGateway.SkillRangeGetByRecipeID(ID);
                _skillRange = new List<CraftingRecipeSkillRange>();
                foreach (Recipe_Skill_Range range in skillRanges) { _skillRange.Add(new CraftingRecipeSkillRange(range)); }
            }
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
                Item book = ItemGateway.BookGetByRecipeID(ID);
                if (book == null)
                { _recipeBook = new RecipeBook(0); }
                else
                { _recipeBook = new RecipeBook(book.itemID); }
            }
            return _recipeBook;
        } // get
    } // property RecipeBook

    private List<CraftingRecipeIngredient> _ingredients = null;
    public List<CraftingRecipeIngredient> Ingredients
    {
        get
        {
            if (_ingredients == null)
            {
                List<Recipe_Ingredients> recipeIngredients = RecipeGateway.IngredientsGetByRecipeID(ID);
                _ingredients = new List<CraftingRecipeIngredient>();
                foreach (Recipe_Ingredients ingredient in recipeIngredients) { _ingredients.Add(new CraftingRecipeIngredient(ingredient)); }
            }
            return _ingredients;
        } // get
    } // property Ingredients

    private List<CraftingRecipeAgent> _agents = null;
    public List<CraftingRecipeAgent> Agents
    {
        get
        {
            if (_agents == null)
            {
                List<Recipe_Agents> recipeAgents = RecipeGateway.AgentsGetByRecipeID(ID);
                _agents = new List<CraftingRecipeAgent>();
                foreach (Recipe_Agents agent in recipeAgents) { _agents.Add(new CraftingRecipeAgent(agent)); }
            }
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