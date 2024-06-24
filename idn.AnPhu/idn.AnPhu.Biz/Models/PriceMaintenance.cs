using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class PriceMaintenance : EntityBase
    {
        [DataColum]
        public int PriceMaintenanceId { get; set; }

        [DataColum]
        public string PriceMaintenanceName { get; set; }

        [DataColum]
        public decimal PriceMaintenanceValue { get; set; }

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
