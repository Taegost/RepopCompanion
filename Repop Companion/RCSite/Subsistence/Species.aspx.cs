using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Subsistence_Species : BasePage
{
    public Species CurrentSpecies { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(Request.QueryString.Get("SpeciesID")))
        {
            Response.Redirect("Default.aspx");
        } // if (!String.IsNullOrEmpty(Request.QueryString.Get("RecipeID")))

        int itemID = Convert.ToInt32(Request.QueryString.Get("SpeciesID"));
        CurrentSpecies = SpeciesGateway.GetSpeciesBySpeciesID(itemID);
        if (CurrentSpecies == null) { Response.Redirect("Default.aspx"); }
        Title = CurrentSpecies.displayName;

    } // method Page_Load
} // class Subsistence_Species