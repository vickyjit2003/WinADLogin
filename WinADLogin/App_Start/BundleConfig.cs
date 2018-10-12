using System.Web.Optimization;

namespace WinADLogin
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.ScriptBundle("~/bundle/js")
                .Include("~/Scripts/jquery-1.9.1.min.js").Include("~/Scripts/moment.min.js").Include("~/Scripts/bootstrap.min.js").Include("~/Scripts/Main.js"));
            //.Include("~/Scripts/*.js"));
            System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.StyleBundle("~/bundle/css")
                 .Include("~/Content/Bootstrap3.3.7/bootstrap.css").Include("~/Content/Bootstrap3.3.7/bootstrap-datetimepicker.css").Include("~/Content/Mainstyles.css"));
            BundleTable.EnableOptimizations = false;
        }
    }
}