using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var Culture = "vi-VN";
            var data = ServiceFactory.SlideBannerManager.SelectTop(4, Culture);
            ViewData["ListSlide"] = data;
            var listhotproudct = ServiceFactory.ProductManager.GetListHotProduct(Culture);
            ViewData["ListHotProduct"] = listhotproudct;
            var listhotnews = ServiceFactory.NewsManager.GetHotNewsTop(3, Culture);
            ViewData["ListHotNews"] = listhotnews;
            //var listsalenews = ServiceFactory.NewsManager.GetByCateShortName(100, Culture, "tin-khuyen-mai");
            //ViewData["ListSaleNews"] = listsalenews;
            //var services = ServiceFactory.HtmlPageCategoryManager.GetAllActiveByShortName("dich-vu", Culture);
            //ViewData["Services"] = services;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}