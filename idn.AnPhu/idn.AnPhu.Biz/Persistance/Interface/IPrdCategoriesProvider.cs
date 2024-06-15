using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    //internal class IPrdCategoriesProvider
    //{
    //}

    interface IPrdCategoriesProvider : IDataProvider<ProductCategory>
    {
        List<ProductCategory> Search(int startIndex, int lenght, ref int totalItem, string culture);
        List<ProductCategoryBase> GetAllProductCategory(string culture);
        List<ProductCategory> ListAllProductCategory(string culture);
        void Add(ProductCategory model, string culture);
        ProductCategory GetByShortName(ProductCategory model, string culture);
    }
}
