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
	public class AdBannerRightsManager : DataManagerBase<AdBannerRights>
	{
		public AdBannerRightsManager(IDataProvider<AdBannerRights> provider)
		  : base(provider)
		{
		}

		IAdBannerRightsProvider AdBannerRightsProvider
		{
			get
			{
				return (IAdBannerRightsProvider)Provider;
			}
		}

		public List<AdBannerRights> GetAll()
		{
			int total = 0;
			return Provider.GetAll(0, 0, ref total);
		}

	}
}
