using Client.Core.Data.Entities;
using ind.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace idn.AnPhu.Biz.Models
{
    public class News : EntityBase
    {
        [DataColum]
        public int NewsId { get; set; }

        [DataColum]
        public int NewsCategoryId { get; set; }

        [DataColum]
        public string NewsTitle { get; set; }

        [DataColum]
        public string NewsShortName { get; set; }

        [DataColum]
        public string NewsImage { get; set; }

        [DataColum]
        public string NewsSummary { get; set; }

        [DataColum]
        public string NewsBody { get; set; }

        [DataColum]
        public string NewsDescription { get; set; }

        [DataColum]
        public string NewsKeyword { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public DateTime PublishDate { get; set; }

        [DataColum]
        public string ShowDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public string Culture { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public int Count { get; set; }

        [DataColum]
        public bool IsHotNews { get; set; }

        [DataColum]
        public bool IsAdsNews { get; set; }

        [DataColum]
        public string NewsCategoryTitle { get; set; }
        [DataColum]
        public string NewsCategoryShortName { get; set; }

    }

    public class NewsCategories : NewsCategoryBase
    {
        public NewsCategories()
            : base()
        {
        }
        public NewsCategories(int id)
            : this()
        {

            this.NewsCategoryId = id;
        }
        public NewsCategories(string name)
            : this()
        {

            this.NewsCategoryTitle = name;
        }
        [DataColum]
        public string NewsCategoryShortName { get; set; }

        [DataColum]
        public string NewsCategorySummary { get; set; }

        [DataColum]
        public string NewsCategoryDescription { get; set; }

        [DataColum]
        public string NewsCategoryKeyword { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public int OrderNo { get; set; }

        [DataColum]
        public string Culture { get; set; }

        public List<News> ListNews { get; set; }

    }
}
