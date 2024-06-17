using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    //internal class ProductProvider
    //{
    //}
    public class ProductProvider : DataAccessBase, IProductProvider
    {
        public Product Get(Product dummy)
        {
            var comm = this.GetCommand("sp_ProductGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "ProductId", dummy.ProductId);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<Product>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public Product GetByCode(Product dummy, string culture)
        {
            var comm = this.GetCommand("sp_ProductGetByCode");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<string>(this.Factory, "ProductCode", dummy.ProductCode);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<Product>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public void Add(Product item, string Culture)
        {
            var comm = this.GetCommand("sp_Product_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "ProductName", item.ProductName);
            comm.AddParameter<string>(this.Factory, "ProductTitle", item.ProductTitle);
            comm.AddParameter<string>(this.Factory, "ProductCode", item.ProductCode);
            comm.AddParameter<int>(this.Factory, "PrdCategoryId", item.PrdCategoryId);
            comm.AddParameter<string>(this.Factory, "ProductSummary", item.ProductSummary);
            comm.AddParameter<string>(this.Factory, "ProductDescription", item.ProductDescription);
            comm.AddParameter<string>(this.Factory, "ProductKeyword", item.ProductKeyword);
            comm.AddParameter<string>(this.Factory, "ProductVideo", item.ProductVideo);
            comm.AddParameter<string>(this.Factory, "ProductBrochure", item.ProductBrochure);
            comm.AddParameter<string>(this.Factory, "ProductSlogan", item.ProductSlogan);
            comm.AddParameter<string>(this.Factory, "ProductBackground", item.ProductBackground);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<decimal>(this.Factory, "ProductPrice", item.ProductPrice);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<bool>(this.Factory, "IsHotProduct", item.IsHotProduct);
            comm.AddParameter<bool>(this.Factory, "IsNewProduct", item.IsNewProduct);
            comm.AddParameter<bool>(this.Factory, "IsSaleProduct", item.IsSaleProduct);
            comm.AddParameter<string>(this.Factory, "ProductImage", item.ProductImage);
            comm.AddParameter<string>(this.Factory, "ProductImage2", item.ProductImage2);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Culture", Culture);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Add(Product item)
        {
            //var comm = this.GetCommand("sp_HtmlPage_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "HtmlPageTitle", item.HtmlPageTitle);
            //comm.AddParameter<string>(this.Factory, "HtmlPageShortName", item.HtmlPageShortName);
            //comm.AddParameter<string>(this.Factory, "HtmlPageSummary", item.HtmlPageSummary);
            //comm.AddParameter<string>(this.Factory, "HtmlPageDescription", item.HtmlPageDescription);
            //comm.AddParameter<string>(this.Factory, "HtmlPageKeyword", item.HtmlPageKeyword);
            //comm.AddParameter<string>(this.Factory, "HtmlPageBody", item.HtmlPageBody);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            //comm.AddParameter<string>(this.Factory, "HtmlPageImage", item.HtmlPageImage);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Culture", Culture);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }
        public void Update(Product @new, Product old)
        {
            var item = @new;
            item.ProductId = old.ProductId;
            var comm = this.GetCommand("sp_Product_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ProductId", item.ProductId);
            comm.AddParameter<int>(this.Factory, "PrdCategoryId", item.PrdCategoryId);
            comm.AddParameter<string>(this.Factory, "ProductName", item.ProductName);
            comm.AddParameter<string>(this.Factory, "ProductTitle", item.ProductTitle);
            comm.AddParameter<string>(this.Factory, "ProductCode", item.ProductCode);
            comm.AddParameter<string>(this.Factory, "ProductSummary", item.ProductSummary);
            comm.AddParameter<string>(this.Factory, "ProductDescription", item.ProductDescription);
            comm.AddParameter<string>(this.Factory, "ProductKeyword", item.ProductKeyword);
            comm.AddParameter<string>(this.Factory, "ProductSlogan", item.ProductSlogan);
            comm.AddParameter<string>(this.Factory, "ProductBackground", item.ProductBackground);
            comm.AddParameter<decimal>(this.Factory, "ProductPrice", item.ProductPrice);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<bool>(this.Factory, "IsHotProduct", item.IsHotProduct);
            comm.AddParameter<bool>(this.Factory, "IsNewProduct", item.IsNewProduct);
            comm.AddParameter<bool>(this.Factory, "IsSaleProduct", item.IsSaleProduct);
            comm.AddParameter<string>(this.Factory, "ProductVideo", item.ProductVideo);
            comm.AddParameter<string>(this.Factory, "ProductBrochure", item.ProductBrochure);
            comm.AddParameter<string>(this.Factory, "ProductImage", item.ProductImage);
            comm.AddParameter<string>(this.Factory, "ProductImage2", item.ProductImage2);
            comm.AddParameter<string>(this.Factory, "UpdateBy", item.UpdateBy);
            //comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            //comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Product item)
        {
            var comm = this.GetCommand("sp_Product_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ProductId", item.ProductId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<Product> GetAll(int startIndex, int lenght, ref int totalItem)
        {
            throw new NotImplementedException();
        }

        //public List<HtmlPage> SelectTop4()
        //{
        //    var comm = this.GetCommand("sp_SliderBanner_SelectTop4");
        //    if (comm == null) return null;
        //    var dt = this.GetTable(comm);
        //    return EntityBase.ParseListFromTable<HtmlPage>(dt);
        //}

        public List<Product> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_ProductSearch");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<Product>(dt);
        }
        public List<Product> GetListHotProduct(string culture)
        {
            var comm = this.GetCommand("sp_ProductGetHotProduct");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Product>(dt);
        }
        public List<Product> GetListNewProduct(string culture)
        {
            var comm = this.GetCommand("sp_ProductGetNewProduct");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Product>(dt);
        }

        public List<Product> GetListSaleProduct(string culture)
        {
            var comm = this.GetCommand("sp_ProductGetSaleProduct");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Product>(dt);
        }

        public List<Product> GetListHotNewSaleProduct(string culture)
        {
            var comm = this.GetCommand("sp_ProductGetHotNewSaleProduct");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Product>(dt);
        }

        public List<Product> ProductGetByCateId(int cateid, string culture)
        {
            var comm = this.GetCommand("sp_ProductGetByCateId");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "PrdCategoryId", cateid);
            var dt = this.GetTable(comm);

            return EntityBase.ParseListFromTable<Product>(dt);
        }
        public List<Product> ProductGetAllActive(string culture)
        {
            var comm = this.GetCommand("sp_ProductGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);

            return EntityBase.ParseListFromTable<Product>(dt);
        }
    }
}
