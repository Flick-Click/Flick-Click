using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Flick_Click
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "News",
                url: "News",
                new { controller = "News", action = "News", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ShowAll",
                url: "ShowAll",
                new { controller = "ShowAll", action = "ShowAll", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SignUp",
                url: "SignUp",
                new { controller = "SignUp", action = "SignUp", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                new { controller = "Contact", action = "Contact", id = UrlParameter.Optional }
            );

            //defaults
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
