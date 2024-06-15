using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    //internal interface IProductPropertyProvider
    //{
    //}

    public interface IProductPropertyProvider : IDataProvider<ProductProperty>
    {
        List<ProductProperty> GetByPrdId(int productid, string culture);
        List<ProductProperty> GetAllActive(int productid, string culture);
        List<ProductProperty> GetByPrdMyCode(string productcode);
        void Add(ProductProperty model, string culture);
        ProductProperty Get(ProductProperty dummy);
    }
}
