using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace YoeJoyHelper
{
    public class CommonUtility
    {
        /// <summary>
        /// 保存图片的公共方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="uploader"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public static string SaveImage(HttpContext context, FileUpload uploader, out string Msg)
        {
            Msg = String.Empty;
            string newImgPath = String.Empty;
            try
            {
                //直接取得文件名
                string fileName = uploader.FileName.ToString();
                //取得上传文件路径
                string url = uploader.PostedFile.FileName.ToString();
                //获取文件MIME内容类型
                string type = uploader.PostedFile.ContentType;
                string type2 = fileName.Substring(fileName.IndexOf(".") + 1);
                //获取文件大小
                int size = uploader.PostedFile.ContentLength;

                //判断同名文件
                if (File.Exists(url))
                {
                    Msg = "存在同名文件，请重新上传";
                }
                else
                {
                    if (type2 == "gif" || type2 == "jpg" || type2 == "bmp" || type2 == "png")
                    {
                        if (size <= 4134904)
                        {
                            //string basePath = context.Server.MapPath(imgFolderPath) + "\\";
                            string basePath = String.Concat(ConfigurationManager.AppSettings["ImagePhyicalPath"].ToString(), "products\\");
                            string newFileName = String.Concat(Guid.NewGuid(), fileName);
                            uploader.SaveAs(String.Concat(basePath, newFileName));
                            Msg = "保存成功！";
                            newImgPath = newFileName;
                        }
                        else
                        {
                            Msg = "文件大于4M，请重新上传";
                        }
                    }
                }
                return newImgPath;
            }
            catch
            {
                Msg = "Server Error: 保存图片失败";
                return newImgPath;
            }
        }

        /// <summary>
        /// 绑定下拉列表初始的状态
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> BindTrueFalseStatus()
        {
            Dictionary<int, string> statusDic = new Dictionary<int, string>();
            statusDic.Add(0, "无效");
            statusDic.Add(1, "有效");
            return statusDic;
        }

        public static Dictionary<int, string> BindTrueFalseStatus(int status)
        {
            Dictionary<int, string> statusDic = new Dictionary<int, string>();
            if (status == 0)
            {
                statusDic.Add(status, "无效");
                statusDic.Add(1, "有效");
            }
            else
            {
                statusDic.Add(status, "有效");
                statusDic.Add(0, "无效");
            }
            return statusDic;
        }
    }
}