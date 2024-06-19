using Client.Core.Data.Entities.Validation;
using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class Video : EntityBase
    {
        [DataColum]
        public int VideoId { get; set; }

        [DataColum]
        public int VideoCategoryId { get; set; }

        [Length(250)]
        [DataColum]
        [RequireField]
        public string VideoTitle { get; set; }

        [Length(250)]
        [DataColum]
        public string VideoSummary { get; set; }

        [DataColum]
        public string VideoShortName { get; set; }

        [DataColum]
        public string VideoDescription { get; set; }

        [DataColum]
        public string VideoKeyword { get; set; }




        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public string VideoUrl { get; set; }

    }
}
