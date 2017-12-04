using System.Web;
using System.Web.Optimization;

namespace EducationalWebsite
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/LibMainjs").Include(
                                        "~/Content/js/jquery-2.1.4.min.js",
                                         "~/Content/js/jquery.flexslider.js",
                                         "~/Content/js/owl.carousel.js",
                                         "~/Content/js/simplyCountdown.js",
                                         "~/Content/js/main.js",
                                         "~/Content/js/move-top.js",
                                         "~/Content/js/easing.js",
                                         "~/Content/js/bootstrap.js"

                                                        ));
            bundles.Add(new StyleBundle("~/bundles/LibMaincss").Include(
                                         "~/Content/css/bootstrap.css",
                                          "~/Content/css/font-awesome.css",
                                           "~/Content/css/flexslider.css",
                                            "~/Content/css/owl.carousel.css",
                                             "~/Content/css/style.css"

                ));

        }

    }
}
