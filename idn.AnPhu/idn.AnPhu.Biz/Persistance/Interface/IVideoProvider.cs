using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IVideoProvider : IDataProvider<Video>
    {
        List<Video> Search(int startIndex, int lenght, ref int totalItem, string culture);
        void Add(Video model, string culture);
        List<Video> GetListVideosByCateId(int cateid, int startIndex, int lenght, ref int totalItem, string culture);
    }
}
