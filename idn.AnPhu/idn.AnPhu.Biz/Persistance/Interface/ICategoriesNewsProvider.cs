using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
	interface ICategoriesNewsProvider : IImportableDataProvider<CategoriesNews>
	{
		List<CategoriesNews> Search(string txtSearch, int startIndex, int pageCount, ref int totalItems);

		CategoriesNews GetByShortName(string shortName);

		List<CategoriesNews> GetAllActive();
	}
}
