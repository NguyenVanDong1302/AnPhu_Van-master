using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class Location : EntityBase
    {
        [DataColum]
        public int LocationCode { get; set; }

        [DataColum]
        public int LocationDiscountId { get; set; }

        [DataColum]
        public string LocationName { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string CreateBy { get; set; }
    }
}
