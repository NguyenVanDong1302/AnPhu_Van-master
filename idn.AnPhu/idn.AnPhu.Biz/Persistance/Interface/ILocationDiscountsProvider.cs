using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
	public interface ILocationDiscountsProvider : IDataProvider<LocationDiscounts>
	{
		void Add(LocationDiscounts model, string culture);
		List<LocationDiscounts> Search(int startIndex, int lenght, ref int totalItem, string culture);
		List<LocationDiscounts> GetAllActive(string culture);
	}
}
