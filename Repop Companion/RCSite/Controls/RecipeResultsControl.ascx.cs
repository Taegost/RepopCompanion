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
    long _groupID = 1;
    /// <summary>
    /// GroupID is whether the item is the Main product (1) or a byproduct (2,3,4)
    /// </summary>
    public long GroupID
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

    public List<CraftingRecipeResult> RecipeResults { get; private set; }
    public int Count { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="results"></param>
    public void SetRecipeResults(List<CraftingRecipeResult> results)
    {
        if (results == null)
        {
            throw new ArgumentOutOfRangeException("results", null, "Value CANNOT be null");
        }
        RecipeResults = results;
        List<CraftingRecipeResult> controlDataSource = new List<CraftingRecipeResult>();

        // If the group ID is 0 or less, show all results.  Else, provide the subset corresponding to the group
        // This may provide an empty table.  It's up to the end-user to decide what to do with empty tables
        if (GroupID < 1)
        {
            controlDataSource = RecipeResults;
        }
        else
        {
            foreach (CraftingRecipeResult item in RecipeResults)
            {
                if (item.Group == GroupID) { controlDataSource.Add(item); }
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
                    CraftingRecipeResult gameData = (CraftingRecipeResult)e.Row.DataItem;

                    nameControl.Text = gameData.Result.Name;
                    nameControl.NavigateUrl = gameData.Result.URL;

                    gradeLabel.Text = gameData.MinimumGrade.ToString();
                    difficultyLabel.Text = gameData.Difficulty.ToString();
                    foreach (CraftingRecipeFilter filter in gameData.Filters)
                    {
                        HyperLink rowControl = new HyperLink();
                        switch (filter.Slot)
                        {
                            case 1:
                                rowControl = (HyperLink)e.Row.FindControl("lnk_Ingredient1");
                                break;
                            case 2:
                                rowControl = (HyperLink)e.Row.FindControl("lnk_Ingredient2");
                                break;
                            case 3:
                                rowControl = (HyperLink)e.Row.FindControl("lnk_Ingredient3");
                                break;
                            case 4:
                                rowControl = (HyperLink)e.Row.FindControl("lnk_Ingredient4");
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("Slot", filter.Slot, "Value must be between 1-4");
                        } // switch (filter.Slot)
                        if (filter.Ingredient != null)
                        {
                            rowControl.Text = filter.IngredientFullName;
                            rowControl.NavigateUrl = filter.Ingredient.URL;
                        }
                    } // foreach (CraftingRecipeFilter filter in gameData.Filters)
                } // if (!string.Equals(levelLabel.Text, "Name", StringComparison.CurrentCultureIgnoreCase))
                break;
        } // switch
    } // method grd_Results_RowDataBound
} // Controls_RecipeResultsControl