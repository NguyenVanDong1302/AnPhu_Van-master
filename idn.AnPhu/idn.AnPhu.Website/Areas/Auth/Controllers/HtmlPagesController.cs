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
using idn.AnPhu.Website.Extensions;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
	public class HtmlPagesController : AdministratorController
	{
		private HtmlPagesManager HtmlPagesManager
		{
			get { return ServiceFactory.HtmlPagesManager; }
		}

		private HtmlPageCategoriesManager HtmlPageCategoriesManager
		{
			get { return ServiceFactory.HtmlPageCategoriesManager; }
		}

		#region["List   trang tĩnh"]
		// GET: Auth/HtmlPages
		public ActionResult Index()
		{
			var model = HtmlPagesManager.GetAll();
			return View(model);
		}
		#endregion

		#region["Tạo mới  trang tĩnh"]
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Title = "Tạo mới   trang tĩnh";
			ViewBag.message = "";
			ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
			return View();
		}

		[HttpPost, ValidateInput(false)]
		public ActionResult Create(HtmlPages model)
		{
			var createBy = "";
			if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
			{
				createBy = CUtils.StrTrim(UserState.UserName);
				model.CreateBy = createBy;
			}
			try
			{
				model.HtmlPageShortName = model.HtmlPageTitle.ToUrlSegment(250).ToLower();
				HtmlPagesManager.Add(model);
				ViewBag.message = "Thêm mới  trang tĩnh thành công";
				ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
				return View(model);
			}
			catch (Exception e)
			{
				ViewBag.message = "Thêm mới  trang tĩnh thất bại";
				ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
				return View(model);

			}


		}
		#endregion

		#region["Thay đổi thông tin trang tĩnh"]
		[HttpGet]
		public ActionResult Update(int id)
		{
			if (CUtils.IsNullOrEmpty(id))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var HtmlPages = HtmlPagesManager.Get(new HtmlPages() { HtmlPageId = id });

			if (HtmlPages != null)
			{
				ViewBag.message = "";
				ViewBag.IsEdit = true;
				ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
				return View(HtmlPages);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost, ValidateInput(false)]
		[ValidateAntiForgeryToken]
		public ActionResult Update(HtmlPages model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.HtmlPageCategoryId))
			{
				var HtmlPages = HtmlPagesManager.Get(new HtmlPages() { HtmlPageId = model.HtmlPageId });
				if (HtmlPages != null)
				{
					model.HtmlPageShortName = model.HtmlPageTitle.ToUrlSegment(250).ToLower();
					HtmlPagesManager.Update(model, HtmlPages);
					message = "Cập nhật  trang tĩnh thành công!";
				}
				else
				{
					message = "Mã  trang tĩnh '" + model.HtmlPageCategoryId + "' không có trong hệ thống!";
				}
			}
			else
			{
				message = "Mã  trang tĩnh trống!";
			}
			ViewBag.message = message;
			ViewBag.IsEdit = true;
			ViewBag.ListCategories = HtmlPageCategoriesManager.GetAll();
			return View(model);
		}

		#endregion

		[HttpGet]
		public ActionResult Delete(int HtmlPageId)
		{
			if (CUtils.IsNullOrEmpty(HtmlPageId))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			try
			{
				HtmlPagesManager.Remove(new HtmlPages() { HtmlPageId = HtmlPageId });
				//ViewBag.message = "Xóa chiết khấu theo vùng miền mã " + HtmlPagesId + "thành công";
				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return RedirectToAction("Index");
			}
		}
	}
}