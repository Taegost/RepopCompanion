using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Blueprints_Blueprint : BasePage
{
    public BlueprintBase CurrentBlueprint { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("BlueprintID"))) { Response.Redirect("~/Blueprints/Default.aspx"); }

        int currentID = Convert.ToInt32(Request.QueryString.Get("BlueprintID"));
        CurrentBlueprint = new BlueprintBase(currentID);
        if (CurrentBlueprint == null || CurrentBlueprint.Name.Equals("n/a")) { Response.Redirect("~/Blueprints/Default.aspx"); }
        Title = CurrentBlueprint.Name;

        grd_Recipes.DataSource = CurrentBlueprint.Recipes;
        grd_Recipes.DataBind();

        RecipeWrapper.Visible = grd_Recipes.Rows.Count > 0;
    } // method Page_Load

    protected void grd_Recipes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                CraftingRecipe gameData = (CraftingRecipe)e.Row.DataItem;
                e.Row.CssClass += " " + gameData.ParentSkill.Name;
                break;
        } // switch
    } // method grd_Recipes_RowDataBound
} // class Blueprints_Blueprint