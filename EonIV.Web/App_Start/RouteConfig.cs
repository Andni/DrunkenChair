﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Niklasson.DrunkenChair
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "EonIvCharacterCreator", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Hello",
                url: "{controller}/{action}/{name}/{id}"
            );
        }
    }
}
