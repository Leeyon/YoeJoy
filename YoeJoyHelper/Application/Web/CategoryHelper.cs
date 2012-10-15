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

        #region 备用代码
        /// <summary>
        /// 定义共享的内存对象的GategoryList对象
        /// 主要用于快速检索Hashtable的相关信息
        /// </summary>
        //internal static Hashtable c1Hash = SharedCacheObj<Hashtable>.GetSharedCacheObj(SharedCacheObjSettings.CategoryOneHashCacheSettings, CategoryManager.GetInstance().GetC1Hash());
        //internal static Hashtable c2Hash = SharedCacheObj<Hashtable>.GetSharedCacheObj(SharedCacheObjSettings.CategoryTwoHashCacheSettings, CategoryManager.GetInstance().GetC2Hash());
        //internal static Hashtable c3Hash = SharedCacheObj<Hashtable>.GetSharedCacheObj(SharedCacheObjSettings.CategoryThreeHashCacheSettings, CategoryManager.GetInstance().GetC3Hash());
        #endregion

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

            StringBuilder strb = new StringBuilder();

            string baseURL = YoeJoyConfig.SiteBaseURL;

            foreach (Category1Info c1Info in c1List.Keys)
            {
                int c1SysNo = c1Info.SysNo;

                Dictionary<string, C2C3Dic> c2c3Dic = new Dictionary<string, C2C3Dic>();
                strb.Append(String.Concat(@"<tr><td class='item'><h3><a href='", baseURL,@"Pages/SubProductList1.aspx?c1=", c1SysNo, "' title='大分类'>"));
                strb.Append(c1Info.C1Name);
                strb.Append("</a></h3>");
                strb.Append("<ul class='item1 item0'>");

                foreach (Category2Info c2Info in c2List.Keys)
                {
                    int c2SysNo = c2Info.SysNo;

                    if (c2Info.C1SysNo == c1SysNo && c2List != null)
                    {
                        strb.Append(String.Concat(@"<li><a href='", baseURL,@"Pages/SubProductList2.aspx?c1=", c1SysNo, "&c2=", c2SysNo, "' title='二级分类'>", c2Info.C2Name, "</a></li>"));
                        List<C3MiniInfo> c3InfoList = new List<C3MiniInfo>();
                        foreach (Category3Info c3Info in c3List.Keys)
                        {
                            if (c3Info.C2SysNo == c2SysNo && c3List != null)
                            {
                                c3InfoList.Add(new C3MiniInfo { C3SysNo = c3Info.SysNo, C3Name = c3Info.C3Name });
                            }
                        }
                        c2c3Dic.Add(c2Info.C2Name, new C2C3Dic() { C2Name = c2Info.C2Name, C3MiniList = c3InfoList });
                    }
                }

                strb.Append("</ul>");
                strb.Append(@"<div class='fdmenu'><div class='l_global'><table border='0' cellpadding='0' cellspacing='0'>");

                foreach (string c2Name in c2c3Dic.Keys)
                {
                    strb.Append(String.Concat(@"<tr><td width='50' valign='top'><span class='fltitle'>", c2Name, "</span></td><td><ul>"));

                    foreach (C3MiniInfo c3Info in c2c3Dic[c2Name].C3MiniList)
                    {
                        strb.Append(String.Concat("<li>", c3Info.C3Name, "</li>"));
                    }

                    strb.Append("</ul></td></tr>");
                }

                strb.Append(@"</table></div><div class='r_global'><p>推荐品牌</p>");

                strb.Append("</div></div>");
                strb.Append(@"</td></tr>");
            }

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
                                    
                                    strb.Append(string.Concat("<li><a href='",baseURL,"Pages/SubProductList2.aspx?c1=", c1SysNo, "&c2=", c2SysNo, "&c3=", c3SysNo, "'>"));
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

        #region 备用代码
        ///// <summary>
        ///// 通过category1的sysNo获得分类信息
        ///// </summary>
        ///// <returns></returns>
        //public static Category1Info GetC1InfoBySysNo(int c1SysNo)
        //{
        //    if (c1Hash.ContainsKey(c1SysNo))
        //    {
        //        Category1Info c1Info = null;
        //        foreach (DictionaryEntry c1InfoDic in c1Hash)
        //        {
        //            if (((int)c1InfoDic.Key) == c1SysNo)
        //            {
        //                c1Info = c1InfoDic.Value as Category1Info;
        //            }
        //        }
        //        return c1Info;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// 通过category2的sysNo获得分类信息
        ///// </summary>
        ///// <param name="c2SysNo"></param>
        ///// <returns></returns>
        //public static Category2Info GetC2InfoBySysNo(int c2SysNo)
        //{
        //    if (c2Hash.ContainsKey(c2SysNo))
        //    {
        //        Category2Info c2Info = null;
        //        foreach (DictionaryEntry c2InfoDic in c2Hash)
        //        {
        //            if (((int)c2InfoDic.Key) == c2SysNo)
        //            {
        //                c2Info = c2InfoDic.Value as Category2Info;
        //            }
        //        }
        //        return c2Info;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// 通过category3的sysNo获得分类信息
        ///// </summary>
        ///// <param name="c3SysNo"></param>
        ///// <returns></returns>
        //public static Category3Info GetC3InfoBySysNo(int c3SysNo)
        //{
        //    if (c3Hash.ContainsKey(c3SysNo))
        //    {
        //        Category3Info c3Info = null;
        //        foreach (DictionaryEntry c3InfoDic in c3Hash)
        //        {
        //            if (((int)c3InfoDic.Key) == c3SysNo)
        //            {
        //                c3Info = c3InfoDic.Value as Category3Info;
        //            }
        //        }
        //        return c3Info;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        #endregion

    }
}
