using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
	interface IHtmlPagesProvider : IImportableDataProvider<HtmlPages>
	{
		List<HtmlPages> GetHtmlPageByCateId(int id);

		HtmlPages GetByShortName(string shortName);
	}

}
