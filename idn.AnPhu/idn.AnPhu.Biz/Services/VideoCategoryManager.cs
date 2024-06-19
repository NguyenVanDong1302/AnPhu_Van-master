using Client.Core.Data;
using System;
using System.Collections.Generic;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;

namespace idn.AnPhu.Biz.Services
{
    public class VideoCategoryManager : DataManagerBase<VideoCategory>
    {
        public VideoCategoryManager()
            : base()
        { }

        public VideoCategoryManager(IDataProvider<VideoCategory> provider)
            : base(provider)
        {
        }

        private IVideoCategoryProvider VideoCategoryProvider
        {
            get { return (IVideoCategoryProvider)Provider; }
        }
        public List<VideoCategory> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return VideoCategoryProvider.Search(startIndex, lenght, ref totalItem, culture);
        }

        public List<VideoCategoryBase> GetAllVideoCategory(string culture)
        {
            return VideoCategoryProvider.GetAllVideoCategory(culture);
        }
        public List<VideoCategory> ListAllVideoCategory(string culture)
        {
            return VideoCategoryProvider.ListAllVideoCategory(culture);
        }
        public void Add(VideoCategory model, string Culture)
        {
            VideoCategoryProvider.Add(model, Culture);
        }
        public VideoCategory GetByShortName(VideoCategory model, string Culture)
        {
            return VideoCategoryProvider.GetByShortName(model, Culture);
        }
    }
}
