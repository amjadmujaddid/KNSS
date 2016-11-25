    using System.Web;
using System.Web.Optimization;

namespace AppMockup2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/dist/jquery/jquery-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/dist/bootstrap/bootstrap.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/dist/app/app.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                      "~/Scripts/dist/datepicker/bootstrap-datepicker.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/input-mask").Include(
                      "~/Scripts/dist/input-mask/jquery.inputmask.*"
                      ));

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/dist/bootstrap/bootstrap.min.css",
                      "~/Content/dist/adminLTE/AdminLTE.css",
                      "~/Content/dist/adminLTE/AdminLTE_fonts.css",
                      "~/Content/dist/bootstrap/font-awesome.min.css",
                      "~/Content/dist/datepicker/datepicker3.css"
                      ));
            
        }
    }
}
