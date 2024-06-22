using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

using Client.Core.Data.DataAccess;
using idn.AnPhu.Constants;


namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    internal class PrdCategoriesProvider : DataAccessBase, IPrdCategoriesProvider
    {
        public void Add(PrdCategories model, string culture)
        {
            throw new NotImplementedException();
        }

        public void Add(PrdCategories item)
        {
            throw new NotImplementedException();
        }

        public PrdCategories Get(PrdCategories dummy)
        {
            throw new NotImplementedException();
        }

        public List<PrdCategories> GetAll(int startIndex, int count, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_PrdCategories_GetAll");

            DataTable table = this.GetTable(comm);

            table.TableName = TableName.PrdCategories;

            return EntityBase.ParseListFromTable<PrdCategories>(table);
        }

        public List<ProductCategoryBase> GetAllProductCategory(string culture)
        {
            throw new NotImplementedException();
        }

        public PrdCategories GetByShortName(PrdCategories dummy, string culture)
        {
            var comm = this.GetCommand("Sp_PrdCategories_GetByShortName");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<string>(this.Factory, "shortName", dummy.PrdCategoryShortName);
            //comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var htmlPageCate = EntityBase.ParseListFromTable<PrdCategories>(dt).FirstOrDefault();
            return htmlPageCate ?? null;
            //throw new NotImplementedException();
        }

        public List<PrdCategories> ListAllProductCategory(string culture)
        {
            var comm = this.GetCommand("sp_ProductCategoryGetAll");
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            var listGroupNews = EntityBase.ParseListFromTable<PrdCategories>(dt);

            return listGroupNews;
        }

        public void Remove(PrdCategories item)
        {
            throw new NotImplementedException();
        }

        public List<PrdCategories> Search(string txtSearch, int startIndex, int pageSize, ref int totalItems)
        {
            DbCommand comm = this.GetCommand("Sp_PrdCategories_Search");
            comm.AddParameter<string>(this.Factory, "txtSearch", (txtSearch != null && txtSearch.Trim().Length > 0) ? txtSearch : null);
            comm.AddParameter<int>(this.Factory, "startIndex", startIndex);
            comm.AddParameter<int>(this.Factory, "count", pageSize);
   
            // đại diện cho DbParameter, để sử dụng như 1 biến bình thường 
            DbParameter totalItemsParam = comm.AddParameter(this.Factory, "totalItems", DbType.Int32, null);
            totalItemsParam.Direction = ParameterDirection.Output;

            var table = this.GetTable(comm);
            table.TableName = TableName.PrdCategories;

            if (totalItemsParam.Value != DBNull.Value)
            {
                totalItems = Convert.ToInt32(totalItemsParam.Value);
            }

            return EntityBase.ParseListFromTable<PrdCategories>(table);

        }

        public void Update(PrdCategories @new, PrdCategories old)
        {
            throw new NotImplementedException();
        }
    }
}
