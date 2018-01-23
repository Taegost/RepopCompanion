using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingRecipeSkillRange
/// </summary>
public class CraftingRecipeSkillRange
{
    public long RecipeID { get; private set; }
    public DifficultyEnum Difficulty { get; private set; }
    public long MinF { get; private set; }
    public long MinD { get; private set; }
    public long MinC { get; private set; }
    public long MinB { get; private set; }
    public long MinA { get; private set; }
    public long MinAA { get; private set; }
    public long Over1 { get; private set; }
    public long Over2 { get; private set; }

    public CraftingRecipeSkillRange(Recipe_Skill_Range skillRange)
    {
        RecipeID = skillRange.recipeID;
        Difficulty = (DifficultyEnum)skillRange.level;
        MinF = skillRange.minf;
        MinD = skillRange.mind;
        MinC = skillRange.minc;
        MinB = skillRange.minb;
        MinA = skillRange.mina;
        MinAA = skillRange.minaa;
        Over1 = skillRange.over1;
        Over2 = skillRange.over2;
    } // constructor
} // class CraftingRecipeSkillRange