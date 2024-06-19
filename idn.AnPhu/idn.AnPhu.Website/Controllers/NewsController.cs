using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Website.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Controllers
{
    public class NewsController : BaseController
    {
        private int _userPageSize = 6;
        // GET: News
        public ActionResult ShowNews()
        {
            var newcate = ServiceFactory.NewsCategoryManager.ListAllNewsCategory(Culture);

            if (newcate.Count > 0)
            {
                return RedirectToAction("ShowCateNews", new { shortname = newcate[0].NewsCategoryShortName });
            }
            else
            {
                return View();
            }

        }
        public ActionResult ShowListCateNews(int page = 0)
        {
            var total = 0;
            string keyword = ConfigurationManager.AppSettings["keyword"];
            string decsription = ConfigurationManager.AppSettings["description"];
            var list = ServiceFactory.NewsManager.GetAllActive(page * _userPageSize, _userPageSize, ref total, Culture);
            var listcate = ServiceFactory.NewsCategoryManager.ListAllNewsCategory(Culture);
            var listhotnews = ServiceFactory.NewsManager.GetHotNewsTop(6, Culture);
            ViewData["ListHotNews"] = listhotnews;
            ViewBag.Keywords = keyword;
            ViewBag.Desciption = decsription;
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.ListCates = listcate;
            ViewBag.List = list;
            return View();
        }

        public ActionResult ShowCateNews(string shortname, int page = 0)
        {
            var list = ServiceFactory.NewsCategoryManager.ListAllNewsCategory(Culture);
            var total = 0;
            var category = ServiceFactory.NewsCategoryManager.GetByShortName(new NewsCategories { NewsCategoryShortName = shortname }, Culture);
            if (category != null)
            {
                category.ListNews = ServiceFactory.NewsManager.GetListNewsByCateNewsId(category.NewsCategoryId, page * _userPageSize, _userPageSize, ref total, Culture);
                ViewBag.Keywords = category.NewsCategoryKeyword;
                if (page != 0)
                {
                    ViewBag.Desciption = category.NewsCategoryDescription + " - " + page;
                }
                else
                {
                    ViewBag.Desciption = category.NewsCategoryDescription;
                }
            }
            else
            {
                return ResultHelper.NotFoundResult(this);
            }
            //var data = ServiceFactory.NewsManager.get
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.ListCates = list;
            ViewBag.shortname = category.NewsCategoryShortName;
            return View(category);
        }









        public ActionResult Detail(string category, string shortname, int newsid)
        {
            var list = ServiceFactory.NewsCategoryManager.ListAllNewsCategory(Culture);
            var data = ServiceFactory.NewsManager.GetDetail(new News { NewsId = newsid });
            var othernews = ServiceFactory.NewsManager.GetOtherNews(data.NewsId, Culture);
            ViewBag.ListOthers = othernews;
            ViewBag.ListCates = list;
            ViewBag.categoryshortname = category;
            ViewBag.Keywords = data.NewsKeyword;
            ViewBag.Desciption = data.NewsDescription;
            ViewBag.MetaOGImage = data.NewsImage;
            return View(data);
        }
    }
}