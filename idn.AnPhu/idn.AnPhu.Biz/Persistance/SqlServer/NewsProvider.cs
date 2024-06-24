using idn.AnPhu.Biz.Models;
using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using idn.AnPhu.Constants;
using System.Data.Common;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class NewsProvider : DataAccessBase, INewsProvider
    {
        public News Get(News dummy)
        {
            var comm = this.GetCommand("sp_NewsGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "NewsId", dummy.NewsId);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<News>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public News GetDetail(News dummy)
        {
            var comm = this.GetCommand("sp_NewsGetDetail");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "NewsId", dummy.NewsId);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<News>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public void Add(News item, string Culture)
        {
            var comm = this.GetCommand("sp_News_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "NewsTitle", item.NewsTitle);
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", item.NewsCategoryId);
            comm.AddParameter<string>(this.Factory, "NewsShortName", item.NewsShortName);
            comm.AddParameter<string>(this.Factory, "NewsSummary", item.NewsSummary);
            comm.AddParameter<string>(this.Factory, "NewsDescription", item.NewsDescription);
            comm.AddParameter<string>(this.Factory, "NewsKeyword", item.NewsKeyword);
            comm.AddParameter<string>(this.Factory, "NewsBody", item.NewsBody);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<bool>(this.Factory, "IsHotNews", item.IsHotNews);
            comm.AddParameter<bool>(this.Factory, "IsAdsNews", item.IsAdsNews);
            comm.AddParameter<DateTime>(this.Factory, "PublishDate", item.PublishDate);
            comm.AddParameter<string>(this.Factory, "NewsImage", item.NewsImage);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Culture", Culture);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Add(News item)
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
        public void Update(News @new, News old)
        {
            var item = @new;
            item.NewsId = old.NewsId;
            var comm = this.GetCommand("sp_News_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsId", item.NewsId);
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", item.NewsCategoryId);
            comm.AddParameter<string>(this.Factory, "NewsTitle", item.NewsTitle);
            comm.AddParameter<string>(this.Factory, "NewsShortName", item.NewsShortName);
            comm.AddParameter<string>(this.Factory, "NewsSummary", item.NewsSummary);
            comm.AddParameter<string>(this.Factory, "NewsDescription", item.NewsDescription);
            comm.AddParameter<string>(this.Factory, "NewsKeyword", item.NewsKeyword);
            comm.AddParameter<string>(this.Factory, "NewsBody", item.NewsBody);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<bool>(this.Factory, "IsAdsNews", item.IsAdsNews);
            comm.AddParameter<bool>(this.Factory, "IsHotNews", item.IsHotNews);
            comm.AddParameter<DateTime>(this.Factory, "PublishDate", item.PublishDate);
            comm.AddParameter<string>(this.Factory, "NewsImage", item.NewsImage);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(News item)
        {
            var comm = this.GetCommand("sp_News_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "NewsId", item.NewsId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<News> GetAll(int startIndex, int lenght, ref int totalItem)
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

        public List<News> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_News_Search");
            comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.News;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<News>(table);
        }

        public List<News> GetByCateId(int categoryid, int topcount, string culture)
        {
            var comm = this.GetCommand("sp_NewsGetByCateId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", categoryid);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);

            return EntityBase.ParseListFromTable<News>(dt);
        }
        public List<News> GetHotNewsTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_NewsGetHot");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);

            return EntityBase.ParseListFromTable<News>(dt);
        }
        public List<News> GetAdsNewsTop(int topcount, string culture)
        {
            var comm = this.GetCommand("sp_NewsGetIsAds");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);

            return EntityBase.ParseListFromTable<News>(dt);
        }
        public List<News> GetByCateShortName(int topcount, string culture, string shortname)
        {
            var comm = this.GetCommand("sp_NewsGetByCateShortName");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<string>(this.Factory, "NewsCategoryShortName", shortname);
            comm.AddParameter<int>(this.Factory, "TopCount", topcount);
            var dt = this.GetTable(comm);

            return EntityBase.ParseListFromTable<News>(dt);
        }
        public List<News> GetOtherNews(int newsid, string culture)
        {
            var comm = this.GetCommand("sp_NewsGetOther");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "NewsId", newsid);
            var dt = this.GetTable(comm);

            return EntityBase.ParseListFromTable<News>(dt);
        }
        public List<News> GetListNewsByCateNewsId(int catenewsid, int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_NewsSearchByCateId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "NewsCategoryId", catenewsid);
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);
            //throw new NotImplementedException();
        }
        public List<News> GetAllActive(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_NewsGetAllActive");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<News>(dt);
            //throw new NotImplementedException();
        }

        public List<News> SearchUsersSide(int newsCategoryId, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_News_SearchByCate");
            comm.AddParameter<int>(this.Factory, "newsCategoryId", newsCategoryId);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);

            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.News;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }

            return EntityBase.ParseListFromTable<News>(table);
        }

        public List<News> GetHot(int top)
        {
            DbCommand comm = this.GetCommand("Sp_News_GetHot");
            comm.AddParameter<int>(this.Factory, "top", top);
            var table = this.GetTable(comm);
            table.TableName = TableName.News;

            return EntityBase.ParseListFromTable<News>(table);
        }

        public List<News> SearchNewsOther(string search)
        {
            DbCommand comm = this.GetCommand("Sp_News_SearchNewsOther");
            comm.AddParameter<string>(this.Factory, "search", (search != null && search.Trim().Length > 0) ? search : null);

            var table = this.GetTable(comm);
            table.TableName = TableName.News;
            return EntityBase.ParseListFromTable<News>(table);
        }

    }
}
