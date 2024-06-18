using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IHtmlPageProvider : IDataProvider<HtmlPage>
    {
        List<HtmlPage> Search(int startIndex, int lenght, ref int totalItem, string culture);
        void Add(HtmlPage model, string culture);
        List<HtmlPage> GetHtmlPageByCateId(int Cateid, string culture);
        HtmlPage GetHtmlPageByShortName(HtmlPage model, string culture);
        HtmlPage HtmlPageGetByShortName(string shortname, string culture);
        List<HtmlPage> HtmlPageGetShortNameCate(int pageid);
    }
}
