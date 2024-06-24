using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
	public class SlideBanners : EntityBase
	{
		[DataColum]
		public int SlideBannerId { get; set; }

		[DataColum]
		public string Url { get; set; }

		[DataColum]
		public string Image { get; set; }

		[DataColum]
		public bool IsActive { get; set; }

		[DataColum]
		public DateTime CreateDate { get; set; }

		public string CreateDateFormat
		{
			get
			{
				return CreateDate == null ? "" : CreateDate.ToString("dd/MM/yyyy");
			}
		}

		[DataColum]
		public DateTime UpdateDate { get; set; }

		[DataColum]
		public int OrderNo { get; set; }

		[DataColum]
		public string CreateBy { get; set; }

		[DataColum]
		public string SlideTitle { get; set; }

		[DataColum]
		public string SlideDescription1 { get; set; }

		[DataColum]
		public string SlideDescription2 { get; set; }

		[DataColum]
		public string Color { get; set; }

		[DataColum]
		public string Position { get; set; }

		[DataColum]
		public string Culture { get; set; }
	}
}
