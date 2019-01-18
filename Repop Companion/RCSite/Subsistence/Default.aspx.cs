using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Subsistence_Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grd_Species.DataSource = SpeciesGateway.GetAllSpecies();
        grd_Species.DataBind();
    } // method Page_Load
} // class Subsistence_Default