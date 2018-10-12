using System;
using WinADLogin.Models.Common;

namespace WinADLogin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(GoTo.Login, false);//"~/Webpages/Login/LoginPage.aspx");
        }
    }
}