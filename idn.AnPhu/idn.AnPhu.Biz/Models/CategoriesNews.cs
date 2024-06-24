using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
	public class CategoriesNews : EntityBase
	{
		[DataColum]
		//[DataColumEx("UserCode")]
		public int NewsCategoryId { get; set; }

		[DataColum]
		//[DataColumEx("UserCode")]
		public int ParentId { get; set; }

		[DataColum]
		public string NewsCategoryTitle { get; set; }

		[DataColum]
		public string NewsCategoryShortName { get; set; }

		[DataColum]
		public string NewsCategorySummary { get; set; }

		[DataColum]
		public string NewsCategoryDescription { get; set; }

		[DataColum]
		public string NewsCategoryKeyword { get; set; }

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
