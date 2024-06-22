using Client.Core.Data;
using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Biz.Persistance.SqlServer;
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

    public class PrdCategoriesManager : DataManagerBase<PrdCategories>
    {
        public PrdCategoriesManager(IDataProvider<PrdCategories> provider) : base(provider)
        {

        }

        IPrdCategoriesProvider PrdCategoriesProvider
        {
            get
            {
                return (IPrdCategoriesProvider)Provider;
            }
        }
        public PageInfo<PrdCategories> Search(string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<PrdCategories>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;

            pageInfo.DataList = PrdCategoriesProvider.Search(txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;

            return pageInfo;
        }

        public PrdCategories GetByShortName(PrdCategories model, string culture)
        {
            return PrdCategoriesProvider.GetByShortName(model, culture);
        }

        public List<ProductCategoryBase> GetAllProductCategory(string culture)
        {
            return PrdCategoriesProvider.GetAllProductCategory(culture);
        }
        public List<PrdCategories> ListAllProductCategory(string culture)
        {
            return PrdCategoriesProvider.ListAllProductCategory(culture);
        }
        public void Add(PrdCategories model, string Culture)
        {
            PrdCategoriesProvider.Add(model, Culture);
        }
        public List<PrdCategories> GetAll()
        {
            int total = 0;
            return PrdCategoriesProvider.GetAll(0, 0, ref total);
        }
    }
}
