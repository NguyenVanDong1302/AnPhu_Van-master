using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
	public class HtmlPageCategoriesProvider : DataAccessBase, IHtmlPageCategoriesProvider
	{
		public HtmlPageCategories Get(HtmlPageCategories dummy)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPageCategories_GetById");

			comm.AddParameter<int>(this.Factory, "HtmlPageCategoryId", dummy.HtmlPageCategoryId);

			var table = this.GetTable(comm);
			table.TableName = TableName.HtmlPageCategories;
			return EntityBase.ParseListFromTable<HtmlPageCategories>(table).FirstOrDefault();
		}

		public List<HtmlPageCategories> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPageCategories_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.HtmlPageCategories;

			return EntityBase.ParseListFromTable<HtmlPageCategories>(table);
		}

		public HtmlPageCategories GetAllActiveByShortName(string shortname)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPageCategories_GetAllActiveByShortName");

			comm.AddParameter<string>(this.Factory, "shortname", shortname);

			var table = this.GetTable(comm);
			table.TableName = TableName.HtmlPageCategories;

			return EntityBase.ParseListFromTable<HtmlPageCategories>(table).FirstOrDefault();
		}

		public void Add(HtmlPageCategories item)
		{
			DbCommand comm = this.GetCommand("Sp_HtmlPageCategories_Create");

			comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategoryTitle", (item.HtmlPageCategoryTitle != null && item.HtmlPageCategoryTitle.Trim().Length > 0) ? item.HtmlPageCategoryTitle.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategoryShortName", (item.HtmlPageCategoryShortName != null && item.HtmlPageCategoryShortName.Trim().Length > 0) ? item.HtmlPageCategoryShortName.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategorySummary", (item.HtmlPageCategorySummary != null && item.HtmlPageCategorySummary.Trim().Length > 0) ? item.HtmlPageCategorySummary.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategoryDescription", (item.HtmlPageCategoryDescription != null && item.HtmlPageCategoryDescription.Trim().Length > 0) ? item.HtmlPageCategoryDescription.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategoryKeyword", (item.HtmlPageCategoryKeyword != null && item.HtmlPageCategoryKeyword.Trim().Length > 0) ? item.HtmlPageCategoryKeyword.Trim() : null);
			comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(HtmlPageCategories @new, HtmlPageCategories old)
		{
			var item = @new;
			item.HtmlPageCategoryId = old.HtmlPageCategoryId;
			var comm = this.GetCommand("Sp_HtmlPageCategories_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "HtmlPageCategoryId", item.HtmlPageCategoryId);
			comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategoryTitle", (item.HtmlPageCategoryTitle != null && item.HtmlPageCategoryTitle.Trim().Length > 0) ? item.HtmlPageCategoryTitle.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategoryShortName", (item.HtmlPageCategoryShortName != null && item.HtmlPageCategoryShortName.Trim().Length > 0) ? item.HtmlPageCategoryShortName.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategorySummary", (item.HtmlPageCategorySummary != null && item.HtmlPageCategorySummary.Trim().Length > 0) ? item.HtmlPageCategorySummary.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategoryDescription", (item.HtmlPageCategoryDescription != null && item.HtmlPageCategoryDescription.Trim().Length > 0) ? item.HtmlPageCategoryDescription.Trim() : null);
			comm.AddParameter<string>(this.Factory, "HtmlPageCategoryKeyword", (item.HtmlPageCategoryKeyword != null && item.HtmlPageCategoryKeyword.Trim().Length > 0) ? item.HtmlPageCategoryKeyword.Trim() : null);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(HtmlPageCategories item)
		{

		}

		public void Import(List<HtmlPageCategories> list, bool deleteExist)
		{
		}
	}
}
