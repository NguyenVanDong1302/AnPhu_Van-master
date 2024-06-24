using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using System;
using System.Net;
using System.Web.Mvc;
using idn.AnPhu.Website.Extensions;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
	public class HtmlPageCategoriesController : AdministratorController
	{
		private HtmlPageCategoriesManager HtmlPageCategoriesManager
		{
			get { return ServiceFactory.HtmlPageCategoriesManager; }
		}

		#region["List danh mục danh mục trang tĩnh"]
		// GET: Auth/HtmlPageCategories
		public ActionResult Index()
		{
			var model = HtmlPageCategoriesManager.GetAll();
			return View(model);
		}
		#endregion

		#region["Tạo mới danh mục trang tĩnh"]
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Title = "Tạo mới danh mục danh mục trang tĩnh";
			ViewBag.message = "";
			ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
			return View();
		}

		[HttpPost]
		public ActionResult Create(HtmlPageCategories model)
		{
			var createBy = "";
			if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
			{
				createBy = CUtils.StrTrim(UserState.UserName);
				model.CreateBy = createBy;
			}
			try
			{
				model.HtmlPageCategoryShortName = model.HtmlPageCategoryTitle.ToUrlSegment(250).ToLower();
				HtmlPageCategoriesManager.Add(model);
				ViewBag.message = "Thêm mới danh mục trang tĩnh thành công";
				ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
				return View(model);
			}
			catch (Exception e)
			{
				ViewBag.message = "Thêm mới danh mục trang tĩnh thất bại";
				ViewBag.ListCategoriesVideo = HtmlPageCategoriesManager.GetAll();
				return View(model);

			}


		}
		#endregion

		#region["Thay đổi thông tin danh mục trang tĩnh"]
		[HttpGet]
		public ActionResult Update(int id)
		{
			if (CUtils.IsNullOrEmpty(id))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var HtmlPageCategories = HtmlPageCategoriesManager.Get(new HtmlPageCategories() { HtmlPageCategoryId = id });

			if (HtmlPageCategories != null)
			{
				ViewBag.message = "";
				ViewBag.IsEdit = true;
				ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
				return View(HtmlPageCategories);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(HtmlPageCategories model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.HtmlPageCategoryId))
			{
				var HtmlPageCategories = HtmlPageCategoriesManager.Get(new HtmlPageCategories() { HtmlPageCategoryId = model.HtmlPageCategoryId });
				if (HtmlPageCategories != null)
				{
					model.HtmlPageCategoryShortName = model.HtmlPageCategoryTitle.ToUrlSegment(250).ToLower();
					HtmlPageCategoriesManager.Update(model, HtmlPageCategories);
					message = "Cập nhật danh mục trang tĩnh thành công!";
				}
				else
				{
					message = "Mã danh mục trang tĩnh '" + model.HtmlPageCategoryId + "' không có trong hệ thống!";
				}
			}
			else
			{
				message = "Mã danh mục trang tĩnh trống!";
			}
			ViewBag.message = message;
			ViewBag.IsEdit = true;
			ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
			return View(model);
		}

		#endregion
	}
}