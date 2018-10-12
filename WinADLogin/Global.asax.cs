using System;
using System.Web.Optimization;

namespace WinADLogin
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            //Exceptions Errors Handels
            //StringBuilder Message = new StringBuilder();
            string Description = string.Empty;
            try
            {
                Exception Ex = Server.GetLastError();
                Server.Transfer("~/Webpages/GlobalPages/Error.aspx");
            }
            catch (Exception Ex)
            {
                Server.Transfer("~/Webpages/GlobalPages/Error.aspx");
            }
        }

    }
}