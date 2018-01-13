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
            Response.Redirect("Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("ItemID")))

        CurrentItem = ItemGateway.GetItemByID(Convert.ToInt32(Request.QueryString.Get("ItemID")));
        Title = CurrentItem.displayName;
        Item_Value value = ItemGateway.GetItemValueByItemID(CurrentItem.itemID);
        if (value == null)
        {
            lbl_Value.Text = "n/a";
        }
        else
        {
            lbl_Value.Text = value.value.ToString();
        }
        Item_Stackable itemStackInfo = ItemGateway.GetItemStackInfoByItemID(CurrentItem.itemID);
        if (itemStackInfo == null)
        {
            lbl_MaxStackSize.Text = "n/a";
            lbl_DefaultStackSize.Text = "n/a";
        }
        else
        {
            lbl_MaxStackSize.Text = itemStackInfo.maxStackSize.ToString();
            lbl_DefaultStackSize.Text = itemStackInfo.defaultStackSize.ToString();
        }
        
        switch (ItemGateway.DetermineItemGroupByItemID(CurrentItem.itemID))
        {
            case ItemGroupEnum.RecipeBook:
                rpt_RecipeBook.DataSource = RecipeGateway.GetAllRecipesGrantedByRecipeBookID(CurrentItem.itemID);
                rpt_RecipeBook.DataBind();
                break;
            case ItemGroupEnum.CraftingComponent:
                rpt_ComponentTypes.DataSource = ComponentGateway.GetComponentsByItemID(CurrentItem.itemID);
                rpt_ComponentTypes.DataBind();
                rpt_FilterTypes.DataSource = FilterGateway.GetFiltersByItemID(CurrentItem.itemID);
                rpt_FilterTypes.DataBind();
                break;
        } // switch

        RecipeBookWrapper.Visible = rpt_RecipeBook.Items.Count > 0;
        ComponentWrapper.Visible = rpt_ComponentTypes.Items.Count > 0;
    } // method Page_Load
} // class Items_Item