using Client.Core.Data.Entities.Validation;
using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class ProductVersion : EntityBase
    {
        [DataColum]
        public int VersionId { get; set; }

        [DataColum]
        public int ProductId { get; set; }

        [Length(50)]
        [DataColum]
        public string VersionCode { get; set; }

        [Length(250)] //50
        [DataColum]
        public string VersionTitle { get; set; }

        [DataColum]
        public decimal VersionPrice { get; set; }


        [DataColum]
        public string Culture { get; set; }

        [Length(250)]
        [DataColum]
        public string VersionDescription { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        [Length(50)]
        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public bool IsRegister { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

    }
}
