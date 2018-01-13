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
    public Crafting_Filters CurrentFilter { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("FilterID")))
        {
            Response.Redirect("Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("RecipeID")))

        int itemID = Convert.ToInt32(Request.QueryString.Get("FilterID"));
        CurrentFilter = FilterGateway.GetFilterByFilterID(itemID);
        if (CurrentFilter == null) { Response.Redirect("Default.aspx"); }

        // Main information
        Title = CurrentFilter.displayName;

    } // method Page_Load
} // class Filters_Filter