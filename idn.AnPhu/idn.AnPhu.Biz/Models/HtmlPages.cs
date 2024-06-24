using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
	public class HtmlPages : EntityBase
	{
		[DataColum]
		public int HtmlPageId { get; set; }

		[DataColum]
		public int HtmlPageCategoryId { get; set; }

		[DataColum]
		public string HtmlPageCategoryTitle { get; set; }

		[DataColum]
		public string HtmlPageTitle { get; set; }

		[DataColum]
		public string HtmlPageBody { get; set; }

		[DataColum]
		public string HtmlPageImage { get; set; }

		[DataColum]
		public string HtmlPageDescription { get; set; }

		[DataColum]
		public string HtmlPageKeyword { get; set; }

		[DataColum]
		public string HtmlPageShortName { get; set; }

		[DataColum]
		public string CreateBy { get; set; }

		[DataColum]
		public DateTime CreateDate { get; set; }

		[DataColum]
		public bool IsActive { get; set; }

		[DataColum]
		public int OrderNo { get; set; }

		[DataColum]
		public string Culture { get; set; }

		[DataColum]
		public string HtmlPageSummary { get; set; }
	}
}
