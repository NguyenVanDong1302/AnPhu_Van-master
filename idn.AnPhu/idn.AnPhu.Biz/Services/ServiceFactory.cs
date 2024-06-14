﻿using idn.AnPhu.Biz.Persistance.SqlServer;
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

        public static PrdCategoriesManager ProductCategoryManager
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
    }
}
