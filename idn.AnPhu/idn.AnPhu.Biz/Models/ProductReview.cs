using Client.Core.Data.Entities.Validation;
using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class ProductReview : EntityBase
    {
        [DataColum]
        public int ReviewId { get; set; }

        [DataColum]
        public int ProductId { get; set; }

        [Length(256)]
        [DataColum]
        public string ReviewLogo { get; set; }

        [Length(256)]
        [DataColum]
        public string ReviewTitle { get; set; }


        [DataColum]
        public string ReviewBody { get; set; }

        [Length(256)]
        [DataColum]
        public string ReviewSource { get; set; }

        [Length(1000)]
        [DataColum]
        public string ReviewDescription { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        [DataColum]
        public string UpdateBy { get; set; }

        [Length(500)]
        [DataColum]
        public string ReviewKeyword { get; set; }

        public override void ParseData(System.Data.DataRow dr)
        {
            base.ParseData(dr);
            base.ParseDataEx(dr);
        }
    }
}
