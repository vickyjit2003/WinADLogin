
namespace WinADLogin.Models.Common
{
    public class FolderPaths
    {
        public static string Login = "~/Webpages/Login";
        public static string GlobalPage = "~/Webpages/GlobalPages";
    }

    public class GoTo
    {
        //Login
        public static string Login = FolderPaths.Login + "/LoginPage.aspx";
        //Landing
        public static string Landing = "~/Webpages/LandingPage.aspx";
        //UnAutherizeruser
        public static string UnAuthorisedUser = "~/Webpages/Unauthoriseduser.aspx";
        //DefaultPage
        public static string Default = "~/Default.aspx";
        //Globalpage
        public static string Errorpage = FolderPaths.GlobalPage + "/Error.aspx";
    }

    public class Sessions
    {
        public static string LoginTime = "LoginTime";
        public static string UserActive = "UserActive";
        public static string ADUserName = "ADUserName";
        public static string UserName = "UserName";
        public static string UserFullName = "UserFullName";
        public static string RedirectTo = "RedirectTo";
        public static string UpdateSession = "UpdateSession";

    }

    public class Webconfig
    {
        public static string DomainName = "DomainName";

    }
    public class MessagesStatic
    {
        public static string InvalidLogin = "Please enter valid Username/Password";
        public static string DefaultFilelable = "Please Select File";
    }


}