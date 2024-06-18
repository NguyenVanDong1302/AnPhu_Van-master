using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class HtmlPageCategory : HtmlPageCategoryBase
    {
        public HtmlPageCategory()
            : base()
        {
        }
        public HtmlPageCategory(int id)
            : this()
        {

            this.HtmlPageCategoryId = id;
        }
        public HtmlPageCategory(string name)
            : this()
        {

            this.HtmlPageCategoryTitle = name;
        }

        [DataColum]
        public string HtmlPageCategoryShortName { get; set; }

        [DataColum]
        public string HtmlPageCategorySummary { get; set; }

        [DataColum]
        public string HtmlPageCategoryDescription { get; set; }

        [DataColum]
        public string HtmlPageCategoryKeyword { get; set; }
        [DataColum]
        public string HtmlPageCategoryImage { get; set; }

        [DataColum]
        public string HtmlPageCategoryImage2 { get; set; }


        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string HtmlPageCategoryParentName { get; set; }
        public List<HtmlPage> ListPage { get; set; }

    }
}
