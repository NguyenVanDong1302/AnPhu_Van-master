using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
	public class AdBannerRights : EntityBase
	{
		[DataColum]
		public int AdRightId { get; set; }
		[DataColum]
		public string AdRightName { get; set; }
		[DataColum]
		public string AdRightImage { get; set; }
		[DataColum]
		public string AdRightLink { get; set; }
		[DataColum]
		public bool IsActive { get; set; }
		[DataColum]
		public string Culture { get; set; }
	}
}
