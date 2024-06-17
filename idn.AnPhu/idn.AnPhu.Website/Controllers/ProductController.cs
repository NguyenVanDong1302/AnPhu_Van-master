using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using idn.AnPhu.Biz.Models;
using System.Globalization;
using idn.AnPhu.Website.Utils;
using idn.AnPhu.Website.Helper;

namespace idn.AnPhu.Website.Controllers
{
    public class ProductController : BaseController
    {

        // GET: Auth/Product
        public ActionResult Detail(string productcode, string shortname)
        {
            var Culture = "vi-VN";
            var product = ServiceFactory.ProductManager.GetByCode(new Product { ProductCode = "santa-fe" }, Culture);

            if (product != null)
            {
                product.Properties = ServiceFactory.ProductPropertyManager.GetByPrdId(product.ProductId, Culture);


                ViewBag.isInterior = true;
                ViewBag.isExterior = true;

                //product.Reviews = ServiceFactory.ProductReviewManager.GetByPrdId(product.ProductId, Culture);
                //    #region["Gallery Products"]

                //    var sRootGallery = "~/tempfiles/uploads/products/gallery/" + productcode + "/gallery/";
                //    if (!Directory.Exists(Server.MapPath(sRootGallery)))
                //        sRootGallery = "~/tempfiles/uploads/products/gallery/" + productcode + "/";
                //    var gaCat = "";
                //    var gaCatItem = "";
                //    var galleryCat = ServiceFactory.AppDicDomainManager.GetListAppDicDomainByItemCode("GALLERY_CAT");
                //    if (galleryCat != null && galleryCat.Count > 0)
                //    {
                //        foreach (var gaItem in galleryCat)
                //        {

                //            gaCat += "<li>";
                //            gaCat += "<a class=\"" + gaItem.Item_Code.ToLower() + "\" href=\"javascript:cubeGalleryCustomiz('1','" + gaItem.Item_Code.ToLower() + "');\" style=\"z-index: 8\">" + gaItem.Item_Value + "</a>";
                //            gaCat += "</li>";
                //            gaCatItem += StringUtils.galleryItemMB(sRootGallery, gaItem.Item_Code.ToLower(), gaItem.Item_Value);
                //        }
                //    }

                //    ViewBag.gaCat = gaCat;
                //    ViewBag.gaCatItem = gaCatItem;

                //    ViewBag.Product = product;
                //    #endregion
                //    #region["360"]
                var variablesScript = "";
                //    var sRootExperience = "~/tempfiles/uploads/products/360/" + productcode;
                //    var sRootColor = "~/tempfiles/uploads/products/360";
                //    string[] arrExDir = null;
                //    string[] arrInDir = null;
                //    if (Directory.Exists(Server.MapPath(sRootExperience + "/experience")))
                //    {
                //        sRootExperience = sRootExperience + "/experience";
                //        arrExDir = Directory.GetDirectories(Server.MapPath(sRootExperience), "ex_*");
                //        arrInDir = Directory.GetDirectories(Server.MapPath(sRootExperience), "i*");
                //        //
                //        sRootColor += "/experience";
                //    }
                //    else if (Directory.Exists(Server.MapPath(sRootExperience + "")))
                //    {
                //        arrExDir = Directory.GetDirectories(Server.MapPath(sRootExperience), "ex_*");
                //        arrInDir = Directory.GetDirectories(Server.MapPath(sRootExperience), "i*");
                //    }
                //    if (arrExDir != null && arrInDir != null)
                //    {
                //        String exScript = "";
                //        foreach (String sDir in arrExDir)
                //        {
                //            if (exScript.Length > 0) exScript += ",";
                //            exScript += "{";
                //            exScript += "Code:'" + Path.GetFileName(sDir) + "'";
                //            String[] arrColor = System.IO.File.ReadAllLines(sDir + "//" + Path.GetFileName(sDir) + ".txt");
                //            if (arrColor.Length > 0)
                //                exScript += ",NameVN:'" + arrColor[0] + "'";
                //            else
                //                exScript += ",NameVN:''";
                //            if (arrColor.Length > 1)
                //                exScript += ",NameEN:'" + arrColor[1] + "'";
                //            else
                //                exScript += ",NameEN:''";
                //            exScript += "}";
                //        }
                //        String inScript = "";
                //        foreach (String sDir in arrInDir)
                //        {
                //            if (inScript.Length > 0) inScript += ",";
                //            inScript += "{";
                //            inScript += "Code:'" + Path.GetFileName(sDir) + "'";
                //            String[] arrColor = System.IO.File.ReadAllLines(sDir + "//" + Path.GetFileName(sDir) + ".txt");
                //            if (arrColor.Length > 0)
                //                inScript += ",NameVN:'" + arrColor[0] + "'";
                //            else
                //                inScript += ",NameVN:''";
                //            if (arrColor.Length > 1)
                //                inScript += ",NameEN:'" + arrColor[1] + "'";
                //            else
                //                inScript += ",NameEN:''";
                //            inScript += "}";
                //        }
                //        //variablesScript = "<script type=\"text/javascript\">  //<![CDATA[";
                //        variablesScript += "var iExtCount= " + arrExDir.Length + "; var iIntCount=" + arrInDir.Length + "; var expRoot= '" + Url.Content(sRootExperience) + "'; var colorRoot = '" + Url.Content(sRootColor) + "'; var arrExt = [" + exScript + "]; var arrInt = [" + inScript + "];";
                //        //variablesScript += "//]]></script>";

                //    }
                //    ViewBag.variablesScript = variablesScript;
                //    if (arrInDir == null)
                //    {
                //        ViewBag.isInterior = false;
                //    }
                //    else
                //    {
                //        if (arrInDir.Length == 0)
                //        {
                //            ViewBag.isInterior = false;
                //        }
                //        else
                //        {
                //            ViewBag.isInterior = true;
                //        }
                //    }
                //    if (arrExDir == null)
                //    {
                //        ViewBag.isExterior = false;
                //    }
                //    else
                //    {
                //        if (arrExDir.Length == 0)
                //        {
                //            ViewBag.isExterior = false;
                //        }
                //        else
                //        {
                //            ViewBag.isExterior = true;
                //        }
                //    }


                //    #endregion
                //    #region["Thong so ky thuat"]
                //    var sFile = string.Format("~/tempfiles/uploads/products/html/{0}_{1}.htm", product.ProductCode.Replace('-', '_'), "spec");
                //    var contentFile = StringUtils.File_Read(sFile);
                //    ViewBag.contentFile = !String.IsNullOrEmpty(contentFile) ? contentFile : "";
                //    #endregion
                //    #region["Properties"]
                //    product.Properties = ServiceFactory.ProductPropertyManager.GetAllActive(product.ProductId, Culture);


                //    #endregion
                //    ViewBag.Keywords = product.ProductKeyword;
                //    ViewBag.Desciption = product.ProductDescription;
                //    ViewBag.MetaOGImage = product.ProductImage;
                //    return View(product);     
            }
            //else
            //{
            //    return ResultHelper.NotFoundResult(this);
            //}
            return View(product);

            //return View();
            
        }
    }
}