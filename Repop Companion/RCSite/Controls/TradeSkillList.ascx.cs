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
        List<Skill> skillList = SkillGateway.AllTradeSkills();
        rpt_TradeSkills.DataSource = skillList;
        rpt_TradeSkills.DataBind();
    } // method Page_Load
} // class Controls_TradeSkillList