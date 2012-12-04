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

        public static string GetHomePromotionProductsHTMWrapper()
        {
            CacheObjSetting cacheSetting = StaticCacheObjSettings.SiteHomePromoProductListCacheSetting;
            string key = cacheSetting.CacheKey;
            int duration = cacheSetting.CacheDuration;
            string homePromotion = CacheObj<string>.GetCachedObj(key, duration, GetHomePromotionProductsHTML());
            return homePromotion;
        }

        public static string InitC3ProductFilterWrapper(int c3SysNo)
        {
            CacheObjSetting cacheSetting = DynomicCacheObjSettings.CategoryOneWeeklyBestSaledProductsCacheSettings;
            string key = String.Format(cacheSetting.CacheKey, c3SysNo);
            int duration = cacheSetting.CacheDuration;
            string c3ProductFilterHTML = CacheObj<string>.GetCachedObj(key, duration, InitC3ProductFilter(c3SysNo));
            return c3ProductFilterHTML;
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
                    strb.Append(String.Format(@"<div class='chocolate'>
            <h2>
                <span>{0}</span> <a href='#'>更多&gt;&gt;</a>
            </h2>
            <div class='mainShow'>
                <div class='mainProduct'>", c2IdDic[key].ToString().Trim()));

                    string imageBasePath = YoeJoyConfig.ImgVirtualPathBase;

                    strb.Append("<ul class='product'>");

                    List<FrontDsiplayProduct> c2Products = C1DisplayProductService.GetC1DsiplayProducts(key);
                    if (c2Products != null)
                    {
                        string productsItemHTMLTempate = @"<li>
                  <div>
                    <h3><a href='{0}'><img alt='产品图片' src='{1}' width='140' height='140'></a></h3>
                    <p><a href='{2}'>{3}</a></p>
                    <b>￥{4}</b> </div>
                </li>";

                        foreach (FrontDsiplayProduct c2Product in c2Products)
                        {
                            string imagePath = imageBasePath + c2Product.ImgPath;
                            string deeplink = YoeJoyConfig.SiteBaseURL + "pages/product.aspx?c1=" + categoryOneId + "&c2=" + key + "&c3=" + c2Product.C3SysNo + "&pid=" + c2Product.ProductSysNo;
                            strb.Append(String.Format(productsItemHTMLTempate, deeplink, imagePath, deeplink, c2Product.ProductPromotionWord, c2Product.Price));
                        }

                    }
                    strb.Append("</ul></div>");
                    ADModuleForSite ad = ADService.GetHomeAdByPosition(key);
                    if (ad != null)
                    {
                        string c2AdHTMLTemplate = @"<div class='hot'><a href='{0}' target='_blank'><img width='192' height='360' src='{1}' alt='{2}'></img></a>";
                        strb.Append(String.Format(c2AdHTMLTemplate, ad.ADLink, String.Concat(imageBasePath, ad.ADImg), ad.ADName));
                    }
                    strb.Append("</div></div></div>");
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
            List<C1WeeklyBestSaledProduct> products = C1EmptyInventoryProductService.GetGetC1EmptyInventoryProducts(categoryOneId);
            StringBuilder strb = new StringBuilder();
            if (products != null)
            {
                string emptyInventoryItemHTML = @"<dd>
                    <h2>
                        <a href='{0}'>
                            <img src='{1}'></a></h2>
                    <p>
                        <a href='{2}'>{3}</a> <span>￥<em>{4}</em></span>
                    </p>
                </dd>";

                foreach (C1WeeklyBestSaledProduct product in products)
                {
                    string thumbImg = YoeJoyConfig.ImgVirtualPathBase + product.ImgPath;
                    string deeplink = YoeJoyConfig.SiteBaseURL + "Pages/Product.aspx?c1=" + categoryOneId + "&c2=" + product.C2SysNo + "&c3=" + product.C3SysNo + "&pid=" + product.ProductSysNo;
                    strb.Append(String.Format(emptyInventoryItemHTML, deeplink, thumbImg, deeplink, product.ProductPromotionWord, product.Price));
                }
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
            StringBuilder strb = new StringBuilder("<ul class='sellRanking'>");
            if (products != null)
            {
                string imageBasePath = YoeJoyConfig.ImgVirtualPathBase;
                string c1LastedDisCountProductItemHTML = @"<li><span>1</span> <a class='productPic' href='{0}'>
                        <img src='{1}'></a>
                        <p>
                            <a href='{2}'>{3}</a> <em>￥<b>{4}</b></em>
                        </p>
                    </li>";

                for (int i = 0; i < products.Count; i++)
                {
                    C1WeeklyBestSaledProduct product = products[i];
                    string thumbImg = imageBasePath + product.ImgPath;
                    string deeplink = YoeJoyConfig.SiteBaseURL + "Pages/Product.aspx?c1=" + categoryOneId + "&c2=" + product.C2SysNo + "&c3=" + product.C3SysNo + "&pid=" + product.ProductSysNo;
                    strb.Append(String.Format(c1LastedDisCountProductItemHTML, deeplink, thumbImg, deeplink, product.ProductPromotionWord, product.Price));
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
                StringBuilder strb = new StringBuilder();

                string filterItemHTMLTemplate = @"<div class='attr'><input class='selectedValue' value='0' type='hidden'> <em class='attrName'>{0}：<input type='hidden' value='{1}'/></em>
                    <a class='all selected' href='javascript:'>全部<input type='hidden' value='0'/></a>
<strong>{2}</strong> </div>".Trim();

                foreach (C3ProductAttribution attr in c3Attrs)
                {
                    if (attr.Options != null)
                    {
                        StringBuilder strb2 = new StringBuilder();
                        string filterOptionHTMLTemplate = @"<span><a href='javascript:'>{0}</a><input type='hidden' value='{1}'/></span>";
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
                string productListItemHTMLTemplate1 = @"<li class='show1'>
                    <div class='group'>
                        <div class='photo'>
                            <a href='{0}' target='_parent'>
                                <img class='photo' alt='商品' src='{1}'
                                    width='190' height='190'/></a></div>
                        <div class='goodsName'>
                            <a href='{2}'>{3}</a></div>
                        <div class='mem0'>
                            <p class='price'>
                                ¥{4}</p>
                            <p align='right'>
                                评论:1000条</p>
                        </div>
                        <div class='botton'>
                            <a class='ck' href='{5}' target='_parent'>查看详情</a></div>
                    </div>
                </li>";

                string productListItemHTMLTemplate2 = @"<li class='show2'>
                    <div class='group'>
                        <div class='photo'>
                            <a href='{0}' target='_parent'>
                                <img class='photo' alt='商品' src='{1}'
                                    width='190' height='190'></a></div>
                        <div class='goodsName'>
                            <a href='{2}'>{3}</a></div>
                        <div class='mem0'>
                            <p class='price'>
                                ¥{4}</p>
                            <p align='right'>
                                评论:1000条</p>
                        </div>
                        <div class='botton'>
                            <p>
                                <a class='sub' href='javascript:void(0)'>-</a>
                                <input class='num' maxlength='3' value='1' type='text'>
                                <a class='add' href='javascript:void(0)'>+</a></p>
                            <a class='ck' href='process1.html'>直接购买</a></div>
                    </div>
                </li>";
                foreach (FrontDsiplayProduct product in products)
                {
                    string imgPath = YoeJoyConfig.ImgVirtualPathBase + product.ImgPath;
                    string deeplink = YoeJoyConfig.SiteBaseURL + "pages/product.aspx?c1=" + c1SysNo + "&c2=" + c2SysNo + "&c3=" + c3SysNo + "&pid=" + product.ProductSysNo;
                    if (product.IsCanPurchase)
                    {
                        strb.Append(String.Format(productListItemHTMLTemplate2, deeplink, imgPath, deeplink, product.ProductPromotionWord, product.Price));
                    }
                    else
                    {
                        strb.Append(String.Format(productListItemHTMLTemplate1,deeplink,imgPath,deeplink,product.ProductPromotionWord,product.Price,deeplink));
                    }
                }
            }
            strb.Append("</ul>");

            productListHTML = strb.ToString();

            return productListHTML;
        }

        /// <summary>
        /// 获得首页促销商品的HTML
        /// </summary>
        /// <returns></returns>
        public static string GetHomePromotionProductsHTML()
        {
            string HomeInComingProductHTML = String.Empty;
            List<FrontDsiplayProduct> products = HomePromotionProductService.GetHomePromotionProducts();
            if (products != null)
            {
                string imageVitualPath = YoeJoyConfig.ImgVirtualPathBase;
                StringBuilder strb = new StringBuilder("<ul class='product products'>");
                foreach (FrontDsiplayProduct product in products)
                {
                    string productLink = String.Format("/Pages/Product.aspx?c1={0}&c2={1}&c3={2}&pid={3}", product.C1SysNo, product.C2SysNo, product.C3SysNo, product.ProductSysNo);
                    string innerHTML = @"<li>
                    <h3>
                        <a href='{0}'>
                            <img alt='产品图片' src='{1}' width='140' height='140'/></a></h3>
                    <p>
                        <a href='{2}'>{3}</a></p>
                    <b>￥{4}</b> </li>";
                    string imgURL = String.Concat(imageVitualPath, product.ImgPath);
                    strb.Append(String.Format(innerHTML, productLink, imgURL, productLink, product.ProductPromotionWord, product.Price));
                }
                strb.Append("</ul>");
                HomeInComingProductHTML = strb.ToString();
            }
            return HomeInComingProductHTML;
        }

        /// <summary>
        /// 
        /// 获得浏览过该商品的用户还看过的商品
        /// </summary>
        /// <returns></returns>
        public static string GetProductAlsoSeenHTML(int c1SysNo,int c2SysNo,int c3SysNo,int productSysno)
        {
            string alsoSeenProductHTML = String.Empty;

            List<FrontDsiplayProduct> products = ProductMappingService.GetRelatedProductFromC3(c3SysNo, productSysno);
            if (products != null)
            {
                StringBuilder strb = new StringBuilder("<ul class='list'>");

                string liHTML = @"<li><a href='{0}'>
                        <img class='photo' alt='{1}' src='{2}'
                            width='140' height='140'></a>
                        <div class='goodsName'>
                            <a href='{3}'>{4}</a></div>
                        <span class='price'>¥{5}</span></li>";

                foreach (FrontDsiplayProduct product in products)
                {
                    string imgPath = YoeJoyConfig.ImgVirtualPathBase + product.ImgPath;
                    string deeplink = YoeJoyConfig.SiteBaseURL + "pages/product.aspx?c1=" + c1SysNo + "&c2=" + c2SysNo + "&c3=" + c3SysNo + "&pid=" + product.ProductSysNo;
                    strb.Append(String.Format(liHTML, deeplink, product.ProductPromotionWord, imgPath, deeplink, product.ProductPromotionWord, product.Price));
                }
                strb.Append("</ul>");
                alsoSeenProductHTML = strb.ToString();
            }
            return alsoSeenProductHTML;
        }

        /// <summary>
        ///获得猜你喜欢的商品
        /// </summary>
        /// <param name="c1SysNo"></param>
        /// <param name="c2SysNo"></param>
        /// <param name="c3SysNo"></param>
        /// <param name="productSysno"></param>
        /// <returns></returns>
        public static string GetProductGuessYouLikeHTML(int c1SysNo, int c2SysNo, int c3SysNo, int productSysno)
        {
            string guessYouLikeProductHTML = String.Empty;

            List<FrontDsiplayProduct> products = ProductMappingService.GetRelatedProductFromC2(c2SysNo, c3SysNo);
            if (products != null)
            {
                StringBuilder strb = new StringBuilder("<ul class='group'>");

                string liHTML = @" <li><a class='photo' href='{0}'>
                        <img alt='{1}' src='{2}' width='60'
                            height='60'></a>
                        <p class='goodsName'>
                            <a href='{3}'>{4}</a></p>
                        <p align='right'>
                            ¥<span class='price'>{5}</span></p>
                    </li>";

                foreach (FrontDsiplayProduct product in products)
                {
                    string imgPath = YoeJoyConfig.ImgVirtualPathBase + product.ImgPath;
                    string deeplink = YoeJoyConfig.SiteBaseURL + "pages/product.aspx?c1=" + c1SysNo + "&c2=" + product.C2SysNo + "&c3=" + product.C3SysNo + "&pid=" + product.ProductSysNo;
                    strb.Append(String.Format(liHTML, deeplink, product.ProductPromotionWord, imgPath, deeplink, product.ProductPromotionWord, product.Price));
                }
                strb.Append("</ul>");
                guessYouLikeProductHTML = strb.ToString();
            }
            return guessYouLikeProductHTML;
        }

        /// <summary>
        /// 获得购物车中
        /// 购买了此商品的用户还购买了的商品
        /// </summary>
        /// <param name="c1SysNo"></param>
        /// <param name="c2SysNo"></param>
        /// <param name="c3SysNo"></param>
        /// <param name="productSysno"></param>
        /// <returns></returns>
        public static string GetProductAlsoBuyInCartCheck(int c1SysNo, int c2SysNo, int c3SysNo, int productSysno)
        {
            string alsoBuyProductHTML = String.Empty;

            List<FrontDsiplayProduct> products = ProductMappingService.GetRelatedProductFromC3(c3SysNo, productSysno, 6);
            if (products != null)
            {
                StringBuilder strb = new StringBuilder("<ul>");

                string liHTML = @"<li><a href='{0}'>
                                <img alt='{1}' src='{2}' width='118' height='118'/>
                                <p>
                                    {3}</p>
                            </a><span>¥{4}</span></li>";

                foreach (FrontDsiplayProduct product in products)
                {
                    string imgPath = YoeJoyConfig.ImgVirtualPathBase + product.ImgPath;
                    string deeplink = YoeJoyConfig.SiteBaseURL + "pages/product.aspx?c1=" + c1SysNo + "&c2=" + product.C2SysNo + "&c3=" + product.C3SysNo + "&pid=" + product.ProductSysNo;
                    strb.Append(String.Format(liHTML, deeplink, product.ProductPromotionWord, imgPath, product.ProductPromotionWord, product.Price));
                }
                strb.Append("</ul>");
                alsoBuyProductHTML = strb.ToString();
            }
            return alsoBuyProductHTML;
        }

    }
}
