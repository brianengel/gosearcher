using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GoSearcher
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/sitecss").Include(
                "~/css/normalize.css",
                "~/css/bootstrap.css",
                "~/css/site.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
                "~/js/jquery.js",
                "~/js/angular.js",
                "~/js/bootstrap.js",
                "~/js/main.search.js"
            ));
        }
    }
}