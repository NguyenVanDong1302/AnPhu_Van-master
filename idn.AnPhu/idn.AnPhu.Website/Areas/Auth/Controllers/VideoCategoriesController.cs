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
	public class VideoCategoriesController : AdministratorController
	{
		private VideoCategoriesManager VideoCategoriesManager
		{
			get { return ServiceFactory.VideoCategoriesManager; }
		}

		#region["List danh mục danh mục video"]
		// GET: Auth/VideoCategories
		public ActionResult Index()
		{
			var model = VideoCategoriesManager.GetAll();
			return View(model);
		}
		#endregion

		#region["Tạo mới danh mục video"]
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Title = "Tạo mới danh mục danh mục video";
			ViewBag.message = "";
			ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
			return View();
		}

		[HttpPost]
		public ActionResult Create(VideoCategories model)
		{
			var createBy = "";
			if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
			{
				createBy = CUtils.StrTrim(UserState.UserName);
				model.CreateBy = createBy;
			}
			try
			{
				VideoCategoriesManager.Add(model);
				ViewBag.message = "Thêm mới danh mục video thành công";
				ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
				return View(model);
			}
			catch (Exception e)
			{
				ViewBag.message = "Thêm mới danh mục video thất bại";
				ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
				return View(model);

			}


		}
		#endregion

		#region["Thay đổi thông tin danh mục video"]
		[HttpGet]
		public ActionResult Update(int id)
		{
			if (CUtils.IsNullOrEmpty(id))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var VideoCategories = VideoCategoriesManager.Get(new VideoCategories() { VideoCategoryId = id });

			if (VideoCategories != null)
			{
				ViewBag.message = "";
				ViewBag.IsEdit = true;
				ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
				return View(VideoCategories);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(VideoCategories model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.VideoCategoryId))
			{
				var VideoCategories = VideoCategoriesManager.Get(new VideoCategories() { VideoCategoryId = model.VideoCategoryId });
				if (VideoCategories != null)
				{
					VideoCategoriesManager.Update(model, VideoCategories);
					message = "Cập nhật danh mục video thành công!";
				}
				else
				{
					message = "Mã danh mục video '" + model.VideoCategoryId + "' không có trong hệ thống!";
				}
			}
			else
			{
				message = "Mã danh mục video trống!";
			}
			ViewBag.message = message;
			ViewBag.IsEdit = true;
			ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
			return View(model);
		}

		#endregion
	}
}