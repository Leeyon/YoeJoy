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

        public static string GetSiteAdWrapper(int positionId)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.SiteADCacheSetting;
            string key = String.Format(cacheSetting.CacheKey, positionId);
            int duration = cacheSetting.CacheDuration;
            string siteAdHTML = CacheObj<string>.GetCachedObj(key, duration, GetSiteAd(positionId));
            return siteAdHTML;
        }


        public static string GetSiteAd(int positionId)
        {
            string siteAdHTML = String.Empty;
            string imageVitualPath = ConfigurationManager.AppSettings["ImageVitrualPath"].ToString();
            ADModuleForSite ad = ADService.GetHomeAdByPosition(positionId);
            if (ad != null)
            {
                string adImg = String.Concat(imageVitualPath, ad.ADImg);
                siteAdHTML = String.Format("<a href='{0}' target='_blank'><img src='{1}' alt='{2}' /></a>", ad.ADLink, adImg, ad.ADName);
            }
            return siteAdHTML;
        }
    }
}
