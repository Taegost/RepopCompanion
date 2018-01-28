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
    public FittingBase CurrentFitting { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("FittingID")))
        {
            Response.Redirect("~/Fittings/Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("ComponentID")))

        int currentID = Convert.ToInt32(Request.QueryString.Get("FittingID"));
        CurrentFitting = new FittingBase(currentID) ;
        if (CurrentFitting == null || CurrentFitting.Name.Equals("n/a")) { Response.Redirect("~/Fittings/Default.aspx"); }
        Title = CurrentFitting.Name;

    } // method Page_Load
} // class Items_Fitting