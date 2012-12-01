using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoeJoyHelper.Model;

namespace YoeJoyHelper
{
    /// <summary>
    /// 前台商类品展示的Helper
    /// </summary>
    public class FrontProductsHelper
    {

        public static string GetHomeCategoryOneProductsDisplayHTMLWrapper(string categoryOneId)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.HomeCategoryOneProductDisplayCacheSettings;
            string key = String.Format(cacheSetting.CacheKey, categoryOneId);
            int duration = cacheSetting.CacheDuration;
            string homeCategoryOneProductsDisplayHTML = CacheObj<string>.GetCachedObj(key, duration, GetHomeCategoryOneProductsDisplayHTML(categoryOneId));
            return homeCategoryOneProductsDisplayHTML;
        }

        public static string GetC1ProductsDisplayHTMLWrapper(int categoryOneId)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.CategoryOneProductsDisplayCacheSettings;
            string key = String.Format(cacheSetting.CacheKey, categoryOneId);
            int duration = cacheSetting.CacheDuration;
            string c1ProductsDisplayHTML = CacheObj<string>.GetCachedObj(key, duration, GetC1ProductsDisplayHTML(categoryOneId));
            return c1ProductsDisplayHTML;
        }

        public static string GetC1EmptyInventoryProductsHTMLWrapper(int categoryOneId)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.CategoryOneEmptyInventoryProductsCacheSettings;
            string key = String.Format(cacheSetting.CacheKey, categoryOneId);
            int duration = cacheSetting.CacheDuration;
            string c1EmptyInventoryProductsHTML = CacheObj<string>.GetCachedObj(key, duration, GetC1EmptyInventoryProductsHTML(categoryOneId));
            return c1EmptyInventoryProductsHTML;
        }

        public static string GetC1LastedDisCountProductsHTMLWrapper(int categoryOneId)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.CategoryOneLastedDiscountProductsCacheSettings;
            string key = String.Format(cacheSetting.CacheKey, categoryOneId);
            int duration = cacheSetting.CacheDuration;
            string c1LastedDisCountProductsHTML = CacheObj<string>.GetCachedObj(key, duration, GetC1LastedDisCountProductsHTML(categoryOneId));
            return c1LastedDisCountProductsHTML;
        }

        public static string GetC1WeeklyBestSaledProductsHTMLWrapper(int categoryOneId)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.CategoryOneWeeklyBestSaledProductsCacheSettings;
            string key = String.Format(cacheSetting.CacheKey, categoryOneId);
            int duration = cacheSetting.CacheDuration;
            string c1WeeklyBestSaledProductsHTML = CacheObj<string>.GetCachedObj(key, duration, GetC1WeeklyBestSaledProductsHTML(categoryOneId));
            return c1WeeklyBestSaledProductsHTML;
        }

        /// <summary>
        /// 首页大类商品展示的HTML代码
        /// </summary>
        /// <param name="categoryOneId"></param>
        /// <returns></returns>
        public static string GetHomeCategoryOneProductsDisplayHTML(string categoryOneId)
        {
            string homeCategoryOneProductsDisplayHTML = String.Empty;
            Dictionary<int, string> c2IdDic = HomeCategoryOneProductService.GetCategoryTwoIDs(categoryOneId);
            if (c2IdDic != null)
            {
                StringBuilder strb = new StringBuilder("<div class='sort'>");

                strb.Append(@"<ul class='sortHeader'>");
                foreach (int key in c2IdDic.Keys)
                {
                    strb.Append(String.Concat("<li><a  href='#'>", c2IdDic[key].ToString().Trim(), "</a></li>"));
                }
                strb.Append("</ul>");
                strb.Append(@"<div class='main'>");
                string baseURL = YoeJoyConfig.SiteBaseURL;
                string deeplinkTemplate = "{0}Pages/Product.aspx?c1={1}&c2={2}&c3={3}&pid={4}";
                string productsItemHTMLTempate = @"<li>
                                    <div>
                                        <h3>
                                            <a href='{0}'>
                                                <img alt='产品图片' src='{1}' width='140' height='140'/></a></h3>
                                        <p>
                                            <a href='{2}'>{3}</a></p>
                                        <b>￥{4}</b>
                                    </div>
                                </li>";
                string imageBasePath = YoeJoyConfig.ImgVirtualPathBase;
                foreach (int key in c2IdDic.Keys)
                {
                    List<FrontDsiplayProduct> products = HomeCategoryOneProductService.GetHomeCategoryOneDisplayProducts(key);
                    strb.Append(" <div class='sort1Con'><ul class='product sortContent'>");
                    if (products != null)
                    {
                        for (int i = 0; i < products.Count; i++)
                        {
                            FrontDsiplayProduct product = products[i];
                            string imagePath = imageBasePath + product.ImgPath;
                            string deeplink = String.Format(deeplinkTemplate, baseURL, product.C1SysNo, product.C2SysNo, product.C3SysNo, product.ProductSysNo);
                            strb.Append(String.Format(productsItemHTMLTempate, deeplink, imagePath, deeplink, product.ProductPromotionWord, product.Price));
                        }
                        strb.Append("</ul></div>");
                    }
                }
                strb.Append("</div>");
                strb.Append("</div>");
                homeCategoryOneProductsDisplayHTML = strb.ToString();
            }
            return homeCategoryOneProductsDisplayHTML;
        }

        /// <summary>
        /// 获得大类下的所有二类展示的商品
        /// </summary>
        /// <param name="categoryOneId"></param>
        /// <returns></returns>
        public static string GetC1ProductsDisplayHTML(int categoryOneId)
        {
            string c1ProductsDisplayHTML = String.Empty;
            Dictionary<int, string> c2IdDic = C1DisplayProductService.GetC2DsiplayIDs(categoryOneId);
            if (c2IdDic != null)
            {
                StringBuilder strb = new StringBuilder();

                foreach (int key in c2IdDic.Keys)
                {
                    strb.Append(String.Format(@"<div class='threefl'><table border='0' cellSpacing='0' cellPadding='0' width='100%' height='22'>
          <tbody><tr>
            <td width='94'><span>{0}</span></td>
            <td align='right'>更多&gt;&gt;</td>
          </tr>
        </tbody></table>", c2IdDic[key].ToString().Trim()));

                    string imageBasePath = YoeJoyConfig.ImgVirtualPathBase;

                    strb.Append("<ul class='tslist list' style='height: 385px;'>");

                    List<FrontDsiplayProduct> c2Products = C1DisplayProductService.GetC1DsiplayProducts(key);
                    if (c2Products != null)
                    {
                        string productsItemHTMLTempate = @" <li><a href='pages/product.aspx?c1={0}&c2={1}&c3={2}&pid={3}'>
                        <p>
                            <img src='{4}' /><span class='price'>{5}元</span></p>
                        <span>{6}</span></a></li>";

                        foreach (FrontDsiplayProduct c2Product in c2Products)
                        {
                            string imagePath = imageBasePath + c2Product.ImgPath;
                            strb.Append(String.Format(productsItemHTMLTempate, categoryOneId, key, c2Product.C3SysNo, c2Product.ProductSysNo, imagePath, c2Product.Price, c2Product.ProductPromotionWord));
                        }

                    }
                    strb.Append("</ul>");
                    ADModuleForSite ad = ADService.GetHomeAdByPosition(key);
                    if (ad != null)
                    {
                        string c2AdHTMLTemplate = @"<a href='{0}' target='_blank'><img src='{1}' alt='{2}'></img></a>";
                        strb.Append(String.Format(c2AdHTMLTemplate, ad.ADLink, String.Concat(imageBasePath, ad.ADImg), ad.ADName));
                    }
                    strb.Append("</div>");
                }
                c1ProductsDisplayHTML = strb.ToString();
            }
            return c1ProductsDisplayHTML;
        }

        /// <summary>
        /// 获得大类的清库商品
        /// </summary>
        /// <param name="categoryOneId"></param>
        /// <returns></returns>
        public static string GetC1EmptyInventoryProductsHTML(int categoryOneId)
        {
            string c1EmptyInventoryProductsHTML = String.Empty;
            List<EmptyInventoryProduct> products = C1EmptyInventoryProductService.GetGetC1EmptyInventoryProducts(categoryOneId);
            StringBuilder strb = new StringBuilder("<ul class='s_item'>");
            if (products != null)
            {

                string emptyInventoryItemHTML = @"<li><a href='Product.aspx?c1={0}&c2={1}&c3={2}&pid={3}'>{4}</a>&nbsp;&nbsp;￥<span class='price'>{5}</span></li>";
                foreach (EmptyInventoryProduct product in products)
                {
                    strb.Append(String.Format(emptyInventoryItemHTML, categoryOneId, product.C2SysNo, product.C3SysNo, product.ProductSysNo, product.ProductPromotionWord, product.Price));
                }
                strb.Append("</ul>");
                c1EmptyInventoryProductsHTML = strb.ToString();
            }
            return c1EmptyInventoryProductsHTML;
        }

        /// <summary>
        /// 获得大类的最新降价模块的商品
        /// </summary>
        /// <param name="categoryOneId"></param>
        /// <returns></returns>
        public static string GetC1LastedDisCountProductsHTML(int categoryOneId)
        {
            string c1LastedDisCountProductsHTML = String.Empty;
            List<C1LastestDiscountProduct> products = C1LastedDisCountProductService.GetC1LastestDiscountProduct(categoryOneId);
            StringBuilder strb = new StringBuilder("<ul class='s_item'>");
            if (products != null)
            {
                string imageBasePath = YoeJoyConfig.ImgVirtualPathBase;
                string c1LastedDisCountProductItemHTML = @"<li>
                <table cellspacing='0' cellpadding='0'>
                    <tbody>
                        <tr>
                            <td width='60'>
                                <a href='products/product.html?c1={0}&c2={1}&c3={2}&pid={3}'>
                                    <img src='{4}'></a>
                            </td>
                            <td valign='top' width='124'>
                                <a href='products/product.html?c1={5}&c2={6}&c3={7}&pid={8}'>{9}</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ￥<span class='price'>{10}</span>
                            </td>
                            <td align='right'>
                                <span class='jjfd'>降价幅度：{11}%</span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </li>";
                foreach (C1LastestDiscountProduct product in products)
                {
                    string thumbImg = imageBasePath + product.ImgPath;
                    strb.Append(String.Format(c1LastedDisCountProductItemHTML,
                        categoryOneId, product.C2SysNo, product.C3SysNo, product.ProductSysNo, thumbImg,
                        categoryOneId, product.C2SysNo, product.C3SysNo, product.ProductSysNo,
                        product.ProductPromotionWord, product.Price, product.DiscountRate));
                }
                strb.Append("</ul>");
                c1LastedDisCountProductsHTML = strb.ToString();
            }
            return c1LastedDisCountProductsHTML;
        }

        /// <summary>
        /// 大类页面本周销量排行
        /// </summary>
        /// <param name="categoryOneId"></param>
        /// <returns></returns>
        public static string GetC1WeeklyBestSaledProductsHTML(int categoryOneId)
        {
            string c1WeeklyBestSaledProductsHTML = String.Empty;
            List<C1WeeklyBestSaledProduct> products = C1WeeklyBestSaledProductService.GetC1WeeklyBestSaledProduct(categoryOneId);
            StringBuilder strb = new StringBuilder("<ul class='m_item'>");
            if (products != null)
            {
                string imageBasePath = YoeJoyConfig.ImgVirtualPathBase;
                string c1LastedDisCountProductItemHTML = @"<li>
        <table border='0' cellspacing='0' cellpadding='0'>
            <tbody>
                <tr>
                    <td width='22' align='center'>
                        {0}
                    </td>
                    <td width='60'>
                        <a href='Product.aspx?c1={1}&c2={2}&c3={3}&pid={4}'>
                            <img src='{5}'/>
                        </a>
                    </td>
                    <td valign='top' width='102' align='right'>
                        <a href='Product.aspx?c1={6}&c2={7}&c3={8}&pid={9}'>
                            <p>
                                {10}</p>
                        </a>￥<span class='price'>{11}</span>
                    </td>
                </tr>
            </tbody>
        </table>
    </li>";

                for (int i = 0; i < products.Count; i++)
                {
                    C1WeeklyBestSaledProduct product = products[i];
                    string thumbImg = imageBasePath + product.ImgPath;
                    string productRankTag = i < 3 ? String.Concat(@"<img src='../static/images/xl", (i + 1), ".png'/>") : (i + 1).ToString().Trim();
                    strb.Append(String.Format(c1LastedDisCountProductItemHTML, productRankTag,
                        categoryOneId, product.C2SysNo, product.C3SysNo, product.ProductSysNo, thumbImg,
                        categoryOneId, product.C2SysNo, product.C3SysNo, product.ProductSysNo,
                        product.ProductPromotionWord, product.Price));
                }
                strb.Append("</ul>");
                c1WeeklyBestSaledProductsHTML = strb.ToString();
            }
            return c1WeeklyBestSaledProductsHTML;
        }

        /// <summary>
        /// 初始化第三类商品列表的表头
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="c3SysNo"></param>
        /// <param name="c1SysNo"></param>
        /// <param name="c2SysNo"></param>
        /// <returns></returns>
        public static string InitC3ProductListHeader(int c3SysNo, string attribution2Ids)
        {
            string productListHeaderHTML = String.Empty;
            int productTotalCount = C3ProductListSerivice.GetPagedProductListItemTotalCount(c3SysNo, attribution2Ids);
            StringBuilder strb = new StringBuilder("<div class='fyitem'>");
            if (productTotalCount == -1)
            {
                productListHeaderHTML = "<b>系统异常</b>";
            }
            else if (productTotalCount == 0)
            {
                productListHeaderHTML = "<b>没有符合条件的商品</b>";
            }
            else
            {
                int pagedCount = int.Parse(YoeJoyConfig.ProductListPagedCount);
                int totalPageCount = (productTotalCount <= pagedCount) ? 1 : productTotalCount / pagedCount;

                string enableArrowHTML = @"<a class='enableArrow' id='nextArrow'></a>";
                string disableArrowHTML = @"<a class='disableArrow' id='prevArrow'></a>";
                string topNavHTML = String.Empty;
                string topNavHTMLTemplate = @"共<span>{0}<input type='hidden' value='{1}' id='totalCount'/></span>个商品<img src='../static/images/pxtjfg.gif' width='2' height='20'><span id='currentPageNum'>1</span>/{2}<input type='hidden' value='1' id='currentPageIndex'/><input type='hidden' value='1' id='pagedSeed'/><input type='hidden' value='{3}' id='totalPagedCount'/><input type='hidden' value='{4}' id='seed'/>{5}{6}";
                if (totalPageCount == 1)
                {
                    topNavHTML = String.Format(topNavHTMLTemplate, productTotalCount, productTotalCount, totalPageCount, totalPageCount, pagedCount, disableArrowHTML, disableArrowHTML);
                }
                else
                {
                    topNavHTML = String.Format(topNavHTMLTemplate, productTotalCount, productTotalCount, totalPageCount, totalPageCount, pagedCount, disableArrowHTML, enableArrowHTML);
                }
                strb.Append(topNavHTML);
            }

            strb.Append("</div>");

            productListHeaderHTML = strb.ToString();

            return productListHeaderHTML;
        }

        /// <summary>
        /// 获得商品列表的底部导航栏
        /// </summary>
        /// <param name="c3SysNo"></param>
        /// <param name="attribution2Ids"></param>
        /// <returns></returns>
        public static string InitC3ProductListFooter(int c3SysNo, string attribution2Ids)
        {
            string productListFooterHTML = String.Empty;

            int productTotalCount = C3ProductListSerivice.GetPagedProductListItemTotalCount(c3SysNo, attribution2Ids);
            StringBuilder strb = new StringBuilder("<div id='listFooter' class='fyitem1' align='right'>");
            if (productTotalCount > 0)
            {
                int pagedCount = int.Parse(YoeJoyConfig.ProductListPagedCount);
                int totalPageCount = (productTotalCount <= pagedCount) ? 1 : productTotalCount / pagedCount;

                string disablePrevButtonHTML = @"<span id='prevBtn' class='prev prev0'>上一页</span>";
                string enableNextArrowHTML = @"<span id='nextBtn' class='prev next1'>下一页</span>";
                string bottomNavHTML = String.Empty;
                string bottomNavItemHTMLTemplate = @"<span class='pagenum'>{0}</span>";
                string bottomNavHTMLTemplate = @"{0}{1}{2}<span>共{3}页</span><span>到第</span>
        <input id='txtPageNum' maxlength='2' width='2' type='text' />
        <span>页</span>
        <input id='btnPageNum' value='确定' type='button' />";
                if (totalPageCount > 1)
                {
                    string bottomNavItenHTML = String.Empty;
                    for (int i = 1; i <= totalPageCount; i++)
                    {
                        bottomNavItenHTML += String.Format(bottomNavItemHTMLTemplate, i);
                    }
                    bottomNavHTML = String.Format(bottomNavHTMLTemplate, disablePrevButtonHTML, bottomNavItenHTML, enableNextArrowHTML, totalPageCount);
                }
                strb.Append(bottomNavHTML);
            }

            strb.Append("</div>");

            productListFooterHTML = strb.ToString();

            return productListFooterHTML;
        }

        /// <summary>
        /// 获得商品列表的筛选项目
        /// </summary>
        /// <param name="c3SysNo"></param>
        /// <returns></returns>
        public static string InitC3ProductFilter(int c3SysNo)
        {
            string C3ProductFilterHTML = String.Empty;

            List<C3ProductAttribution> c3Attrs = C3ProductListSerivice.GetC3ProductAttribution(c3SysNo);
            if (c3Attrs != null)
            {
                StringBuilder strb = new StringBuilder("<tbody id='filterTable'>");

                string filterItemHTMLTemplate = @"<tr>
                    <td class='option' valign='top' width='32' align='right'>
                        {0}:
                       <input type='hidden' value='{1}'/>
                    </td>
                    <td>
                        <ul>
                            <li class='selected'>全部<input type='hidden' value='0'/></li>
                            {2}
                            <input class='selectedValue' type='hidden' value='0'/>
                        </ul>
                    </td>
                </tr>".Trim();

                foreach (C3ProductAttribution attr in c3Attrs)
                {
                    if (attr.Options != null)
                    {
                        StringBuilder strb2 = new StringBuilder();
                        string filterOptionHTMLTemplate = @"<li>{0}<input type='hidden' value='{1}'/></li>";
                        foreach (C3ProductAttributionOption option in attr.Options)
                        {
                            strb2.Append(String.Format(filterOptionHTMLTemplate, option.OptionName, option.OptionSysNo));
                        }
                        strb.Append(String.Format(filterItemHTMLTemplate, attr.A2Name, attr.A2SysNo, strb2.ToString()));
                    }
                    else
                    {
                        strb.Append(String.Format(filterItemHTMLTemplate, attr.A2Name, attr.A2SysNo, String.Empty));
                    }
                }

                strb.Append("</tbody>");
                C3ProductFilterHTML = strb.ToString();
            }
            return C3ProductFilterHTML;
        }

        /// <summary>
        /// 获得商品列表
        /// </summary>
        /// <param name="orderOption"></param>
        /// <param name="startIndex"></param>
        /// <param name="pagedCount"></param>
        /// <param name="c3SysNo"></param>
        /// <param name="c1SysNo"></param>
        /// <param name="c2SysNo"></param>
        /// <returns></returns>
        public static string GetC3PageProductListHTML(YoeJoyEnum.ProductListSortedOrder orderOption, int startIndex, int c3SysNo, int c1SysNo, int c2SysNo, string attribution2Ids)
        {
            string productListHTML = String.Empty;
            StringBuilder strb = new StringBuilder("<ul>");

            string baseURL = YoeJoyConfig.SiteBaseURL;
            int pagedCount = int.Parse(YoeJoyConfig.ProductListPagedCount);

            List<FrontDsiplayProduct> products = C3ProductListSerivice.GetPagedProductList((startIndex - 1), pagedCount, c3SysNo, orderOption, attribution2Ids);
            if (products != null)
            {
                string imageBaseURL = YoeJoyConfig.ImgVirtualPathBase;
                string productListItemHTMLTemplate = @"<li><a href='Product.aspx?c1={0}&c2={1}&c3={2}&pid={3}' target='_parent'>
                            <p>
                                <img src='{4}'><span class='price'>{5}元</span></p>
                            <span>{6}</span></a></li>";
                foreach (FrontDsiplayProduct product in products)
                {
                    strb.Append(String.Format(productListItemHTMLTemplate, c1SysNo, c2SysNo, c3SysNo, product.ProductSysNo, String.Concat(imageBaseURL, product.ImgPath), product.Price, product.ProductPromotionWord));
                }
            }
            strb.Append("</ul>");

            productListHTML = strb.ToString();

            return productListHTML;
        }
    }
}
