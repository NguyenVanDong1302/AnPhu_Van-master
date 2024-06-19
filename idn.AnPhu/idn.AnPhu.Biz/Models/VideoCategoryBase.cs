using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class VideoCategoryBase : EntityBase
    {
        [DataColum]
        public int VideoCategoryId { get; set; }

        [DataColum]
        public int ParentId { get; set; }

        [DataColum]
        public string VideoCategoryTitle { get; set; }

        private VideoCategoryBase _parent;
        public VideoCategoryBase Parent
        {
            get
            {
                return _parent ?? (_parent = new VideoCategoryBase()
                {
                    VideoCategoryId = ParentId
                });
            }
            set { _parent = value; }
        }

        public List<VideoCategoryBase> Children { get; set; }

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
                    return string.Format("{0}{1}", l, VideoCategoryTitle);

                }

                return VideoCategoryTitle;
            }
        }
    }
}
