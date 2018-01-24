﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Components_Component : BasePage
{
    public Crafting_Components CurrentComponent { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("ComponentID")))
        {
            Response.Redirect("Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("ComponentID")))

        int currentID = Convert.ToInt32(Request.QueryString.Get("ComponentID"));
        CurrentComponent = ComponentGateway.CraftingComponentGetByComponentID(currentID);
        if (CurrentComponent == null) { Response.Redirect("Default.aspx"); }
        Title = CurrentComponent.displayName;

        rpt_Items.DataSource = ItemGateway.GetItemsByComponentID(CurrentComponent.componentID);
        rpt_Items.DataBind();
        grd_Ingredients.DataSource = RecipeGateway.GetAllRecipesThatUseComponentAsIngredient(CurrentComponent.componentID);
        grd_Ingredients.DataBind();
        grd_Agents.DataSource = RecipeGateway.GetAllRecipesThatUseComponentAsAgent(CurrentComponent.componentID);
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
                Recipe gameData = (Recipe)e.Row.DataItem;
                e.Row.CssClass += " " + SkillGateway.GetSkillById(gameData.skillID).displayName;
                break;
        } // switch
    } // method grd_Ingredients_RowDataBound

    protected void grd_Agents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                Recipe gameData = (Recipe)e.Row.DataItem;
                e.Row.CssClass += " " + SkillGateway.GetSkillById(gameData.skillID).displayName;
                break;
        } // switch
    } // method grd_Agents_RowDataBound
} // class Components_Component