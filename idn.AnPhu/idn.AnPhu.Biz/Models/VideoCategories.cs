using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
	public class VideoCategories : EntityBase
	{
		[DataColum]
		public int VideoCategoryId { get; set; }

		[DataColum]
		public int ParentId { get; set; }

		[DataColum]
		public string VideoCategoryTitle { get; set; }

		[DataColum]
		public string VideoCategoryShortName { get; set; }

		[DataColum]
		public string VideoCategorySummary { get; set; }

		[DataColum]
		public string VideoCategoryDescription { get; set; }

		[DataColum]
		public string VideoCategoryKeyword { get; set; }

		[DataColum]
		public DateTime CreateDate { get; set; }

		[DataColum]
		public string CreateBy { get; set; }

		[DataColum]
		public bool IsActive { get; set; }

		[DataColum]
		public int OrderNo { get; set; }

		[DataColum]
		public string Culture { get; set; }

	}
}
