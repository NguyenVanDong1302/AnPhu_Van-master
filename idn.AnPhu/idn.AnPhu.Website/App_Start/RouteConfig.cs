using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace idn.AnPhu.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Routes are registered using: Portal.Web.Extensions.RoutingHelper
            //Routes are configured at: Config\Routes.config

            //RoutingHelper.RegisterRoutes(RouteTable.Routes, RouteMappingConfiguration.Current);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "front_end_gioi_thieu",
            //    "{culture}/gioi-thieu",
            //    new { culture = "vi", controller = "Home", action = "About", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            //routes.MapRoute(
            //    "front_end_lien_he",
            //    "{culture}/lien-he",
            //    new { culture = "vi", controller = "Home", action = "Contact", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            //routes.MapRoute(
            //    "Default",    
            //    "{culture}/{controller}/{action}/{id}",
            //    new { culture = "vi", controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);

            routes.MapRoute(
                 "productdetail",
                 url: "{culture}/san-pham",
                 new { culture = "vi", controller = "Product", action = "Detail" },
                 new[] { "idn.AnPhu.Website.Controllers" }
             );
    
            routes.MapRoute(
             "NetAdvImage",
             "{scriptPath}/tinymce/plugins/netadvimage/{action}",
             new { controller = "NetAdvImage" }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "admin",
                url: "admin",
                defaults: new { controller = "Account", action = "Admin" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );
            //routes.MapRoute(
            //    name: "productdetail",
            //    url: "{culture}/san-pham/{productcode}",
            //    defaults: new { culture = "vi", controller = "Product", action = "Detail", productcode = UrlParameter.Optional }
            //);

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
     
        }
    }
}
