using idn.AnPhu.Biz.Models;
using Client.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface INewsProvider : IDataProvider<News>
    {
        List<News> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<News> GetListNewsByCateNewsId(int catenewsid, int startIndex, int lenght, ref int totalItem, string culture);
        void Add(News model, string culture);
        List<News> GetByCateId(int categoryid, int topcount, string culture);
        List<News> GetHotNewsTop(int topcount, string culture);
        List<News> GetAdsNewsTop(int topcount, string culture);
        News GetDetail(News model);
        List<News> GetOtherNews(int newsid, string culture);
        List<News> GetByCateShortName(int newsid, string culture, string shortname);
        List<News> GetAllActive(int startIndex, int lenght, ref int totalItem, string culture);
    }
}
