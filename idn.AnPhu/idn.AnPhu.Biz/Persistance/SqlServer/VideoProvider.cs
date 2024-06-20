using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class VideoProvider : DataAccessBase, IVideoProvider
    {
        public Video Get(Video dummy)
        {
            var comm = this.GetCommand("sp_VideoGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "VideoId", dummy.VideoId);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<Video>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public void Add(Video item, string Culture)
        {
            var comm = this.GetCommand("sp_Video_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "VideoTitle", item.VideoTitle);
            comm.AddParameter<int>(this.Factory, "VideoCategoryId", item.VideoCategoryId);
            comm.AddParameter<string>(this.Factory, "VideoShortName", item.VideoShortName);
            comm.AddParameter<string>(this.Factory, "VideoSummary", item.VideoSummary);
            comm.AddParameter<string>(this.Factory, "VideoDescription", item.VideoDescription);
            comm.AddParameter<string>(this.Factory, "VideoKeyword", item.VideoKeyword);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "VideoUrl", item.VideoUrl);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Culture", Culture);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Add(Video item)
        {
            //var comm = this.GetCommand("sp_Video_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "VideoTitle", item.VideoTitle);
            //comm.AddParameter<string>(this.Factory, "HtmlPageShortName", item.VideoShortName);
            //comm.AddParameter<string>(this.Factory, "HtmlPageSummary", item.VideoSummary);
            //comm.AddParameter<string>(this.Factory, "HtmlPageDescription", item.VideoDescription);
            //comm.AddParameter<string>(this.Factory, "HtmlPageKeyword", item.VideoKeyword);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            //comm.AddParameter<string>(this.Factory, "HtmlPageImage", item.VideoUrl);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Culture", Culture);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }
        public void Update(Video @new, Video old)
        {
            var item = @new;
            item.VideoId = old.VideoId;
            var comm = this.GetCommand("sp_Video_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VideoId", item.VideoId);
            comm.AddParameter<int>(this.Factory, "VideoCategoryId", item.VideoCategoryId);
            comm.AddParameter<string>(this.Factory, "VideoTitle", item.VideoTitle);
            comm.AddParameter<string>(this.Factory, "VideoShortName", item.VideoShortName);
            comm.AddParameter<string>(this.Factory, "VideoSummary", item.VideoSummary);
            comm.AddParameter<string>(this.Factory, "VideoDescription", item.VideoDescription);
            comm.AddParameter<string>(this.Factory, "VideoKeyword", item.VideoKeyword);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "VideoUrl", item.VideoUrl);
            //comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            //comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(Video item)
        {
            var comm = this.GetCommand("sp_Video_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VideoId", item.VideoId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<Video> GetAll(int startIndex, int lenght, ref int totalItem)
        {
            throw new NotImplementedException();
        }

        //public List<HtmlPage> SelectTop4()
        //{
        //    var comm = this.GetCommand("sp_SliderBanner_SelectTop4");
        //    if (comm == null) return null;
        //    var dt = this.GetTable(comm);
        //    return EntityBase.ParseListFromTable<HtmlPage>(dt);
        //}

        public List<Video> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_VideoSearch");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "StartIndex", startIndex);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            comm.AddParameter<int>(this.Factory, "Length", lenght);
            var totalItemsParam = comm.AddParameter(this.Factory, "TotalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;
            var dt = this.GetTable(comm);
            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItem = Convert.ToInt32(totalItemsParam.Value);
            }
            return EntityBase.ParseListFromTable<Video>(dt);
        }
        public List<Video> GetListVideosByCateId(int cateid, int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_VideoSearchByCateId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "VideoCategoryId", cateid);
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
            return EntityBase.ParseListFromTable<Video>(dt);
            //throw new NotImplementedException();
        }
    }
}
