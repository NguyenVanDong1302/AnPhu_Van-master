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
	public class VideoCategoriesProvider : DataAccessBase, IVideoCategoriesProvider
	{
		public VideoCategories Get(VideoCategories dummy)
		{
			DbCommand comm = this.GetCommand("Sp_VideoCategories_GetById");

			comm.AddParameter<int>(this.Factory, "VideoCategoryId", dummy.VideoCategoryId);

			var table = this.GetTable(comm);
			table.TableName = TableName.VideoCategories;
			return EntityBase.ParseListFromTable<VideoCategories>(table).FirstOrDefault();
		}

		public List<VideoCategories> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_VideoCategories_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.VideoCategories;

			return EntityBase.ParseListFromTable<VideoCategories>(table);
		}

		public void Add(VideoCategories item)
		{
			DbCommand comm = this.GetCommand("Sp_VideoCategories_Create");
			comm.AddParameter<string>(this.Factory, "VideoCategoryTitle", (item.VideoCategoryTitle != null && item.VideoCategoryTitle.Trim().Length > 0) ? item.VideoCategoryTitle.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoCategorySummary", (item.VideoCategorySummary != null && item.VideoCategorySummary.Trim().Length > 0) ? item.VideoCategorySummary.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoCategoryDescription", (item.VideoCategoryDescription != null && item.VideoCategoryDescription.Trim().Length > 0) ? item.VideoCategoryDescription.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoCategoryKeyword", (item.VideoCategoryKeyword != null && item.VideoCategoryKeyword.Trim().Length > 0) ? item.VideoCategoryKeyword.Trim() : "");
			comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
			comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(VideoCategories @new, VideoCategories old)
		{
			var item = @new;
			item.VideoCategoryId = old.VideoCategoryId;
			var comm = this.GetCommand("Sp_VideoCategories_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "VideoCategoryId", item.VideoCategoryId);
			comm.AddParameter<string>(this.Factory, "VideoCategoryTitle", (item.VideoCategoryTitle != null && item.VideoCategoryTitle.Trim().Length > 0) ? item.VideoCategoryTitle.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoCategorySummary", (item.VideoCategorySummary != null && item.VideoCategorySummary.Trim().Length > 0) ? item.VideoCategorySummary.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoCategoryDescription", (item.VideoCategoryDescription != null && item.VideoCategoryDescription.Trim().Length > 0) ? item.VideoCategoryDescription.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoCategoryKeyword", (item.VideoCategoryKeyword != null && item.VideoCategoryKeyword.Trim().Length > 0) ? item.VideoCategoryKeyword.Trim() : "");
			comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(VideoCategories item)
		{
			var comm = this.GetCommand("Sp_VideoCategories_Delete");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "VideoCategorieId", item.VideoCategoryId);
			this.SafeExecuteNonQuery(comm);
		}

		public void Import(List<VideoCategories> list, bool deleteExist)
		{
		}
	}
}
