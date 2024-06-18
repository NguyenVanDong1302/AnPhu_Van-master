using Client.Core.Data;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using idn.AnPhu.Biz.Models;

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


        public List<News> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return NewsProvider.Search(startIndex, lenght, ref totalItem, culture);
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
        public void Add(News model, string Culture)
        {
            NewsProvider.Add(model, Culture);
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
    }
}
