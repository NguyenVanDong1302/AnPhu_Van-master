using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    interface IPrdCategoriesProvider : IDataProvider<PrdCategories>
    {
        List<PrdCategories> Search(string txtSearch, int startIndex, int pageCount, ref int totalItems);
        List<ProductCategoryBase> GetAllProductCategory(string culture);
        List<PrdCategories> ListAllProductCategory(string culture);
        void Add(PrdCategories model, string culture);
        PrdCategories GetByShortName(PrdCategories model, string culture);
    }
}
