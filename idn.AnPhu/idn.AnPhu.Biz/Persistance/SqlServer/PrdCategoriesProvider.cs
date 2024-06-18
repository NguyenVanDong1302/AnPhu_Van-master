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
//using Client.Core.Data.Entities;
//using Client.Core.Utils;
//using idn.AnPhu.Biz.Models;
//using idn.AnPhu.Biz.Persistance.Interface;
//using idn.AnPhu.Constants;
//using idn.AnPhu.Utils;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Common;
//using System.Linq;
//using System.Text;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    internal class PrdCategoriesProvider : DataAccessBase, IPrdCategoriesProvider
    {
        public void Add(ProductCategory model, string culture)
        {
            throw new NotImplementedException();
        }

        public void Add(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory Get(ProductCategory dummy)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryBase> GetAllProductCategory(string culture)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetByShortName(ProductCategory model, string culture)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> ListAllProductCategory(string culture)
        {
            var comm = this.GetCommand("sp_ProductCategoryGetAll");
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            var listGroupNews = EntityBase.ParseListFromTable<ProductCategory>(dt);

            return listGroupNews;
        }

        public void Remove(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            var comm = this.GetCommand("sp_ProductCategorySearch");
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
            return EntityBase.ParseListFromTable<ProductCategory>(dt);
        }

        public void Update(ProductCategory @new, ProductCategory old)
        {
            throw new NotImplementedException();
        }
    }
}
