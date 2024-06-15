using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idn.AnPhu.Biz.Persistance.Interface;


namespace idn.AnPhu.Biz.Services
{
    //internal class ProductPropertyManager
    //{
    //}

    public class ProductPropertyManager : DataManagerBase<ProductProperty>
    {
        public ProductPropertyManager()
            : base()
        { }

        public ProductPropertyManager(IDataProvider<ProductProperty> provider)
            : base(provider)
        {
        }

        private IProductPropertyProvider ProductPropertyProvider
        {
            get { return (IProductPropertyProvider)Provider; }
        }


        public List<ProductProperty> GetByPrdId(int productid, string culture)
        {
            return ProductPropertyProvider.GetByPrdId(productid, culture);
        }
        public List<ProductProperty> GetAllActive(int productid, string culture)
        {
            return ProductPropertyProvider.GetAllActive(productid, culture);
        }
        public List<ProductProperty> GetByPrdMyCode(string productcode)
        {
            return ProductPropertyProvider.GetByPrdMyCode(productcode);
        }
        public void Add(ProductProperty model, string Culture)
        {
            ProductPropertyProvider.Add(model, Culture);
        }






    }
}
