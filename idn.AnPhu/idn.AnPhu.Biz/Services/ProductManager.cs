﻿using Client.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using Client.Core.Data.Entities.Paging;


namespace idn.AnPhu.Biz.Services
{
    public class ProductManager : DataManagerBase<Product>
    {
        public ProductManager()
            : base()
        { }

        public ProductManager(IDataProvider<Product> provider)
            : base(provider)
        {
        }

        private IProductProvider ProductProvider
        {
            get { return (IProductProvider)Provider; }
        }


        public PageInfo<Product> Search(string txtSearch, int pageIndex, int pageSize)
        {
            int totalItems = 0;
            var pageInfo = new PageInfo<Product>(pageIndex, pageSize);
            var startIndex = (pageIndex - 1) * pageSize;
            pageInfo.DataList = ProductProvider.Search(txtSearch, startIndex, pageSize, ref totalItems);
            pageInfo.ItemCount = totalItems;
            return pageInfo;
        }
        public List<Product> ProductGetByCateId(int cateid, string culture)
        {
            return ProductProvider.ProductGetByCateId(cateid, culture);
        }
        public List<Product> ProductGetAllActive(string culture)
        {
            return ProductProvider.ProductGetAllActive(culture);
        }
        public void Add(Product model, string Culture)
        {
            ProductProvider.Add(model, Culture);
        }

        /// ///////////////////////////////////////////////////////
        public List<Product> GetListHotProduct(string culture)
        {
            return ProductProvider.GetListHotProduct(culture);
        }

        public List<Product> GetListNewProduct(string culture)
        {
            return ProductProvider.GetListNewProduct(culture);
        }

        public List<Product> GetListSaleProduct(string culture)
        {
            return ProductProvider.GetListSaleProduct(culture);
        }

        public List<Product> GetListHotNewSaleProduct(string culture)
        {
            return ProductProvider.GetListHotNewSaleProduct(culture);
        }
        public Product GetByCode(Product model, string culture)
        {
            return ProductProvider.GetByCode(model, culture);
        }

        public dynamic GetByCode(Product product, object culture)
        {
            throw new NotImplementedException();
        }
    }
}
