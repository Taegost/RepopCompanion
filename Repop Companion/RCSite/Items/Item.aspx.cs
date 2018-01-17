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
    public Item CurrentItem { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("ItemID")))
        {
            //Response.Redirect("Default.aspx");
            Response.Redirect("/Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("ItemID")))

        CurrentItem = ItemGateway.GetItemByID(Convert.ToInt32(Request.QueryString.Get("ItemID")));
        if (CurrentItem == null) { Response.Redirect("/Default.aspx"); }
        Title = CurrentItem.displayName;

        // Core item information that is common amongst almost all item types
        Item_Value value = ItemGateway.GetItemValueByItemID(CurrentItem.itemID);
        if (value != null) { lbl_Value.Text = value.value.ToString(); }
        Item_Stackable itemStackInfo = ItemGateway.GetItemStackInfoByItemID(CurrentItem.itemID);
        if (itemStackInfo != null)
        {
            lbl_MaxStackSize.Text = itemStackInfo.maxStackSize.ToString();
            lbl_DefaultStackSize.Text = itemStackInfo.defaultStackSize.ToString();
        }
        Item_Power_Source powerSource = ItemGateway.GetItemPowerSourceInfoByItemID(CurrentItem.itemID);
        if (powerSource != null) { lbl_PowerIndex.Text = powerSource.powerIndex.ToString(); }
        Item_Stores_Power powerStorage = ItemGateway.GetItemPowerStorageInfoByItemID(CurrentItem.itemID);
        if (powerStorage != null) { lbl_PowerStorage.Text = powerStorage.maxStorage.ToString(); }
        
        switch (ItemGateway.DetermineItemGroupByItemID(CurrentItem.itemID))
        {
            case ItemGroupEnum.RecipeBook:
                rpt_RecipeBook.DataSource = RecipeGateway.GetAllRecipesGrantedByRecipeBookID(CurrentItem.itemID);
                rpt_RecipeBook.DataBind();
                break;
            case ItemGroupEnum.RawMaterial:
                rpt_Species.DataSource = SpeciesGateway.GetAllSpeciesResultsForItem(CurrentItem.itemID);
                rpt_Species.DataBind();
                SpeciesWrapper.Visible = rpt_Species.Items.Count > 0;
                SetUpCraftingInfo();
                break;
            case ItemGroupEnum.CraftingComponent:
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
                Recipe currentRecipe = (Recipe)e.Row.DataItem;
                nameLink.Text = currentRecipe.displayName;
                nameLink.NavigateUrl = LinkGenerator.GenerateRecipeLink(currentRecipe.recipeID);
                HyperLink skillLink = (HyperLink)e.Row.FindControl("lnk_Skill");
                Skill currentSkill = SkillGateway.GetSkillById(currentRecipe.skillID);
                e.Row.CssClass += " " + currentSkill.displayName;
                skillLink.Text = currentSkill.displayName;
                skillLink.NavigateUrl = LinkGenerator.GenerateTradeskillLink(currentSkill.skillID);
                break;
        } // switch
    } // method grd_Recipe_RowDataBound

    protected void grd_Ingredient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                HyperLink nameLink = (HyperLink)e.Row.FindControl("lnk_Name");
                Recipe currentRecipe = (Recipe)e.Row.DataItem;
                nameLink.Text = currentRecipe.displayName;
                nameLink.NavigateUrl = LinkGenerator.GenerateRecipeLink(currentRecipe.recipeID);
                HyperLink skillLink = (HyperLink)e.Row.FindControl("lnk_Skill");
                Skill currentSkill = SkillGateway.GetSkillById(currentRecipe.skillID);
                skillLink.Text = currentSkill.displayName;
                skillLink.NavigateUrl = LinkGenerator.GenerateTradeskillLink(currentSkill.skillID);
                e.Row.CssClass += " " + currentSkill.displayName;
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
                Recipe currentRecipe = (Recipe)e.Row.DataItem;
                nameLink.Text = currentRecipe.displayName;
                nameLink.NavigateUrl = LinkGenerator.GenerateRecipeLink(currentRecipe.recipeID);
                HyperLink skillLink = (HyperLink)e.Row.FindControl("lnk_Skill");
                Skill currentSkill = SkillGateway.GetSkillById(currentRecipe.skillID);
                e.Row.CssClass +=" " + currentSkill.displayName;
                skillLink.Text = currentSkill.displayName;
                skillLink.NavigateUrl = LinkGenerator.GenerateTradeskillLink(currentSkill.skillID);
                break;
        } // switch

        // Need to add logic to determine the results
    } // method grd_Agent_RowDataBound

    private void SetUpCraftingInfo()
    {
        rpt_ComponentTypes.DataSource = ComponentGateway.GetComponentsByItemID(CurrentItem.itemID);
        rpt_ComponentTypes.DataBind();
        Crafting_Filters craftingFilter = FilterGateway.GetCraftingFilterByItemID(CurrentItem.itemID);
        if (craftingFilter != null)
        {
            lnk_Filter.Text = craftingFilter.displayName;
            lnk_Filter.NavigateUrl = LinkGenerator.GenerateFilterLink(craftingFilter.filterID);
        }
        grd_Recipe.DataSource = RecipeGateway.GetRecipesByResultItemIDAndType(CurrentItem.itemID, ItemTypeEnum.Item);
        grd_Recipe.DataBind();
        grd_Ingredient.DataSource = RecipeGateway.GetAllRecipesThatUseItemAsIngredient(CurrentItem.itemID);
        grd_Ingredient.DataBind();
        grd_Agent.DataSource = RecipeGateway.GetAllRecipesThatUseItemAsAgent(CurrentItem.itemID);
        grd_Agent.DataBind();
    } // SetUpCraftingInfo
} // class Items_Item