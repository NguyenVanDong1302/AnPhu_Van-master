using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace idn.AnPhu.Biz.Models
{
    public class Product : EntityBase
    {
        [DataColum]
        public int ProductId { get; set; }

        [DataColum]
        public int PrdCategoryId { get; set; }

        [DataColum]
        public string ProductName { get; set; }

        [DataColum]
        public string ProductTitle { get; set; }

        [DataColum]
        public string ProductCode { get; set; }

        [DataColum]
        public string ProductImage { get; set; }

        [DataColum]
        public string ProductImage2 { get; set; }

        [DataColum]
        public decimal ProductPrice { get; set; }

        [DataColum]
        public string ProductSlogan { get; set; }

        [DataColum]
        public string ProductSummary { get; set; }

        [DataColum]
        public string ProductDescription { get; set; }

        [DataColum]
        public string ProductKeyword { get; set; }

        [DataColum]
        public string ProductVideo { get; set; }

        [DataColum]
        public string ProductBrochure { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        [DataColum]
        public string UpdateBy { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public int Counter { get; set; }

        [DataColum]
        public int VersionId { get; set; }

        [DataColum]
        public bool IsHotProduct { get; set; }

        [DataColum]
        public bool IsNewProduct { get; set; }

        [DataColum]
        public bool IsSaleProduct { get; set; }

        [DataColum]
        public string PrdCategoryTitle { get; set; }

        [DataColum]
        public string ProductBackground { get; set; }


        public List<ProductProperty> Properties
        {
            get;
            set;
        }

        public List<ProductVersion> Versions
        {
            get;
            set;
        }
        public List<ProductReview> Reviews
        {
            get;
            set;
        }
    }
}
