using System;
using WinADLogin.Models.Common;

namespace WinADLogin.Webpages
{
    public partial class Unauthoriseduser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Ok_Click(object sender, EventArgs e)
        {
            Response.Redirect(GoTo.Login, false);
        }
    }
}