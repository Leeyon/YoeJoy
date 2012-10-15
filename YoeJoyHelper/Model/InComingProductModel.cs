using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using Icson.Objects;

namespace YoeJoyHelper.Model
{

    public class InComingProductForHome
    {
        public string SysNo { get; set; }
        public int Price { get; set; }
        public string PromotionWord { get; set; }
        public string ImgCover { get; set; }
    }

    public class InComingProductService
    {
        private static readonly string GetHomeInComingProductSqlCmdTemplate = @"  select top 4 olp.ProductSysNo,p.ProductName,p.PromotionWord,CONVERT(float,pp.CurrentPrice) as price,pimg.product_limg from OnlineListProduct olp 
  left join Product p on olp.ProductSysNo=p.SysNo 
  left join Product_Price pp on olp.ProductSysNo=pp.ProductSysNo
  left join Product_Images pimg on olp.ProductSysNo=pimg.product_sysNo
  where p.Status=1 and pimg.orderNum=1 and olp.OnlineAreaType={0} and olp.OnlineRecommendType={1}
  order by olp.ListOrder ASC";

        public static List<InComingProductForHome> GetHomeInComingProduct()
        {
            int onlineAreaType = (int)AppEnum.OnlineAreaType.HomePage;
            int onlineRecommendType = (int)AppEnum.OnlineRecommendType.NewArrive;
            string sqlCmd = String.Format(GetHomeInComingProductSqlCmdTemplate, onlineAreaType, onlineRecommendType);
            DataTable data = new SqlDBHelper().ExecuteQuery(sqlCmd);
            int count = data.Rows.Count;
            List<InComingProductForHome> products = new List<InComingProductForHome>();
            for (int i = 0; i < count; i++)
            {
                products.Add(new InComingProductForHome()
                {
                    SysNo = data.Rows[i]["ProductSysNo"].ToString().Trim(),
                    PromotionWord = data.Rows[i]["PromotionWord"].ToString().Trim(),
                    Price = int.Parse(data.Rows[i]["price"].ToString().Trim()),
                    ImgCover = data.Rows[i]["product_limg"].ToString().Trim(),
                });
            }
            return products;
        }
    }

}

