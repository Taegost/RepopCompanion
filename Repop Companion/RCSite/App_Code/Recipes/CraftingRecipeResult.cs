using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repop_Companion.DataModels;

/// <summary>
/// Summary description for CraftingRecipeResult
/// </summary>
public class CraftingRecipeResult
{
    public CraftingRecipe ParentRecipe { get; private set; }
    public long Count { get; private set; }
    public long Group { get; private set; }
    public ItemTypeEnum Type { get; private set; }
    public GradeEnum MinimumGrade { get; private set; }
    public IRecipeResultItem Result { get; private set; }
    public List<CraftingRecipeFilter> Filters { get; private set; }
    public DifficultyEnum Difficulty { get; private set; }

    public CraftingRecipeResult(Recipe_Results recipeResult)
    {
        ParentRecipe = new CraftingRecipe(recipeResult.recipeID);
        Count = recipeResult.count;
        Type = (ItemTypeEnum)recipeResult.type;
        MinimumGrade = (GradeEnum)recipeResult.grade;
        Group = recipeResult.groupID;
        Difficulty = (DifficultyEnum)recipeResult.level;

        switch (Type)
        {
            case ItemTypeEnum.Item:
                Result = new ItemBase(recipeResult.resultID);
                break;
            case ItemTypeEnum.Fitting:
                Result = new FittingBase(recipeResult.resultID);
                break;
            case ItemTypeEnum.Blueprint:
                Result = new BlueprintBase(recipeResult.resultID);
                break;
        } // switch (Type)

        Filters = new List<CraftingRecipeFilter>();
        Filters.Add(new CraftingRecipeFilter(ParentRecipe.ID, recipeResult.filter1ID, recipeResult.ingCount1, 1));
        Filters.Add(new CraftingRecipeFilter(ParentRecipe.ID, recipeResult.filter2ID, recipeResult.ingCount2, 2));
        Filters.Add(new CraftingRecipeFilter(ParentRecipe.ID, recipeResult.filter3ID, recipeResult.ingCount3, 3));
        Filters.Add(new CraftingRecipeFilter(ParentRecipe.ID, recipeResult.filter4ID, recipeResult.ingCount4, 4));
    } // constructor
} // class CraftingRecipeResult