﻿using System.Web.Optimization;

namespace GoSearcher
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/sitecss").Include(
                "~/css/normalize.css",
                "~/css/bootstrap.css",
                "~/css/yamm.css",
                "~/css/site.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
                "~/js/jquery.js",
                "~/js/angular.js",
                "~/js/angular-route.js",
                "~/js/bootstrap.js",
                "~/js/main.search.js"
            ));
        }
    }
}