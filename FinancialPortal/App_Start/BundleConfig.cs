using System.Web;
using System.Web.Optimization;

namespace FinancialPortal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            //------------------------------------------
            bundles.Add(new StyleBundle("~/bundles/Content/css").Include(
                        "~/Content/material-kit.css",
                        "~/Content/Site.css"));
            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                        "~/Scripts/Material/jquery.min.js",
                        "~/Scripts/Material/popper.min.js",
                        "~/Scripts/Material/bootstrap-material-design.min.js",
                        "~/Scripts/Material/moment.min.js",
                        "~/Scripts/Material/material-kit.js"));
        }
    }
}
