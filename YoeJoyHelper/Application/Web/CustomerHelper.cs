﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using YoeJoyHelper.Security;
using System.Collections;
using YoeJoyHelper.Model;


using Icson.Utils;
using Icson.Objects;


using Icson.Objects.Basic;
using Icson.Objects.Online;

using Icson.BLL;
using Icson.BLL.Online;
using Icson.BLL.Basic;

using System.Threading;
using YoeJoyHelper.Model;

namespace YoeJoyHelper
{
    /// <summary>
    /// 用户的helper类
    /// </summary>
    public class CustomerHelper
    {
        /// <summary>
        /// 注册新用户
        /// </summary>
        public static bool RegisterNewCustomer(HttpContext context, NewRegisterCustomerModel customer, out string msg)
        {
            bool isSuccess = false;
            msg = String.Empty;

            string customerID = customer.CustomerID.Trim();
            string password1 = customer.PassWordInput1.Trim();
            string password2 = customer.PassWordInput2.Trim();
            string customerEmail = customer.CustomerEmail.Trim();

            if (customerID == "")
            {
                msg += "请输入用户名！<br />";
            }
            else if (!CommonUtility.IsValidNum(customerID, "^[\u4e00-\u9fa5a-zA-Z]+$"))//原需求只允许中英文
            {
                msg += "用户名只能包含中英文字符！<br />";
            }
            else if (customerID.Length < 3 || customerID.Length > 20)
            {
                msg += "用户名长度必须大于等于3个字符！<br />";
            }
            if (password1 == "")
            {
                msg += "请输入密码！<br />";
            }
            else if (!CommonUtility.IsValidNum(password1, "[a-zA-Z0-9]+$"))//原需求只允许英文数字组合
            {
                msg += "密码只能是英文数字组合！<br />";
            }
            else if (password1.Length < 6 || password1.Length > 20)
            {
                msg += "密码长度必须大于等于6个字符！<br />";
            }
            else if (password2 == "")
            {
                msg += "请输入确认密码！<br />";
            }
            else if (password2 != password1)
            {
                msg += "请确保两次输入的密码一致！<br />";
            }

            if (customerEmail == "")
            {
                msg += "请输入电子邮箱！<br />";
            }
            else if (!Util.IsEmailAddress(customerEmail))
            {
                msg += "请正确输入电子邮箱地址！";
            }

            try
            {

                //定义一个用户对象并赋值
                CustomerInfo oCustomer = new CustomerInfo();
                //-----基础的三个信息，用户名，密码，邮箱---//
                oCustomer.CustomerID = customerID;
                //DESC加密用户密码
                oCustomer.Pwd = DESProvider.EncryptString(password1, YoeJoyConfig.DESCEncryptKey);
                oCustomer.Email = customerEmail;

                //---其他信息---//
                oCustomer.EmailStatus = (int)AppEnum.EmailStatus.Origin;
                oCustomer.Status = (int)AppEnum.BiStatus.Valid;
                oCustomer.DwellAreaSysNo = AppConst.IntNull;
                oCustomer.ReceiveAreaSysNo = AppConst.IntNull;

                oCustomer.CustomerRank = (int)AppEnum.CustomerRank.Ordinary;
                oCustomer.IsManualRank = (int)AppEnum.YNStatus.No;
                oCustomer.CustomerType = (int)AppEnum.CustomerType.Personal;

                oCustomer.RegisterTime = DateTime.Now;
                oCustomer.LastLoginTime = DateTime.Now;
                oCustomer.LastLoginIP = context.Request.UserHostAddress;

                oCustomer.ValidScore = 0;
                oCustomer.TotalScore = 0;
                oCustomer.ValidFreeShipFee = 0;
                oCustomer.TotalFreeShipFee = 0;


                //注册操作
                CustomerManager.GetInstance().Insert(oCustomer);

                IcsonSessionInfo oSession = (IcsonSessionInfo)context.Session["IcsonSessionInfo"];
                if (oSession == null)
                {
                    oSession = new IcsonSessionInfo();
                    context.Session["IcsonSessionInfo"] = oSession;
                }
                //指定当前用户为注册的用户
                oSession.sCustomer = oCustomer;

                isSuccess = true;
            }
            catch (BizException exp)
            {
                msg = exp.Message;
            }
            catch (Exception ex)
            {
                ErrorLog.GetInstance().Write(ex.ToString());
                string url = "../CustomError.aspx?msg=" + context.Server.UrlEncode("用户注册失败！");
                context.Response.Redirect(url);
            }

            if (isSuccess)
            {
                //Response.Redirect("../Customer/NewCustomer.aspx?Type=success");
                msg += "注册成功";
                //lblErrmsg.Text = "恭喜您，注册成功！<br/>";
                //lblErrmsg.Text += "<a href='../Account/AccountCenter.aspx'><span style='color:#FF298F'>请点击进入用户中心！</ span></ a>";

                //Response.Redirect("../Account/AccountCenter.aspx");
            }
            return isSuccess;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="context"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool CustomerLogin(HttpContext context, string name, string password, out string msg)
        {
            bool isSuccess = false;
            msg = String.Empty;

            if (name == "")
            {
                msg = "请输入用户名！";
                return isSuccess;
            }

            if (password == "")
            {
                msg = "密码不能为空！";
                return isSuccess;
            }

            CustomerInfo oCustomer = null;
            oCustomer = CustomerManager.GetInstance().Load(name);
            string encryptPassword = DESProvider.EncryptString(password, YoeJoyConfig.DESCEncryptKey);
            //string encryptPassword = DESProvider.DecryptString(oCustomer.Pwd, YoeJoyConfig.DESCEncryptKey);
            if (oCustomer == null)
            {
                msg = "用户不存在";
                return isSuccess;
            }

            if (oCustomer.Pwd != encryptPassword)
            {
                msg = "密码不正确";
                return isSuccess;
            }
            else if (oCustomer.Status != (int)AppEnum.BiStatus.Valid)
            {
                msg = "用户名已经作废";
                return isSuccess;
            }
            else
            {
                //初始化会员级别，删除过期会员级别
                //NewPointManager.GetInstance().DelOverDueRank(oCustomer.SysNo);
                //oCustomer = CustomerManager.GetInstance().Load(name);
                //NewPointManager.GetInstance().InitRank(oCustomer.SysNo, oCustomer.CustomerRank);
                //NewPointManager.GetInstance().DelOverDueRank(oCustomer.SysNo);
                oCustomer = CustomerManager.GetInstance().Load(name);

                System.Web.HttpCookie mycookie = new System.Web.HttpCookie("LoginInfo");	//申明新的COOKIE变量
                mycookie.Domain = "www.MMMbuy.cn";
                mycookie.Expires = DateTime.Now.AddYears(1);
                mycookie.Value = name + "," + DateTime.Now.ToString(AppConst.DateFormatLong);
                context.Response.Cookies.Add(mycookie);

                IcsonSessionInfo oSession = CommonUtility.GetUserSession(context);
                oSession.sCustomer = oCustomer;

                Hashtable ht = new Hashtable(5);
                ht.Add("SysNo", oCustomer.SysNo);
                ht.Add("LastLoginIP", context.Request.UserHostAddress);
                ht.Add("LastLoginTime", DateTime.Now);
                CustomerManager.GetInstance().Update(ht);

                //if (oCustomer.IsManualRank != (int)AppEnum.YNStatus.Yes)
                //{
                //    int customerRank = CustomerManager.GetInstance().SetRank(oCustomer.SysNo);
                //    oSession.sCustomer.CustomerRank = customerRank;
                //}

                isSuccess = true;

            }

            return isSuccess;
        }

        /// <summary>
        /// 获得用户的基本信息
        /// </summary>
        /// <param name="cInfo"></param>
        /// <returns></returns>
        public static string GetCustomerBasicInfo(CustomerInfo cInfo)
        {
            string customInfoHTML = String.Empty;

            StringBuilder strb = new StringBuilder("<tbody>");

            string profileRowHTMLTemplate = "<tr><td>{0}</td><td>{1}</td></tr>";

            strb.Append(String.Format(profileRowHTMLTemplate, "用户ID：", cInfo.CustomerID.ToString().Trim()));
            strb.Append(String.Format(profileRowHTMLTemplate, "会员等级：", AppEnum.GetCustomerRank(cInfo.CustomerRank)));
            strb.Append(String.Format(profileRowHTMLTemplate, "积分：", cInfo.ValidScore > 0 ? cInfo.ValidScore : 0));

            string emailStatus=String.Empty;
            if(cInfo.EmailStatus==(int)AppEnum.EmailStatus.Origin)
            {
                emailStatus="未验证";
            }
            else
            {
                emailStatus="已验证";
            }

            strb.Append(String.Format(profileRowHTMLTemplate, "邮箱验证：",emailStatus));

            strb.Append("</tbody>");
            customInfoHTML = strb.ToString();
            return customInfoHTML;
        }

        /// <summary>
        /// 获得用户分页的收藏列表
        /// </summary>
        /// <param name="customerSysNo"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string GetCustomerWishListProducts(int customerSysNo,int startIndex)
        {
            string wishListHTML = String.Empty;

            int pageCount = int.Parse(YoeJoyConfig.WishListPagedCount);
            List<WishListModule> wishList = WishListService.GetCustomerWishList(customerSysNo, startIndex, pageCount);

            if (wishList!= null)
            {
                StringBuilder strb = new StringBuilder();

                ///TODO: Add logic to impelemnt wishlist UI.

                wishListHTML = strb.ToString();
            }

            return wishListHTML;
        }

    }
}
