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
	public class PriceOptionsProvider : DataAccessBase, IPriceOptionsProvider
	{
		public PriceOptions Get(PriceOptions dummy)
		{
			DbCommand comm = this.GetCommand("Sp_PriceOptions_GetById");

			comm.AddParameter<int>(this.Factory, "PriceOptionId", dummy.PriceOptionId);

			var table = this.GetTable(comm);
			table.TableName = TableName.PriceOptions;
			return EntityBase.ParseListFromTable<PriceOptions>(table).FirstOrDefault();
		}

		public List<PriceOptions> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_PriceOptions_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.PriceOptions;

			return EntityBase.ParseListFromTable<PriceOptions>(table);
		}

		public void Add(PriceOptions item)
		{
			DbCommand comm = this.GetCommand("Sp_PriceOptions_Create");
			comm.AddParameter<string>(this.Factory, "PriceOptionTitle", (item.PriceOptionTitle != null && item.PriceOptionTitle.Trim().Length > 0) ? item.PriceOptionTitle.Trim() : "");
			comm.AddParameter<int>(this.Factory, "PriceOptionValue", item.PriceOptionValue);
			comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(PriceOptions @new, PriceOptions old)
		{
			var item = @new;
			item.PriceOptionId = old.PriceOptionId;
			var comm = this.GetCommand("Sp_PriceOptions_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "PriceOptionId", item.PriceOptionId);
			comm.AddParameter<string>(this.Factory, "PriceOptionTitle", (item.PriceOptionTitle != null && item.PriceOptionTitle.Trim().Length > 0) ? item.PriceOptionTitle.Trim() : "");
			comm.AddParameter<int>(this.Factory, "PriceOptionValue", item.PriceOptionValue);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(PriceOptions item)
		{
			var comm = this.GetCommand("Sp_PriceOptions_Delete");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "PriceOptionId", item.PriceOptionId);
			this.SafeExecuteNonQuery(comm);
		}

		public void Import(List<PriceOptions> list, bool deleteExist)
		{
		}
	}
}
