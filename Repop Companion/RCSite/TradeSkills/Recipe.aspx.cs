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
    public Int32 RecipeID { get; private set; }
    public Recipe CurrentRecipe { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("RecipeID")))
        {
            Response.Redirect("Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("RecipeID")))

        RecipeID = Convert.ToInt32(Request.QueryString.Get("RecipeID"));
        CurrentRecipe = RecipeGateway.GetRecipeById(RecipeID);
        if (CurrentRecipe == null) { Response.Redirect("~/TradeSkills/Default.aspx"); }

        // Main information
        Title = CurrentRecipe.displayName;
        Skill recipeSkill = SkillGateway.GetSkillById(CurrentRecipe.skillID);
        lnk_Skill.Text = recipeSkill.displayName;
        lnk_Skill.NavigateUrl = LinkGenerator.GenerateTradeskillLink(recipeSkill.skillID);
        RecipeWrapper.Attributes.Add("class", lnk_Skill.Text);
        Item recipeBook = ItemGateway.GetBookByRecipeID(CurrentRecipe.recipeID);

        if (recipeBook == null)
        { lnk_RecipeBook.Text = "n/a"; }
        else
        {
            lnk_RecipeBook.Text = recipeBook.displayName;
            lnk_RecipeBook.NavigateUrl = LinkGenerator.GenerateItemLink(recipeBook.itemID);
        }

        lbl_Steps.Text = Convert.ToString(CurrentRecipe.steps);
        lbl_WeightIngredient.Text = Convert.ToString(CurrentRecipe.ingredientWeight);
        lbl_WeightAgent.Text = Convert.ToString(CurrentRecipe.agentWeight);

        // Difficulty information
        grd_Difficulty.DataSource = RecipeGateway.GetSkillRangeByRecipeID(RecipeID);
        grd_Difficulty.DataBind();

        // Ingredient information
        grd_Ingredients.DataSource = RecipeGateway.GetRecipeIngredientsByRecipeID(RecipeID);
        grd_Ingredients.DataBind();

        // Agent information
        grd_Agents.DataSource = RecipeGateway.GetRecipeAgentsByRecipeID(RecipeID);
        grd_Agents.DataBind();

        // Results
        List<Recipe_Results> recipeResults = RecipeGateway.GetRecipeResultsByRecipeID(RecipeID);
        ctl_MainResults.SetRecipeResults(recipeResults);
        ctl_ByProduct1.SetRecipeResults(recipeResults);
        ctl_ByProduct2.SetRecipeResults(recipeResults);
        ctl_ByProduct3.SetRecipeResults(recipeResults);
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
                    Recipe_Skill_Range gameData = (Recipe_Skill_Range)e.Row.DataItem;
                    levelLabel.Text = ((DifficultyEnum)gameData.level).ToString();
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
                    Recipe_Ingredients gameData = (Recipe_Ingredients)e.Row.DataItem;
                    itemLink.Text = (RecipeGateway.GetCraftingComponentByComponentID(gameData.componentID).displayName);
                    itemLink.NavigateUrl = LinkGenerator.GenerateComponentLink(gameData.componentID);
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
                    Recipe_Agents gameData = (Recipe_Agents)e.Row.DataItem;
                    itemLink.Text = (RecipeGateway.GetCraftingComponentByComponentID(gameData.componentID).displayName);
                    itemLink.NavigateUrl = LinkGenerator.GenerateComponentLink(gameData.componentID);
                } // if
                break;
        } // switch
    } // method grd_Agents_RowDataBound
} // class TradeSkills_Recipe