using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoeJoyHelper.Model;
using System.Configuration;

using Icson.Utils;
using Icson.Objects.Sale;
using Icson.Objects.Basic;

using Icson.BLL;
using Icson.BLL.Basic;
using Icson.BLL.Sale;
using Icson.Objects;

namespace YoeJoyHelper
{
    /// <summary>
    /// 限时抢购的Helper类
    /// </summary>
    public class PanicBuyingHelper
    {
        public static string GetPanicProductsForHome()
        {
            string HomePanicHTML = String.Empty;
            List<PanicBuyingProductModelForHome> panicProducts = PanicBuyingProductService.GetHomePanicProduct();
            if (panicProducts != null)
            {
                string imageVitualPath = ConfigurationManager.AppSettings["ImageVitrualPath"].ToString();
                StringBuilder strb = new StringBuilder("<ul id='container'>");
                foreach (PanicBuyingProductModelForHome panic in panicProducts)
                {
                    string liTemplate = @"<li style='text-align:center;'>
                            <p align='center'>
                                <div class='time'>
                                <span class='qgtime'>100</span>天<span class='qgtime'>23</span>小时<span class='qgtime'>59</span>分<span
                                    class='qgtime'>59</span>秒</div>
                                <a href='products/product.html?pid={0}'>
                                    <img src='{1}' alt='商品' width='100' height='100' /></a><br />
                                <a href='products/product.html?pid={2}'>{3}</a><br />
                                抢购价:<span class='price01'> ￥{4}</span></p> 
                                <input type='hidden' class='buttonEndTime' value='{5}'/>
                        </li>";
                    string imgURL = String.Concat(imageVitualPath, panic.CoverImg);
                    strb.Append(String.Format(liTemplate, panic.ProductSysNo, (imageVitualPath + panic.CoverImg), panic.ProductSysNo, panic.PromotionWord, panic.ProductPrice, panic.EndTime.ToString("MM-dd-yyyy HH:mm:ss")));
                }
                strb.Append("</ul>");
                HomePanicHTML = strb.ToString();
            }
            return HomePanicHTML;
        }
    }
}
