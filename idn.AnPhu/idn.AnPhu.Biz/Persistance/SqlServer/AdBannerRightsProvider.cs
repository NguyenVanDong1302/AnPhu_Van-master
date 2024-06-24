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
	public class AdBannerRightsProvider : DataAccessBase, IAdBannerRightsProvider
	{
		public AdBannerRights Get(AdBannerRights dummy)
		{
			DbCommand comm = this.GetCommand("Sp_AdBannerRights_GetById");

			comm.AddParameter<int>(this.Factory, "AdRightId", dummy.AdRightId);

			var table = this.GetTable(comm);
			table.TableName = TableName.AdBannerRights;
			return EntityBase.ParseListFromTable<AdBannerRights>(table).FirstOrDefault();
		}

		public List<AdBannerRights> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_AdBannerRights_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.AdBannerRights;

			return EntityBase.ParseListFromTable<AdBannerRights>(table);
		}

		public List<AdBannerRights> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
		{
			return null;
		}

		public void Add(AdBannerRights item)
		{
		}

		public void Update(AdBannerRights @new, AdBannerRights old)
		{
			var item = @new;
			item.AdRightId = old.AdRightId;
			var comm = this.GetCommand("Sp_AdBannerRights_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "AdBannerRights", item.AdRightId);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<string>(this.Factory, "AdRightName", (item.AdRightName != null && item.AdRightName.Trim().Length > 0) ? item.AdRightName.Trim() : "");
			comm.AddParameter<string>(this.Factory, "AdRightImage", (item.AdRightImage != null && item.AdRightImage.Trim().Length > 0) ? item.AdRightImage.Trim() : null);
			comm.AddParameter<string>(this.Factory, "AdRightLink", (item.AdRightLink != null && item.AdRightLink.Trim().Length > 0) ? item.AdRightLink.Trim() : null);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(AdBannerRights item)
		{
		}

		public void Import(List<AdBannerRights> list, bool deleteExist)
		{
		}
	}
}
