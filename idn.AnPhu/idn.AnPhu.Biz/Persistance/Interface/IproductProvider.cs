using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IProductProvider : IDataProvider<Product>
    {
        List<Product> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<Product> ProductGetByCateId(int cateid, string culture);
        void Add(Product model, string culture);
        List<Product> ProductGetAllActive(string culture);
        List<Product> GetListHotProduct(string culture);
        List<Product> GetListNewProduct(string culture);
        List<Product> GetListSaleProduct(string culture);
        List<Product> GetListHotNewSaleProduct(string culture);
        Product GetByCode(Product model, string culture);
    }
}
