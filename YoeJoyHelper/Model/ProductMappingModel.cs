using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace YoeJoyHelper.Model
{
    //关联类型
    public enum ProductMappingType:int
    {
        [Description("同级关联")]
        TheSameLevel=1,
        [Description("主子关联")]
        MasterLevel=2,
    }

    /// <summary>
    /// 商品关联模型
    /// 允许多对多的类型
    /// </summary>
    public class ProductMappingModel
    {
        public string MappingId { get; set; }
        //商品ID
        public int P1SysNo { get; set; }
        //关联商品ID
        public int P2SysNo { get; set; }
        //关联类型
        public ProductMappingType MappingType { get; set; }
        //关联索引
        public string MappingIndex { get; set; }
    }


    public class ProductMappingService
    {

        private static readonly string getPMInfoSqlCmdTemplate = @"select pm.MId,p.ProductName,pm.M_Index from Product_Mapping pm 
  left join Product p on pm.P2SysNo=p.SysNo
  where pm.P1SysNo={0} and pm.M_Type={1} {2}";

        private static readonly string removeProductMappingSqlCmdTemplate=@"delete from [mmbuy].[dbo].[Product_Mapping] where [MId]={0}";

        /// <summary>
        /// 添加商品关联
        /// </summary>
        /// <param name="mappingModle"></param>
        /// <returns></returns>
        public static bool AddProductMapping(ProductMappingModel mappingModle)
        {
            bool result = false;

            try
            {
                SqlParameter[] paras = new SqlParameter[5];
                paras[0] = new SqlParameter("@Product1SysNo", SqlDbType.Int, 4);
                paras[0].Value = mappingModle.P1SysNo;
                paras[0].Direction = ParameterDirection.Input;
                paras[1] = new SqlParameter("@Product2SysNo", SqlDbType.Int, 4);
                paras[1].Value = mappingModle.P2SysNo;
                paras[1].Direction = ParameterDirection.Input;
                paras[2] = new SqlParameter("@MappingType", SqlDbType.Int, 4);
                paras[2].Value =(int)mappingModle.MappingType;
                paras[2].Direction = ParameterDirection.Input;
                paras[3] = new SqlParameter("@MappingIndex", SqlDbType.VarChar,8000);
                paras[3].Value = mappingModle.MappingIndex;
                paras[3].Direction = ParameterDirection.Input;
                paras[4] = new SqlParameter("@result", SqlDbType.Bit, 1);
                paras[4].Direction = ParameterDirection.Output;
                object outputValue;
                if (new SqlDBHelper().ExecuteStoredProcedure("AddProductMapping", paras, "@result", out outputValue) > 0)
                {
                    if ((bool)outputValue)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 查询关联商品
        /// </summary>
        /// <param name="p1SysNo"></param>
        /// <param name="pMType"></param>
        /// <param name="mIndex"></param>
        /// <returns></returns>
        public static DataTable GetProductMappingInfo(int p1SysNo, ProductMappingType pMType, string mIndex)
        {
            string mIndexSerachSqlCmd = String.IsNullOrEmpty(mIndex) ? String.Empty : String.Format("and pm.M_Index like '%{0}%'", mIndex);
            string sqlCmd = String.Format(getPMInfoSqlCmdTemplate, p1SysNo, (int)pMType, mIndexSerachSqlCmd);
            return new SqlDBHelper().ExecuteQuery(sqlCmd);
        }

        /// <summary>
        /// 删除商品关联
        /// </summary>
        /// <param name="mappingId"></param>
        /// <returns></returns>
        public static bool RemoveProductMapping(string mappingId)
        {
            try
            {
                string sqlCmd = String.Format(removeProductMappingSqlCmdTemplate, mappingId);
                if (new SqlDBHelper().ExecuteNonQuery(sqlCmd) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}