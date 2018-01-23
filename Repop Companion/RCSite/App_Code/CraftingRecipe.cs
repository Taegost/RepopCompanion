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

    public CraftingRecipe(long recipeId)
    {
        ID = recipeId;
        Recipe recipeRecord = RecipeGateway.GetRecipeById(ID);
        Name = recipeRecord.displayName;
        Description = recipeRecord.displayDescription;
        Steps = recipeRecord.steps;
        IngredientWeight = recipeRecord.ingredientWeight;
        AgentWeight = recipeRecord.agentWeight;
        parentSkillID = recipeRecord.skillID;
    } // constructor
} // class CraftingRecipe