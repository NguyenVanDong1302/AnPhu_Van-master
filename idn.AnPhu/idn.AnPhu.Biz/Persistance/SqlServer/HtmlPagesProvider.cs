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
	public class HtmlPagesProvider : DataAccessBase, IHtmlPagesProvider
	{
		public HtmlPages Get(HtmlPages dummy)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPages_GetById");

			comm.AddParameter<int>(this.Factory, "HtmlPageId", dummy.HtmlPageId);

			var table = this.GetTable(comm);
			table.TableName = TableName.HtmlPages;
			return EntityBase.ParseListFromTable<HtmlPages>(table).FirstOrDefault();
		}

		public HtmlPages GetByShortName(string shortName)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPages_GetByShortName");

			comm.AddParameter<string>(this.Factory, "shortName", shortName);

			var table = this.GetTable(comm);
			table.TableName = TableName.HtmlPages;
			return EntityBase.ParseListFromTable<HtmlPages>(table).FirstOrDefault();
		}

		public List<HtmlPages> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPages_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.HtmlPages;

			return EntityBase.ParseListFromTable<HtmlPages>(table);
		}

		public List<HtmlPages> GetHtmlPageByCateId(int id)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPages_GetHtmlPageByCateId");
			comm.AddParameter<int>(this.Factory, "id", id);

			var table = this.GetTable(comm);
			table.TableName = TableName.HtmlPages;

			return EntityBase.ParseListFromTable<HtmlPages>(table);
		}

		public void Add(HtmlPages item)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPages_Create");
			comm.AddParameter<string>(this.Factory, "HtmlPageTitle", (item.HtmlPageTitle != null && item.HtmlPageTitle.Trim().Length > 0) ? item.HtmlPageTitle.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageShortName", (item.HtmlPageShortName != null && item.HtmlPageShortName.Trim().Length > 0) ? item.HtmlPageShortName.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageBody", (item.HtmlPageBody != null && item.HtmlPageBody.Trim().Length > 0) ? item.HtmlPageBody.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageImage", (item.HtmlPageImage != null && item.HtmlPageImage.Trim().Length > 0) ? item.HtmlPageImage.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageDescription", (item.HtmlPageDescription != null && item.HtmlPageDescription.Trim().Length > 0) ? item.HtmlPageDescription.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageKeyword", (item.HtmlPageKeyword != null && item.HtmlPageKeyword.Trim().Length > 0) ? item.HtmlPageKeyword.Trim() : "");
			comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<int>(this.Factory, "HtmlPageCategoryId", item.HtmlPageCategoryId);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageSummary", (item.HtmlPageSummary != null && item.HtmlPageSummary.Trim().Length > 0) ? item.HtmlPageSummary.Trim() : null);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(HtmlPages @new, HtmlPages old)
		{
			var item = @new;
			item.HtmlPageId = old.HtmlPageId;
			var comm = this.GetCommand("Sp_HtmlPages_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "HtmlPageId", item.HtmlPageId);
			comm.AddParameter<string>(this.Factory, "HtmlPageTitle", (item.HtmlPageTitle != null && item.HtmlPageTitle.Trim().Length > 0) ? item.HtmlPageTitle.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageShortName", (item.HtmlPageShortName != null && item.HtmlPageShortName.Trim().Length > 0) ? item.HtmlPageShortName.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageBody", (item.HtmlPageBody != null && item.HtmlPageBody.Trim().Length > 0) ? item.HtmlPageBody.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageImage", (item.HtmlPageImage != null && item.HtmlPageImage.Trim().Length > 0) ? item.HtmlPageImage.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageDescription", (item.HtmlPageDescription != null && item.HtmlPageDescription.Trim().Length > 0) ? item.HtmlPageDescription.Trim() : "");
			comm.AddParameter<string>(this.Factory, "HtmlPageKeyword", (item.HtmlPageKeyword != null && item.HtmlPageKeyword.Trim().Length > 0) ? item.HtmlPageKeyword.Trim() : "");
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<int>(this.Factory, "HtmlPageCategoryId", item.HtmlPageCategoryId);
			comm.AddParameter<string>(this.Factory, "HtmlPageSummary", (item.HtmlPageSummary != null && item.HtmlPageSummary.Trim().Length > 0) ? item.HtmlPageSummary.Trim() : null);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(HtmlPages item)
		{
			var comm = this.GetCommand("Sp_HtmlPages_Delete");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "HtmlPageId", item.HtmlPageId);
			this.SafeExecuteNonQuery(comm);
		}

		public void Import(List<HtmlPages> list, bool deleteExist)
		{
		}
	}
}
