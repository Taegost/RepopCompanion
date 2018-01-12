using System;
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
        CurrentComponent = ItemGateway.GetCraftingComponentByComponentID(currentID);

    } // method Page_Load
} // class Components_Component