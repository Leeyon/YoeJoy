using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Configuration;

namespace YoeJoyHelper.Model
{
    public class PanicBuyingProductModelForHome
    {
        public string ProductSysNo { get; set; }
        public string PromotionWord { get; set; }
        public int ProductPrice { get; set; }
        public DateTime EndTime { get; set; }
        public string CoverImg { get; set; }
    }

    public class PanicBuyingProductService
    {
        private static readonly string GetHomeLastedPanicProductSqlCmdTemplate = @"select top 2 sc.ProductSysNo,p.ProductName,p.PromotionWord,p.PromotionWord,CONVERT(float,pp.CurrentPrice) as price,pis.product_limg,sc.EndTime from Sale_CountDown sc left join 
  Product p on sc.ProductSysNo=p.SysNo left join
  Product_Price pp on sc.ProductSysNo=pp.ProductSysNo left join 
  Product_Images pis on sc.ProductSysNo=pis.product_sysNo
  where sc.Status=1 and pis.status=1 and pis.orderNum=1 order by sc.SysNo DESC";

        public static List<PanicBuyingProductModelForHome> GetHomePanicProduct()
        {
            DataTable data = new SqlDBHelper().ExecuteQuery(GetHomeLastedPanicProductSqlCmdTemplate);
            int rowCount = data.Rows.Count;
            if (rowCount > 0)
            {
                List<PanicBuyingProductModelForHome> panicProducts = new List<PanicBuyingProductModelForHome>();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    panicProducts.Add(new PanicBuyingProductModelForHome()
                    {
                        ProductSysNo = data.Rows[i]["ProductSysNo"].ToString().Trim(),
                        PromotionWord = data.Rows[i]["PromotionWord"].ToString().Trim(),
                        ProductPrice = int.Parse(data.Rows[i]["price"].ToString().Trim()),
                        EndTime = DateTime.Parse(data.Rows[i]["EndTime"].ToString().Trim()),
                        CoverImg = data.Rows[i]["product_limg"].ToString().Trim(),
                    });
                }
                return panicProducts;
            }
            else
            {
                return null;
            }
        }
    }
}
