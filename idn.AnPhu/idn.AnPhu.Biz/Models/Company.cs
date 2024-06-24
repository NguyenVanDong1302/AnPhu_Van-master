using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
	public class Company : EntityBase
	{
		[DataColum]
		public int CompanyId { get; set; }

		[DataColum]
		public string CompanyName { get; set; }

		[DataColum]
		public string CompanyInfo { get; set; }

		[DataColum]
		public string CompanyHotline { get; set; }

		[DataColum]
		public string CompanyMail { get; set; }

		[DataColum]
		public string CompanyFace { get; set; }

		[DataColum]
		public string CompanyYoutube { get; set; }

		[DataColum]
		public string CompanyGoogle { get; set; }

		[DataColum]
		public string Culture { get; set; }

		[DataColum]
		public DateTime UpdateDate { get; set; }

		public string UpdateDateFormat
		{
			get
			{
				return UpdateDate == null ? "" : UpdateDate.ToString("dd/MM/yyyy");
			}
		}

		[DataColum]
		public string UpdateBy { get; set; }
	}
}
