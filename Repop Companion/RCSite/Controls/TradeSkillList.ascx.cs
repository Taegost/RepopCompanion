using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repop_Companion.App_Code;
using Repop_Companion.DataModels;

public partial class Controls_TradeSkillList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rpt_TradeSkills.DataSource = SkillGateway.TradeSkillsGetAll();
        rpt_TradeSkills.DataBind();
    } // method Page_Load
} // class Controls_TradeSkillList