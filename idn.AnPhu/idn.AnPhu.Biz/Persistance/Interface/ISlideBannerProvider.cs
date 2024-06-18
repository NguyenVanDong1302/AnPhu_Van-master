using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface ISlideBannerProvider : IDataProvider<SlideBanner>
    {
        void Add(SlideBanner model, string culture);
        List<SlideBanner> SelectTop(int topcount, string culture);
        List<SlideBanner> Search(int startIndex, int lenght, ref int totalItem, string culture);
    }
}
