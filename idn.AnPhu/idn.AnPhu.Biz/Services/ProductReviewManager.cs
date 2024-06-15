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
    //internal class ProductReviewManager
    //{
    //}

    public class ProductReviewManager : DataManagerBase<ProductReview>
    {
        public ProductReviewManager()
            : base()
        { }

        public ProductReviewManager(IDataProvider<ProductReview> provider)
            : base(provider)
        {
        }

        private IProductReviewProvider ProductReviewProvider
        {
            get { return (IProductReviewProvider)Provider; }
        }


        public List<ProductReview> GetByPrdId(int productid, string culture)
        {
            return ProductReviewProvider.GetByPrdId(productid, culture);
        }
        public void Add(ProductReview model, string Culture)
        {
            ProductReviewProvider.Add(model, Culture);
        }
    }
}
