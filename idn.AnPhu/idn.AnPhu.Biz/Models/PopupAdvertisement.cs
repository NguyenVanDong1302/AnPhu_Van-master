using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
	public class PopupAdvertisement : EntityBase
	{
		[DataColum]
		public int Id { get; set; }

		[DataColum]
		public string Image { get; set; }

		[DataColum]
		public string Link { get; set; }
	}
}
