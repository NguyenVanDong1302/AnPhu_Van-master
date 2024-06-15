using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    //internal class PrdCategoriesManager
    //{
    //}

    public class PrdCategoriesManager : DataManagerBase<ProductCategory>
    {
        public PrdCategoriesManager()
            : base()
        { }

        public PrdCategoriesManager(IDataProvider<ProductCategory> provider)
            : base(provider)
        {
        }

        private IPrdCategoriesProvider ProductCategoryProvider
        {
            get { return (IPrdCategoriesProvider)Provider; }
        }
        public List<ProductCategory> Search(int startIndex, int lenght, ref int totalItem, string culture)
        {
            return ProductCategoryProvider.Search(startIndex, lenght, ref totalItem, culture);
        }
        public ProductCategory GetByShortName(ProductCategory model, string culture)
        {
            return ProductCategoryProvider.GetByShortName(model, culture);
        }

        public List<ProductCategoryBase> GetAllProductCategory(string culture)
        {
            return ProductCategoryProvider.GetAllProductCategory(culture);
        }
        public List<ProductCategory> ListAllProductCategory(string culture)
        {
            return ProductCategoryProvider.ListAllProductCategory(culture);
        }
        public void Add(ProductCategory model, string Culture)
        {
            ProductCategoryProvider.Add(model, Culture);
        }
    }
}
