using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoeJoyHelper.Model;

namespace YoeJoyHelper
{
    public class ProductDetailHelper
    {
        public static string GetProductDetailImages(int productSysNo)
        {
            string productImgHTML = String.Empty;

            List<ProductDetailImg> imgs = ProductDetailBasicService.GetProductDetailImgs(productSysNo);
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
