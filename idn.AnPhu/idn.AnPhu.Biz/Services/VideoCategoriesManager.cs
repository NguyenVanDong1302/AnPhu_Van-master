using Client.Core.Data;
using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
	public class VideoCategoriesManager : DataManagerBase<VideoCategories>
	{
		public VideoCategoriesManager(IDataProvider<VideoCategories> provider)
		  : base(provider)
		{
		}

		IVideoCategoriesProvider VideoCategoriesProvider
		{
			get
			{
				return (IVideoCategoriesProvider)Provider;
			}
		}

		public List<VideoCategories> GetAll()
		{
			int total = 0;
			return Provider.GetAll(0, 0, ref total);
		}

		public override void Add(VideoCategories item)
		{
			item.IsActive = true;
			base.Add(item);
		}
	}
}
