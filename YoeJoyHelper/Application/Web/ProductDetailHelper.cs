using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoeJoyHelper.Model;

namespace YoeJoyHelper
{
    public class ProductDetailHelper
    {

        private ProductDetailModel productDetail;

        private ProductDetailHelper()
        {
            throw new NotImplementedException("禁止对ProductDetailHelper类声明无参的构造函数");
        }

        public ProductDetailHelper(int productSysNo)
        {
            //string key = String.Format(DynomicCacheObjSettings.ProductBaiscInfoCacheSettings.CacheKey, productSysNo);
            //int duration = DynomicCacheObjSettings.ProductBaiscInfoCacheSettings.CacheDuration;
            //productDetail = CacheObj<ProductDetailModel>.GetCachedObj(key, duration, ProductDetailBasicService.GetProductDetailBasicInfo(productSysNo));
            productDetail = ProductDetailBasicService.GetProductDetailBasicInfo(productSysNo);
        }

        /// <summary>
        /// 获取商品图片展示
        /// </summary>
        /// <returns></returns>
        public string GetProductDetailImages()
        {
            string productImgHTML = String.Empty;

            List<ProductDetailImg> imgs = productDetail.Images;
            if (imgs != null)
            {
                string imgVirtualPathBase = YoeJoyConfig.ImgVirtualPathBase;

                StringBuilder strb = new StringBuilder("<ul>");

                string imgItemHTMLTemplate = @"<li><a href='#'><span>
                                        <img src='{0}'></span><div>
                                        </div>
                                    </a></li>";


                foreach (ProductDetailImg img in imgs)
                {
                    strb.Append(String.Format(imgItemHTMLTemplate, String.Concat(imgVirtualPathBase, img.LargeImg)));
                }

                strb.Append("</ul>");
                productImgHTML = strb.ToString();
            }

            return productImgHTML;
        }
    }
}
