﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Text;
using YoeJoyHelper.Model;

namespace YoeJoyHelper
{
    /// <summary>
    /// 品牌的Helper类
    /// </summary>
    public class BrandsHelper
    {

        public static string GetBrandsForHomeWrapper(int topNum)
        {
            CacheObjSetting cacheSetting = StaticCacheObjSettings.SiteHomeBrandsCacheSetting;
            string key = cacheSetting.CacheKey;
            int duration = cacheSetting.CacheDuration;
            string homeBrandsHTML = CacheObj<string>.GetCachedObj(key, duration, GetBrandsForHome(topNum));
            return homeBrandsHTML;
        }

        public static string GetBrandsForCategoryOneProductsWrapper(string c1SysNo)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.HomeCategoryOneProductBrandsDisplayCacheSettings;
            string key = String.Format(cacheSetting.CacheKey, c1SysNo);
            int duration = cacheSetting.CacheDuration;
            string homeBrandsHTML = CacheObj<string>.GetCachedObj(key, duration, GetBrandsForCategoryOneProducts(c1SysNo));
            return homeBrandsHTML;
        }

        /// <summary>
        /// 得到首页显示的品牌旗舰店
        /// </summary>
        /// <returns></returns>
        public static string GetBrandsForHome(int topNum)
        {
            string homeBrandsHTML = String.Empty;
            string imageVitualPath = YoeJoyConfig.ImgVirtualPathBase;
            StringBuilder strb = new StringBuilder("<ul>");
            List<BrandForHome> homeBrands = BrandService.GetHomeCenterBrands(topNum);
            if (homeBrands != null)
            {
                foreach (BrandForHome homeBrand in homeBrands)
                {
                    strb.Append(string.Format(@"<a href='./brands.aspx?bid={0}' target='_self''>
                            <img alt='{1}' src='{2}' /></a></li>", homeBrand.BrandSysNo, homeBrand.BrandName, (imageVitualPath + homeBrand.BrandLogo)));
                }
            }
            strb.Append("</ul>");
            homeBrandsHTML = strb.ToString();
            return homeBrandsHTML;
        }

        /// <summary>
        /// 大类商品展示商标
        /// </summary>
        /// <returns></returns>
        public static string GetBrandsForCategoryOneProducts(string c1SysNo)
        {
            string homeBrandsHTML = String.Empty;
            string imageVitualPath = YoeJoyConfig.ImgVirtualPathBase;

            List<BrandForHome> homeBrands = BrandService.GetCategoryOneBrands(c1SysNo);
            if (homeBrands != null)
            {
                int tRowCount = homeBrands.Count % 8;
                string tdHTMLTemplate = @"<li><a href='{0}brands.aspx?bid={1}'><img src='{2}'></a> </li>";
                StringBuilder strb = new StringBuilder("<ul>");
                for (int i = 0; i < tRowCount; i++)
                {
                    strb.Append(String.Format(tdHTMLTemplate,YoeJoyConfig.SiteBaseURL,homeBrands[i].BrandSysNo,imageVitualPath + homeBrands[i].BrandLogo, homeBrands[i].BrandName));
                }
                strb.Append("</ul>");
                homeBrandsHTML = strb.ToString();
            }
            return homeBrandsHTML;
        }
    }
}
