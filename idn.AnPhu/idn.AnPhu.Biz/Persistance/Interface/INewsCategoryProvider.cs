using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface INewsCategoryProvider : IDataProvider<NewsCategories>
    {
        List<NewsCategories> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<NewsCategoryBase> GetAllNewsCategory(string culture);
        List<NewsCategories> ListAllNewsCategory(string culture);
        void Add(NewsCategories model, string culture);
        NewsCategories GetByShortName(NewsCategories model, string culture);
    }
}
