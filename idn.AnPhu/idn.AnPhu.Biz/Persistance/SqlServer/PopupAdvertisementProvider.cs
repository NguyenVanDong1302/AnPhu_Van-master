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
	public class PopupAdvertisementProvider : DataAccessBase, IPopupAdvertisementProvider
	{
		public PopupAdvertisement Get(PopupAdvertisement dummy)
		{
			DbCommand comm = this.GetCommand("Sp_PopupAdvertisement_GetById");

			comm.AddParameter<int>(this.Factory, "Id", dummy.Id);

			var table = this.GetTable(comm);
			table.TableName = TableName.PopupAdvertisement;
			return EntityBase.ParseListFromTable<PopupAdvertisement>(table).FirstOrDefault();
		}

		public List<PopupAdvertisement> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_PopupAdvertisement_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.PopupAdvertisement;

			return EntityBase.ParseListFromTable<PopupAdvertisement>(table);
		}

		public List<PopupAdvertisement> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
		{
			return null;
		}

		public void Add(PopupAdvertisement item)
		{
		}

		public void Update(PopupAdvertisement @new, PopupAdvertisement old)
		{
			var item = @new;
			item.Id = old.Id;
			var comm = this.GetCommand("Sp_PopupAdvertisement_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "Id", item.Id);
			comm.AddParameter<string>(this.Factory, "Image", (item.Image != null && item.Image.Trim().Length > 0) ? item.Image.Trim() : null);
			comm.AddParameter<string>(this.Factory, "Link", (item.Link != null && item.Link.Trim().Length > 0) ? item.Link.Trim() : null);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(PopupAdvertisement item)
		{
		}

		public void Import(List<PopupAdvertisement> list, bool deleteExist)
		{
		}
	}
}
