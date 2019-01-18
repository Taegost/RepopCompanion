using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Components_Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rpt_AllComponents.DataSource = ComponentGateway.GetAllComponents();
        rpt_AllComponents.DataBind();
    } // method Page_Load
} // class Components_Default