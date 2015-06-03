using System;
using System.Linq;
using System.Web.Optimization;

namespace D2DQuest.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new StyleBundle("~/css/public.css")
                .Include("~/Content/CSS/public.css", 
                         "~/Content/CSS/validation.css"));

            bundles.Add(new ScriptBundle("~/js/jqall.js")
                .Include("~/Content/JS/jquery*"));

            bundles.Add(new ScriptBundle("~/js/uh.js")
                .Include("~/Content/JS/registerWordAjaxHandler.js"));
        }
    }
}
