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
            services.Add(typeof(AdBannerRightsManager), new AdBannerRightsManager(new AdBannerRightsProvider()));
            services.Add(typeof(CategoriesNewsManager), new CategoriesNewsManager(new CategoriesNewsProvider()));
            services.Add(typeof(CompanyManager), new CompanyManager(new CompanyProvider()));
            services.Add(typeof(HtmlPageCategoriesManager), new HtmlPageCategoriesManager(new HtmlPageCategoriesProvider()));
            services.Add(typeof(HtmlPagesManager), new HtmlPagesManager(new HtmlPagesProvider()));
            services.Add(typeof(LocationDiscountsManager), new LocationDiscountsManager(new LocationDiscountsProvider()));
            services.Add(typeof(PopupAdvertisementManager), new PopupAdvertisementManager(new PopupAdvertisementProvider()));
            services.Add(typeof(PriceOptionsManager), new PriceOptionsManager(new PriceOptionsProvider()));
            services.Add(typeof(SlideBannersManager), new SlideBannersManager(new SlideBannersProvider()));
            services.Add(typeof(VideoCategoriesManager), new VideoCategoriesManager(new VideoCategoriesProvider()));
            services.Add(typeof(AdBannerLeftsManager), new AdBannerLeftsManager(new AdBannerLeftsProvider()));
            services.Add(typeof(VideosManager), new VideosManager(new VideosProvider()));
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

        public static AdBannerRightsManager AdBannerRightsManager
        {
            get
            {
                return (AdBannerRightsManager)services[typeof(AdBannerRightsManager)];
            }
            set
            {
                services[typeof(AdBannerRightsManager)] = value;
            }
        }

        public static VideosManager VideosManager
        {
            get
            {
                return (VideosManager)services[typeof(VideosManager)];
            }
            set
            {
                services[typeof(VideosManager)] = value;
            }
        }
        public static AdBannerLeftsManager AdBannerLeftsManager
        {
            get
            {
                return (AdBannerLeftsManager)services[typeof(AdBannerLeftsManager)];
            }
            set
            {
                services[typeof(AdBannerLeftsManager)] = value;
            }
        }
        public static VideoCategoriesManager VideoCategoriesManager
        {
            get
            {
                return (VideoCategoriesManager)services[typeof(VideoCategoriesManager)];
            }
            set
            {
                services[typeof(VideoCategoriesManager)] = value;
            }
        }
        public static SlideBannersManager SlideBannersManager
        {
            get
            {
                return (SlideBannersManager)services[typeof(SlideBannersManager)];
            }
            set
            {
                services[typeof(SlideBannersManager)] = value;
            }
        }
        public static PriceOptionsManager PriceOptionsManager
        {
            get
            {
                return (PriceOptionsManager)services[typeof(PriceOptionsManager)];
            }
            set
            {
                services[typeof(PriceOptionsManager)] = value;
            }
        }
        public static PopupAdvertisementManager PopupAdvertisementManager
        {
            get
            {
                return (PopupAdvertisementManager)services[typeof(PopupAdvertisementManager)];
            }
            set
            {
                services[typeof(PopupAdvertisementManager)] = value;
            }
        }
        public static LocationDiscountsManager LocationDiscountsManager
        {
            get
            {
                return (LocationDiscountsManager)services[typeof(LocationDiscountsManager)];
            }
            set
            {
                services[typeof(LocationDiscountsManager)] = value;
            }
        }
        public static HtmlPagesManager HtmlPagesManager
        {
            get
            {
                return (HtmlPagesManager)services[typeof(HtmlPagesManager)];
            }
            set
            {
                services[typeof(HtmlPagesManager)] = value;
            }
        }
        public static HtmlPageCategoriesManager HtmlPageCategoriesManager
        {
            get
            {
                return (HtmlPageCategoriesManager)services[typeof(HtmlPageCategoriesManager)];
            }
            set
            {
                services[typeof(HtmlPageCategoriesManager)] = value;
            }
        }
        public static CompanyManager CompanyManager
        {
            get
            {
                return (CompanyManager)services[typeof(CompanyManager)];
            }
            set
            {
                services[typeof(CompanyManager)] = value;
            }
        }
        public static CategoriesNewsManager CategoriesNewsManager
        {
            get
            {
                return (CategoriesNewsManager)services[typeof(CategoriesNewsManager)];
            }
            set
            {
                services[typeof(CategoriesNewsManager)] = value;
            }
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
