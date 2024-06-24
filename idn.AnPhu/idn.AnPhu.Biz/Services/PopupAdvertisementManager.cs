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
	public class PopupAdvertisementManager : DataManagerBase<PopupAdvertisement>
	{
		public PopupAdvertisementManager(IDataProvider<PopupAdvertisement> provider)
			: base(provider)
		{
		}

		IPopupAdvertisementProvider PopupAdvertisementProvider
		{
			get
			{
				return (IPopupAdvertisementProvider)Provider;
			}
		}

		public List<PopupAdvertisement> GetAll()
		{
			int total = 0;
			return Provider.GetAll(0, 0, ref total);
		}
	}
}
