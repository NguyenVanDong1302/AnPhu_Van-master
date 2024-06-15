using Client.Core.Data.Entities.Validation;
using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class ProductPropertyDetail : EntityBase
    {
        [DataColum]
        public int ProductPropertyDetailId { get; set; }


        [DataColum]
        public int ProductId { get; set; }
        [DataColum]
        public int ProductPropertyId { get; set; }


        [DataColum]
        public string ProductPropertyTitle { get; set; }

        [DataColum]
        public string ProductPropertyDetailBody { get; set; }

        [Length(250)]
        [DataColum]
        public string ProductPropertyDetailTitle { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public bool IsActive { get; set; }



    }
}
