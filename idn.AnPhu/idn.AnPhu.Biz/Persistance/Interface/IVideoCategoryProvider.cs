using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IVideoCategoryProvider : IDataProvider<VideoCategory>
    {
        List<VideoCategory> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<VideoCategoryBase> GetAllVideoCategory(string culture);
        List<VideoCategory> ListAllVideoCategory(string culture);
        void Add(VideoCategory model, string culture);
        VideoCategory GetByShortName(VideoCategory model, string culture);
    }
}
