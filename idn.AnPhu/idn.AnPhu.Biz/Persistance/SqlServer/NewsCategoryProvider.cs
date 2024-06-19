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
    public class NewsCategoryProvider : DataAccessBase, INewsCategoryProvider
    {
        public NewsCategories Get(NewsCategories dummy)
        {
            var comm = this.GetCommand("sp_NewsCategoryGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", dummy.NewsCategoryId);
            var dt = this.GetTable(comm);
            var htmlPageCate = EntityBase.ParseListFromTable<NewsCategories>(dt).FirstOrDefault();
            return htmlPageCate ?? null;
            //throw new NotImplementedException();
        }
        public NewsCategories GetByShortName(NewsCategories dummy, string culture)
        {
            var comm = this.GetCommand("sp_NewsCategoryGetByShortName");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<string>(this.Factory, "NewsCategoryShortName", dummy.NewsCategoryShortName);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var htmlPageCate = EntityBase.ParseListFromTable<NewsCategories>(dt).FirstOrDefault();
            return htmlPageCate ?? null;
            //throw new NotImplementedException();
        }
        public void Add(NewsCategories item, string Culture)
        {
            var comm = this.GetCommand("sp_NewsCategory_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "NewsCategoryTitle", item.NewsCategoryTitle);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "NewsCategoryShortName", item.NewsCategoryShortName);
            comm.AddParameter<string>(this.Factory, "NewsCategorySummary", item.NewsCategorySummary);
            comm.AddParameter<string>(this.Factory, "NewsCategoryDescription", item.NewsCategoryDescription);
            comm.AddParameter<string>(this.Factory, "NewsCategoryKeyword", item.NewsCategoryKeyword);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Culture", Culture);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Add(NewsCategories item)
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
        public void Update(NewsCategories @new, NewsCategories old)
        {
            var item = @new;
            item.NewsCategoryId = old.NewsCategoryId;
            var comm = this.GetCommand("sp_NewsCategory_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", item.NewsCategoryId);
            comm.AddParameter<string>(this.Factory, "NewsCategoryTitle", item.NewsCategoryTitle);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "NewsCategorySummary", item.NewsCategorySummary);
            comm.AddParameter<string>(this.Factory, "NewsCategoryDescription", item.NewsCategoryDescription);
            comm.AddParameter<string>(this.Factory, "NewsCategoryKeyword", item.NewsCategoryKeyword);
            comm.AddParameter<string>(this.Factory, "NewsCategoryShortName", item.NewsCategoryShortName);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            //comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            //comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public List<NewsCategories> GetAll(int startIndex, int lenght, ref int totalItem)
        {
            throw new NotImplementedException();
        }
        public void Remove(NewsCategories item)
        {
            //var comm = this.GetCommand("sp_HtmlPage_Delete");
            //if (comm == null) return;
            //comm.AddParameter<int>(this.Factory, "HtmlPageId", item.HtmlPageId);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }
        public List<NewsCategories> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_NewsCategorySearch");
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
            return EntityBase.ParseListFromTable<NewsCategories>(dt);
        }
        public List<NewsCategoryBase> GetAllNewsCategory(string culture)
        {
            //var comm = this.GetCommand("sp_NewsCategoryGetAll");
            //comm.AddParameter<string>(this.Factory, "Culture", culture);
            //if (comm == null) return null;
            //var dt = this.GetTable(comm);
            //var listGroupNews = EntityBase.ParseListFromTable<NewsCategories>(dt);
            //try
            //{
            //    var toGroupNewsTree = NewsCategoryExtensions.ToCategoryTree(GetHtmlPageCategoryBaseList(listGroupNews));
            //    var toFlatGroupNewsTree = NewsCategoryExtensions.ToFlatCategoryTree(toGroupNewsTree);
            //    return toFlatGroupNewsTree;
            //}
            //catch (Exception)
            //{

            //    //throw;
            //}
            return null;
            //throw new NotImplementedException();
        }
        public List<NewsCategories> ListAllNewsCategory(string culture)
        {
            var comm = this.GetCommand("sp_NewsCategoryGetAll");
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            var listGroupNews = EntityBase.ParseListFromTable<NewsCategories>(dt);

            return listGroupNews;
            //throw new NotImplementedException();
        }
        public static List<NewsCategoryBase> GetHtmlPageCategoryBaseList(List<NewsCategories> s)
        {
            var listPageBase = new List<NewsCategoryBase>();
            if (s != null)
            {
                listPageBase.AddRange(s.Cast<NewsCategoryBase>());
            }

            return listPageBase;
        }
    }
}
