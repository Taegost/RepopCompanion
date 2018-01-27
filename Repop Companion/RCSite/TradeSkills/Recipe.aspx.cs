using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class TradeSkills_Recipe : BasePage
{
    public CraftingRecipe CurrentRecipe { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("RecipeID")))
        {
            Response.Redirect("Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("RecipeID")))

        long incomingID = Convert.ToInt64(Request.QueryString.Get("RecipeID"));
        if (incomingID == 0) { Response.Redirect("~/TradeSkills/Default.aspx"); }
        CurrentRecipe = new CraftingRecipe(incomingID);
        if (CurrentRecipe.Name.Equals("n/a")) { Response.Redirect("~/TradeSkills/Default.aspx"); }

        // Main information
        Title = CurrentRecipe.Name;
        lnk_Skill.Text = CurrentRecipe.ParentSkill.Name;
        lnk_Skill.NavigateUrl = CurrentRecipe.ParentSkill.URL;
        RecipeWrapper.Attributes.Add("class", lnk_Skill.Text);

        lnk_RecipeBook.Text = CurrentRecipe.RecipeBook.Name;
        lnk_RecipeBook.NavigateUrl = CurrentRecipe.RecipeBook.URL;

        lbl_Steps.Text = Convert.ToString(CurrentRecipe.Steps);
        lbl_WeightIngredient.Text = Convert.ToString(CurrentRecipe.IngredientWeight);
        lbl_WeightAgent.Text = Convert.ToString(CurrentRecipe.AgentWeight);

        // Difficulty information
        grd_Difficulty.DataSource = CurrentRecipe.SkillRange;
        grd_Difficulty.DataBind();

        // Ingredient information
        grd_Ingredients.DataSource = CurrentRecipe.Ingredients;
        grd_Ingredients.DataBind();

        // Agent information
        grd_Agents.DataSource = CurrentRecipe.Agents; ;
        grd_Agents.DataBind();

        // Results
        ctl_MainResults.SetRecipeResults(CurrentRecipe.Results);
        ctl_ByProduct1.SetRecipeResults(CurrentRecipe.Results);
        ctl_ByProduct2.SetRecipeResults(CurrentRecipe.Results);
        ctl_ByProduct3.SetRecipeResults(CurrentRecipe.Results);
        if (ctl_ByProduct1.Count + ctl_ByProduct2.Count + ctl_ByProduct3.Count == 0) { ByProducts.Visible = false; }

    } // method Page_Load


    protected void grd_Difficulty_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                Label levelLabel = (Label)e.Row.FindControl("lbl_LevelColumn");
                if (!string.Equals(levelLabel.Text, "Level", StringComparison.CurrentCultureIgnoreCase))
                {
                    CraftingRecipeSkillRange gameData = (CraftingRecipeSkillRange)e.Row.DataItem;
                    levelLabel.Text = (gameData.Difficulty).ToString();
                } // if
                break;
        } // switch
    } // method grd_Difficulty_RowDataBound

    protected void grd_Ingredients_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                HyperLink itemLink = (HyperLink)e.Row.FindControl("lnk_IngredientName");
                if (!string.Equals(itemLink.Text, "Name", StringComparison.CurrentCultureIgnoreCase))
                {
                    CraftingRecipeIngredient gameData = (CraftingRecipeIngredient)e.Row.DataItem;
                    itemLink.Text = gameData.CraftingComponent.Name;
                    itemLink.NavigateUrl = gameData.CraftingComponent.URL;
                } // if
                break;
        } // switch
    } // method grd_Ingredients_RowDataBound

    protected void grd_Agents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                HyperLink itemLink = (HyperLink)e.Row.FindControl("lnk_AgentName");
                if (!string.Equals(itemLink.Text, "Name", StringComparison.CurrentCultureIgnoreCase))
                {
                    CraftingRecipeAgent gameData = (CraftingRecipeAgent)e.Row.DataItem;
                    itemLink.Text = gameData.CraftingComponent.Name;
                    itemLink.NavigateUrl = gameData.CraftingComponent.URL;
                } // if
                break;
        } // switch
    } // method grd_Agents_RowDataBound
} // class TradeSkills_Recipe