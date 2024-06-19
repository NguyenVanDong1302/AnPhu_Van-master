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
    public class VideoCategoryProvider : DataAccessBase, IVideoCategoryProvider
    {
        public VideoCategory Get(VideoCategory dummy)
        {
            var comm = this.GetCommand("sp_VideoCategoryGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "VideoCategoryId", dummy.VideoCategoryId);
            var dt = this.GetTable(comm);
            var htmlPageCate = EntityBase.ParseListFromTable<VideoCategory>(dt).FirstOrDefault();
            return htmlPageCate ?? null;
            //throw new NotImplementedException();
        }
        public VideoCategory GetByShortName(VideoCategory dummy, string culture)
        {
            var comm = this.GetCommand("sp_VideoCategoryGetByShortName");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<string>(this.Factory, "VideoCategoryShortName", dummy.VideoCategoryShortName);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var htmlPageCate = EntityBase.ParseListFromTable<VideoCategory>(dt).FirstOrDefault();
            return htmlPageCate ?? null;
            //throw new NotImplementedException();
        }
        public void Add(VideoCategory item, string Culture)
        {
            var comm = this.GetCommand("sp_VideoCategory_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "VideoCategoryTitle", item.VideoCategoryTitle);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "VideoCategoryShortName", item.VideoCategoryShortName);
            comm.AddParameter<string>(this.Factory, "VideoCategorySummary", item.VideoCategorySummary);
            comm.AddParameter<string>(this.Factory, "VideoCategoryDescription", item.VideoCategoryDescription);
            comm.AddParameter<string>(this.Factory, "VideoCategoryKeyword", item.VideoCategoryKeyword);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Culture", Culture);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Add(VideoCategory item)
        {
            //var comm = this.GetCommand("sp_HtmlPage_Insert");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "HtmlPageTitle", item.HtmlPageTitle);
            //comm.AddParameter<string>(this.Factory, "HtmlPageShortName", item.HtmlPageShortName);
            //comm.AddParameter<string>(this.Factory, "HtmlPageSummary", item.HtmlPageSummary);
            //comm.AddParameter<string>(this.Factory, "HtmlPageDescription", item.HtmlPageDescription);
            //comm.AddParameter<string>(this.Factory, "HtmlPageKeyword", item.HtmlPageKeyword);
            //comm.AddParameter<string>(this.Factory, "HtmlPageBody", item.HtmlPageBody);
            //comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            //comm.AddParameter<string>(this.Factory, "HtmlPageImage", item.HtmlPageImage);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Culture", Culture);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }
        public void Update(VideoCategory @new, VideoCategory old)
        {
            var item = @new;
            item.VideoCategoryId = old.VideoCategoryId;
            var comm = this.GetCommand("sp_VideoCategory_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "VideoCategoryId", item.VideoCategoryId);
            comm.AddParameter<string>(this.Factory, "VideoCategoryTitle", item.VideoCategoryTitle);
            comm.AddParameter<int>(this.Factory, "ParentId", item.ParentId);
            comm.AddParameter<string>(this.Factory, "VideoCategorySummary", item.VideoCategorySummary);
            comm.AddParameter<string>(this.Factory, "VideoCategoryDescription", item.VideoCategoryDescription);
            comm.AddParameter<string>(this.Factory, "VideoCategoryKeyword", item.VideoCategoryKeyword);
            comm.AddParameter<string>(this.Factory, "VideoCategoryShortName", item.VideoCategoryShortName);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            //comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            //comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public List<VideoCategory> GetAll(int startIndex, int lenght, ref int totalItem)
        {
            throw new NotImplementedException();
        }
        public void Remove(VideoCategory item)
        {
            //var comm = this.GetCommand("sp_HtmlPage_Delete");
            //if (comm == null) return;
            //comm.AddParameter<int>(this.Factory, "HtmlPageId", item.HtmlPageId);
            //comm.SafeExecuteNonQuery();
            throw new NotImplementedException();
        }
        public List<VideoCategory> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_VideoCategorySearch");
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
            return EntityBase.ParseListFromTable<VideoCategory>(dt);
        }
        public List<VideoCategoryBase> GetAllVideoCategory(string culture)
        {
            //var comm = this.GetCommand("sp_VideoCategoryGetAll");
            //comm.AddParameter<string>(this.Factory, "Culture", culture);
            //if (comm == null) return null;
            //var dt = this.GetTable(comm);
            //var listGroupNews = EntityBase.ParseListFromTable<VideoCategory>(dt);
            //try
            //{
            //    var toGroupNewsTree = VideoCategoryExtensions.ToCategoryTree(GetVideoCategoryBaseList(listGroupNews));
            //    var toFlatGroupNewsTree = VideoCategoryExtensions.ToFlatCategoryTree(toGroupNewsTree);
            //    return toFlatGroupNewsTree;
            //}
            //catch (Exception)
            //{

            //    //throw;
            //}
            return null;
            //throw new NotImplementedException();
        }
        public List<VideoCategory> ListAllVideoCategory(string culture)
        {
            var comm = this.GetCommand("sp_VideoCategoryGetAll");
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            var listGroupNews = EntityBase.ParseListFromTable<VideoCategory>(dt);

            return listGroupNews;
            //throw new NotImplementedException();
        }
        public static List<VideoCategoryBase> GetVideoCategoryBaseList(List<VideoCategory> s)
        {
            var listPageBase = new List<VideoCategoryBase>();
            if (s != null)
            {
                listPageBase.AddRange(s.Cast<VideoCategoryBase>());
            }

            return listPageBase;
        }
    }
}
