using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Items_Item : BasePage
{
    public ItemBase CurrentItem { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("ItemID")))
        {
            Response.Redirect("~/Items/Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("ItemID")))
        long incomingID = Convert.ToInt64(Request.QueryString.Get("ItemID"));
        if (incomingID == 0) { Response.Redirect("~/Items/Default.aspx"); }

        CurrentItem = new ItemBase(incomingID);
        if (CurrentItem.Name.Equals("n/a")) { Response.Redirect("~/Items/Default.aspx"); }
        Title = CurrentItem.Name;

        // Core item information that is common amongst almost all item types
        lbl_Value.Text = CurrentItem.Value.ToString();
        if (CurrentItem.StackInfo.IsStackable)
        {
            lbl_MaxStackSize.Text = CurrentItem.StackInfo.MaxStackSize.ToString();
            lbl_DefaultStackSize.Text = CurrentItem.StackInfo.DefaultStackSize.ToString();
            StackInfoWrapper.Visible = true;
        }
        if (CurrentItem.PowerSource.StoresPower)
        {
            lbl_PowerIndex.Text = CurrentItem.PowerSource.PowerIndex.ToString();
            lbl_PowerStorage.Text = CurrentItem.PowerSource.MaxStorage.ToString();
            PowerInfoWrapper.Visible = true;
        }
        
        switch (CurrentItem.Group)
        {
            case ItemGroupEnum.RecipeBook:
                RecipeBook book = new RecipeBook(CurrentItem.ID);
                rpt_RecipeBook.DataSource = book.RecipesTaught;
                rpt_RecipeBook.DataBind();
                break;
            case ItemGroupEnum.RawMaterial:
                RawMaterial material = new RawMaterial(CurrentItem.ID);
                rpt_Species.DataSource = material.SpeciesResults;
                rpt_Species.DataBind();
                SpeciesWrapper.Visible = rpt_Species.Items.Count > 0;
                SetUpCraftingInfo();
                break;
            case ItemGroupEnum.CraftingComponent:
                VisualizationControl.SetItem(CurrentItem);
                CraftingVisualizerSection.Visible = true;
                SetUpCraftingInfo();
                break;
        } // switch

        RecipeBookWrapper.Visible = rpt_RecipeBook.Items.Count > 0;
        ComponentWrapper.Visible = rpt_ComponentTypes.Items.Count > 0;
        FilterWrapper.Visible = lnk_Filter.Text != "";
        RecipeWrapper.Visible = grd_Recipe.Rows.Count > 0;
        IngredientWrapper.Visible = grd_Ingredient.Rows.Count > 0;
        AgentWrapper.Visible = grd_Agent.Rows.Count > 0;
    } // method Page_Load

    protected void grd_Recipe_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                HyperLink nameLink = (HyperLink)e.Row.FindControl("lnk_Name");
                CraftingRecipe currentRecipe = (CraftingRecipe)e.Row.DataItem;
                nameLink.Text = currentRecipe.Name;
                nameLink.NavigateUrl = currentRecipe.URL;
                HyperLink skillLink = (HyperLink)e.Row.FindControl("lnk_Skill");
                e.Row.CssClass += " " + currentRecipe.ParentSkill.Name;
                skillLink.Text = currentRecipe.ParentSkill.Name;
                skillLink.NavigateUrl = currentRecipe.ParentSkill.URL;
                break;
        } // switch
    } // method grd_Recipe_RowDataBound

    protected void grd_Ingredient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                HyperLink nameLink = (HyperLink)e.Row.FindControl("lnk_Name");
                CraftingRecipe currentRecipe = (CraftingRecipe)e.Row.DataItem;
                nameLink.Text = currentRecipe.Name;
                nameLink.NavigateUrl = currentRecipe.URL;
                HyperLink skillLink = (HyperLink)e.Row.FindControl("lnk_Skill");
                skillLink.Text = currentRecipe.ParentSkill.Name;
                skillLink.NavigateUrl = currentRecipe.ParentSkill.URL;
                e.Row.CssClass += " " + currentRecipe.ParentSkill.Name;
                // The logic below here needs to be re-written.  It's ugly.
                HyperLink resultLink = (HyperLink)e.Row.FindControl("lnk_Result");
                //List<Crafting_Filters> itemFilters = FilterGateway.GetCraftingFiltersByItemID(objectID);
                //foreach (Recipe recipe in result)
                //{
                //    foreach (Crafting_Filters filter in itemFilters)
                //    {
                //        Recipe_Results tempResult = RecipeGateway.GetRecipeResultByRecipeIdAndFilterId(recipe.recipeID, filter.filterID);
                //        if (tempResult != null) { returnObject.Add(recipe); break; }
                //    }
                //}

                //switch ((ItemTypeEnum)recipeResult.type)
                //{
                //    case ItemTypeEnum.Item:
                //        Item itemResult = ItemGateway.GetItemByID(recipeResult.resultID);
                //        resultLink.Text = itemResult.displayName;
                //        resultLink.NavigateUrl = LinkGenerator.GenerateItemLink(itemResult.itemID);
                //        break;
                //    case ItemTypeEnum.Fitting:
                //        Fitting fittingResult = ItemGateway.GetFittingByID(recipeResult.resultID);
                //        resultLink.Text = fittingResult.displayName;
                //        resultLink.NavigateUrl = LinkGenerator.GenerateFittingLink(fittingResult.fittingID);
                //        break;
                //    case ItemTypeEnum.Blueprint:
                //        Structure blueprintResult = ItemGateway.GetBlueprintByID(recipeResult.resultID);
                //        resultLink.Text = blueprintResult.displayName;
                //        resultLink.NavigateUrl = LinkGenerator.GenerateBlueprintLink(blueprintResult.structureID);
                //        break;
                //} // switch ((ItemTypeEnum)recipeResult.type)
                break;
        } // switch (e.Row.RowType)
    } // method grd_Ingredient_RowDataBound

    protected void grd_Agent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                HyperLink nameLink = (HyperLink)e.Row.FindControl("lnk_Name");
                CraftingRecipe currentRecipe = (CraftingRecipe)e.Row.DataItem;
                nameLink.Text = currentRecipe.Name;
                nameLink.NavigateUrl = currentRecipe.URL;
                HyperLink skillLink = (HyperLink)e.Row.FindControl("lnk_Skill");
                e.Row.CssClass +=" " + currentRecipe.ParentSkill.Name;
                skillLink.Text = currentRecipe.ParentSkill.Name;
                skillLink.NavigateUrl = currentRecipe.ParentSkill.URL;
                break;
        } // switch

        // Need to add logic to determine the results
    } // method grd_Agent_RowDataBound

    private void SetUpCraftingInfo()
    {
        rpt_ComponentTypes.DataSource = CurrentItem.Components;
        rpt_ComponentTypes.DataBind();
        if (CurrentItem.Filter != null)
        {
            lnk_Filter.Text = CurrentItem.Filter.Name;
            lnk_Filter.NavigateUrl = CurrentItem.Filter.URL;
        }
        grd_Recipe.DataSource = CurrentItem.Recipes;
        grd_Recipe.DataBind();
        grd_Ingredient.DataSource = CurrentItem.RecipesUsedAsIngredient;
        grd_Ingredient.DataBind();
        grd_Agent.DataSource = CurrentItem.RecipesUsedAsAgent;
        grd_Agent.DataBind();
    } // SetUpCraftingInfo
} // class Items_Item