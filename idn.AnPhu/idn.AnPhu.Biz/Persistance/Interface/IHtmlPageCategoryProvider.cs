using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IHtmlPageCategoryProvider : IDataProvider<HtmlPageCategory>
    {
        List<HtmlPageCategory> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<HtmlPageCategoryBase> GetAllHtmlPageCategory(string culture);
        void Add(HtmlPageCategory model, string culture);
        List<HtmlPageCategoryBase> GetAllHtmlPageCategoryById(int id, string culture);
        List<HtmlPageCategory> GetAllActiveByParentId(int parentid, string culture);
        List<HtmlPageCategory> GetAllActiveByShortName(string parentshortname, string culture);
    }
}
