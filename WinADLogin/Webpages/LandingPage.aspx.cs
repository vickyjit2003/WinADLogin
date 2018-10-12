using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WinADLogin.Models.Common;

namespace WinADLogin.Webpages
{
    public partial class LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Displayusername = string.Empty;
            if (!IsPostBack)
            {
                try
                {
                    username.InnerText = Session[Sessions.UserFullName].ToString();
                    spnmessage.InnerText = ConfigurationManager.AppSettings["Welcomemsg"];
                }
                catch (Exception Ex)
                {
                    Response.Redirect(GoTo.Login, false);
                }
            }
        }
    }
}