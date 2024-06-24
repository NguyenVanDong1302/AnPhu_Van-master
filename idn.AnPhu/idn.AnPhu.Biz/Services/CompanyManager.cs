using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Biz.Persistance.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
	public class CompanyManager : DataManagerBase<Company>
	{
		public CompanyManager(IDataProvider<Company> provider)
		 : base(provider)
		{
		}

		ICompanyProvider CompanyProvider
		{
			get
			{
				return (ICompanyProvider)Provider;
			}
		}

		public List<Company> GetAll()
		{
			int total = 0;
			return Provider.GetAll(0, 0, ref total);
		}
	}
}
