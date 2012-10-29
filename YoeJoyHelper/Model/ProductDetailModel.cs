using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;

namespace YoeJoyHelper.Model
{
    /// <summary>
    /// 商品详细模型类
    /// </summary>
    public class ProductDetailModel
    {
        public string SysNo { get; set; }
        public string ProductBriefName { get; set; }
        public string ProductBaiscPrice { get; set; }
        public string ProductCurrentPrice { get; set; }
        //详细说明
        public string ProductDescriptionLong { get; set; }
        //包装清单
        public string PackageList { get; set; }
        //一次限购数量
        public int LimitedQty { get; set; }
        //商品图片
        public List<ProductDetailImg> Images { get; set; }
    }

    /// <summary>
    /// 商品详细图片展示
    /// </summary>
    public class ProductDetailImg
    {
        public string LargeImg { get; set; }
        public string ThumbnailImg { get; set; }
    }

    #region 商品详细信息服务类

    /// <summary>
    /// 商品详细基础服务类
    /// </summary>
    public class ProductDetailBasicService
    {

        private static readonly string getProductImgsSqlCmdTemplate = @"select pimg.product_limg,pimg.product_simg,
            pimg.orderNum,pimg.status from Product_Images pimg
            where pimg.product_sysNo={0} and pimg.status=1 order by pimg.orderNum";

        /// <summary>
        /// 获得商品的全部展示图片
        /// </summary>
        /// <param name="productSysNo"></param>
        /// <returns></returns>
        public static List<ProductDetailImg> GetProductDetailImgs(int productSysNo)
        {
            try
            {
                string sqlCmd = String.Format(getProductImgsSqlCmdTemplate, productSysNo);
                DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
                int rowCount = data.Rows.Count;
                if (rowCount > 0)
                {
                    List<ProductDetailImg> imgs = new List<ProductDetailImg>();
                    for (int i = 0; i < rowCount; i++)
                    {
                        imgs.Add(new ProductDetailImg()
                        {
                            ThumbnailImg=data.Rows[i]["product_simg"].ToString().Trim(),
                            LargeImg=data.Rows[i]["product_limg"].ToString().Trim(),
                        });
                    }
                    return imgs;
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
