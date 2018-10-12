using System;
using WinADLogin.Models.Common;


namespace WinADLogin
{
    public partial class WinAdLogin : System.Web.UI.MasterPage
    {
        public static int Count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hfUserFullName.Value = Session[Sessions.UserFullName].ToString();
                    hfAdUsername.Value = Session[Sessions.UserName].ToString();
                    UserName.Text = hfAdUsername.Value;
                    UserName.ToolTip = hfAdUsername.Value;
                }
            }
            catch (Exception Ex)
            {
                Response.Redirect(GoTo.Login, false);
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect(GoTo.Login, false);
        }
        protected void ClockTimer_Tick(object sender, EventArgs e)
        {
            Session[Sessions.UpdateSession] = "Updated :" + Count++ + "Min";
            string TEst = Session[Sessions.UpdateSession].ToString();
            btnSession_Click(null, EventArgs.Empty);
        }
        protected void btnSession_Click(object sender, EventArgs e)
        {
            Session[Sessions.UpdateSession] = "Updated :" + Count++ + "Min";
            string TEst = Session[Sessions.UpdateSession].ToString();
        }

    }
}