using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoeJoyHelper.Model;

namespace YoeJoyHelper
{
    public class SearchHelper
    {
        /// <summary>
        /// 初始化Search1的筛选项
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static string InitSearch1C3ProductFilter(string keyWords)
        {
            string serach1C3ProductFilterHTML = String.Empty;

            List<C3ProductSerach1Filter> search1Filters = Search1ProductService.GetSearch1C3Names(keyWords);
            if (search1Filters != null)
            {
                StringBuilder strb = new StringBuilder(@"<tbody id='filterTable'><tr>
                    <td class='option' valign='top' width='32' align='right'>
                        分类:
                    </td>
                    <td>
                        <ul>
                            <li class='selected'>全部</li>".Trim());

                string filterItemHTMLTemplate = @"
                            <li>{0}<input type='hidden' value='{1}'/><input type='hidden' value='{2}'/><input type='hidden' value='{3}'/></li>".Trim();

                foreach (C3ProductSerach1Filter filter in search1Filters)
                {
                    strb.Append(String.Format(filterItemHTMLTemplate, filter.C3Name, filter.C1SysNo, filter.C2SysNo, filter.C3SysNo));
                }

                strb.Append(@"</ul>
                    </td>
                </tr></tbody>".Trim());
                serach1C3ProductFilterHTML = strb.ToString();
            }
            return serach1C3ProductFilterHTML;
        }

        /// <summary>
        /// 初始化Serach1商品列表表头
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static string InitSearch1C3ProductListHeader(string keyWords)
        {
            string productListHeaderHTML = String.Empty;
            int productTotalCount = Search1ProductService.GetSearch1C3ProductTotalCount(keyWords);
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
        /// 初始化Serach1商品列表表尾
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static string InitSearch1C3ProductListFooter(string keyWords)
        {
            string productListFooterHTML = String.Empty;

            int productTotalCount = Search1ProductService.GetSearch1C3ProductTotalCount(keyWords);
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

        public static string GetSearch1ProductListHTML(YoeJoyEnum.ProductListSortedOrder orderOption, int startIndex, string keyWords)
        {
            string productListHTML = String.Empty;
            StringBuilder strb = new StringBuilder("<ul>");

            string baseURL = YoeJoyConfig.SiteBaseURL;
            int pagedCount = int.Parse(YoeJoyConfig.ProductListPagedCount);

            List<Search1DsiplayProduct> products = Search1ProductService.GetPagedSearch1Products((startIndex-1), pagedCount, orderOption, keyWords);
            if (products != null)
            {
                string imageBaseURL = YoeJoyConfig.ImgVirtualPathBase;
                string productListItemHTMLTemplate = @"<li><a href='product.html?c1={0}&c2={1}&c3={2}&pid={3}' target='_parent'>
                            <p>
                                <img src='{4}'><span class='price'>{5}元</span></p>
                            <span>{6}</span></a></li>";
                foreach (Search1DsiplayProduct product in products)
                {
                    strb.Append(String.Format(productListItemHTMLTemplate, product.C1SysNo, product.C2SysNo, product.C3SysNo, product.ProductSysNo, String.Concat(imageBaseURL,product.ImgPath), product.Price, product.ProductPromotionWord));
                }
            }
            strb.Append("</ul>");

            productListHTML = strb.ToString();

            return productListHTML;
        }

        /// <summary>
        /// 初始化Serach2商品列表表头
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static string InitSearch2C3ProductListHeader(int c3SysNo, string attribution2IdStr, string keyWords)
        {
            string productListHeaderHTML = String.Empty;
            int productTotalCount = Search2ProductService.GetSearch2C3ProductTotalCount(c3SysNo, attribution2IdStr, keyWords);
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
        /// 初始化Serach2商品列表表尾
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static string InitSearch2C3ProductListFooter(int c3SysNo, string attribution2IdStr, string keyWords)
        {
            string productListFooterHTML = String.Empty;

            int productTotalCount = Search2ProductService.GetSearch2C3ProductTotalCount(c3SysNo, attribution2IdStr, keyWords);
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
        /// 获得Search2的分页商品
        /// </summary>
        /// <param name="orderOption"></param>
        /// <param name="startIndex"></param>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static string GetSearch2ProductListHTML(YoeJoyEnum.ProductListSortedOrder orderOption, int startIndex, int c3SysNo, int c1SysNo, int c2SysNo, string attribution2Ids,string keyWords)
        {
            string productListHTML = String.Empty;
            StringBuilder strb = new StringBuilder("<ul>");

            string baseURL = YoeJoyConfig.SiteBaseURL;
            int pagedCount = int.Parse(YoeJoyConfig.ProductListPagedCount);

            List<FrontDsiplayProduct> products = Search2ProductService.GetPagedProductList((startIndex - 1), pagedCount, c3SysNo, orderOption, attribution2Ids, keyWords);
            if (products != null)
            {
                string imageBaseURL = YoeJoyConfig.ImgVirtualPathBase;
                string productListItemHTMLTemplate = @"<li><a href='product.html?c1={0}&c2={1}&c3={2}&pid={3}' target='_parent'>
                            <p>
                                <img src='{4}'><span class='price'>{5}元</span></p>
                            <span>{6}</span></a></li>";
                foreach (FrontDsiplayProduct product in products)
                {
                    strb.Append(String.Format(productListItemHTMLTemplate, c1SysNo,c2SysNo, c3SysNo, product.ProductSysNo, String.Concat(imageBaseURL, product.ImgPath), product.Price, product.ProductPromotionWord));
                }
            }
            strb.Append("</ul>");

            productListHTML = strb.ToString();

            return productListHTML;
        }
    }
}
