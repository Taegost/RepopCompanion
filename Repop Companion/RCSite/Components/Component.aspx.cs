using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Components_Component : BasePage
{
    public CraftingComponent CurrentComponent { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("ComponentID")))
        {
            Response.Redirect("Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("ComponentID")))

        long currentID = Convert.ToInt32(Request.QueryString.Get("ComponentID"));
        CurrentComponent = new CraftingComponent(currentID);
        if (CurrentComponent.Name.Equals("n/a")) { Response.Redirect("Default.aspx"); }
        Title = CurrentComponent.Name;

        rpt_Items.DataSource = CurrentComponent.Items;
        rpt_Items.DataBind();
        grd_Ingredients.DataSource = CurrentComponent.RecipesUsedAsIngredient;
        grd_Ingredients.DataBind();
        grd_Agents.DataSource = CurrentComponent.RecipesUsedAsAgent;
        grd_Agents.DataBind();

        ItemWrapper.Visible = rpt_Items.Items.Count > 0;
        IngredientWrapper.Visible = grd_Ingredients.Rows.Count > 0;
        AgentWrapper.Visible = grd_Agents.Rows.Count > 0;

    } // method Page_Load

    protected void grd_Ingredients_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                CraftingRecipe gameData = (CraftingRecipe)e.Row.DataItem;
                e.Row.CssClass += " " + gameData.ParentSkill.Name;
                break;
        } // switch
    } // method grd_Ingredients_RowDataBound

    protected void grd_Agents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                CraftingRecipe gameData = (CraftingRecipe)e.Row.DataItem;
                e.Row.CssClass += " " + gameData.ParentSkill.Name;
                break;
        } // switch
    } // method grd_Agents_RowDataBound
} // class Components_Component