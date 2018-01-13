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
                            nameControl.NavigateUrl = LinkGenerator.GenerateItemLink(ItemGateway.GetItemByID(gameData.resultID).itemID);
                            break;
                        case ItemTypeEnum.Fitting:
                            nameControl.Text = (ItemGateway.GetFittingByID(gameData.resultID).displayName);
                            break;
                        case ItemTypeEnum.Blueprint:
                            nameControl.Text = (ItemGateway.GetBlueprintByID(gameData.resultID).displayName);
                            break;
                    } // switch ((ResultTypeEnum)gameData.type)

                    gradeLabel.Text = ((GradeEnum)gameData.grade).ToString();
                    difficultyLabel.Text = ((DifficultyEnum)gameData.level).ToString();
                    if (gameData.filter1ID > 0)
                    {
                        HyperLink ingredientControl = (HyperLink)e.Row.FindControl("lnk_Ingredient1");
                        string newValue = RecipeGateway.GetCraftingFilterByFilterID(gameData.filter1ID).displayName;
                        if (gameData.ingCount1 > 0) newValue += " (" + gameData.ingCount1 + ")";
                        ingredientControl.Text = newValue;
                        ingredientControl.NavigateUrl = LinkGenerator.GenerateFilterLink(gameData.filter1ID);
                    }
                    if (gameData.filter2ID > 0)
                    {
                        HyperLink ingredientControl = (HyperLink)e.Row.FindControl("lnk_Ingredient2");
                        string newValue = RecipeGateway.GetCraftingFilterByFilterID(gameData.filter2ID).displayName;
                        if (gameData.ingCount2 > 0) newValue += " (" + gameData.ingCount2 + ")";
                        ingredientControl.Text = newValue;
                        ingredientControl.NavigateUrl = LinkGenerator.GenerateFilterLink(gameData.filter2ID);
                    }
                    if (gameData.filter3ID > 0)
                    {
                        HyperLink ingredientControl = (HyperLink)e.Row.FindControl("lnk_Ingredient3");
                        string newValue = RecipeGateway.GetCraftingFilterByFilterID(gameData.filter3ID).displayName;
                        if (gameData.ingCount3 > 0) newValue += " (" + gameData.ingCount3 + ")";
                        ingredientControl.Text = newValue;
                        ingredientControl.NavigateUrl = LinkGenerator.GenerateFilterLink(gameData.filter3ID);
                    }
                    if (gameData.filter4ID > 0)
                    {
                        HyperLink ingredientControl = (HyperLink)e.Row.FindControl("lnk_Ingredient4");
                        string newValue = RecipeGateway.GetCraftingFilterByFilterID(gameData.filter4ID).displayName;
                        if (gameData.ingCount4 > 0) newValue += " (" + gameData.ingCount4 + ")";
                        ingredientControl.Text = newValue;
                        ingredientControl.NavigateUrl = LinkGenerator.GenerateFilterLink(gameData.filter4ID);
                    }
                } // if (!string.Equals(levelLabel.Text, "Name", StringComparison.CurrentCultureIgnoreCase))
                break;
        } // switch
    } // method grd_Results_RowDataBound
} // Controls_RecipeResultsControl