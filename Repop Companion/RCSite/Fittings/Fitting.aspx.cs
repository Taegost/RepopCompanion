using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Items_Fitting : BasePage
{
    public Fitting CurrentFitting { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("FittingID")))
        {
            Response.Redirect("Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("ComponentID")))

        int currentID = Convert.ToInt32(Request.QueryString.Get("FittingID"));
        CurrentFitting = ItemGateway.FittingGetByID(currentID);
        Title = CurrentFitting.displayName;

    } // method Page_Load
} // class Items_Fitting