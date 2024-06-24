using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Constants;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
	public class CompanyProvider : DataAccessBase, ICompanyProvider
	{
		public Company Get(Company dummy)
		{
			DbCommand comm = this.GetCommand("Sp_Company_GetById");

			comm.AddParameter<int>(this.Factory, "CompanyId", dummy.CompanyId);

			var table = this.GetTable(comm);
			table.TableName = TableName.Company;
			return EntityBase.ParseListFromTable<Company>(table).FirstOrDefault();
		}

		public List<Company> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_Company_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.Company;

			return EntityBase.ParseListFromTable<Company>(table);
		}

		public List<Company> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
		{
			return null;
		}

		public void Add(Company item)
		{
		}

		public void Update(Company @new, Company old)
		{
			var item = @new;
			item.CompanyId = old.CompanyId;
			var comm = this.GetCommand("Sp_Company_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "CompanyId", item.CompanyId);
			comm.AddParameter<string>(this.Factory, "CompanyName", (item.CompanyName != null && item.CompanyName.Trim().Length > 0) ? item.CompanyName.Trim() : "");
			comm.AddParameter<string>(this.Factory, "CompanyInfo", (item.CompanyInfo != null && item.CompanyInfo.Trim().Length > 0) ? item.CompanyInfo.Trim() : null);
			comm.AddParameter<string>(this.Factory, "CompanyHotline", (item.CompanyHotline != null && item.CompanyHotline.Trim().Length > 0) ? item.CompanyHotline.Trim() : null);
			comm.AddParameter<string>(this.Factory, "UpdateBy", (item.UpdateBy != null && item.UpdateBy.Trim().Length > 0) ? item.UpdateBy.Trim() : null);
			comm.AddParameter<string>(this.Factory, "CompanyMail", (item.CompanyMail != null && item.CompanyMail.Trim().Length > 0) ? item.CompanyMail.Trim() : null);
			comm.AddParameter<string>(this.Factory, "CompanyFace", (item.CompanyFace != null && item.CompanyFace.Trim().Length > 0) ? item.CompanyFace.Trim() : null);
			comm.AddParameter<string>(this.Factory, "CompanyYoutube", (item.CompanyYoutube != null && item.CompanyYoutube.Trim().Length > 0) ? item.CompanyYoutube.Trim() : null);
			comm.AddParameter<string>(this.Factory, "CompanyGoogle", (item.CompanyGoogle != null && item.CompanyGoogle.Trim().Length > 0) ? item.CompanyGoogle.Trim() : null);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(Company item)
		{
		}

		public void Import(List<Company> list, bool deleteExist)
		{
		}
	}
}
