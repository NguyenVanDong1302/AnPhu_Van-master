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
	public class HtmlPageCategoriesManager : DataManagerBase<HtmlPageCategories>
	{
		public HtmlPageCategoriesManager(IDataProvider<HtmlPageCategories> provider)
		   : base(provider)
		{
		}

		IHtmlPageCategoriesProvider HtmlPageCategoriesProvider
		{
			get
			{
				return (IHtmlPageCategoriesProvider)Provider;
			}
		}

		public List<HtmlPageCategories> GetAll()
		{
			int total = 0;
			return HtmlPageCategoriesProvider.GetAll(0, 0, ref total);
		}

		public HtmlPageCategories GetAllActiveByShortName(string shortname)
		{
			return HtmlPageCategoriesProvider.GetAllActiveByShortName(shortname);
		}

		public override void Add(HtmlPageCategories item)
		{
			base.Add(item);
		}
	}
}
