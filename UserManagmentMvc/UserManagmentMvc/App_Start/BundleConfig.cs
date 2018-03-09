using System.Web.Optimization;

namespace UserManagmentMvc.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                       "~/scripts/jquery.datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalForm").Include(
                      "~/scripts/modalForm.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery.datetimepicker.css"));            
        }
    }
}