using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Items_Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rpt_AllItems.DataSource = ItemGateway.GetAllItems();
        rpt_AllItems.DataBind();
    } // method Page_Load
} // class Items_Default