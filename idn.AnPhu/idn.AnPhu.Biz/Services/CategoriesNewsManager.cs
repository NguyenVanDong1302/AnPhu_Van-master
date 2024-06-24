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
	public class CategoriesNewsManager : DataManagerBase<CategoriesNews>
	{
		public CategoriesNewsManager(IDataProvider<CategoriesNews> provider)
		   : base(provider)
		{
		}

		ICategoriesNewsProvider CategoriesNewsProvider
		{
			get
			{
				return (ICategoriesNewsProvider)Provider;
			}
		}

		public List<CategoriesNews> GetAll()
		{
			int total = 0;
			return CategoriesNewsProvider.GetAll(0, 0, ref total);
		}

		public CategoriesNews GetByShortName(string shortName)
		{
			return CategoriesNewsProvider.GetByShortName(shortName);
		}

		public List<CategoriesNews> GetAllActive()
		{
			return CategoriesNewsProvider.GetAllActive();
		}

		public override void Add(CategoriesNews item)
		{
			item.IsActive = true;
			base.Add(item);
		}

		public PageInfo<CategoriesNews> Search(string txtSearch, int pageIndex, int pageSize)
		{
			int totalItems = 0;
			var pageInfo = new PageInfo<CategoriesNews>(pageIndex, pageSize);
			var startIndex = (pageIndex - 1) * pageSize;
			pageInfo.DataList = CategoriesNewsProvider.Search(txtSearch, startIndex, pageSize, ref totalItems);
			pageInfo.ItemCount = totalItems;
			return pageInfo;
		}
	}
}
