using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Biz.Persistance.SqlServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class ServiceFactory
    {
        static Hashtable services = new Hashtable();

        static ServiceFactory()
        {
            #region["Auth"]
            services.Add(typeof(Sys_UserManager), new Sys_UserManager(new Sys_UserProvider()));
            services.Add(typeof(Sys_GroupManager), new Sys_GroupManager(new Sys_GroupProvider()));
            services.Add(typeof(PrdCategoriesManager), new PrdCategoriesManager(new AnPhu.Biz.Persistance.SqlServer.PrdCategoriesProvider()));
            services.Add(typeof(ProductPropertyManager), new ProductPropertyManager(new ProductPropertyProvider()));
            services.Add(typeof(ProductReviewManager), new ProductReviewManager(new AnPhu.Biz.Persistance.SqlServer.ProductReviewProvider()));
            services.Add(typeof(AppDicDomainManager), new AppDicDomainManager(new AnPhu.Biz.Persistance.SqlServer.AppDicDomainProvider()));
            services.Add(typeof(ProductManager), new ProductManager(new idn.AnPhu.Biz.Persistance.SqlServer.ProductProvider()));
            services.Add(typeof(SlideBannerManager), new SlideBannerManager(new idn.AnPhu.Biz.Persistance.SqlServer.SlideBanneProvider()));
            services.Add(typeof(NewsManager), new NewsManager(new idn.AnPhu.Biz.Persistance.SqlServer.NewsProvider()));
            services.Add(typeof(HtmlPageCategoryManager), new HtmlPageCategoryManager(new idn.AnPhu.Biz.Persistance.SqlServer.HtmlPageCategoryProvider()));
            services.Add(typeof(HtmlPageManager), new HtmlPageManager(new idn.AnPhu.Biz.Persistance.SqlServer.HtmlPageProvider()));
            services.Add(typeof(NewsCategoryManager), new NewsCategoryManager(new idn.AnPhu.Biz.Persistance.SqlServer.NewsCategoryProvider()));
            services.Add(typeof(VideoCategoryManager), new VideoCategoryManager(new idn.AnPhu.Biz.Persistance.SqlServer.VideoCategoryProvider()));
            services.Add(typeof(VideoManager), new VideoManager(new idn.AnPhu.Biz.Persistance.SqlServer.VideoProvider()));
            services.Add(typeof(ProductPropertiesManager), new ProductPropertiesManager(new ProductPropertiesProvider()));
            services.Add(typeof(ProductReviewsManager), new ProductReviewsManager(new ProductReviewsProvider()));
            services.Add(typeof(ProductVersionsManager), new ProductVersionsManager(new ProductVersionsProvider()));
            #endregion
        }

        public static T GetService<T>()
        {
            foreach (var service in services.Values)
            {
                if (service is T)
                {
                    return (T)service;
                }
            }
            return default(T);
        }

        public static Sys_UserManager Sys_UserManager
        {
            get
            {
                return (Sys_UserManager)services[typeof(Sys_UserManager)];
            }
            set
            {
                services[typeof(Sys_UserManager)] = value;
            }
        }
        public static Sys_GroupManager Sys_GroupManager
        {
            get
            {
                return (Sys_GroupManager)services[typeof(Sys_GroupManager)];
            }
            set
            {   
                services[typeof(Sys_GroupManager)] = value;
            }
        }

        public static ProductVersionsManager ProductVersionsManager
        {
            get
            {
                return (ProductVersionsManager)services[typeof(ProductVersionsManager)];
            }
            set
            {
                services[typeof(ProductVersionsManager)] = value;
            }
        }
        //public static PrdCategoriesManager ProductCategoryManager
        //{
        //    get
        //    {
        //        return (PrdCategoriesManager)services[typeof(PrdCategoriesManager)];
        //    }
        //    set
        //    {
        //        services[typeof(PrdCategoriesManager)] = value;
        //    }
        //}

        public static PrdCategoriesManager PrdCategoriesManager
        {
            get
            {
                return (PrdCategoriesManager)services[typeof(PrdCategoriesManager)];
            }
            set
            {
                services[typeof(PrdCategoriesManager)] = value;
            }
        }
        public static ProductReviewsManager ProductReviewsManager
        {
            get
            {
                return (ProductReviewsManager)services[typeof(ProductReviewsManager)];
            }
            set
            {
                services[typeof(ProductReviewsManager)] = value;
            }
        }

        public static ProductManager ProductManager
        {
            get
            {
                return (ProductManager)services[typeof(ProductManager)];
            }
            set
            {
                services[typeof(ProductManager)] = value;
            }
        }

        //public static object ProductPropertyManager { get; set; }
        public static ProductPropertyManager ProductPropertyManager
        {
            get
            {
                return (ProductPropertyManager)services[typeof(ProductPropertyManager)];
            }
            set
            {
                services[typeof(ProductPropertyManager)] = value;
            }
        }

        public static ProductReviewManager ProductReviewManager
        {
            get
            {
                return (ProductReviewManager)services[typeof(ProductReviewManager)];
            }
            set
            {
                services[typeof(ProductReviewManager)] = value;
            }
        }

        public static AppDicDomainManager AppDicDomainManager
        {
            get
            {
                return (AppDicDomainManager)services[typeof(AppDicDomainManager)];
            }
            set
            {
                services[typeof(AppDicDomainManager)] = value;
            }
        }

        public static SlideBannerManager SlideBannerManager
        {
            get
            {
                return (SlideBannerManager)services[typeof(SlideBannerManager)];
            }
            set
            {
                services[typeof(SlideBannerManager)] = value;
            }
        }

        public static NewsManager NewsManager
        {
            get
            {
                return (NewsManager)services[typeof(NewsManager)];
            }
            set
            {
                services[typeof(NewsManager)] = value;
            }
        }

        public static HtmlPageCategoryManager HtmlPageCategoryManager
        {
            get
            {
                return (HtmlPageCategoryManager)services[typeof(HtmlPageCategoryManager)];
            }
            set
            {
                services[typeof(HtmlPageCategoryManager)] = value;
            }
        }

        public static HtmlPageManager HtmlPageManager
        {
            get
            {
                return (HtmlPageManager)services[typeof(HtmlPageManager)];
            }
            set
            {
                services[typeof(HtmlPageManager)] = value;
            }
        }
        public static NewsCategoryManager NewsCategoryManager
        {
            get
            {
                return (NewsCategoryManager)services[typeof(NewsCategoryManager)];
            }
            set
            {
                services[typeof(NewsCategoryManager)] = value;
            }
        }
        public static VideoCategoryManager VideoCategoryManager
        {
            get
            {
                return (VideoCategoryManager)services[typeof(VideoCategoryManager)];
            }
            set
            {
                services[typeof(VideoCategoryManager)] = value;
            }
        }

        public static VideoManager VideoManager
        {
            get
            {
                return (VideoManager)services[typeof(VideoManager)];
            }
            set
            {
                services[typeof(VideoManager)] = value;
            }
        }
        public static ProductPropertiesManager ProductPropertiesManager
        {
            get
            {
                return (ProductPropertiesManager)services[typeof(ProductPropertiesManager)];
            }
            set
            {
                services[typeof(ProductPropertiesManager)] = value;
            }
        }
    }

}
