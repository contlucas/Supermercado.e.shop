using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Supermercado.E.Shop
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/bootstrap-theme.min.css",
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/site.css"));
        }
    }
}