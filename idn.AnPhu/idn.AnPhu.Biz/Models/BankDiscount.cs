using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class BankDiscount : EntityBase
    {
        [DataColum]
        public int BankDiscountId { get; set; }

        [DataColum]
        public string BankDiscountName { get; set; }

        [DataColum]
        public double BankDiscountValue { get; set; }

        [DataColum]
        public decimal BankValue { get; set; }


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
