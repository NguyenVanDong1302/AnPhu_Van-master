using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class SlideBannersController : AdministratorController
    {
        private SlideBannersManager SlideBannersManager
        {
            get { return ServiceFactory.SlideBannersManager; }
        }

        #region["List danh mục slide"]
        // GET: Auth/SlideBanners
        public ActionResult Index()
        {
            var model = SlideBannersManager.GetAll();
            return View(model);
        }
        #endregion

        #region["Tạo mới slide"]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Title = "Tạo mới danh mục slide";
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Create(SlideBanners model)
        {
            var createBy = "";
            if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
            {
                createBy = CUtils.StrTrim(UserState.UserName);
                model.CreateBy = createBy;
            }
            try
            {
                SlideBannersManager.Add(model);
                ViewBag.message = "Thêm mới slide thành công";
                return View(model);
            }
            catch (Exception e)
            {
                ViewBag.message = "Thêm mới slide thất bại";
                ViewBag.ListCategoriesSlideBanners = SlideBannersManager.GetAll();
                return View(model);

            }


        }
        #endregion

        #region["Thay đổi thông tin slide"]
        [HttpGet]
        public ActionResult Update(int id)
        {
            if (CUtils.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var SlideBanners = SlideBannersManager.Get(new SlideBanners() { SlideBannerId = id });

            if (SlideBanners != null)
            {
                ViewBag.message = "";
                ViewBag.IsEdit = true;
                return View(SlideBanners);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SlideBanners model)
        {
            var message = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.SlideBannerId))
            {
                var SlideBanners = SlideBannersManager.Get(new SlideBanners() { SlideBannerId = model.SlideBannerId });
                if (SlideBanners != null)
                {
                    SlideBannersManager.Update(model, SlideBanners);
                    message = "Cập nhật slide thành công!";
                }
                else
                {
                    message = "Mã slide '" + model.SlideBannerId + "' không có trong hệ thống!";
                }
            }
            else
            {
                message = "Mã slide trống!";
            }
            ViewBag.message = message;
            ViewBag.IsEdit = true;
            return View(model);
        }

        #endregion

        #region["Xóa slide"]
        [HttpGet]
        public ActionResult Delete(int SlideBannerId)
        {
            if (CUtils.IsNullOrEmpty(SlideBannerId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                SlideBannersManager.Remove(new SlideBanners() { SlideBannerId = SlideBannerId });
                //ViewBag.message = "Xóa slide mã " + SlideBannersId + "thành công";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}