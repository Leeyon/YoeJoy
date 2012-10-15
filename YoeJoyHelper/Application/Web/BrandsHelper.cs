using System;
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
            CacheObjSetting cacheSetting = StaticCacheObjSettings.SiteHomeInComingProductsCacheSetting;
            string key = cacheSetting.CacheKey;
            int duration = cacheSetting.CacheDuration;
            string homeBrandsHTML = CacheObj<string>.GetCachedObj(key, duration, GetBrandsForHome(topNum));
            return homeBrandsHTML;
        }

        public static string GetBrandsForCategoryOneProductsWrapper(string c1SysNo)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.HomeCategoryOneProductBrandsDisplayCacheSettings;
            string key =String.Format(cacheSetting.CacheKey,c1SysNo);
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
            List<BrandForHome> homeBrands = BrandService.GetHomeCenterBrands(topNum.ToString().Trim());
            if (homeBrands != null)
            {
                foreach (BrandForHome homeBrand in homeBrands)
                {
                    strb.Append(string.Format(@"<li><a href='./brands.aspx?bid={0}' target='_self''>
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
                string tdHTMLTemplate = @"<td><img src='{0}' alt='{1}' /></td>";
                StringBuilder strb = new StringBuilder();
                for (int i = 0; i < tRowCount; i++)
                {
                    strb.Append("<tr>");
                    for (int j = i * 2, k = 0; j < homeBrands.Count && k < 2; j++, k++)
                    {
                        strb.Append(String.Format(tdHTMLTemplate, imageVitualPath + homeBrands[j].BrandLogo, homeBrands[j].BrandName));
                    }
                    strb.Append("</tr>");
                }
                homeBrandsHTML = strb.ToString();
            }
            return homeBrandsHTML;
        }
    }
}
