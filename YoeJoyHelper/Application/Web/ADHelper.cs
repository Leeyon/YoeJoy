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
    /// 广告的helper类
    /// </summary>
    public class ADHelper
    {

        public static string GetSiteStaticAdWrapper(int positionId, string cssClass, string width, string height)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.SiteADCacheSetting;
            string key = String.Format(cacheSetting.CacheKey, positionId);
            int duration = cacheSetting.CacheDuration;
            string siteAdHTML = CacheObj<string>.GetCachedObj(key, duration, GetSiteStaticAd(positionId, cssClass, width, height));
            return siteAdHTML;
        }


        public static string GetSiteStaticAd(int positionId, string cssClass, string width, string height)
        {
            string siteAdHTML = String.Empty;
            string imageVitualPath = ConfigurationManager.AppSettings["ImageVitrualPath"].ToString();
            ADModuleForSite ad = ADService.GetHomeAdByPosition(positionId);
            if (ad != null)
            {
                string adImg = String.Concat(imageVitualPath, ad.ADImg);
                if (String.IsNullOrEmpty(width) || String.IsNullOrEmpty(height))
                {
                    siteAdHTML = String.Format("<a class='{0}' href='{1}' target='_blank' ><img src='{2}' alt='{3}' /></a>", cssClass, ad.ADLink, adImg, ad.ADName);
                }
                else
                {
                    siteAdHTML = String.Format("<a class='{0}' href='{1}' target='_blank' ><img width='{2}' height='{3}' src='{4}' alt='{5}' /></a>", cssClass, ad.ADLink, width, height, adImg, ad.ADName);
                }
            }
            return siteAdHTML;
        }
    }
}
