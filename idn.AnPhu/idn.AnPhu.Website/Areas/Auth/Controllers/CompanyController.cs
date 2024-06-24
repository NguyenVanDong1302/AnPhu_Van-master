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
	public class CompanyController : AdministratorController
	{
		private CompanyManager CompanyManager
		{
			get { return ServiceFactory.CompanyManager; }
		}
		public ActionResult Index()
		{
			try
			{
				List<Company> model = new List<Company>();
				model = CompanyManager.GetAll();
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
			var banner = CompanyManager.Get(new Company() { CompanyId = id });

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
		[HttpPost, ValidateInput(false)]
		[ValidateAntiForgeryToken]

		public ActionResult Update(Company model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.CompanyId))
			{
				var popup = CompanyManager.Get(new Company() { CompanyId = model.CompanyId });
				if (popup != null)
				{
					CompanyManager.Update(model, popup);
					message = "Cập nhật thông tin liên hệ thành công!";
				}
				else
				{
					message = "thông tin liên hệ không có trong hệ thống!";
				}
			}
			else
			{
				message = "thông tin liên hệ trống!";
			}
			ViewBag.message = message;
			return View(model);
		}
	}
}