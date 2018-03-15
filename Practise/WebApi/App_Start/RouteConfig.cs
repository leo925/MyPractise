using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Readers",
                url: "Readers/{id}",
                defaults: new
                {
                    controller = "Reader",
                    action="Get",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
