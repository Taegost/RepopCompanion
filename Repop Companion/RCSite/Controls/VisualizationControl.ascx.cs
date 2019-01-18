using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_VisualizationControl : System.Web.UI.UserControl
{

    public void SetItem(ItemBase item)
    {
        CraftingRecipe currentRecipe = item.Recipes[0];
        recipeCell.CssClass = currentRecipe.Name;
        lnk_ItemName.Text = item.Name;
        lnk_ItemName.NavigateUrl = item.URL;
        lnk_ItemName.CssClass = "NoLinkStyle " + currentRecipe.Name;
        lnk_ItemRecipe.Text = currentRecipe.Name;
        lnk_ItemRecipe.NavigateUrl = currentRecipe.URL;
        lnk_ItemRecipe.CssClass = "NoLinkStyle " + currentRecipe.Name;
        rpt_Ingredients.DataSource = currentRecipe.Ingredients;
        rpt_Ingredients.DataBind();
    } // method SetItem
} // class Controls_VisualizationControl