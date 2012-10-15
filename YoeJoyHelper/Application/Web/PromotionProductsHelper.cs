using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YoeJoyHelper.Model;
using System.Configuration;
using System.Collections;

namespace YoeJoyHelper
{
    /// <summary>
    /// 促销商品的Helper类
    /// </summary>
    public class PromotionProductsHelper
    {


        public static string GetPromotionProductsForHome()
        {
            string homePromotionHTML = String.Empty;
            StringBuilder strb = new StringBuilder("<ul class='tslist list'>");
            List<PromotionProductModelForHome> promos = PromotionProductService.GetHomePromotionProducts();
            foreach (PromotionProductModelForHome promo in promos)
            {
                string imageVitualPath=ConfigurationManager.AppSettings["ImageVitrualPath"].ToString();
                string innerHTML=@"  <li><a href='products/product.html?pid={0}'>
                <p>
                    <img src='{1}' /><span class='price'>{2}元</span></p>
                <span>{3}</span></a></li>";
                strb.Append(String.Format(innerHTML, promo.ProductSysNo, (imageVitualPath + promo.LargeImgPath), promo.ProductPrice, promo.PromotionWord));
            }
            strb.Append("</ul>");
            homePromotionHTML = strb.ToString();
            return homePromotionHTML;
        }
    }
}
