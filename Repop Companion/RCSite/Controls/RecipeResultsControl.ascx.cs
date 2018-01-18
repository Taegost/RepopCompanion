using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Controls_RecipeResultsControl : System.Web.UI.UserControl
{
    int _groupID = 1;
    public Int32 GroupID
    {
        get
        {
            return _groupID;
        }
        set
        {
            _groupID = value;
        }
    } // property GroupID

    public List<Recipe_Results> RecipeResults { get; private set; }
    public int Count { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="results"></param>
    public void SetRecipeResults(List<Recipe_Results> results)
    {
        if (results == null)
        {
            throw new ArgumentOutOfRangeException("results", null, "Value CANNOT be null");
        }
        RecipeResults = results;
        List<Recipe_Results> controlDataSource = new List<Recipe_Results>();

        // If the group ID is 0 or less, show all results.  Else, provide subset
        // This may provide an empty table.  It's up to the end-user to decide what to do with empty tables
        if (GroupID < 1)
        {
            controlDataSource = RecipeResults;
        }
        else
        {
            foreach (Recipe_Results item in RecipeResults)
            {
                if (item.groupID == GroupID) { controlDataSource.Add(item); }
            } // foreach (Recipe_Results item in RecipeResults)
        } // if (GroupID < 1) 

        Count = controlDataSource.Count;
        grd_Results.DataSource = controlDataSource;
        grd_Results.DataBind();
    } // method SetRecipeResults

    protected void Page_Load(object sender, EventArgs e)
    {
        if (RecipeResults == null)
        {
            throw new ArgumentOutOfRangeException("RecipeResults", null, "Value MUST be set");
        }
    } // method Page_Load

    private void ParseResultIngredients(Recipe_Results recipeResults, HyperLink linkControl, long ingredientCount, long filterID, long slotID)
    {

        if (filterID == 0 && ingredientCount == -1)
        {
            List<Recipe_Ingredients> ingredients = RecipeGateway.GetRecipeIngredientsByRecipeID(recipeResults.recipeID);
            var ingredient = (from item in ingredients
                              where item.ingSlot == slotID
                              select item).FirstOrDefault();
            if (ingredient == null)
            {
                linkControl.Text = "";
                linkControl.NavigateUrl = "";
            }
            else
            {
                linkControl.Text = ComponentGateway.GetCraftingComponentByComponentID(ingredient.componentID).displayName;
                if (ingredient.count > 1) linkControl.Text += " (" + ingredient.count + ")";
                linkControl.NavigateUrl = LinkGenerator.GenerateComponentLink(ingredient.componentID);
                return;
            } // if (ingredient == null)
        } // if (filterID == 0 && ingredientCount == -1)
        if (ingredientCount == 0)
        {
            linkControl.Text = "None";
            linkControl.NavigateUrl = "";
            return;
        }
        if (filterID > 0)
        {
            linkControl.Text = FilterGateway.GetCraftingFilterByFilterID(filterID).displayName;
                if (ingredientCount > 0) linkControl.Text += " (" + ingredientCount + ")";
            linkControl.NavigateUrl = LinkGenerator.GenerateFilterLink(filterID);
        } // if (ingredientCount == 0)
    } // ParseResultIngredients

    protected void grd_Results_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                HyperLink nameControl = (HyperLink)e.Row.FindControl("lnk_ResultName");
                if (!string.Equals(nameControl.Text, "Name", StringComparison.CurrentCultureIgnoreCase))
                {
                    Label gradeLabel = (Label)e.Row.FindControl("lbl_Grade");
                    Label difficultyLabel = (Label)e.Row.FindControl("lbl_Difficulty");
                    Recipe_Results gameData = (Recipe_Results)e.Row.DataItem;

                    switch ((ItemTypeEnum)gameData.type)
                    {
                        case ItemTypeEnum.Item:
                            nameControl.Text = (ItemGateway.GetItemByID(gameData.resultID).displayName);
                            nameControl.NavigateUrl = LinkGenerator.GenerateItemLink(gameData.resultID);
                            break;
                        case ItemTypeEnum.Fitting:
                            nameControl.Text = (ItemGateway.GetFittingByID(gameData.resultID).displayName);
                            nameControl.NavigateUrl = LinkGenerator.GenerateFittingLink(gameData.resultID);
                            break;
                        case ItemTypeEnum.Blueprint:
                            nameControl.Text = (ItemGateway.GetBlueprintByID(gameData.resultID).displayName);
                            nameControl.NavigateUrl = LinkGenerator.GenerateBlueprintLink(gameData.resultID);
                            break;
                    } // switch ((ResultTypeEnum)gameData.type)

                    gradeLabel.Text = ((GradeEnum)gameData.grade).ToString();
                    difficultyLabel.Text = ((DifficultyEnum)gameData.level).ToString();
                        ParseResultIngredients(gameData, (HyperLink)e.Row.FindControl("lnk_Ingredient1"), gameData.ingCount1, gameData.filter1ID, 1);
                        ParseResultIngredients(gameData, (HyperLink)e.Row.FindControl("lnk_Ingredient2"), gameData.ingCount2, gameData.filter2ID, 2);
                        ParseResultIngredients(gameData, (HyperLink)e.Row.FindControl("lnk_Ingredient3"), gameData.ingCount3, gameData.filter3ID, 3);
                        ParseResultIngredients(gameData, (HyperLink)e.Row.FindControl("lnk_Ingredient4"), gameData.ingCount4, gameData.filter4ID, 4);
                } // if (!string.Equals(levelLabel.Text, "Name", StringComparison.CurrentCultureIgnoreCase))
                break;
        } // switch
    } // method grd_Results_RowDataBound
} // Controls_RecipeResultsControl