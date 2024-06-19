﻿using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using idn.AnPhu.Biz.Persistance.Interface;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class HtmlPageProvider : DataAccessBase, IHtmlPageProvider
    {
        public HtmlPage Get(HtmlPage dummy)
        {
            var comm = this.GetCommand("sp_HtmlPageGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "HtmlPageId", dummy.HtmlPageId);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<HtmlPage>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public HtmlPage GetHtmlPageByShortName(HtmlPage dummy, string culture)
        {
            var comm = this.GetCommand("sp_HtmlPageGetByShortName");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<string>(this.Factory, "HtmlPageShortName", dummy.HtmlPageShortName);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<HtmlPage>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public HtmlPage HtmlPageGetByShortName(string shortname, string culture)
        {
            var comm = this.GetCommand("sp_HtmlPageGetByShortName");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<string>(this.Factory, "HtmlPageShortName", shortname);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<HtmlPage>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();
        }
        public void Add(HtmlPage item, string Culture)
        {
            var comm = this.GetCommand("sp_HtmlPage_Insert");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "HtmlPageTitle", item.HtmlPageTitle);
            comm.AddParameter<int>(this.Factory, "HtmlPageCategoryId", item.HtmlPageCategoryId);
            comm.AddParameter<string>(this.Factory, "HtmlPageCategoryShortName", item.HtmlPageCategoryShortName);
            comm.AddParameter<string>(this.Factory, "HtmlPageShortName", item.HtmlPageShortName);
            comm.AddParameter<string>(this.Factory, "HtmlPageSummary", item.HtmlPageSummary);
            comm.AddParameter<string>(this.Factory, "HtmlPageDescription", item.HtmlPageDescription);
            comm.AddParameter<string>(this.Factory, "HtmlPageKeyword", item.HtmlPageKeyword);
            comm.AddParameter<string>(this.Factory, "HtmlPageBody", item.HtmlPageBody);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "HtmlPageImage", item.HtmlPageImage);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Culture", Culture);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }
        public void Add(HtmlPage item)
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
        public void Update(HtmlPage @new, HtmlPage old)
        {
            var item = @new;
            item.HtmlPageId = old.HtmlPageId;
            var comm = this.GetCommand("sp_HtmlPage_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "HtmlPageId", item.HtmlPageId);
            comm.AddParameter<int>(this.Factory, "HtmlPageCategoryId", item.HtmlPageCategoryId);
            comm.AddParameter<string>(this.Factory, "HtmlPageCategoryShortName", item.HtmlPageCategoryShortName);
            comm.AddParameter<string>(this.Factory, "HtmlPageTitle", item.HtmlPageTitle);
            comm.AddParameter<string>(this.Factory, "HtmlPageShortName", item.HtmlPageShortName);
            comm.AddParameter<string>(this.Factory, "HtmlPageSummary", item.HtmlPageSummary);
            comm.AddParameter<string>(this.Factory, "HtmlPageDescription", item.HtmlPageDescription);
            comm.AddParameter<string>(this.Factory, "HtmlPageKeyword", item.HtmlPageKeyword);
            comm.AddParameter<string>(this.Factory, "HtmlPageBody", item.HtmlPageBody);
            comm.AddParameter<int>(this.Factory, "OrderNo", item.OrderNo);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "HtmlPageImage", item.HtmlPageImage);
            //comm.AddParameter<DateTime>(this.Factory, "CreateDate", item.CreateDate);
            //comm.AddParameter<DateTime>(this.Factory, "EditDate", item.EditDate);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public void Remove(HtmlPage item)
        {
            var comm = this.GetCommand("sp_HtmlPage_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "HtmlPageId", item.HtmlPageId);
            comm.SafeExecuteNonQuery();
            //throw new NotImplementedException();
        }

        public List<HtmlPage> GetAll(int startIndex, int lenght, ref int totalItem)
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

        public List<HtmlPage> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_HtmlPageSearch");
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
            return EntityBase.ParseListFromTable<HtmlPage>(dt);
        }
        public List<HtmlPage> GetHtmlPageByCateId(int cateid, string culture)
        {
            var comm = this.GetCommand("sp_HtmlPageGetByCateId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "HtmlPageCategoryId", cateid);

            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<HtmlPage>(dt);
        }

        public List<HtmlPage> HtmlPageGetShortNameCate(int pageid)
        {
            var comm = this.GetCommand("sp_HtmlPageGetShortNameCate");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "HtmlPageId", pageid);


            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<HtmlPage>(dt);
        }


    }
}