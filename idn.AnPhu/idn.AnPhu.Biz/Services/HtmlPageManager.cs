using Client.Core.Data;
using System;
using System.Collections.Generic;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;

namespace idn.AnPhu.Biz.Services
{
    public class HtmlPageManager : DataManagerBase<HtmlPage>
    {
        public HtmlPageManager()
            : base()
        { }

        public HtmlPageManager(IDataProvider<HtmlPage> provider)
            : base(provider)
        {
        }

        private IHtmlPageProvider HtmlPageProvider
        {
            get { return (IHtmlPageProvider)Provider; }
        }


        public List<HtmlPage> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return HtmlPageProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
        public List<HtmlPage> GetHtmlPageByCateId(int cateid, string culture)
        {
            return HtmlPageProvider.GetHtmlPageByCateId(cateid, culture);
        }
        public HtmlPage GetHtmlPageByShortName(HtmlPage model, string culture)
        {
            return HtmlPageProvider.GetHtmlPageByShortName(model, culture);
        }

        public HtmlPage HtmlPageGetByShortName(string shortname, string culture)
        {
            return HtmlPageProvider.HtmlPageGetByShortName(shortname, culture);
        }
        public List<HtmlPage> HtmlPageGetShortNameCate(int pageid)
        {
            return HtmlPageProvider.HtmlPageGetShortNameCate(pageid);
        }
        public void Add(HtmlPage model, string Culture)
        {
            HtmlPageProvider.Add(model, Culture);
        }
    }
}
