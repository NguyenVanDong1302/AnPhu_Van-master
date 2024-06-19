using Client.Core.Data;
using idn.AnPhu.Biz.Models;
//using ind.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using idn.AnPhu.Biz.Persistance.Interface;


namespace idn.AnPhu.Biz.Services
{
    public class NewsCategoryManager : DataManagerBase<NewsCategories>
    {
        public NewsCategoryManager()
            : base()
        { }

        public NewsCategoryManager(IDataProvider<NewsCategories> provider)
            : base(provider)
        {
        }

        private INewsCategoryProvider NewsCategoryProvider
        {
            get { return (INewsCategoryProvider)Provider; }
        }
        public List<NewsCategories> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return NewsCategoryProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<NewsCategoryBase> GetAllNewsCategory(string culture)
        {
            return NewsCategoryProvider.GetAllNewsCategory(culture);
        }
        public List<NewsCategories> ListAllNewsCategory(string culture)
        {
            return NewsCategoryProvider.ListAllNewsCategory(culture);
        }
        public void Add(NewsCategories model, string Culture)
        {
            NewsCategoryProvider.Add(model, Culture);
        }
        public NewsCategories GetByShortName(NewsCategories model, string Culture)
        {
            return NewsCategoryProvider.GetByShortName(model, Culture);
        }
    }
}
