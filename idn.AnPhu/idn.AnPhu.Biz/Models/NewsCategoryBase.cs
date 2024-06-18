using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ind.AnPhu.Biz.Models
{
    public class NewsCategoryBase : EntityBase
    {
        [DataColum]
        public int NewsCategoryId { get; set; }

        [DataColum]
        public int ParentId { get; set; }

        [DataColum]
        public string NewsCategoryTitle { get; set; }

        private NewsCategoryBase _parent;
        public NewsCategoryBase Parent
        {
            get
            {
                return _parent ?? (_parent = new NewsCategoryBase()
                {
                    NewsCategoryId = ParentId
                });
            }
            set { _parent = value; }
        }

        public List<NewsCategoryBase> Children { get; set; }

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
                    return string.Format("{0}{1}", l, NewsCategoryTitle);

                }

                return NewsCategoryTitle;
            }
        }
    }
}
