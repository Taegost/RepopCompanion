using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class TradeSkills_Default : BasePage
{
    protected Int32 tradeSkillID;

    protected string TradeSkillName
    {
        get
        {
            return SkillGateway.GetSkillById(tradeSkillID).displayName;
        } // get
    } // property TradeSkillName

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString.Get("TradeSkillID")))
        {
            tradeSkillID = Convert.ToInt32(Request.QueryString.Get("TradeSkillID"));

            rpt_Recipes.DataSource = RecipeGateway.RecipesInSkill(tradeSkillID);
            rpt_Recipes.DataBind();
            rpt_Items.DataSource = ItemGateway.GetAllItemsCreatedByTradeskillID(tradeSkillID);
            rpt_Items.DataBind();
            rpt_Fittings.DataSource = ItemGateway.GetAllFittingsCreatedByTradeskillID(tradeSkillID);
            rpt_Fittings.DataBind();
            rpt_Blueprints.DataSource = ItemGateway.GetAllBlueprintsCreatedByTradeskillID(tradeSkillID);
            rpt_Blueprints.DataBind();
        }
        TradeskillWrapper.Visible = rpt_Recipes.Items.Count > 0;
        ItemWrapper.Visible = rpt_Items.Items.Count > 0;
        FittingWrapper.Visible = rpt_Fittings.Items.Count > 0;
        BlueprintWrapper.Visible = rpt_Blueprints.Items.Count > 0;
        NoRecords.Visible = !TradeskillWrapper.Visible;
    } // Page_Load


    protected void rpt_Items_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:
                {
                    HyperLink recipeLink = (HyperLink)e.Item.FindControl("lnk_RecipeLink");
                    Item currentItem = (Item)e.Item.DataItem;
                    List<Recipe> itemRecipe = RecipeGateway.GetRecipesByResultItemIDAndType(currentItem.itemID, ItemTypeEnum.Item);
                    var singleRecipe = (from item in itemRecipe
                                where item.skillID == tradeSkillID
                                select item).FirstOrDefault();
                    recipeLink.Text = singleRecipe.displayName;
                    recipeLink.NavigateUrl = LinkGenerator.GenerateRecipeLink(singleRecipe.recipeID);
                    break;
                }
        } // switch
    } // method rpt_Items_ItemDataBound

    protected void rpt_Fittings_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:
                {
                    HyperLink recipeLink = (HyperLink)e.Item.FindControl("lnk_RecipeLink");
                    Fitting currentItem = (Fitting)e.Item.DataItem;
                    List<Recipe> itemRecipe = RecipeGateway.GetRecipesByResultItemIDAndType(currentItem.fittingID, ItemTypeEnum.Fitting);
                    var singleRecipe = (from item in itemRecipe
                                        where item.skillID == tradeSkillID
                                        select item).FirstOrDefault();
                    recipeLink.Text = singleRecipe.displayName;
                    recipeLink.NavigateUrl = LinkGenerator.GenerateRecipeLink(singleRecipe.recipeID);
                    break;
                }
        } // switch
    } // method rpt_Fittings_ItemDataBound

    protected void rpt_Blueprints_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        switch (e.Item.ItemType)
        {
            case ListItemType.Item:
            case ListItemType.AlternatingItem:
                {
                    HyperLink recipeLink = (HyperLink)e.Item.FindControl("lnk_RecipeLink");
                    Structure currentItem = (Structure)e.Item.DataItem;
                    List<Recipe> itemRecipe = RecipeGateway.GetRecipesByResultItemIDAndType(currentItem.structureID, ItemTypeEnum.Blueprint);
                    var singleRecipe = (from item in itemRecipe
                                        where item.skillID == tradeSkillID
                                        select item).FirstOrDefault();
                    recipeLink.Text = singleRecipe.displayName;
                    recipeLink.NavigateUrl = LinkGenerator.GenerateRecipeLink(singleRecipe.recipeID);
                    break;
                }
        } // switch
    } // method rpt_Blueprints_ItemDataBound
} // class TradeSkills_Default