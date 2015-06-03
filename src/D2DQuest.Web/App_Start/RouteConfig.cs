using System.Web.Mvc;
using System.Web.Routing;

namespace D2DQuest.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Registration",
                url: "registration",
                defaults: new { controller = "Registration", action = "Registration" }
            );

            routes.MapRoute(
                name: "Raffle",
                url: "raffle",
                defaults: new { controller = "Raffle", action = "Raffle" }
            );

            routes.MapRoute(
                name: "Information",
                url: "information",
                defaults: new { controller = "Information", action = "Information" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Registration", action = "Registration" }
            );
        }
    }
}