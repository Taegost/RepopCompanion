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
public CharacterTradeSkill CurrentSkill { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString.Get("TradeSkillID")))
        {
            long tradeSkillID = Convert.ToInt32(Request.QueryString.Get("TradeSkillID"));
            CurrentSkill = new CharacterTradeSkill(tradeSkillID);
            if (!CurrentSkill.Name.Equals("n/a"))
            {
                rpt_Recipes.DataSource = CurrentSkill.Recipes;
                rpt_Recipes.DataBind();
                rpt_Items.DataSource = CurrentSkill.Items;
                rpt_Items.DataBind();
                rpt_Fittings.DataSource = CurrentSkill.Fittings;
                rpt_Fittings.DataBind();
                rpt_Blueprints.DataSource = CurrentSkill.Blueprints;
                rpt_Blueprints.DataBind();
            } // if (!CurrentSkill.Name.Equals("n/a"))
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("TradeSkillID")))
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
                    ItemBase currentItem = (ItemBase)e.Item.DataItem;
                    var singleRecipe = (from item in currentItem.Recipes
                                where item.ParentSkill.ID == CurrentSkill.ID
                                select item).FirstOrDefault();
                    recipeLink.Text = singleRecipe.Name;
                    recipeLink.NavigateUrl = singleRecipe.URL;
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
                    FittingBase currentItem = (FittingBase)e.Item.DataItem;
                    var singleRecipe = (from item in currentItem.Recipes
                                        where item.ParentSkill.ID == CurrentSkill.ID
                                        select item).FirstOrDefault();
                    recipeLink.Text = singleRecipe.Name;
                    recipeLink.NavigateUrl = singleRecipe.URL;
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
                    BlueprintBase currentItem = (BlueprintBase)e.Item.DataItem;
                    var singleRecipe = (from item in currentItem.Recipes
                                        where item.ParentSkill.ID == CurrentSkill.ID
                                        select item).FirstOrDefault();
                    recipeLink.Text = singleRecipe.Name;
                    recipeLink.NavigateUrl = singleRecipe.URL;
                    break;
                }
        } // switch
    } // method rpt_Blueprints_ItemDataBound
} // class TradeSkills_Default