using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
	public class AdBannerLefts : EntityBase
	{
		[DataColum]
		public int AdLeftId { get; set; }
		[DataColum]
		public string AdLeftName { get; set; }
		[DataColum]
		public string AdLeftImage { get; set; }
		[DataColum]
		public string AdLeftLink { get; set; }
		[DataColum]
		public bool IsActive { get; set; }
		[DataColum]
		public string Culture { get; set; }
	}
}
