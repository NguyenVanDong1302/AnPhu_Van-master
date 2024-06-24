using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Constants;
using idn.AnPhu.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
	public class CategoriesNewsProvider : DataAccessBase, ICategoriesNewsProvider
	{
		public CategoriesNews Get(CategoriesNews dummy)
		{
			DbCommand comm = this.GetCommand("Sp_CategoriesNews_GetById");

			comm.AddParameter<int>(this.Factory, "newsCategoryId", dummy.NewsCategoryId);

			var table = this.GetTable(comm);
			table.TableName = TableName.CategoriesNews;
			return EntityBase.ParseListFromTable<CategoriesNews>(table).FirstOrDefault();
		}

		public CategoriesNews GetByShortName(string shortName)
		{
			DbCommand comm = this.GetCommand("Sp_CategoriesNews_GetByShortName");

			comm.AddParameter<string>(this.Factory, "shortName", shortName);

			var table = this.GetTable(comm);
			table.TableName = TableName.CategoriesNews;
			return EntityBase.ParseListFromTable<CategoriesNews>(table).FirstOrDefault();
		}

		public List<CategoriesNews> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_CategoriesNews_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.CategoriesNews;

			return EntityBase.ParseListFromTable<CategoriesNews>(table);
		}

		public List<CategoriesNews> GetAllActive()
		{
			DbCommand comm = this.GetCommand("Sp_CategoriesNews_GetAllActive");

			var table = this.GetTable(comm);
			table.TableName = TableName.CategoriesNews;

			return EntityBase.ParseListFromTable<CategoriesNews>(table);
		}

		public List<CategoriesNews> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_CategoriesNews_Search");
			comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
			comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "count", pageSize);

			DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;

			var table = this.GetTable(comm);
			table.TableName = TableName.CategoriesNews;

			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItems = Convert.ToInt32(totalItemsParam.Value);
			}
			return EntityBase.ParseListFromTable<CategoriesNews>(table);
		}

		public void Add(CategoriesNews item)
		{
			DbCommand comm = this.GetCommand("Sp_CategoriesNews_Create");

			comm.AddParameter<int>(this.Factory, "parentId", item.ParentId);
			comm.AddParameter<string>(this.Factory, "newsCategoryTitle", (item.NewsCategoryTitle != null && item.NewsCategoryTitle.Trim().Length > 0) ? item.NewsCategoryTitle.Trim() : null);
			comm.AddParameter<string>(this.Factory, "newsCategoryShortName", (item.NewsCategoryShortName != null && item.NewsCategoryShortName.Trim().Length > 0) ? item.NewsCategoryShortName.Trim() : null);
			comm.AddParameter<string>(this.Factory, "newsCategorySummary", (item.NewsCategorySummary != null && item.NewsCategorySummary.Trim().Length > 0) ? item.NewsCategorySummary.Trim() : null);
			comm.AddParameter<string>(this.Factory, "newsCategoryDescription", (item.NewsCategoryDescription != null && item.NewsCategoryDescription.Trim().Length > 0) ? item.NewsCategoryDescription.Trim() : null);
			comm.AddParameter<string>(this.Factory, "newsCategoryKeyword", (item.NewsCategoryKeyword != null && item.NewsCategoryKeyword.Trim().Length > 0) ? item.NewsCategoryKeyword.Trim() : null);
			comm.AddParameter<string>(this.Factory, "createBy", item.CreateBy);
			comm.AddParameter<bool>(this.Factory, "isActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "orderNo", item.OrderNo);
			comm.AddParameter<string>(this.Factory, "culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(CategoriesNews @new, CategoriesNews old)
		{
			var item = @new;
			item.NewsCategoryId = old.NewsCategoryId;
			var comm = this.GetCommand("Sp_CategoriesNews_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "CategoriesNewsId", item.NewsCategoryId);
			comm.AddParameter<int>(this.Factory, "parentId", item.ParentId);
			comm.AddParameter<string>(this.Factory, "newsCategoryTitle", (item.NewsCategoryTitle != null && item.NewsCategoryTitle.Trim().Length > 0) ? item.NewsCategoryTitle.Trim() : null);
			comm.AddParameter<string>(this.Factory, "newsCategoryShortName", (item.NewsCategoryShortName != null && item.NewsCategoryShortName.Trim().Length > 0) ? item.NewsCategoryShortName.Trim() : null);
			comm.AddParameter<string>(this.Factory, "newsCategorySummary", (item.NewsCategorySummary != null && item.NewsCategorySummary.Trim().Length > 0) ? item.NewsCategorySummary.Trim() : null);
			comm.AddParameter<string>(this.Factory, "newsCategoryDescription", (item.NewsCategoryDescription != null && item.NewsCategoryDescription.Trim().Length > 0) ? item.NewsCategoryDescription.Trim() : null);
			comm.AddParameter<string>(this.Factory, "newsCategoryKeyword", (item.NewsCategoryKeyword != null && item.NewsCategoryKeyword.Trim().Length > 0) ? item.NewsCategoryKeyword.Trim() : null);
			comm.AddParameter<bool>(this.Factory, "isActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "orderNo", item.OrderNo);
			comm.AddParameter<string>(this.Factory, "culture", item.Culture);

			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(CategoriesNews item)
		{

		}

		public void Import(List<CategoriesNews> list, bool deleteExist)
		{
		}


	}
}
