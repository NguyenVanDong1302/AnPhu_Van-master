using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    //internal interface IProductReviewProvider
    //{
    //}

    public interface IProductReviewProvider : IDataProvider<ProductReview>
    {
        List<ProductReview> GetByPrdId(int productid, string culture);
        void Add(ProductReview model, string culture);
    }
}
