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

        public ActionResult BuyCar(string data, int productid = 0, int versionid = 0)
        {

            var Culture = "vi-VN";
            var listpro = ServiceFactory.ProductManager.ProductGetAllActive(Culture);
            if (listpro.Count > 0)
            {
                foreach (Product item in listpro)
                {
                    item.Versions = ServiceFactory.ProductVersionsManager.GetByPrdId(item.ProductId, Culture);
                }
            }
          
            var data1 = ServiceFactory.ProductManager.Get(new Product { ProductId = productid });
            var listdata = ServiceFactory.ProductManager.ProductGetAllActive(Culture);
            ViewBag.Categories = new SelectList(listdata, "ProductId", "ProductName");//lấy ra một 1 item cảu list
            var listver = ServiceFactory.ProductVersionsManager.GetByPrdId(productid, Culture);
            ViewBag.Versions = new SelectList(listver, "VersionId", "VersionTitle");
            var listlocation = ServiceFactory.LocationDiscountsManager.GetAllActive(Culture);
            ViewBag.Locations = new SelectList(listlocation, "LocationDiscountId", "LocationDiscountName");
            var priceinsurrance = ServiceFactory.PriceInsurranceManager.GetAllActive(Culture);
            ViewBag.PriceInsurrance = new SelectList(priceinsurrance, "PriceInsurranceId", "PriceInsurranceName");
            var pricemaintenance = ServiceFactory.PriceMaintenanceManager.GetAllActive(Culture);
            ViewBag.PriceMaintenance = new SelectList(pricemaintenance, "PriceMaintenanceId", "PriceMaintenanceName");

            var listlocation1 = ServiceFactory.LocationManager.GetAllActive(Culture);
            ViewBag.Locations1 = new SelectList(listlocation1, "LocationDiscountId", "LocationName");

            ViewBag.Keywords = "giá xe hyundai, bảng giá xe hyundai, gia xe hyundai, bang gia xe hyundai, Hyundai Cầu Diễn";
            ViewBag.Desciption = "Bảng giá các xe Hyundai đầy đủ và chính xác nhất. Thông tin được cung cấp bởi Hyundai Cầu Diễn - Đại lý ủy quyền của Hyundai Thành Công";
            return View(listpro);

        }
        public ActionResult SupportBuyCar(int productid = 0, int versionid = 0)
        {
            //var product = ServiceFactory.ProductManager.Get(new Product { ProductId = productid });
            //product.VersionId = versionid;
            string keyword = ConfigurationManager.AppSettings["keyword"];
            string decsription = ConfigurationManager.AppSettings["description"];
            var version = ServiceFactory.ProductVersionsManager.GetByPrdId(productid, Culture);
            var listpro = ServiceFactory.ProductManager.ProductGetAllActive(Culture);
            var listlocation = ServiceFactory.BankDiscountManager.GetAllActive(Culture);
            ViewBag.Locations = new SelectList(listlocation, "BankDiscountValue", "BankDiscountName");

            //string h1 = "<script>$(\"#ProductId\").change(function () { var listcars = new Array();";
            //string h2 = "<script>$(\"#ProductId\").change(function () { var listcars = new Array();";
            //string url = "<script>$(\"#ProductId\").change(function () { var listcars = new Array();";
            string str = "<script>$(\"#ProductId\").change(function () { var listcars = new Array();";

            //h1 += "listcars[0]='';";
            //h2 += "listcars[0]='';";
            //url += "listcars[0]='#';";
            str += "listcars[0]='/images/blank_car.png';";
            foreach (var item in listpro)

            {

                //h1 += "listcars[" + item.ProductId.ToString() + "]='" + @String.Format("{0:0,0}", Convert.ToDouble(item.ProductPrice)) + " ' ;";
                //h2 += "listcars[" + item.ProductId.ToString() + "]='" + item.ProductSlogan + "';";
                //url += "listcars[" + item.ProductId.ToString() + "]='/vi/san-pham/" + item.ProductCode + "';";
                str += "listcars[" + item.ProductId.ToString() + "]='/tempfiles/uploads/products/registers/" + item.ProductCode.ToUpper() + "_RE.png';";
            }

            //h1 += "   var selectedValue = $(this).val();";
            //h1 += "  document.getElementById(\"h1-id\").innerHTML=listcars[selectedValue] +' VNĐ';";


            //h1 += " alert(listcars[selectedValue]);";
            //h1 += "});";
            //h1 += "</script>";

            //h2 += "   var selectedValue = $(this).val();";
            //h2 += "  document.getElementById(\"h2-id\").innerHTML=listcars[selectedValue];";
            //h2 += "});";
            //h2 += "</script>";

            //url += "   var selectedValue = $(this).val();";
            //url += "  document.getElementById(\"urlprd\").href=listcars[selectedValue];";
            //url += "});";
            //url += "</script>";

            str += "   var selectedValue = $(this).val();";
            str += "  document.getElementById(\"showimage\").src=listcars[selectedValue];";
            str += "});";
            str += "</script>";

            ViewBag.listarry = str;
            //ViewBag.listurl = url;
            //ViewBag.listh1 = h1;
            //ViewBag.listh2 = h2;
            ViewBag.Keywords = keyword;
            ViewBag.Desciption = decsription;

            ViewBag.Categories = new SelectList(listpro, "ProductId", "ProductName");
            ViewBag.Versions = new SelectList(version, "VersionId", "VersionTitle");

            return View(listpro);
        }
    }
}