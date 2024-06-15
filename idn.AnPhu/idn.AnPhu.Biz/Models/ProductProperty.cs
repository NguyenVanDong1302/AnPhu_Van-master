using Client.Core.Data.Entities.Validation;
using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class ProductProperty : EntityBase
    {
        [DataColum]
        public int ProductPropertyId { get; set; }

        [DataColum]
        public int ProductId { get; set; }

        [DataColum]
        public string ProductPropertyBody { get; set; }

        [Length(250)]
        [DataColum]
        public string ProductPropertyTitle { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [Length(25)]
        [DataColum]
        public string ProductCode { get; set; }

        [Length(250)]
        [DataColum]
        public string ProductName { get; set; }

        public List<ProductPropertyDetail> Detail
        {
            get;
            set;
        }
    }
}
