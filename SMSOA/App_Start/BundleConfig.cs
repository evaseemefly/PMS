using System.Web;
using System.Web.Optimization;

namespace SMSOA
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //绑定easyui的css文件
            bundles.Add(new StyleBundle("~/Scripts/EasyUICss").Include(
                "~/Scripts/EasyUI/themes/color.css",
                "~/Scripts/EasyUI/themes/black/easyui.css",
                "~/Scripts/EasyUI/themes/icon.css"));


            //绑定jquery的js文件
            bundles.Add(new ScriptBundle("~/Scripts/myJquery").Include(
              "~/Scripts/jquery-1.10.2.js",
              "~/Scripts/jquery.validate.js",
              "~/Scripts/jquery.validate.unobtrusive.js",
              "~/Scripts/jquery.unobtrusive-ajax.js"));

            //绑定easyui的js文件
            bundles.Add(new ScriptBundle("~/Scripts/easyUIJS").Include(
                
                "~/Scripts/EasyUI/jquery.easyui.min.js",
                "~/Scripts/EasyUI/locale/easyui-lang-zh_CN.js"));   //本地化文件（汉化文件）

           

            BundleTable.EnableOptimizations = true;//对js代码进行压缩
        }
    }
}
