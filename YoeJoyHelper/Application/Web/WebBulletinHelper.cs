using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace YoeJoyHelper
{
    public class WebBulletinHelper
    {

        public static string GetWebBulletinListForHomeWrapper(int topNum)
        {
            CacheObjSetting cacheSetting = StaticCacheObjSettings.SiteHomeWebBulletinListCacheSetting;
            string key = cacheSetting.CacheKey;
            int duration = cacheSetting.CacheDuration;
            string homeWebBulletinListHTML = CacheObj<string>.GetCachedObj(key, duration, GetWebBulletinListForHome(topNum));
            return homeWebBulletinListHTML;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topNum">最多显示的文章标题条数</param>
        /// <returns></returns>
        public static string GetWebBulletinListForHome(int topNum)
        {
            string homeWebBulletinListHTML = String.Empty;
            StringBuilder strb = new StringBuilder("<ul>");
            Dictionary<string, string> list = WebBulletinUtility.GetWebBulletinList(topNum.ToString().Trim());
            if (list != null)
            {
                foreach (string key in list.Keys)
                {
                    strb.Append(string.Format(@"<li><a href='./news.aspx?nid={0}' target='_self''>{1}</a></li>", key, list[key]));
                }
            }
            strb.Append("</ul>");
            homeWebBulletinListHTML = strb.ToString();
            return homeWebBulletinListHTML;
        }
    }
}
