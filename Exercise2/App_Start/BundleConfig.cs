using System.Web;
using System.Web.Optimization;

namespace Exercise2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/library/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/library/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/library/bootstrap.js",
                      "~/Scripts/library/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/recipeApp").Include(
                                         "~/Scripts/javaS/models.js",
                                         "~/Scripts/javaS/recipesService.js",
                                         "~/Scripts/javaS/renderRecipeEl.js",
                                         "~/Scripts/javaS/renderRecipeDetailsEl.js",
                                         "~/Scripts/loginJs/authService.js",
                                         "~/Scripts/loginJs/renderLoginEl.js",
                                         "~/Scripts/shopItemJs/shopItemService.js",
                                         "~/Scripts/shopItemJs/renderShopItemEl.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
