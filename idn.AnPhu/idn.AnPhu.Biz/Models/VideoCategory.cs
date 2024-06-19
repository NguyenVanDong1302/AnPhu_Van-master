using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class VideoCategory : VideoCategoryBase
    {
        public VideoCategory()
            : base()
        {
        }
        public VideoCategory(int id)
            : this()
        {

            this.VideoCategoryId = id;
        }
        public VideoCategory(string name)
            : this()
        {

            this.VideoCategoryTitle = name;
        }

        [DataColum]
        public string VideoCategoryShortName { get; set; }

        [DataColum]
        public string VideoCategorySummary { get; set; }

        [DataColum]
        public string VideoCategoryDescription { get; set; }

        [DataColum]
        public string VideoCategoryKeyword { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        public List<Video> ListVideo { get; set; }

    }
}
