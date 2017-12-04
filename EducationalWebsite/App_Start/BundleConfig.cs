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
                                         "~/Content/css/bootstrap-theme.css",
                                          "~/Content/css/font-awesome.css",
                                           "~/Content/css/flexslider.css",
                                            "~/Content/css/owl.carousel.css",
                                             "~/Content/css/style.css"

                ));
            bundles.Add(new StyleBundle("~/bundles/LibAdminLayoutcss").Include(
                                         "~/AdminContent/css/main.css",
                                         "~/AdminContent/css/themes/all-themes.css"
                                                                                  ));
            bundles.Add(new ScriptBundle("~/bundles/LibAdminLayoutjs").Include(
                            "~/AdminContent/bundles/libscripts.bundle.js",
                            "~/AdminContent/bundles/mainscripts.bundle.js",
                            "~/AdminContent/bundles/vendorscripts.bundle.js"
                                                                             ));
            bundles.Add(new StyleBundle("~/bundles/LibAdminMaincss").Include(
                                         "~/AdminContent/plugins/morrisjs/morris.css"
                                         ));
            bundles.Add(new ScriptBundle("~/bundles/LibAdminjs").Include(
                                        "~/AdminContent/plugins/jquery-sparkline/jquery.sparkline.min.js",
                                        "~/AdminContent/plugins/chartjs/Chart.bundle.min.js",
                                        "~/AdminContent/js/pages/charts/chartjs.min.js",
                                        "~/AdminContent/js/pages/charts/sparkline.min.js",
                                              "~/AdminContent/js/pages/index.js"

                                                                                         ));
            bundles.Add(new StyleBundle("~/bundles/LibStudentcss").Include(
                                        "~/AdminContent/plugins/dropzone/dropzone.css",
                                        "~/AdminContent/plugins/waitme/waitMe.css",
                                       "~/AdminContent/plugins/bootstrap-material-datetimepicker/css/bootstrap-material-datetimepicker.css",
                                        "~/AdminContent/plugins/bootstrap-select/css/bootstrap-select.css"
                                        ));
            bundles.Add(new ScriptBundle("~/bundles/LibStudentjs").Include(
                "~/AdminContent/plugins/autosize/autosize.js",
                "~/AdminContent/plugins/momentjs/moment.js",
                "~/AdminContent/plugins/dropzone/dropzone.js",
                "~/AdminContent/js/pages/forms/basic-form-elements.js",
                "~/AdminContent/plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/LibDepartmentcss").Include(
                                      "~/AdminContent/plugins/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css"
                                                                            ));
            bundles.Add(new ScriptBundle("~/bundles/LibDepartmentjs").Include(
               "~/AdminContent/plugins/jquery-datatable/jquery.dataTables.js",
               "~/AdminContent/plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js",
               "~/AdminContent/plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js",
               "~/AdminContent/plugins/jquery-datatable/extensions/export/buttons.flash.min.js",
               "~/AdminContent/plugins/jquery-datatable/extensions/export/jszip.min.js",
               "~/AdminContent/plugins/jquery-datatable/extensions/export/pdfmake.min.js",
               "~/AdminContent/plugins/jquery-datatable/extensions/export/vfs_fonts.js",
               "~/AdminContent/plugins/jquery-datatable/extensions/export/buttons.html5.min.js",
               "~/AdminContent/plugins/jquery-datatable/extensions/export/buttons.print.min.js",
               "~/AdminContent/js/pages/tables/jquery-datatable.js"
               ));
            bundles.Add(new StyleBundle("~/bundles/LibMailcss").Include(
 "~/AdminContent/css/inbox.css"
                                                                          ));
            bundles.Add(new ScriptBundle("~/bundles/LibMailjs").Include(
 "~/AdminContent/js/pages/inbox/inbox.js"
                                                                          ));
            bundles.Add(new StyleBundle("~/bundles/LibEventcss").Include(
"~/AdminContent/plugins/fullcalendar/fullcalendar.min.css"
                                                                         ));
            bundles.Add(new ScriptBundle("~/bundles/LibEventjs").Include(
 "~/AdminContent/bundles/fullcalendarscripts.bundle.js",
    "~/AdminContent/js/pages/calendar/calendar.js"
    ));
        }

    }
}
