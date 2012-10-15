﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using Icson.Objects;

namespace YoeJoyHelper.Model
{
    #region 前台商品展示的模型定义
    /// <summary>
    /// 前台展示的商品
    /// </summary>
    public class FrontDsiplayProduct
    {
        public string ProductSysNo { get; set; }
        public int C3SysNo { get; set; }
        public string Price { get; set; }
        public string ImgPath { get; set; }
        public string ProductPromotionWord { get; set; }
    }

    /// <summary>
    /// 前台展示的清库商品
    /// </summary>
    public class EmptyInventoryProduct
    {
        public string ProductSysNo { get; set; }
        public int C2SysNo { get; set; }
        public int C3SysNo { get; set; }
        public string Price { get; set; }
        public string ProductPromotionWord { get; set; }
    }

    /// <summary>
    /// 大类页面最新降价商品
    /// </summary>
    public class C1LastestDiscountProduct
    {
        public string ProductSysNo { get; set; }
        public int C2SysNo { get; set; }
        public int C3SysNo { get; set; }
        public string Price { get; set; }
        public string ProductPromotionWord { get; set; }
        public string ImgPath { get; set; }
        public string DiscountRate { get; set; }
    }

    /// <summary>
    /// 大类每周销量排行商品
    /// </summary>
    public class C1WeeklyBestSaledProduct
    {
        public string ProductSysNo { get; set; }
        public int C2SysNo { get; set; }
        public int C3SysNo { get; set; }
        public string Price { get; set; }
        public string ProductPromotionWord { get; set; }
        public string ImgPath { get; set; }
    }

    /// <summary>
    /// 商品Filter选项
    /// </summary>
    public struct C3ProductAttributionOption
    {
        public int OptionSysNo;
        public string OptionName;
    }

    /// <summary>
    /// 商品Filter
    /// </summary>
    public class C3ProductAttribution
    {
        public int A1SysNo { get; set; }
        public int A2SysNo { get; set; }
        public string A2Name { get; set; }
        public List<C3ProductAttributionOption> Options { get; set; }
    }

    /// <summary>
    /// Serach1初值的分类
    /// </summary>
    public class C3ProductSerach1Filter
    {
        public int C1SysNo { get; set; }
        public int C2SysNo { get; set; }
        public int C3SysNo { get; set; }
        public string C3Name { get; set; }
    }

    #endregion

    #region 前台商品展示的模型服务
    public class HomeCategoryOneProductService
    {
        private static readonly string GetCategoryTwoIDsSqlCmdTemplate = @"select top 5 c1c2.C2SysNo,c2.C2Name 
  from OnlineC1_C2 c1c2 left join Category2 c2 on c1c2.C2SysNo=c2.SysNo
  where c2.C1SysNo={0} 
  order by c1c2.OrderNum";

        private static readonly string GetCategoryTwoProductsSqlCmdTemplate = @"  select op.ProductSysNo,op.ProductBriefName,op.OrderNum,CONVERT(float,pp.CurrentPrice)as Price,pimg.product_limg,p.C3SysNo from OnlineC1_Product as op 
  left join Product as p on op.ProductSysNo=p.SysNo
  left join Product_Images pimg on op.ProductSysNo=pimg.product_sysNo
  left join Product_Price pp on op.ProductSysNo=pp.ProductSysNo
  left join Inventory inv on op.ProductSysNo=inv.ProductSysNo
  where
  (inv.AvailableQty+inv.VirtualQty>0) and
  p.Status=1 and
  (pp.ClearanceSale=1 or pp.currentprice>=IsNull(pp.unitcost,0)) and
  p.C2SysNo={0}
  order by op.OrderNum";

        /// <summary>
        /// 获取前台指定的大类商品中
        /// 需要在首页展示的所有小类的ID和名称
        /// </summary>
        /// <param name="categoryOneId"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetCategoryTwoIDs(string categoryOneId)
        {
            try
            {
                string sqlCmd = String.Format(GetCategoryTwoIDsSqlCmdTemplate, categoryOneId);
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    Dictionary<int, string> C2ProductsDic = new Dictionary<int, string>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        C2ProductsDic.Add(int.Parse(data.Rows[i]["C2SysNo"].ToString().Trim()), data.Rows[i]["C2Name"].ToString().Trim());
                    }
                    return C2ProductsDic;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取需要在前台大类展示的商品
        /// </summary>
        /// <param name="categoryTwoId"></param>
        /// <returns></returns>
        public static List<FrontDsiplayProduct> GetHomeCategoryOneDisplayProducts(int categoryTwoId)
        {
            try
            {
                string sqlCmd = String.Format(GetCategoryTwoProductsSqlCmdTemplate, categoryTwoId);
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    List<FrontDsiplayProduct> C2Products = new List<FrontDsiplayProduct>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        C2Products.Add(new FrontDsiplayProduct()
                        {
                            C3SysNo = int.Parse(data.Rows[i]["C3SysNo"].ToString().Trim()),
                            ImgPath = data.Rows[i]["product_limg"].ToString().Trim(),
                            Price = data.Rows[i]["Price"].ToString().Trim(),
                            ProductSysNo = data.Rows[i]["ProductSysNo"].ToString().Trim(),
                            ProductPromotionWord = data.Rows[i]["ProductBriefName"].ToString().Trim(),
                        });
                    }
                    return C2Products;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }

    public class C1DisplayProductService
    {

        private static readonly string GetC2IDSqlCmdTemplate = @"  select distinct p.C2SysNo,c2.C2Name from OnlineListProduct olp
  left join Product p on olp.CategorySysNo=p.C1SysNo
  left join Category1 c1 on olp.CategorySysNo=c1.SysNo
  left join Category2 c2 on p.C2SysNo=c2.SysNo
  where olp.CategorySysNo=232 and c2.C1SysNo={0}";

        private static readonly string GetC2DisplayProductsSqlCmdTemplate = @"select top 8 olp.ProductSysNo as sysno,p.ProductName,CONVERT(float,pp.CurrentPrice) as price,pimg.product_limg,p.C3SysNo from OnlineListProduct olp
  left join Product p on olp.ProductSysNo=p.SysNo
  left join Product_Price pp on olp.ProductSysNo=pp.ProductSysNo
  left join Product_Images pimg on olp.ProductSysNo=pimg.product_sysNo
  where p.Status=1 
  and pimg.orderNum=1 
  and olp.OnlineAreaType={0} 
  and olp.OnlineRecommendType={1}
  and olp.CategorySysNo=p.C1SysNo 
  and p.C2SysNo={2}
  order by olp.ListOrder ASC";

        /// <summary>
        /// 获得要在大类页面下
        /// 展示的二类推荐商品的CategoryId
        /// </summary>
        /// <param name="c1SysNo"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetC2DsiplayIDs(int c1SysNo)
        {
            try
            {
                string sqlCmd = String.Format(GetC2IDSqlCmdTemplate, c1SysNo);
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    Dictionary<int, string> C2ProductsDic = new Dictionary<int, string>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        C2ProductsDic.Add(int.Parse(data.Rows[i]["C2SysNo"].ToString().Trim()), data.Rows[i]["C2Name"].ToString().Trim());
                    }
                    return C2ProductsDic;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得要在大类页面下
        /// 展示的二类推荐商品
        /// </summary>
        /// <param name="c2SysNo"></param>
        /// <returns></returns>
        public static List<FrontDsiplayProduct> GetC1DsiplayProducts(int c2SysNo)
        {
            try
            {
                int onlineAreaType = (int)AppEnum.OnlineAreaType.FirstCategory;
                int onlineRecommendType = (int)AppEnum.OnlineRecommendType.ExcellentRecommend;
                string sqlCmd = String.Format(GetC2DisplayProductsSqlCmdTemplate, onlineAreaType, onlineRecommendType, c2SysNo);
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    List<FrontDsiplayProduct> C2Products = new List<FrontDsiplayProduct>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        C2Products.Add(new FrontDsiplayProduct()
                        {
                            C3SysNo = int.Parse(data.Rows[i]["C3SysNo"].ToString().Trim()),
                            ImgPath = data.Rows[i]["product_limg"].ToString().Trim(),
                            Price = data.Rows[i]["price"].ToString().Trim(),
                            ProductSysNo = data.Rows[i]["sysno"].ToString().Trim(),
                            ProductPromotionWord = data.Rows[i]["ProductName"].ToString().Trim(),
                        });
                    }
                    return C2Products;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }

    public class C1EmptyInventoryProductService
    {
        private static readonly string GetC1EmptyInventoryProductsSqlCmdTemplate = @"select top 4 olp.ProductSysNo,CONVERT(float,pp.CurrentPrice)as price,p.PromotionWord,p.C3SysNo,p.C2SysNo from OnlineListProduct olp 
  left join Product p on olp.ProductSysNo=p.SysNo
  left join Product_Price pp on olp.ProductSysNo=pp.ProductSysNo
 where olp.CategorySysNo={0}
 and pp.ClearanceSale=1 
 and p.Status=1 
 and OnlineAreaType={1}
 and OnlineRecommendType={2}
 order by olp.ListOrder";

        /// <summary>
        /// 获得清库商品模块的4商品
        /// </summary>
        /// <param name="c1SysNo"></param>
        /// <returns></returns>
        public static List<EmptyInventoryProduct> GetGetC1EmptyInventoryProducts(int c1SysNo)
        {
            try
            {
                int onlineAreaType = (int)AppEnum.OnlineAreaType.FirstCategory;
                int onlineRecommendType = (int)AppEnum.OnlineRecommendType.Promotion;
                string sqlCmd = String.Format(GetC1EmptyInventoryProductsSqlCmdTemplate, c1SysNo, onlineAreaType, onlineRecommendType);
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    List<EmptyInventoryProduct> products = new List<EmptyInventoryProduct>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        products.Add(new EmptyInventoryProduct()
                        {
                            C2SysNo = int.Parse(data.Rows[i]["C2SysNo"].ToString().Trim()),
                            C3SysNo = int.Parse(data.Rows[i]["C3SysNo"].ToString().Trim()),
                            Price = data.Rows[i]["price"].ToString().Trim(),
                            ProductSysNo = data.Rows[i]["ProductSysNo"].ToString().Trim(),
                            ProductPromotionWord = data.Rows[i]["PromotionWord"].ToString().Trim(),
                        });
                    }
                    return products;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }

    public class C1LastedDisCountProductService
    {
        private static readonly string GetC1LastedDiscountProductsSqlCmdTemplate = @"select top 5 olp.ProductSysNo,p.PromotionWord,pimg.product_simg,convert(float,pp.CurrentPrice) as price,CONVERT(int,(1-(pp.CurrentPrice/pp.BasicPrice))*100.00)as discountRate,p.C2SysNo,p.C3SysNo from OnlineListProduct olp
 left join Product p on olp.ProductSysNo=p.SysNo
 left join Product_Price pp on olp.ProductSysNo=pp.ProductSysNo
 left join Product_Images pimg on olp.ProductSysNo=pimg.product_sysNo
 where olp.CategorySysNo={0} 
 and p.Status=1
 and olp.OnlineAreaType={1}
 and olp.OnlineRecommendType={2}
 and pimg.status=1
 and pimg.orderNum=1
 order by olp.ListOrder";

        public static List<C1LastestDiscountProduct> GetC1LastestDiscountProduct(int c1SysNo)
        {
            try
            {
                int onlineAreaType = (int)AppEnum.OnlineAreaType.FirstCategory;
                int onlineRecommendType = (int)AppEnum.OnlineRecommendType.PopularProduct;
                string sqlCmd = String.Format(GetC1LastedDiscountProductsSqlCmdTemplate, c1SysNo, onlineAreaType, onlineRecommendType);
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    List<C1LastestDiscountProduct> products = new List<C1LastestDiscountProduct>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        products.Add(new C1LastestDiscountProduct()
                        {
                            C2SysNo = int.Parse(data.Rows[i]["C2SysNo"].ToString().Trim()),
                            C3SysNo = int.Parse(data.Rows[i]["C3SysNo"].ToString().Trim()),
                            Price = data.Rows[i]["price"].ToString().Trim(),
                            ProductSysNo = data.Rows[i]["ProductSysNo"].ToString().Trim(),
                            ProductPromotionWord = data.Rows[i]["PromotionWord"].ToString().Trim(),
                            DiscountRate = data.Rows[i]["discountRate"].ToString().Trim(),
                            ImgPath = data.Rows[i]["product_simg"].ToString().Trim(),
                        });
                    }
                    return products;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }

    public class C1WeeklyBestSaledProductService
    {
        private static readonly string GetC1WeeklyBestSaledProductsSqlCmdTemplate = @"  select olp.ProductSysNo,p.PromotionWord,CONVERT(float,pp.CurrentPrice)as price,
  p.C2SysNo,p.C3SysNo,pimg.product_simg
  from OnlineListProduct olp
  left join Product p on olp.ProductSysNo=p.SysNo
  left join Product_Price pp on olp.ProductSysNo=pp.ProductSysNo
  left join Product_Images pimg on olp.ProductSysNo=pimg.product_sysNo
  where olp.CategorySysNo={0}
  and p.Status=1
  and olp.OnlineAreaType={1}
  and olp.OnlineRecommendType={2}
  and pimg.status=1
  and pimg.orderNum=1
  order by olp.ListOrder";

        public static List<C1WeeklyBestSaledProduct> GetC1WeeklyBestSaledProduct(int c1SysNo)
        {
            try
            {
                int onlineAreaType = (int)AppEnum.OnlineAreaType.FirstCategory;
                int onlineRecommendType = (int)AppEnum.OnlineRecommendType.PromotionTopic;
                string sqlCmd = String.Format(GetC1WeeklyBestSaledProductsSqlCmdTemplate, c1SysNo, onlineAreaType, onlineRecommendType);
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    List<C1WeeklyBestSaledProduct> products = new List<C1WeeklyBestSaledProduct>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        products.Add(new C1WeeklyBestSaledProduct()
                        {
                            C2SysNo = int.Parse(data.Rows[i]["C2SysNo"].ToString().Trim()),
                            C3SysNo = int.Parse(data.Rows[i]["C3SysNo"].ToString().Trim()),
                            Price = data.Rows[i]["price"].ToString().Trim(),
                            ProductSysNo = data.Rows[i]["ProductSysNo"].ToString().Trim(),
                            ProductPromotionWord = data.Rows[i]["PromotionWord"].ToString().Trim(),
                            ImgPath = data.Rows[i]["product_simg"].ToString().Trim(),
                        });
                    }
                    return products;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }

    public class C3ProductListSerivice
    {
        private static readonly string getPagedProductListItemsSqlCmdTemplate = @"select distinct top {0} p.SysNo,p.ProductName,p.PromotionWord,CONVERT(float,pp.CurrentPrice) as price,pimg.product_limg
  from Product p
  left join Product_Price pp on p.SysNo=pp.ProductSysNo
  left join Product_Images pimg on p.SysNo=pimg.product_sysNo
  left join Product_Attribute2 pa2 on p.SysNo=pa2.ProductSysNo
  where p.Status=1 
  and (pimg.orderNum=1 and pimg.status=1)
  and p.C3SysNo={1}
  {3}
  and p.SysNo not in 
  (select top {2} p.SysNo from Product p where p.Status=1 {4})
  {5}";

        private static readonly string getC3ProductAttributionNameSqlCmdTemplate = @"select ca1.SysNo as A1SysNo,ca2.SysNo as A2SysNo,ca2.Attribute2Name as A2Name from Category_Attribute2 ca2
  left join Category_Attribute1 ca1 on ca2.A1SysNo=ca1.SysNo
  where ca1.C3SysNo={0} and Attribute2Type=1 and ca1.Status=0 and ca2.Status=0
  order by ca1.OrderNum ";

        private static readonly string getC3ProductAttributionOptionSqlCmdTemplate = @"  select ca2o.SysNo,ca2o.Attribute2OptionName from Category_Attribute2 ca2 
  left join Category_Attribute2_Option ca2o on ca2.SysNo=ca2o.Attribute2SysNo
  where ca2.SysNo={0}";

        private static readonly string getProductListItemTotalCountSqlCmdTemplate = @"  select COUNT(distinct p.SysNo)as totalCount from Product p
  left join Product_Attribute2 pa2 on p.SysNo=pa2.ProductSysNo
  where p.Status=1
  {0}
  and p.C3SysNo={1}";

        /// <summary>
        /// 获取分页的商品列表
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pagedCount"></param>
        /// <param name="c3SysNo"></param>
        /// <param name="orderByOption"></param>
        /// <returns></returns>
        public static List<FrontDsiplayProduct> GetPagedProductList(int startIndex, int pagedCount, int c3SysNo, YoeJoyEnum.ProductListSortedOrder orderByOption, string attribution2IdStr)
        {
            string orderByStr = YoeJoySystemDic.ProductListSortedOrderDic[orderByOption];
            string orderByStr1 = orderByStr;
            string arrtibutionFilterSqlCmd = String.Empty;
            if (attribution2IdStr != null)
            {
                arrtibutionFilterSqlCmd = "and pa2.Attribute2OptionSysNo in ( " + attribution2IdStr + " )";
            }
            switch (orderByOption)
            {
                case YoeJoyEnum.ProductListSortedOrder.Default:
                    {
                        break;
                    }
                case YoeJoyEnum.ProductListSortedOrder.Price:
                    {
                        orderByStr1=orderByStr1.Replace("price", "pp.CurrentPrice");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            string sqlCmd = String.Format(getPagedProductListItemsSqlCmdTemplate, pagedCount, c3SysNo, startIndex, arrtibutionFilterSqlCmd, orderByStr1, orderByStr);
            try
            {
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    List<FrontDsiplayProduct> products = new List<FrontDsiplayProduct>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        products.Add(new FrontDsiplayProduct()
                        {
                            C3SysNo = c3SysNo,
                            ImgPath = data.Rows[i]["product_limg"].ToString().Trim(),
                            Price = data.Rows[i]["price"].ToString().Trim(),
                            ProductSysNo = data.Rows[i]["SysNo"].ToString().Trim(),
                            ProductPromotionWord = data.Rows[i]["PromotionWord"].ToString().Trim(),
                        });
                    }
                    return products;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得该类别下的商品总数
        /// </summary>
        /// <param name="c3SysNo"></param>
        /// <returns></returns>
        public static int GetPagedProductListItemTotalCount(int c3SysNo, string attribution2IdStr)
        {
            string arrtibutionFilterSqlCmd = String.Empty;
            if (attribution2IdStr != null)
            {
                arrtibutionFilterSqlCmd = "and pa2.Attribute2OptionSysNo in ( " + attribution2IdStr + " )";
            }
            string sqlCmd = String.Format(getProductListItemTotalCountSqlCmdTemplate,arrtibutionFilterSqlCmd,c3SysNo);
            try
            {
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    return int.Parse(data.Rows[0]["totalCount"].ToString().Trim());
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 获得商品筛选项
        /// </summary>
        /// <param name="c3SysNo"></param>
        /// <returns></returns>
        public static List<C3ProductAttribution> GetC3ProductAttribution(int c3SysNo)
        {
            string sqlCmd = String.Format(getC3ProductAttributionNameSqlCmdTemplate, c3SysNo);
            try
            {
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    List<C3ProductAttribution> c3ProductAttributions = new List<C3ProductAttribution>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        C3ProductAttribution c3ProductAttribution = new C3ProductAttribution()
                        {
                            A1SysNo = int.Parse(data.Rows[i]["A1SysNo"].ToString().Trim()),
                            A2SysNo = int.Parse(data.Rows[i]["A2SysNo"].ToString().Trim()),
                            A2Name = data.Rows[i]["A2Name"].ToString().Trim(),
                        };
                        string sqlCmd2 = String.Format(getC3ProductAttributionOptionSqlCmdTemplate, c3ProductAttribution.A2SysNo);
                        DataTable data2 = new SqlDBHelper().ExecuteQuery(sqlCmd2);
                        int rowCount2 = data2.Rows.Count;
                        if (rowCount2 > 0)
                        {
                            c3ProductAttribution.Options = new List<C3ProductAttributionOption>();
                            for (int j = 0; j < rowCount2; j++)
                            {
                                C3ProductAttributionOption option = new C3ProductAttributionOption()
                                {
                                    OptionSysNo = int.Parse(data2.Rows[j]["SysNo"].ToString().Trim()),
                                    OptionName = data2.Rows[j]["Attribute2OptionName"].ToString().Trim(),
                                };
                                c3ProductAttribution.Options.Add(option);
                            }
                        }
                        else
                        {
                            c3ProductAttribution.Options = null;
                        }
                        c3ProductAttributions.Add(c3ProductAttribution);
                    }
                    return c3ProductAttributions;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }

    public class C3ProductSearchService
    {
        private static readonly string getSearch1C3NamesSqlCmdTemplate = @"select distinct p.C1SysNo,p.C2SysNo,p.C3SysNo,c3.C3Name from Product p 
 left join Category3 c3 on p.C3SysNo=c3.SysNo
 where p.Status=1
 and c3.Status=0
 and 
 (p.PromotionWord like ('%{0}%')
{1})";



        /// <summary>
        /// 获得Serach1的商品小类
        /// </summary>
        /// <returns></returns>
        public static List<C3ProductSerach1Filter> GetSearch1C3Names(string keyWords)
        {
            string childSearchSqlCmd=String.Empty;
            string[] keyWordsArray=keyWords.Split(' ');
            if(keyWordsArray.Length>1)
            {
                for(int i=1;i<keyWordsArray.Length;i++)
                {
                    childSearchSqlCmd+=String.Format(" or p.PromotionWord like ('%{0}%')",keyWordsArray[i].Trim());
                }
            }
            string sqlCmd=String.Format(getSearch1C3NamesSqlCmdTemplate,keyWordsArray[0].Trim(),childSearchSqlCmd);
            try
            {
                DataTable data=new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount=data.Rows.Count;
                if(rowCount>0)
                {
                    List<C3ProductSerach1Filter> filters=new List<C3ProductSerach1Filter>();
                    for(int j=0;j<rowCount;j++)
                    {
                        filters.Add(new C3ProductSerach1Filter()
                        {
                            C1SysNo = int.Parse(data.Rows[j]["C1SysNo"].ToString().Trim()),
                            C2SysNo = int.Parse(data.Rows[j]["C2SysNo"].ToString().Trim()),
                            C3SysNo = int.Parse(data.Rows[j]["C3SysNo"].ToString().Trim()),
                            C3Name = data.Rows[j]["C3Name"].ToString().Trim(),
                        });
                    }
                    return filters;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }

    #endregion
}