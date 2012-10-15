using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using YoeJoyHelper.Model;

namespace YoeJoyHelper
{
    /// <summary>
    /// 商品的Helper类
    /// </summary>
    public class InComingProductHelper
    {

        public static string GetInComingProductForHomeWrapper()
        {
            CacheObjSetting cacheSetting = StaticCacheObjSettings.SiteHomeBrandsCacheSetting;
            string key = cacheSetting.CacheKey;
            int duration = cacheSetting.CacheDuration;
            string HomeInComingProductHTML = CacheObj<string>.GetCachedObj(key, duration, GetInComingProductForHome());
            return HomeInComingProductHTML;
        }

        public static string GetInComingProductForHome()
        {
            string HomeInComingProductHTML = String.Empty;
            List<InComingProductForHome> inComingProducts = InComingProductService.GetHomeInComingProduct();
            string imageVitualPath = ConfigurationManager.AppSettings["ImageVitrualPath"].ToString();
            StringBuilder strb = new StringBuilder("<ul class='tslist list'>");
            foreach (InComingProductForHome product in inComingProducts)
            {
                string innerHTML = @"  <li><a href='products/product.html?pid={0}'>
                <p>
                    <img src='{1}' /><span class='price'>{2}元</span></p>
                <span>{3}</span></a></li>";
                string imgURL = String.Concat(imageVitualPath, product.ImgCover);
                strb.Append(String.Format(innerHTML, product.SysNo, imgURL, product.Price, product.PromotionWord));
            }
            strb.Append("</ul>");
            HomeInComingProductHTML = strb.ToString();
            return HomeInComingProductHTML;
        }
    }
}
