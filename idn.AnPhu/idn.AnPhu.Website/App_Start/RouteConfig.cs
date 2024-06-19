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

            routes.MapRoute(
                name: "register",
                url: "{culture}/dang-ky-lai-thu",
                defaults: new { culture = "vi", controller = "ProductAction", action = "Register" },
                new[] { "idn.AnPhu.Website.Controllers" }
             );

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

            //HtmlPages
            routes.MapRoute(
            name: "service",
            url: "{culture}/dich-vu/{shortname}-{htmlpageid}/{HtmlPageCateId}",
            defaults:
                new
                {
                    culture = "vi",
                    controller = "HtmlPage",
                    action = "ServicesSub",
                    shortname = UrlParameter.Optional,
                    HtmlPageCateId = UrlParameter.Optional,
                    htmlpageid = UrlParameter.Optional
                }
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

            //Router ProductAction 
     
        }
    }
}
