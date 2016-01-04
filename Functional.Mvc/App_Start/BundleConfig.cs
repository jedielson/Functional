using System.Web.Optimization;

namespace Functional.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/Functional").Include(
                "~/Scripts/modaldialog.js",
                "~/Scripts/Controller/ProjetoScripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // tree view
            bundles.Add(new StyleBundle("~/Content/tree").Include(
                "~/Content/bootstrap-tree.css"));

            bundles.Add(new ScriptBundle("~/Scripts/tree").Include(
                    "~/Scripts/bootstrap-tree.js"));

            bundles.Add(new ScriptBundle("~/Scripts/chosen").Include(
                    "~/Scripts/chosen.*"));

            bundles.Add(new StyleBundle("~/Content/chosen").Include(
                        "~/Content/chosen.css"));
        }
    }
}
