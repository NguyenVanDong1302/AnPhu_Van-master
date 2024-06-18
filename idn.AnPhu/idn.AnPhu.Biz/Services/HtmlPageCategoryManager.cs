using Client.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;

namespace idn.AnPhu.Biz.Services
{
    public class HtmlPageCategoryManager : DataManagerBase<HtmlPageCategory>
    {
        public HtmlPageCategoryManager()
            : base()
        { }

        public HtmlPageCategoryManager(IDataProvider<HtmlPageCategory> provider)
            : base(provider)
        {
        }

        private IHtmlPageCategoryProvider HtmlPageCategoryProvider
        {
            get { return (IHtmlPageCategoryProvider)Provider; }
        }
        public List<HtmlPageCategory> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return HtmlPageCategoryProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<HtmlPageCategoryBase> GetAllHtmlPageCategory(string culture)
        {
            return HtmlPageCategoryProvider.GetAllHtmlPageCategory(culture);
        }
        public List<HtmlPageCategoryBase> GetAllHtmlPageCategoryById(int id, string culture)
        {
            return HtmlPageCategoryProvider.GetAllHtmlPageCategoryById(id, culture);
        }
        public List<HtmlPageCategory> GetAllActiveByParentId(int parentid, string culture)
        {
            return HtmlPageCategoryProvider.GetAllActiveByParentId(parentid, culture);
        }
        public List<HtmlPageCategory> GetAllActiveByShortName(string parentid, string culture)
        {
            return HtmlPageCategoryProvider.GetAllActiveByShortName(parentid, culture);
        }
        public void Add(HtmlPageCategory model, string Culture)
        {
            HtmlPageCategoryProvider.Add(model, Culture);
        }
    }
}
