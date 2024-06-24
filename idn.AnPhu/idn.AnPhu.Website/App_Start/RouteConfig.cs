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
                name: "productdetail",
                url: "{culture}/san-pham/{productcode}",
                defaults: new { culture = "vi", controller = "ProductClient", action = "Detail", productcode = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers"}
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "listprd",
              url: "{culture}/danh-sach-san-pham/{shortname}",
              defaults: new { culture = "vi", controller = "Product", action = "ListProductByCate", shortname = UrlParameter.Optional },
               new[] { "idn.AnPhu.Website.Controllers" }
              );

            routes.MapRoute(
               name: "productcate",
               url: "{culture}/danh-muc-san-pham/{shortname}",
               defaults: new { culture = "vi", controller = "Product", action = "ListProductByCateSale", shortname = UrlParameter.Optional },
                     new[] { "idn.AnPhu.Website.Controllers" }

            );

            routes.MapRoute(
                name: "homecontact",
                url: "{culture}/lien-he",
                defaults: new { culture = "vi", controller = "Home", action = "Contact" },
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

            // Video
            //routes.MapRoute(
            //    name: "videocate",
            //    url: "{culture}/video",
            //    defaults: new { culture = "vi", controller = "Videos", action = "ListVideo" },
            //    new[] { "idn.AnPhu.Website.Controllers" }
            //);
            routes.MapRoute(
                name: "videocatedetail",
                url: "{culture}/danh-sach-video/{shortname}",
                defaults: new { culture = "vi", controller = "Videos", action = "ListVideoByCate", shortname = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );


            // News 

            routes.MapRoute(
               name: "tin-tuc",
               url: "{culture}/tin-tuc",
               defaults: new { culture = "vi", controller = "News", action = "ShowListCateNews" },
                     new[] { "idn.AnPhu.Website.Controllers" }
           );
            routes.MapRoute(
                name: "news-cate",
                url: "{culture}/tin-tuc/{shortname}/{page}",
                defaults: new { culture = "vi", controller = "News", action = "ShowCateNews", shortname = UrlParameter.Optional, page = UrlParameter.Optional },
                      new[] { "idn.AnPhu.Website.Controllers" }
            );

           // routes.MapRoute(
           //    name: "news-cate2",
           //    url: "{culture}/tin-tuc/{shortname}/{page}",
           //    defaults: new { culture = "vi", controller = "News", action = "ShowCrudeNews", shortname = UrlParameter.Optional, page = UrlParameter.Optional }
           //);


            routes.MapRoute(
               name: "news-detail",
               url: "{culture}/tin-tuc/{category}/{shortname}/{newsid}",
               defaults: new { culture = "vi", controller = "News", action = "Detail", category = UrlParameter.Optional, shortname = UrlParameter.Optional, newsid = UrlParameter.Optional },
                     new[] { "idn.AnPhu.Website.Controllers" }
           );


            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "idn.AnPhu.Website.Controllers" }
            );

            // ProductAction
            routes.MapRoute(
                name: "productbuycar",
                url: "{culture}/bang-gia",
                defaults: new { culture = "vi", controller = "ProductAction", action = "BuyCar" }
            );
            routes.MapRoute(
                name: "productestimate",
                url: "{culture}/du-toan-chi-phi",
                defaults: new { culture = "vi", controller = "ProductAction", action = "EstimatePrice" }
            );
            routes.MapRoute(
               name: "supportbuycar",
               url: "{culture}/ho-tro-mua-xe",
               defaults: new { culture = "vi", controller = "ProductAction", action = "SupportBuyCar" }
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
