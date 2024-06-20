using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using idn.AnPhu.Biz.Persistance.Interface;

namespace idn.AnPhu.Biz.Services
{
    public class VideoManager : DataManagerBase<Video>
    {
        public VideoManager()
            : base()
        { }

        public VideoManager(IDataProvider<Video> provider)
            : base(provider)
        {
        }

        private IVideoProvider VideoProvider
        {
            get { return (IVideoProvider)Provider; }
        }
        public List<Video> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return VideoProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public void Add(Video model, string Culture)
        {
            VideoProvider.Add(model, Culture);
        }
        public List<Video> GetListVideosByCateId(int catenewsid, int startIndex, int lenght, ref int totalItem, string culture)
        {
            return VideoProvider.GetListVideosByCateId(catenewsid, startIndex, lenght, ref totalItem, culture);
        }
    }
}
