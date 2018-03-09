using System.Web.Mvc;
using System.Web.Routing;

namespace UserManagmentMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { controller = "Home", action = "Index", page = 1 }
            );

            routes.MapRoute(
                name: "pager",
                url: "page{page}",
                defaults: new { controller = "Home", action = "Index", page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
