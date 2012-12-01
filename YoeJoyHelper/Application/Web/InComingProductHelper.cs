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
            StringBuilder strb = new StringBuilder("<ul class='product products'>");
            foreach (InComingProductForHome product in inComingProducts)
            {
                string productLink = String.Format("/Pages/Product.aspx?c1={0}&c2={1}&c3={2}&pid={3}", product.C1SysNo, product.C2SysNo, product.C3SysNo, product.SysNo);
                string innerHTML = @"<li>
                    <h3>
                        <a href='{0}'>
                            <img alt='产品图片' src='{1}' width='140' height='140'/></a></h3>
                    <p>
                        <a href='{2}'>{3}</a></p>
                    <b>￥{4}</b> </li>";
                string imgURL = String.Concat(imageVitualPath, product.ImgCover);
                strb.Append(String.Format(innerHTML, productLink, imgURL, productLink,product.PromotionWord,product.Price));
            }
            strb.Append("</ul>");
            HomeInComingProductHTML = strb.ToString();
            return HomeInComingProductHTML;
        }
    }
}
