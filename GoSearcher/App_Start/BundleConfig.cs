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
            bundles.Add(new StyleBundle("~/bundles/site").Include(
                        "~/css/normalize.css",
                        "~/css/bootstrap.css",
                        "~/css/site.css"));
        }
    }
}