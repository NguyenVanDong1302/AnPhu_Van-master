using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Website.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Controllers
{
    public class VideosController : BaseController
    {
        private int _userPageSize = 12;
        // GET: Videos
        public ActionResult ListVideo()
        {
            var categories = ServiceFactory.VideoCategoryManager.ListAllVideoCategory(Culture);
            if (categories.Count > 0)
            {
                return RedirectToAction("ListVideoByCate", new { shortname = categories[0].VideoCategoryShortName });
            }
            else
            {
                return View();
            }
        }
        public ActionResult ListVideoByCate(string shortname, int page = 0)
        {
            var categories = ServiceFactory.VideoCategoryManager.ListAllVideoCategory(Culture);
            var total = 0;
            var category = ServiceFactory.VideoCategoryManager.GetByShortName(new VideoCategory { VideoCategoryShortName = shortname }, Culture);
            if (category != null)
            {
                category.ListVideo = ServiceFactory.VideoManager.GetListVideosByCateId(category.VideoCategoryId, page * _userPageSize, _userPageSize, ref total, Culture);
                ViewBag.Keywords = category.VideoCategoryKeyword;
                ViewBag.Desciption = category.VideoCategoryDescription;
            }
            else
            {
                return ResultHelper.NotFoundResult(this);
            }
            //var data = ServiceFactory.NewsManager.get
            ViewData["Page"] = page;
            ViewData["TotalItems"] = total;
            ViewBag.PageSize = _userPageSize;
            ViewBag.ListCates = categories;
            ViewBag.shortname = category.VideoCategoryShortName;
            return View(category);
        }
    }
}