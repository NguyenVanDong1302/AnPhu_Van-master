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
	public class PriceOptionsController : AdministratorController
	{
		private PriceOptionsManager PriceOptionsManager
		{
			get { return ServiceFactory.PriceOptionsManager; }
		}

		#region["List danh mục cấu hình"]
		// GET: Auth/PriceOptions
		public ActionResult Index()
		{
			var model = PriceOptionsManager.GetAll();
			return View(model);
		}
		#endregion

		#region["Tạo mới cấu hình"]
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Title = "Tạo mới danh mục cấu hình";
			ViewBag.message = "";
			return View();
		}

		[HttpPost]
		public ActionResult Create(PriceOptions model)
		{
			var createBy = "";
			if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
			{
				createBy = CUtils.StrTrim(UserState.UserName);
				model.CreateBy = createBy;
			}
			try
			{
				PriceOptionsManager.Add(model);
				ViewBag.message = "Thêm mới cấu hình thành công";
				return View(model);
			}
			catch (Exception e)
			{
				ViewBag.message = "Thêm mới cấu hình thất bại";
				ViewBag.ListCategoriesPriceOptions = PriceOptionsManager.GetAll();
				return View(model);

			}


		}
		#endregion

		#region["Thay đổi thông tin cấu hình"]
		[HttpGet]
		public ActionResult Update(int id)
		{
			if (CUtils.IsNullOrEmpty(id))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var PriceOptions = PriceOptionsManager.Get(new PriceOptions() { PriceOptionId = id });

			if (PriceOptions != null)
			{
				ViewBag.message = "";
				ViewBag.IsEdit = true;
				return View(PriceOptions);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(PriceOptions model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.PriceOptionId))
			{
				var PriceOptions = PriceOptionsManager.Get(new PriceOptions() { PriceOptionId = model.PriceOptionId });
				if (PriceOptions != null)
				{
					PriceOptionsManager.Update(model, PriceOptions);
					message = "Cập nhật cấu hình thành công!";
				}
				else
				{
					message = "Mã cấu hình '" + model.PriceOptionId + "' không có trong hệ thống!";
				}
			}
			else
			{
				message = "Mã cấu hình trống!";
			}
			ViewBag.message = message;
			ViewBag.IsEdit = true;
			return View(model);
		}

		#endregion

		#region["Xóa cấu hình"]
		[HttpGet]
		public ActionResult Delete(int PriceOptionId)
		{
			if (CUtils.IsNullOrEmpty(PriceOptionId))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			try
			{
				PriceOptionsManager.Remove(new PriceOptions() { PriceOptionId = PriceOptionId });
				//ViewBag.message = "Xóa cấu hình mã " + PriceOptionsId + "thành công";
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