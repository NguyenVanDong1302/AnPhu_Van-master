﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Constants
{
    public class Stage
    {
        public const string Null = "N";
        public const string Pending = "P";
        public const string Cancel = "C";
        public const string Approved = "A";
        public const string Finished = "F";
        public const string Rejected = "R";
        public const string Working = "W";

        public const string WorkingFull = "WORKING";
        public const string ApprovedFull = "APPROVE";
        public const string PendingFull = "PENDING";

        public const string CancelFull = "CANCEL";
        public const string FinishFull = "FINISH";
        public const string ArriveFull = "ARRIVE";
        public const string RejectFull = "REJECT";
        public const string NoneFull = "NONE";


    }

    public class SexType
    {
        public const string Male = "MALE";
        public const string Female = "FEMALE";
    }

    /// <summary>
    /// 
    /// </summary>
    public class TableName
    {
        public const string Sys_User = "Sys_User";
        public const string Sys_Group = "Sys_Group";
        public const string PrdCategories = "PrdCategories";
        public const string Product = "Product";
        public const string ProductProperties = "ProductProperties";
        public const string ProductVersions = "ProductVersions";
        public const string ProductReviews = "ProductReviews";
        public const string AppDicDomain = "AppDicDomain";
        public const string AdBannerRights = "AdBannerRights";
        public const string CategoriesNews = "CategoriesNews";
        public const string Company = "Company";
        public const string HtmlPageCategories = "HtmlPageCategories";
        public const string HtmlPages = "HtmlPages";
        public const string LocationDiscounts = "LocationDiscounts";
        public const string PopupAdvertisement = "PopupAdvertisement";
        public const string PriceOptions = "PriceOptions";
        public const string SlideBanners = "SlideBanners";
        public const string VideoCategories = "VideoCategories";
        public const string AdBannerLefts = "AdBannerLefts";
        public const string Videos = "Videos";
        public const string News = "News";

    }

    #region["Columns Table"]
    public class TblSys_Group
    {
        public const string GroupCode = "GroupCode";
        public const string GroupName = "GroupName";
        public const string Description = "Description";
        public const string FlagActive = "FlagActive";
        public const string CreateDTime = "CreateDTime";
        public const string CreateBy = "CreateBy";
        public const string UpdateDTime = "UpdateDTime";
        public const string UpdateBy = "UpdateBy";
    }

    public class TblSys_User
    {
        public string UserCode = "UserCode";
    }
    #endregion


    #region["Breadcrumb"]
    public static class Breadcrumb_Code
    {
        public const string Dashboard = "Dashboard";
        public const string Sys_User = "Sys_User";
        
        // Common
        public const string Create = "Create";
        public const string Update = "Update";
        public const string Detail = "Detail";
    }
    public static class Breadcrumb_Name
    {
        public const string Dashboard = "Dashboard";
        public const string Sys_User = "Người dùng";
        // Common
        public const string Create = "Tạo mới";
        public const string Update = "Cập nhật";
        public const string Detail = "Chi tiết";
    }
    #endregion
}
