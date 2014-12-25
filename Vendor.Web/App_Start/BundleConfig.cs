using System.Web;
using System.Web.Optimization;

namespace Vendor.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.unobtrusive*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
				"~/Scripts/jquery-ui-{version}.js",
				"~/Scripts/jquery-ui-zh.js"
				));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));


            //---Vendor Site---

            //-----CSS-----
            bundles.Add(new StyleBundle("~/bundles/css/bootstrap2").Include(
                      "~/Content/vendor/css/bootstrap.min.css", 
                      "~/Content/vendor/css/bootstrap-responsive.min.css"));

			bundles.Add(new StyleBundle("~/bundles/css/vendor").Include(					  
					  "~/Content/vendor/css/uniform.css",
					  "~/Content/vendor/css/select2.css",			  
					  "~/Content/vendor/css/matrix-style.css",
					  "~/Content/vendor/css/matrix-media.css",
					  "~/Content/vendor/css/font.css",
					  "~/Content/vendor/font-awesome/css/font-awesome.css"
					  ));

			bundles.Add(new StyleBundle("~/bundles/css/jqueryui").Include(
					  "~/Content/themes/base/jquery.ui.core.css",
                      //"~/Content/themes/base/jquery.ui.resizable.css",
                      //"~/Content/themes/base/jquery.ui.selectable.css",
                      //"~/Content/themes/base/jquery.ui.accordion.css",
                      "~/Content/themes/base/jquery.ui.autocomplete.css",
                      //"~/Content/themes/base/jquery.ui.button.css",
                      //"~/Content/themes/base/jquery.ui.dialog.css",
                      //"~/Content/themes/base/jquery.ui.slider.css",
                      //"~/Content/themes/base/jquery.ui.tabs.css",
                      "~/Content/themes/base/jquery.ui.datepicker.css",
                      //"~/Content/themes/base/jquery.ui.progressbar.css",
                      "~/Content/themes/base/jquery.ui.theme.css"
					  ));

            //-----JS-----
            bundles.Add(new ScriptBundle("~/bundles/js/vendor-jq").Include(
                     "~/Content/vendor/js/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap2").Include(
                     "~/Content/vendor/js/bootstrap.min.js",
                     "~/Content/vendor/js/bootbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqdataTables").Include(
                      "~/Content/vendor/js/jquery.dataTables.min.js",
                      "~/Content/vendor/js/jquery.dataTables.AjaxSource.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/vendor-plugin").Include(
                      "~/Content/vendor/js/select2.min.js"));
            

        }
    }
}
