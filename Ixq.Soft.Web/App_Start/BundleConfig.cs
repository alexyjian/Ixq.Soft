using System.Web;
using System.Web.Optimization;

namespace Ixq.Soft.Web
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/bundles/basis/css")
                .Include("~/Content/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Content/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/Content/style.css", new CssRewriteUrlTransform())
                .Include("~/Content/animate.css"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/basis/js").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/plugins/metisMenu/jquery.metisMenu.js",
                "~/Scripts/plugins/slimscroll/jquery.slimscroll.min.js",
                "~/Scripts/hplus.js",
                "~/Scripts/contabs.js",
                "~/Scripts/plugins/pace/pace.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Scripts/plugins/layer/js")
                .Include("~/Scripts/plugins/layer/layer.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/basis/js/iframe").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/content.js"));
        }
    }
}
