using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    //internal class ProductReviewProvider
    //{
    //}

    public class ProductReviewProvider : DataAccessBase, IProductReviewProvider
    {
        public ProductReview Get(ProductReview dummy)
        {
            var comm = this.GetCommand("sp_ProductReviewGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "ReviewId", dummy.ReviewId);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<ProductReview>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public List<ProductReview> GetByPrdId(int productId, string culture)
        {
            var comm = this.GetCommand("sp_ProductReviewGetByPrdId");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "ProductId", productId);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<ProductReview>(dt);
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public void Add(ProductReview item, string Culture)
        {
            var comm = this.GetCommand("sp_ProductReview_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "ReviewTitle", item.ReviewTitle);
            comm.AddParameter<string>(this.Factory, "ReviewLogo", item.ReviewLogo);
            comm.AddParameter<string>(this.Factory, "ReviewKeyword", item.ReviewKeyword);
            comm.AddParameter<string>(this.Factory, "ReviewDescription", item.ReviewDescription);
            comm.AddParameter<string>(this.Factory, "ReviewBody", item.ReviewBody);
            comm.AddParameter<string>(this.Factory, "ReviewSource", item.ReviewSource);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<int>(this.Factory, "ProductId", item.ProductId);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Culture", Culture);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Add(ProductReview item)
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
        public void Update(ProductReview @new, ProductReview old)
        {
            var item = @new;
            item.ProductId = old.ProductId;
            var comm = this.GetCommand("sp_ProductReview_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ReviewId", item.ReviewId);
            comm.AddParameter<string>(this.Factory, "ReviewTitle", item.ReviewTitle);
            comm.AddParameter<string>(this.Factory, "ReviewLogo", item.ReviewLogo);
            comm.AddParameter<string>(this.Factory, "ReviewKeyword", item.ReviewKeyword);
            comm.AddParameter<string>(this.Factory, "ReviewDescription", item.ReviewDescription);
            comm.AddParameter<string>(this.Factory, "ReviewBody", item.ReviewBody);
            comm.AddParameter<string>(this.Factory, "ReviewSource", item.ReviewSource);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "UpdateBy", item.UpdateBy);
            //comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            //comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(ProductReview item)
        {
            var comm = this.GetCommand("sp_ProductReview_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ReviewId", item.ReviewId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<ProductReview> GetAll(int startIndex, int lenght, ref int totalItem)
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

        //public List<Product> Search(int startIndex, int lenght, ref int totalItem, string culture)
        //{
        //    var comm = this.GetCommand("sp_ProductSearch");
        //    if (comm == null) return null;
        //    comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
        //    comm.AddParameter<string>(this.Factory, "Culture", culture);
        //    comm.AddParameter<int>(this.Factory, "Length", lenght);
        //    var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
        //    totalItemsParam.Direction = ParameterDirection.Output;
        //    var dt = this.GetTable(comm);
        //    if (totalItemsParam.Value != DBNull.Value)
        //    {
        //        totalItem = Convert.ToInt32(totalItemsParam.Value);
        //    }
        //    return EntityBase.ParseListFromTable<Product>(dt);
        //}

    }
}
