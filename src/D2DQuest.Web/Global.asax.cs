using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using D2DQuest.Web.DI;

namespace D2DQuest.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            BundleTable.EnableOptimizations = true;

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(DIConfig.CreateContainer()));
        }
    }
}