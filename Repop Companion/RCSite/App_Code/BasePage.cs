using System;
using System.Web;

namespace Repop_Companion.App_Code
{


    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            this.PreRender += Page_PreRender;
        } // Constructor

        private void Page_PreRender(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Title) || this.Title.Equals("Untitled Page", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("Page title cannot be \"Untitled Page\" or an empty string.");
            }
        } // Page_PreRender
    } // class BasePage
}