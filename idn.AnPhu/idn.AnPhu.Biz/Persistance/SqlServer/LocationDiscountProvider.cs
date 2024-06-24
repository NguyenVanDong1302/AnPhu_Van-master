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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
	
	public class LocationDiscountsProvider : DataAccessBase, ILocationDiscountsProvider
	{
		public LocationDiscounts Get(LocationDiscounts dummy)
		{
			/*var comm = this.GetCommand("sp_LocationDiscountsGet");
			if (comm == null)
			{
				return null;
			}
			comm.AddParameter<int>(this.Factory, "LocationDiscountsId", dummy.LocationDiscountId);
			var dt = this.GetTable(comm);
			var sliderBanner = EntityBase.ParseListFromTable<LocationDiscounts>(dt).FirstOrDefault();
			return sliderBanner ?? null;
			//throw new NotImplementedException();*/
			DbCommand comm = this.GetCommand("Sp_LocationDiscounts_GetById");

			comm.AddParameter<int>(this.Factory, "LocationDiscountId", dummy.LocationDiscountId);

			var table = this.GetTable(comm);
			table.TableName = TableName.LocationDiscounts;
			return EntityBase.ParseListFromTable<LocationDiscounts>(table).FirstOrDefault();
		}

		public void Add(LocationDiscounts item)
		{
			DbCommand comm = this.GetCommand("sp_LocationDiscount_Create");
			comm.AddParameter<string>(this.Factory, "LocationDiscountName", (item.LocationDiscountName != null && item.LocationDiscountName.Trim().Length > 0) ? item.LocationDiscountName.Trim() : "");
			comm.AddParameter<int>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
			comm.AddParameter<decimal>(this.Factory, "LocationValueRegistry", item.LocationValueRegistry);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
			comm.AddParameter<decimal>(this.Factory, "LocationValue", item.LocationValue);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

			this.SafeExecuteNonQuery(comm);
		}

		/*public void Add(LocationDiscounts item, string culture)
		{
			*//*var comm = this.GetCommand("sp_LocationDiscount_Create");
			if (comm == null) return;
			comm.AddParameter<string>(this.Factory, "LocationDiscountName", item.LocationDiscountName);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<string>(this.Factory, "Culture", culture);
			comm.AddParameter<decimal>(this.Factory, "LocationValue", item.LocationValue);
			comm.AddParameter<decimal>(this.Factory, "LocationValueRegistry", item.LocationValueRegistry);

			comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
			comm.AddParameter<int>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.SafeExecuteNonQuery();
			//throw new NotImplementedException();*//*
			DbCommand comm = this.GetCommand("sp_LocationDiscount_Create");
			comm.AddParameter<string>(this.Factory, "LocationDiscountName", item.LocationDiscountName);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<string>(this.Factory, "Culture", culture);
			comm.AddParameter<decimal>(this.Factory, "LocationValue", item.LocationValue);
			comm.AddParameter<decimal>(this.Factory, "LocationValueRegistry", item.LocationValueRegistry);

			comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
			comm.AddParameter<int>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);

			this.SafeExecuteNonQuery(comm);
		}*/
		public void Update(LocationDiscounts @new, LocationDiscounts old)
		{
			/*var item = @new;
			item.LocationDiscountId = old.LocationDiscountId;
			var comm = this.GetCommand("sp_LocationDiscount_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
			comm.AddParameter<string>(this.Factory, "LocationDiscountName", item.LocationDiscountName);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
			comm.AddParameter<decimal>(this.Factory, "LocationValue", item.LocationValue);
			comm.AddParameter<decimal>(this.Factory, "LocationValueRegistry", item.LocationValueRegistry);


			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.SafeExecuteNonQuery();
			//throw new NotImplementedException();*/
			var item = @new;
			item.LocationDiscountId = old.LocationDiscountId;
			var comm = this.GetCommand("sp_LocationDiscount_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
			comm.AddParameter<string>(this.Factory, "LocationDiscountName", (item.LocationDiscountName != null && item.LocationDiscountName.Trim().Length > 0) ? item.LocationDiscountName.Trim() : "");
			comm.AddParameter<int>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
			comm.AddParameter<decimal>(this.Factory, "LocationValueRegistry", item.LocationValueRegistry);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<decimal>(this.Factory, "LocationValue", item.LocationValue);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(LocationDiscounts item)
		{
			/*var comm = this.GetCommand("sp_LocationDiscount_Delete");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
			comm.SafeExecuteNonQuery();
			//throw new NotImplementedException();*/
			var comm = this.GetCommand("sp_LocationDiscount_Delete");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
			this.SafeExecuteNonQuery(comm);
		}

		/*public List<LocationDiscounts> GetAll(int startIndex, int count, ref int totalItems)
		{
			throw new NotImplementedException();
		}*/
		public List<LocationDiscounts> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("sp_LocationDiscountsGet");

			var table = this.GetTable(comm);
			table.TableName = TableName.LocationDiscounts;

			return EntityBase.ParseListFromTable<LocationDiscounts>(table);
		}


		public List<LocationDiscounts> Search(int startIndex, int lenght, ref int totalItem, string culture)
		{
			var comm = this.GetCommand("sp_LocationDiscountsSearch");
			if (comm == null) return null;
			comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
			comm.AddParameter<int>(this.Factory, "Length", lenght);
			comm.AddParameter<string>(this.Factory, "Culture", culture);
			var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
			totalItemsParam.Direction = ParameterDirection.Output;
			var dt = this.GetTable(comm);
			if (totalItemsParam.Value != DBNull.Value)
			{
				totalItem = Convert.ToInt32(totalItemsParam.Value);
			}
			return EntityBase.ParseListFromTable<LocationDiscounts>(dt);
		}
		public List<LocationDiscounts> GetAllActive(string culture)
		{
			var comm = this.GetCommand("sp_LocationDiscountsGetAllActive");
			if (comm == null) return null;
			comm.AddParameter<string>(this.Factory, "Culture", culture);
			var dt = this.GetTable(comm);
			return EntityBase.ParseListFromTable<LocationDiscounts>(dt);
		}
	}
}
