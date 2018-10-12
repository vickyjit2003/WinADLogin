using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WinADLogin.Models.BAL;
using WinADLogin.Models.Common;

namespace WinADLogin.Webpages.Login
{
    public partial class LoginPage : System.Web.UI.Page
    {
        BAL ObjBAL = BAL.Getstates();
        string DomainName = ConfigurationManager.AppSettings[Webconfig.DomainName];
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session[Sessions.UserActive] = false;
                }
            }
            catch (Exception Ex)
            {
                Response.Redirect(GoTo.Login, false);
            }
        }
        protected void Loginbtn_Click(object sender, EventArgs e)
        {
            string Username = txtUserName.Text;
            string Password = txtPassword.Text;
            string Description = string.Empty;
            string UserFullName = string.Empty;
            string UserNamevalue = string.Empty;
            try
            {
                Loginbtn.Enabled = false;
                bool AutheriseUser = ObjBAL.LogonValid(Username, Password);
                if (AutheriseUser)
                {
                    UserFullName = ObjBAL.GetUserFirstName(DomainName, Username);
                    Session[Sessions.UserFullName] = UserFullName;
                    UserNamevalue = DomainName + "//" + Username;
                    Session[Sessions.ADUserName] = Username;
                    Session[Sessions.UserName] = UserNamevalue;
                    Response.Redirect(GoTo.Landing, false);
                }
                else
                {
                    Description = "Login failed for user <b>" + UserFullName;
                    errormsg.InnerText = MessagesStatic.InvalidLogin;

                }
                Loginbtn.Enabled = true;
            }
            catch (Exception Ex)
            {
                Loginbtn.Enabled = true;
                Description = "Login failed for user Please Try after some time";
                errormsg.InnerText = Description;
            }
        }
    }
}