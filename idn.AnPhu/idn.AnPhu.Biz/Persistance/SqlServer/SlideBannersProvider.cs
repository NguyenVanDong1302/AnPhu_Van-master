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
	public class SlideBannersProvider : DataAccessBase, ISlideBannersProvider
	{
		public SlideBanners Get(SlideBanners dummy)
		{
			DbCommand comm = this.GetCommand("Sp_SlideBanners_GetById");

			comm.AddParameter<int>(this.Factory, "SlideBannerId", dummy.SlideBannerId);

			var table = this.GetTable(comm);
			table.TableName = TableName.SlideBanners;
			return EntityBase.ParseListFromTable<SlideBanners>(table).FirstOrDefault();
		}

		public List<SlideBanners> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_SlideBanners_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.SlideBanners;

			return EntityBase.ParseListFromTable<SlideBanners>(table);
		}

		public void Add(SlideBanners item)
		{
			DbCommand comm = this.GetCommand("Sp_SlideBanners_Create");
			comm.AddParameter<string>(this.Factory, "Url", (item.Url != null && item.Url.Trim().Length > 0) ? item.Url.Trim() : "");
			comm.AddParameter<string>(this.Factory, "Image", (item.Image != null && item.Image.Trim().Length > 0) ? item.Image.Trim() : "");
			comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(SlideBanners @new, SlideBanners old)
		{
			var item = @new;
			item.SlideBannerId = old.SlideBannerId;
			var comm = this.GetCommand("Sp_SlideBanners_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "SlideBannerId", item.SlideBannerId);
			comm.AddParameter<string>(this.Factory, "Url", (item.Url != null && item.Url.Trim().Length > 0) ? item.Url.Trim() : "");
			comm.AddParameter<string>(this.Factory, "Image", (item.Image != null && item.Image.Trim().Length > 0) ? item.Image.Trim() : "");
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(SlideBanners item)
		{
			var comm = this.GetCommand("Sp_SlideBanners_Delete");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "SlideBannerId", item.SlideBannerId);
			this.SafeExecuteNonQuery(comm);
		}

		public void Import(List<SlideBanners> list, bool deleteExist)
		{
		}
	}
}
