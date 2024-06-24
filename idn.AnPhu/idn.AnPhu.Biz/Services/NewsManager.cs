using Client.Core.Data;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using idn.AnPhu.Biz.Models;
using Client.Core.Data.Entities.Paging;

namespace idn.AnPhu.Biz.Services
{
    public class NewsManager : DataManagerBase<News>
    {
        public NewsManager()
            : base()
        { }

        public NewsManager(IDataProvider<News> provider)
            : base(provider)
        {
        }

        private INewsProvider NewsProvider
        {
            get { return (INewsProvider)Provider; }
        }


        public PageInfo<News> Search(string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<News>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;
            pageInfo.DataList = NewsProvider.Search(txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }
        public List<News> GetListNewsByCateNewsId(int catenewsid, int startIndex, int lenght, ref int totalItem, string culture)
        {
            return NewsProvider.GetListNewsByCateNewsId(catenewsid, startIndex, lenght, ref totalItem, culture);
        }
        public List<News> GetByCateId(int categoryid, int topcount, string culture)
        {
            return NewsProvider.GetByCateId(categoryid, topcount, culture);
        }
        public List<News> GetHotNewsTop(int topcount, string culture)
        {
            return NewsProvider.GetHotNewsTop(topcount, culture);
        }
        public List<News> GetAdsNewsTop(int topcount, string culture)
        {
            return NewsProvider.GetAdsNewsTop(topcount, culture);
        }

        public News GetDetail(News model)
        {
            return NewsProvider.GetDetail(model);
        }

        public void Add(News item)
        {
            item.IsActive = true;
            base.Add(item);
        }

        public List<News> GetOtherNews(int newsid, string culture)
        {
            return NewsProvider.GetOtherNews(newsid, culture);
        }
        public List<News> GetByCateShortName(int newsid, string culture, string shortname)
        {
            return NewsProvider.GetByCateShortName(newsid, culture, shortname);
        }
        public List<News> GetAllActive(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return NewsProvider.GetAllActive(startIndex, lenght, ref totalItem, culture);
        }

        public List<News> GetAll()
        {
            int total = 0;
            return Provider.GetAll(0, 0, ref total);
        }

        public List<News> GetHot(int top)
        {
            return NewsProvider.GetHot(top);
        }

   

        public PageInfo<News> SearchUsersSide(int newsCategoryId, int page)
        {
            var pageSize = 6;
            int totalItems = 0;
            var pageInfo = new PageInfo<News>(page, pageSize);
            var startIndex = page * pageSize;
            pageInfo.DataList = NewsProvider.SearchUsersSide(newsCategoryId, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
            //return NewsProvider.SearchUsersSide(newsCategoryId, page, pageSize, ref totalItems);
        }

        public List<News> SearchNewsOther(string search)
        {
            return NewsProvider.SearchNewsOther(search);
        }
    }
}
