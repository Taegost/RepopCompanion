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

    } // method Page_Load
} // class Items_Item