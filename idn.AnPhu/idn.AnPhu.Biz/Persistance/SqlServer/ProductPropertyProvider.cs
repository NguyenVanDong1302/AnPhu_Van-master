using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class ProductPropertyProvider : DataAccessBase, IProductPropertyProvider
    {
        public void Add(ProductProperty model, string culture)
        {
            throw new NotImplementedException();
        }

        public void Add(ProductProperty item)
        {
            throw new NotImplementedException();
        }

        public ProductProperty Get(ProductProperty dummy)
        {
            var comm = this.GetCommand("sp_ProductPropertyGet");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "ProductPropertyId", dummy.ProductPropertyId);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<ProductProperty>(dt).FirstOrDefault();
            return htmlPage ?? null;
            //throw new NotImplementedException();

        }

        public List<ProductProperty> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }

        public List<ProductProperty> GetAllActive(int productid, string culture)
        {
            throw new NotImplementedException();
        }

        public List<ProductProperty> GetByPrdId(int productId, string culture)
        {
            var comm = this.GetCommand("sp_ProductPropertyGetByPrdId");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "ProductId", productId);
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            var htmlPage = EntityBase.ParseListFromTable<ProductProperty>(dt);
            return htmlPage ?? null;
            throw new NotImplementedException();
        }

        public List<ProductProperty> GetByPrdMyCode(string productcode)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductProperty item)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductProperty @new, ProductProperty old)
        {
            throw new NotImplementedException();
        }
    }
}
