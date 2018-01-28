using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Filters_Filter : BasePage
{
    public CraftingFilter CurrentFilter { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("FilterID"))) { Response.Redirect("~/Filters/Default.aspx"); }

        int itemID = Convert.ToInt32(Request.QueryString.Get("FilterID"));
        CurrentFilter = FilterGateway.CraftingFilterGetByFilterID(itemID);
        if (CurrentFilter == null || CurrentFilter.Name.Equals("n/a")) { Response.Redirect("~/Filters/Default.aspx"); }

        // Main information
        Title = CurrentFilter.Name;

        rpt_Items.DataSource = CurrentFilter.Items;
        rpt_Items.DataBind();
        grd_Recipes.DataSource = CurrentFilter.RecipesUsedAsIngredient;
        grd_Recipes.DataBind();

        ItemWrapper.Visible = rpt_Items.Items.Count > 0;
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
    }
} // class Filters_Filter