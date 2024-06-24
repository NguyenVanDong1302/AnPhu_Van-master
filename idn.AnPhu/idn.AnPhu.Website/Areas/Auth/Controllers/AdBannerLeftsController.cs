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
	public class AdBannerLeftsController : AdministratorController
	{
		private AdBannerLeftsManager AdBannerLeftsManager
		{
			get { return ServiceFactory.AdBannerLeftsManager; }
		}
		public ActionResult Index()
		{
			try
			{
				List<AdBannerLefts> model = new List<AdBannerLefts>();
				model = AdBannerLeftsManager.GetAll();
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
			var banner = AdBannerLeftsManager.Get(new AdBannerLefts() { AdLeftId = id });

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
		public ActionResult Update(AdBannerLefts model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.AdLeftId))
			{
				var popup = AdBannerLeftsManager.Get(new AdBannerLefts() { AdLeftId = model.AdLeftId });
				if (popup != null)
				{
					AdBannerLeftsManager.Update(model, popup);
					message = "Cập nhật Ad Banner Left thành công!";
				}
				else
				{
					message = "Ad Banner Left không có trong hệ thống!";
				}
			}
			else
			{
				message = "Ad Banner Left trống!";
			}
			ViewBag.message = message;
			return View(model);
		}
	}
}