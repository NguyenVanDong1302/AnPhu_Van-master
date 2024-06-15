using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class ProductCategoryBase : EntityBase
    {
        [DataColum]
        public int PrdCategoryId { get; set; }

        [DataColum]
        public int ParentId { get; set; }

        [DataColum]
        public string PrdCategoryTitle { get; set; }

        private ProductCategoryBase _parent;
        public ProductCategoryBase Parent
        {
            get
            {
                return _parent ?? (_parent = new ProductCategoryBase()
                {
                    PrdCategoryId = ParentId
                });
            }
            set { _parent = value; }
        }

        public List<ProductCategoryBase> Children { get; set; }

        public int HLevel
        {
            get;
            set;
        }

        public string HlevelTitle
        {
            get
            {
                if (HLevel > 0)
                {
                    var l = "";
                    for (var i = 1; i <= HLevel; ++i)
                    {
                        l += "|--";
                    }
                    return string.Format("{0}{1}", l, PrdCategoryTitle);

                }

                return PrdCategoryTitle;
            }
        }
    }
}
