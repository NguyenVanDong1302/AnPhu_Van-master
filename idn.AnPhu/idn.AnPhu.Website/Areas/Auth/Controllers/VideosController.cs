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
	public class VideosController : AdministratorController
	{
		private VideosManager VideosManager
		{
			get { return ServiceFactory.VideosManager; }
		}

		private VideoCategoriesManager VideoCategoriesManager
		{
			get { return ServiceFactory.VideoCategoriesManager; }
		}

		#region["List danh mục video"]
		// GET: Auth/Videos
		public ActionResult Index()
		{
			var model = VideosManager.GetAll();
			return View(model);
		}
		#endregion

		#region["Tạo mới video"]
		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Title = "Tạo mới danh mục video";
			ViewBag.message = "";
			ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
			return View();
		}

		[HttpPost]
		public ActionResult Create(Videos model)
		{
			var createBy = "";
			if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
			{
				createBy = CUtils.StrTrim(UserState.UserName);
				model.CreateBy = createBy;
			}
			try
			{
				VideosManager.Add(model);
				ViewBag.message = "Thêm mới video thành công";
				ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
				return View(model);
			}
			catch (Exception e)
			{
				ViewBag.message = "Thêm mới video thất bại";
				ViewBag.ListCategoriesVideo = VideosManager.GetAll();
				return View(model);

			}


		}
		#endregion

		#region["Thay đổi thông tin video"]
		[HttpGet]
		public ActionResult Update(int id)
		{
			if (CUtils.IsNullOrEmpty(id))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var Videos = VideosManager.Get(new Videos() { VideoId = id });

			if (Videos != null)
			{
				ViewBag.message = "";
				ViewBag.IsEdit = true;
				ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
				return View(Videos);
			}
			else
			{
				return HttpNotFound();
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(Videos model)
		{
			var message = "";
			if (model != null && !CUtils.IsNullOrEmpty(model.VideoId))
			{
				var Videos = VideosManager.Get(new Videos() { VideoId = model.VideoId });
				if (Videos != null)
				{
					VideosManager.Update(model, Videos);
					message = "Cập nhật video thành công!";
				}
				else
				{
					message = "Mã video '" + model.VideoId + "' không có trong hệ thống!";
				}
			}
			else
			{
				message = "Mã video trống!";
			}
			ViewBag.message = message;
			ViewBag.IsEdit = true;
			ViewBag.ListCategoriesVideo = VideoCategoriesManager.GetAll();
			return View(model);
		}

		#endregion

		[HttpGet]
		public ActionResult Delete(int VideoId)
		{
			if (CUtils.IsNullOrEmpty(VideoId))
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			try
			{
				VideosManager.Remove(new Videos() { VideoId = VideoId });
				//ViewBag.message = "Xóa chiết khấu theo vùng miền mã " + VideosId + "thành công";
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