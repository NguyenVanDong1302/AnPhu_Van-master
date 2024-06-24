using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
	public class AdBannerLeftsManager : DataManagerBase<AdBannerLefts>
	{
		public AdBannerLeftsManager(IDataProvider<AdBannerLefts> provider)
		 : base(provider)
		{
		}

		IAdBannerLeftsProvider AdBannerLeftsProvider
		{
			get
			{
				return (IAdBannerLeftsProvider)Provider;
			}
		}

		public List<AdBannerLefts> GetAll()
		{
			int total = 0;
			return Provider.GetAll(0, 0, ref total);
		}
	}
}
