<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.IO" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/Scripts/jquery-3.3.1.min.js"
        }
        );
        BundleTable.Bundles.Add(new StyleBundle("~/StyleSheets").IncludeDirectory("~/Styles", "*.css"));
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        if (HttpContext.Current.Server.GetLastError().GetBaseException() != null)
        {
            // We are going to write the errors to a log file on disk, since this project is publicly accessible
            // and I don't want to include any security credentials in it.
            // I will have a separate service that runs on my server to periodically pull these logs and notify
            // me if there are any errors
            Exception ex = HttpContext.Current.Server.GetLastError().GetBaseException();
            string logName = "Exception_" + DateTime.Now.ToString("yyyyMMdd_hhmmsstt") + System.Guid.NewGuid() + ".log";
            string logBody = "Error in page " + Request.Url.ToString() + "\n" +
                "Query String: " + Request.QueryString.ToString() + "\n" + 
                "Message: " + ex.Message + "\n" +
                "Stack Trace: " + ex.StackTrace;
            using (StreamWriter errorWriter = new StreamWriter(Server.MapPath("~/Logs/" + logName), true))
            {
                errorWriter.WriteLine(logBody);
            } // using
        } // (HttpContext.Current.Server.GetLastError().GetBaseException() != null)
    } // method Application_Error

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
