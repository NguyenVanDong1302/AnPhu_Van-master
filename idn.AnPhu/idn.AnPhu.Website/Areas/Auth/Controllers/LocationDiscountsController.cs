using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using idn.AnPhu.Website.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class LocationDiscountsController : AdministratorController
	{
		private LocationDiscountsManager LocationDiscountsManager
		{
			get { return ServiceFactory.LocationDiscountsManager; }
		}

		#region["List chiết khấu theo vùng miền"]
		// GET: Auth/LocationDiscounts
		public ActionResult Index()
		{
			var model = LocationDiscountsManager.GetAll();
			return View(model);
		}
		#endregion

		#region["Tạo mới chiết khấu theo vùng miền"]
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Title = "Tạo mới chiết khấu theo vùng miền";
			ViewBag.message = "";
			return View();
		}

		[HttpPost]
		public ActionResult Create(LocationDiscounts model)
		{
			var createBy = "";
			if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
			{
				createBy = CUtils.StrTrim(UserState.UserName);
				model.CreateBy = createBy;
			}
			try
			{
				LocationDiscountsManager.Add(model);
				ViewBag.message = "Thêm mới chiết khấu theo vùng miền thành công";
				return View(model);
			}
			catch (Exception e)
			{
				ViewBag.message = "Thêm mới chiết khấu theo vùng miền thất bại";
				ViewBag.ListCategoriesLocationDiscounts = LocationDiscountsManager.GetAll();
				return View(model);

			}


		}
		#endregion

		#region["Thay đổi thông tin chiết khấu theo vùng miền"]
		[HttpGet]
		public ActionResult Update(int id)
		{
			if (CUtils.IsNullOrEmpty(id))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var LocationDiscounts = LocationDiscountsManager.Get(new LocationDiscounts() { LocationDiscountId = id });

			if (LocationDiscounts != null)
			{
				ViewBag.message = "";
				ViewBag.IsEdit = true;
				return View(LocationDiscounts);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(LocationDiscounts model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.LocationDiscountId))
			{
				var LocationDiscounts = LocationDiscountsManager.Get(new LocationDiscounts() { LocationDiscountId = model.LocationDiscountId });
				if (LocationDiscounts != null)
				{
					LocationDiscountsManager.Update(model, LocationDiscounts);
					message = "Cập nhật chiết khấu theo vùng miền thành công!";
				}
				else
				{
					message = "Mã chiết khấu theo vùng miền '" + model.LocationDiscountId + "' không có trong hệ thống!";
				}
			}
			else
			{
				message = "Mã chiết khấu theo vùng miền trống!";
			}
			ViewBag.message = message;
			ViewBag.IsEdit = true;
			return View(model);
		}

		#endregion

		#region["Xóa cấu hình"]
		[HttpGet]
		public ActionResult Delete(int LocationDiscountId)
		{
			if (CUtils.IsNullOrEmpty(LocationDiscountId))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			try
			{
				LocationDiscountsManager.Remove(new LocationDiscounts() { LocationDiscountId = LocationDiscountId });
				//ViewBag.message = "Xóa chiết khấu theo vùng miền mã " + LocationDiscountId + "thành công";
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