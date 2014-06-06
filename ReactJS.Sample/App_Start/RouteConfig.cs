using System.Web.Mvc;
using System.Web.Routing;

namespace ReactJS.Sample
{
    /// <summary>
    /// Static class responsible for configuring the ASP.NET route system.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Registers all routes in this ASP.NET application.
        /// </summary>
        /// <param name="routes">Routes collection to apply configurations for.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}