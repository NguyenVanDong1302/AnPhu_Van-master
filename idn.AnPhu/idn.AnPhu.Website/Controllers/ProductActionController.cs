using idn.AnPhu.Biz.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using idn.AnPhu.Biz.Models;

namespace idn.AnPhu.Website.Controllers
{
    public class ProductActionController : BaseController
    {
        // GET: ProductAction
        public ActionResult Index()
        {
            return View();
        }

        //[Httpget]
        public ActionResult Register()
        {
            string keyword = ConfigurationManager.AppSettings["keyword"];
            string decsription = ConfigurationManager.AppSettings["description"];
            var listpro = ServiceFactory.ProductManager.ProductGetAllActive("vi-VN");
            ViewBag.Categories = new SelectList(listpro, "ProductId", "ProductName");

            string h1 = "<script>$(\"#ProductId\").change(function () { var listcars = new Array();";
            string h2 = "<script>$(\"#ProductId\").change(function () { var listcars = new Array();";
            string url = "<script>$(\"#ProductId\").change(function () { var listcars = new Array();";
            string str = "<script>$(\"#ProductId\").change(function () { var listcars = new Array();";

            h1 += "listcars[0]='';";
            h2 += "listcars[0]='';";
            url += "listcars[0]='#';";
            str += "listcars[0]='/images/blank_car.png';";
            foreach (var item in listpro)
            {
                h1 += "listcars[" + item.ProductId.ToString() + "]='" + item.ProductName + "';";
                h2 += "listcars[" + item.ProductId.ToString() + "]='" + item.ProductSlogan + "';";
                url += "listcars[" + item.ProductId.ToString() + "]='/vi/san-pham/" + item.ProductCode + "';";
                str += "listcars[" + item.ProductId.ToString() + "]='/tempfiles/uploads/products/registers/" + item.ProductCode.ToUpper() + "_RE.png';";
            }
            h1 += "   var selectedValue = $(this).val();";
            h1 += "  document.getElementById(\"h1-id\").innerHTML=listcars[selectedValue];";
            h1 += "});";
            h1 += "</script>";

            h2 += "   var selectedValue = $(this).val();";
            h2 += "  document.getElementById(\"h2-id\").innerHTML=listcars[selectedValue];";
            h2 += "});";
            h2 += "</script>";

            url += "   var selectedValue = $(this).val();";
            url += "  document.getElementById(\"urlprd\").href=listcars[selectedValue];";
            url += "});";
            url += "</script>";

            str += "   var selectedValue = $(this).val();";
            str += "  document.getElementById(\"showimage\").src=listcars[selectedValue];";
            str += "});";
            str += "</script>";

            ViewBag.listarry = str;
            ViewBag.listurl = url;
            ViewBag.listh1 = h1;
            ViewBag.listh2 = h2;
            ViewBag.Keywords = keyword;
            ViewBag.Desciption = decsription;
            return View();
        }
    }
}