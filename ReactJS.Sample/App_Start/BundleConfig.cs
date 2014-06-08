using System.Web.Optimization;
using System.Web.Optimization.React;

namespace ReactJS.Sample
{
    public static class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            //BundleTable.EnableOptimizations = true; //force optimization while debugging

            // showdown
            var showdown = new ScriptBundle(
                "~/bundles/showdown",
                "//cdnjs.cloudflare.com/ajax/libs/showdown/0.3.1/showdown.min.js").Include(
                    "~/Scripts/showdown.min.js");
            showdown.CdnFallbackExpression = "window.Showdown";
            bundles.Add(showdown);

            // react
            var react = new ScriptBundle(
                "~/bundles/react",
                "//cdnjs.cloudflare.com/ajax/libs/react/0.10.0/react.min.js").Include(
                    "~/Scripts/react.min.js");
            react.CdnFallbackExpression = "window.React";
            bundles.Add(react);

            // tutorial-components
            bundles.Add(new JsxBundle("~/bundles/tutorial").Include(
                "~/Scripts/Tutorial.jsx"
            ));
        }
    }
}
