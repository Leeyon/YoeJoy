using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using Icson.BLL.Basic;
using Icson.DBAccess;
using Icson.Objects;
using Icson.Objects.Basic;
using Icson.Utils;
using YoeJoyHelper.Model;


namespace YoeJoyHelper
{
    /// <summary>
    /// 商品类别的helper类
    /// </summary>
    public class CategoryHelper
    {

        #region 辅助结构体
        internal struct C2C3Dic
        {
            internal string C2Name;
            internal List<C3MiniInfo> C3MiniList;
        }

        internal struct C3MiniInfo
        {
            internal int C3SysNo;
            internal string C3Name;
        }
        #endregion

        /// <summary>
        /// 定义共享的内存对象的GategoryList对象
        /// 主要用于遍历List获得相关信息
        /// </summary>
        private SortedList c1List = SharedCacheObj<SortedList>.GetSharedCacheObj(SharedCacheObjSettings.CategoryOneListCacheSettings, CategoryManager.GetInstance().GetC1List());
        private SortedList c2List = SharedCacheObj<SortedList>.GetSharedCacheObj(SharedCacheObjSettings.CategoryTwoListCacheSettings, CategoryManager.GetInstance().GetC2List());
        private SortedList c3List = SharedCacheObj<SortedList>.GetSharedCacheObj(SharedCacheObjSettings.CategoryThreeListCacheSettings, CategoryManager.GetInstance().GetC3List());

        /// <summary>
        /// 生成主页面的Top Category Navigation的包装方法
        /// 获得被缓存住的Top Category Navigation HTML字符串
        /// </summary>
        /// <returns></returns>
        public string InitCategoryNavigationWrapper()
        {
            CacheObjSetting cacheSetting = StaticCacheObjSettings.SiteTopCategoryNavigationCacheSetting;
            string key = cacheSetting.CacheKey;
            int duration = cacheSetting.CacheDuration;
            string categoryNavHTML = String.Empty;
            categoryNavHTML = CacheObj<string>.GetCachedObj(key, duration, InitCategoryNavigation());
            return categoryNavHTML;
        }

        public string InitSubCategoryNavigationWrapper(int c1SysNo)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.SiteSubCategoryNavigationCacheSetting;
            string key = String.Concat(cacheSetting.CacheKey, c1SysNo);
            int duration = cacheSetting.CacheDuration;
            string categoryNavHTML = String.Empty;
            categoryNavHTML = CacheObj<string>.GetCachedObj(key, duration, InitSubCategoryNavigation(c1SysNo));
            return categoryNavHTML;
        }

        /// <summary>
        /// 生成页面的Top Category Navigation
        /// </summary>
        /// <returns></returns>
        public string InitCategoryNavigation()
        {
            string categoryNavHTML = String.Empty;

            StringBuilder strb = new StringBuilder(@"<span class='header'></span>
    <div class='lbg'><ul id='MeunList'>");

            string baseURL = YoeJoyConfig.SiteBaseURL;

            foreach (Category1Info c1Info in c1List.Keys)
            {
                int c1SysNo = c1Info.SysNo;

                Dictionary<string, C2C3Dic> c2c3Dic = new Dictionary<string, C2C3Dic>();
                strb.Append(String.Format(@"<li class='hover'><div style='padding-top: 2px; border-top-color: currentColor; border-top-width: medium;
                        border-top-style: none;' class='liHover'>
                        <div class='ListMain'>
                            <h2><span>•</span>{0}<i>&gt;</i></h2><p>", c1Info.C1Name));

                foreach (Category2Info c2Info in c2List.Keys)
                {
                    int c2SysNo = c2Info.SysNo;
                    if (c2Info.C1SysNo == c1SysNo && c2List != null)
                    {
                        List<C3MiniInfo> c3InfoList = new List<C3MiniInfo>();
                        foreach (Category3Info c3Info in c3List.Keys)
                        {
                            if (c3Info.C2SysNo == c2SysNo && c3List != null)
                            {
                                c3InfoList.Add(new C3MiniInfo { C3SysNo = c3Info.SysNo, C3Name = c3Info.C3Name });
                            }
                        }
                        c2c3Dic.Add(c2Info.C2Name, new C2C3Dic() { C2Name = c2Info.C2Name, C3MiniList = c3InfoList });
                        strb.Append(String.Format("<a href='{0}Pages/SubProductList1.aspx?c1={1}'>{2}</a> ", baseURL, c1Info.C1ID, c2Info.C2Name));
                    }
                }
                strb.Append("</p></div></div>");

                strb.Append(@"<dl class='Listcontent'><dt> <ul class='menuTwo'>");
                foreach (string c2Name in c2c3Dic.Keys)
                {
                    strb.Append(String.Concat(@"<li><h3>" + c2Name + "</h3><ul>"));
                    foreach (C3MiniInfo c3Info in c2c3Dic[c2Name].C3MiniList)
                    {
                        strb.Append(String.Format(@"<li><a href='{0}Pages/SubProductList2.aspx?c1={1}&c3={2}'>{3}</a></li>", baseURL, c1SysNo, c3Info.C3SysNo, c3Info.C3Name));
                    }
                    strb.Append("</ul><li>");
                }
                strb.Append("</ul><div class='mem'></div></dt>");

                //推荐品牌
                strb.Append(@"<dd><div class='recomment'><h2>推荐品牌</h2><p>");

                List<BrandForHome> brands = BrandService.GetCategoryOneBrands(c1Info.SysNo.ToString().Trim());
                if (brands != null && brands.Count > 0)
                {
                    foreach (BrandForHome brand in brands)
                    {
                                strb.Append(@"<a href='#'>" + brand.BrandName + "</a>");
                    }
                }
                strb.Append("</p></div></dd></dl></li>");
            }

            strb.Append("</ul>");
            strb.Append(@"</div><div class='rbg'></div>");
            categoryNavHTML = strb.ToString();
            return categoryNavHTML;
        }

        /// <summary>
        /// 生成子页面的Sub Category Navigation
        /// </summary>
        /// <returns></returns>
        public string InitSubCategoryNavigation(int c1SysNo)
        {
            string categoryNavHTML = String.Empty;

            string baseURL = YoeJoyConfig.SiteBaseURL;
            StringBuilder strb = new StringBuilder(@"<div class='flbt'>");

            foreach (Category1Info c1Info in c1List.Keys)
            {
                if (c1Info.SysNo == c1SysNo)
                {
                    string c1Name = c1Info.C1Name.Trim();
                    strb.Append(String.Concat(c1Name, "</div>"));
                    strb.Append(@"<table border='0' cellspacing='0' cellpadding='0' width='100%' id='subCategoryMenu'><tbody>");

                    foreach (Category2Info c2Info in c2List.Keys)
                    {

                        if (c2Info.C1SysNo == c1SysNo && c2List != null)
                        {
                            int c2SysNo = c2Info.SysNo;
                            strb.Append(@"<tr><td><h3>");
                            strb.Append(c2Info.C2Name.Trim());
                            strb.Append("</h3><ul>");

                            foreach (Category3Info c3Info in c3List.Keys)
                            {
                                if (c3Info.C2SysNo == c2SysNo && c3List != null)
                                {
                                    int c3SysNo = c3Info.SysNo;

                                    strb.Append(string.Concat("<li><a href='", baseURL, "Pages/SubProductList2.aspx?c1=", c1SysNo, "&c2=", c2SysNo, "&c3=", c3SysNo, "'>"));
                                    strb.Append(c3Info.C3Name.Trim());
                                    strb.Append("</a>");
                                    strb.Append(String.Concat(@"<input type='hidden' value='", c3SysNo, "'/>"));
                                    strb.Append(String.Concat(@"<input type='hidden' value='", c3Info.C3Name.Trim(), "'/>"));
                                    strb.Append("</li>");
                                }
                            }
                            strb.Append("</ul>");
                        }
                    }

                }
            }

            strb.Append("</tboby></table>");
            categoryNavHTML = strb.ToString();
            return categoryNavHTML;
        }
    }
}
