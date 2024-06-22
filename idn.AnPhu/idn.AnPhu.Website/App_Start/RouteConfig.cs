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
                 new { culture = "vi", controller = "ProductClientClient", action = "Detail" },
                 new[] { "idn.AnPhu.Website.Controllers" }
             );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "listprd",
              url: "{culture}/danh-sach-san-pham/{shortname}",
              defaults: new { culture = "vi", controller = "ProductClient", action = "ListProductByCate", shortname = UrlParameter.Optional }
             );

            routes.MapRoute(
               name: "productcate",
               url: "{culture}/danh-muc-san-pham/{shortname}",
               defaults: new { culture = "vi", controller = "ProductClient", action = "ListProductByCateSale", shortname = UrlParameter.Optional }
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



            // News 

            routes.MapRoute(
               name: "tin-tuc",
               url: "{culture}/tin-tuc",
               defaults: new { culture = "vi", controller = "News", action = "ShowListCateNews" }
           );
            routes.MapRoute(
                name: "news-cate",
                url: "{culture}/tin-tuc/{shortname}/{page}",
                defaults: new { culture = "vi", controller = "News", action = "ShowCateNews", shortname = UrlParameter.Optional, page = UrlParameter.Optional }
            );

           // routes.MapRoute(
           //    name: "news-cate2",
           //    url: "{culture}/tin-tuc/{shortname}/{page}",
           //    defaults: new { culture = "vi", controller = "News", action = "ShowCrudeNews", shortname = UrlParameter.Optional, page = UrlParameter.Optional }
           //);


            routes.MapRoute(
               name: "news-detail",
               url: "{culture}/tin-tuc/{category}/{shortname}/{newsid}",
               defaults: new { culture = "vi", controller = "News", action = "Detail", category = UrlParameter.Optional, shortname = UrlParameter.Optional, newsid = UrlParameter.Optional }
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
