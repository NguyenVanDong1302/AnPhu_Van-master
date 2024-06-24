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
	public class PopupAdvertisementController : AdministratorController
	{
		private PopupAdvertisementManager PopupAdvertisementManager
		{
			get { return ServiceFactory.PopupAdvertisementManager; }
		}
		// GET: Auth/PopupAdvertisement
		public ActionResult Index()
		{
			try
			{
				List<PopupAdvertisement> model = new List<PopupAdvertisement>();
				model = PopupAdvertisementManager.GetAll();
				ViewBag.message = "";
				return View(model);
			}
			catch (Exception e)
			{
				ViewBag.message = e.Message;
				return View();
			}
		}

		#region["Thay đổi thông tin popup quảng cáo"]
		[HttpGet]
		public ActionResult Update(int id)
		{
			if (CUtils.IsNullOrEmpty(id))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var popup = PopupAdvertisementManager.Get(new PopupAdvertisement() { Id = id });

			if (popup != null)
			{
				ViewBag.message = "";
				return View(popup);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(PopupAdvertisement model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.Id))
			{
				var popup = PopupAdvertisementManager.Get(new PopupAdvertisement() { Id = model.Id });
				if (popup != null)
				{
					PopupAdvertisementManager.Update(model, popup);
					message = "Cập nhật popup quảng cáo thành công!";
				}
				else
				{
					message = "Popup quảng cáo '" + model.Id + "' không có trong hệ thống!";
				}
			}
			else
			{
				message = "Mã Popup quảng cáo trống!";
			}
			ViewBag.message = message;
			return View(model);
		}

		#endregion
	}
}