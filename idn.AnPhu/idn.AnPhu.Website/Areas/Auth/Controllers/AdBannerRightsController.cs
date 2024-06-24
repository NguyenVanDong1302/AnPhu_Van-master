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
	public class AdBannerRightsController : AdministratorController
	{
		private AdBannerRightsManager AdBannerRightsManager
		{
			get { return ServiceFactory.AdBannerRightsManager; }
		}
		public ActionResult Index()
		{
			try
			{
				List<AdBannerRights> model = new List<AdBannerRights>();
				model = AdBannerRightsManager.GetAll();
				ViewBag.message = "";
				return View(model);
			}
			catch (Exception e)
			{
				ViewBag.message = e.Message;
				return View();
			}
		}

		[HttpGet]
		public ActionResult Update(int id)
		{
			if (CUtils.IsNullOrEmpty(id))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var banner = AdBannerRightsManager.Get(new AdBannerRights() { AdRightId = id });

			if (banner != null)
			{
				ViewBag.message = "";
				return View(banner);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(AdBannerRights model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.AdRightId))
			{
				var popup = AdBannerRightsManager.Get(new AdBannerRights() { AdRightId = model.AdRightId });
				if (popup != null)
				{
					AdBannerRightsManager.Update(model, popup);
					message = "Cập nhật Ad Banner Right thành công!";
				}
				else
				{
					message = "Ad Banner Right không có trong hệ thống!";
				}
			}
			else
			{
				message = "Ad Banner Right trống!";
			}
			ViewBag.message = message;
			return View(model);
		}
	}
}