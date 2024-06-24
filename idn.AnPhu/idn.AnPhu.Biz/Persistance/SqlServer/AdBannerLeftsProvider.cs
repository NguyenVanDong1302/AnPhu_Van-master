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
	public class AdBannerLeftsProvider : DataAccessBase, IAdBannerLeftsProvider
	{
		public AdBannerLefts Get(AdBannerLefts dummy)
		{
			DbCommand comm = this.GetCommand("Sp_AdBannerLefts_GetById");

			comm.AddParameter<int>(this.Factory, "AdLeftId", dummy.AdLeftId);

			var table = this.GetTable(comm);
			table.TableName = TableName.AdBannerLefts;
			return EntityBase.ParseListFromTable<AdBannerLefts>(table).FirstOrDefault();
		}

		public List<AdBannerLefts> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_AdBannerLefts_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.AdBannerLefts;

			return EntityBase.ParseListFromTable<AdBannerLefts>(table);
		}

		public List<AdBannerLefts> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
		{
			return null;
		}

		public void Add(AdBannerLefts item)
		{
		}

		public void Update(AdBannerLefts @new, AdBannerLefts old)
		{
			var item = @new;
			item.AdLeftId = old.AdLeftId;
			var comm = this.GetCommand("Sp_AdBannerLefts_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "AdLeftId", item.AdLeftId);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<string>(this.Factory, "AdLeftName", (item.AdLeftName != null && item.AdLeftName.Trim().Length > 0) ? item.AdLeftName.Trim() : "");
			comm.AddParameter<string>(this.Factory, "AdLeftImage", (item.AdLeftImage != null && item.AdLeftImage.Trim().Length > 0) ? item.AdLeftImage.Trim() : null);
			comm.AddParameter<string>(this.Factory, "AdLeftLink", (item.AdLeftLink != null && item.AdLeftLink.Trim().Length > 0) ? item.AdLeftLink.Trim() : null);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(AdBannerLefts item)
		{
		}

		public void Import(List<AdBannerLefts> list, bool deleteExist)
		{
		}
	}
}
