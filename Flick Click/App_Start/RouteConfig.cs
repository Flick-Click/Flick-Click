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


            //SignUp
            routes.MapRoute(
                name: "SignUp",
                url: "SignUp/{id}",
                defaults: new { controller = "SignUp", action = "SignUp", id = UrlParameter.Optional }
            );
            //SignIn
            routes.MapRoute(
                name: "SignIn",
                url: "SignIn/{id}",
                defaults: new { controller = "SignIn", action = "SignIn", id = UrlParameter.Optional }
            );
            //News
            routes.MapRoute(
                name: "News",
                url: "News/{action}/{id}",
                defaults: new { controller = "News", action = "News", id = UrlParameter.Optional }
            );
            //Contact
            routes.MapRoute(
                name: "Contact",
                url: "Contact/{id}",
                defaults: new { controller = "Contact", action = "Contact", id = UrlParameter.Optional }
            );
            //Movie
            routes.MapRoute(
                name: "LatestTrailer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Movie", action = "LatestTrailer", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MostCommentedMovie",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Movie", action = "MostCommentedMovie", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MovieDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Movie", action = "MovieDetails", id = UrlParameter.Optional }
            );
            //search
            routes.MapRoute(
                name: "Search",
                url: "Search/{id}",
                defaults: new { controller = "Search", action = "Search", id = UrlParameter.Optional }
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
