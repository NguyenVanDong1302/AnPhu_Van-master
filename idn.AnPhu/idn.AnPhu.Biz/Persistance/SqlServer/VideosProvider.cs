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
	public class VideosProvider : DataAccessBase, IVideosProvider
	{
		public Videos Get(Videos dummy)
		{
			DbCommand comm = this.GetCommand("Sp_Videos_GetById");

			comm.AddParameter<int>(this.Factory, "VideoId", dummy.VideoId);

			var table = this.GetTable(comm);
			table.TableName = TableName.Videos;
			return EntityBase.ParseListFromTable<Videos>(table).FirstOrDefault();
		}

		public List<Videos> GetAll(int startIndex, int count, ref int totalItems)
		{
			DbCommand comm = this.GetCommand("Sp_Videos_GetAll");

			var table = this.GetTable(comm);
			table.TableName = TableName.Videos;

			return EntityBase.ParseListFromTable<Videos>(table);
		}

		public void Add(Videos item)
		{
			DbCommand comm = this.GetCommand("Sp_Videos_Create");
			comm.AddParameter<string>(this.Factory, "VideoTitle", (item.VideoTitle != null && item.VideoTitle.Trim().Length > 0) ? item.VideoTitle.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoSummary", (item.VideoSummary != null && item.VideoSummary.Trim().Length > 0) ? item.VideoSummary.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoDescription", (item.VideoDescription != null && item.VideoDescription.Trim().Length > 0) ? item.VideoDescription.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoKeyword", (item.VideoKeyword != null && item.VideoKeyword.Trim().Length > 0) ? item.VideoKeyword.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoUrl", (item.VideoUrl != null && item.VideoUrl.Trim().Length > 0) ? item.VideoUrl.Trim() : "");
			comm.AddParameter<int>(this.Factory, "VideoCategoryId", item.VideoCategoryId);
			comm.AddParameter<string>(this.Factory, "CreateBy", (item.CreateBy != null && item.CreateBy.Trim().Length > 0) ? item.CreateBy.Trim() : null);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			comm.AddParameter<string>(this.Factory, "Culture", (item.Culture != null && item.Culture.Trim().Length > 0) ? item.Culture.Trim() : null);

			this.SafeExecuteNonQuery(comm);
		}

		public void Update(Videos @new, Videos old)
		{
			var item = @new;
			item.VideoId = old.VideoId;
			var comm = this.GetCommand("Sp_Videos_Update");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "VideoId", item.VideoId);
			comm.AddParameter<string>(this.Factory, "VideoTitle", (item.VideoTitle != null && item.VideoTitle.Trim().Length > 0) ? item.VideoTitle.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoSummary", (item.VideoSummary != null && item.VideoSummary.Trim().Length > 0) ? item.VideoSummary.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoDescription", (item.VideoDescription != null && item.VideoDescription.Trim().Length > 0) ? item.VideoDescription.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoKeyword", (item.VideoKeyword != null && item.VideoKeyword.Trim().Length > 0) ? item.VideoKeyword.Trim() : "");
			comm.AddParameter<string>(this.Factory, "VideoUrl", (item.VideoUrl != null && item.VideoUrl.Trim().Length > 0) ? item.VideoUrl.Trim() : "");
			comm.AddParameter<int>(this.Factory, "VideoCategoryId", item.VideoCategoryId);
			comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
			comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
			this.SafeExecuteNonQuery(comm);
		}

		public void Remove(Videos item)
		{
			var comm = this.GetCommand("Sp_Videos_Delete");
			if (comm == null) return;
			comm.AddParameter<int>(this.Factory, "VideoId", item.VideoId);
			this.SafeExecuteNonQuery(comm);
		}

		public void Import(List<Videos> list, bool deleteExist)
		{
		}
	}
}
