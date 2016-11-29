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
                        "~/Scripts/assets/plugins/jQuery/jquery-2.2.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/assets/bootstrap/js/bootstrap.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/AdminLTE/app.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                      "~/Scripts/assets/plugins/datepicker/bootstrap-datepicker.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/input-mask").Include(
                      "~/Scripts/assets/plugins/input-mask/jquery.inputmask.*"
                      ));

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/assets/bootstrap/css/bootstrap.min.css",
                      "~/Content/AdminLTE/AdminLTE.css",
                      //"~/Scripts/assets/dist/css/AdminLTE_fonts.css",
                      "~/Content/AdminLTE/skins/_all-skins.min.css",
                      //"~/Scripts/assets/font-awesome/css/font-awesome.min.css",
                      "~/Scripts/assets/plugins/datepicker/datepicker3.css"
                      ));
            
        }
    }
}
