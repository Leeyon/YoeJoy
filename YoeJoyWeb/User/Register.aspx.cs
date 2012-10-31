using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Icson.Objects;
using Icson.Utils;


using Icson.Objects.Basic;
using Icson.Objects.Online;

using Icson.BLL;
using Icson.BLL.Basic;

using System.Threading;

namespace YoeJoyWeb.User
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbMsg.Visible = false;
            }
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lbMsg.Visible = false;
            lbMsg.Text = String.Empty;

            string customerID = txtName.Text.Trim();

            bool check = true;

            bool isOk = false;

            if (customerID == "")
            {
                lbMsg.Text += "请输入用户名！<br />";
                check = false;
            }
            else if (!IsValidNum(customerID, "^[\u4e00-\u9fa5a-zA-Z]+$"))//原需求只允许中英文
            {
                lbMsg.Text += "用户名只能包含中英文字符！<br />";
                check = false;
            }
            else if (customerID.Length < 3 || customerID.Length > 20)
            {
                lbMsg.Text += "用户名长度必须大于等于3个字符！<br />";
                check = false;
            }
            if (txtPwd.Text.Trim() == "")
            {
                lbMsg.Text += "请输入密码！<br />";
                check = false;
            }
            else if (!IsValidNum(txtPwd.Text.Trim(), "[a-zA-Z0-9]+$"))//原需求只允许英文数字组合
            {
                lbMsg.Text += "密码只能是英文数字组合！<br />";
                check = false;
            }
            else if (txtPwd.Text.Trim().Length < 6 || txtPwd.Text.Trim().Length > 20)
            {
                lbMsg.Text += "密码长度必须大于等于6个字符！<br />";
                check = false;
            }
            else if (txtPwd2.Text.Trim() == "")
            {
                lbMsg.Text += "请输入确认密码！<br />";
                check = false;
            }
            else if (txtPwd2.Text.Trim() != txtPwd.Text.Trim())
            {
                lbMsg.Text += "请确保两次输入的密码一致！<br />";
                check = false;
            }

            if (txtEmail.Text.Trim() == "")
            {
                lbMsg.Text += "请输入电子邮箱！<br />";
                check = false;
            }
            else if (!Util.IsEmailAddress(txtEmail.Text.Trim()))
            {
                lbMsg.Text += "请正确输入电子邮箱地址！";
                check = false;
            }

            try
            {
                System.Web.HttpCookie myCookie = new HttpCookie("LoginInfo");
                //myCookie.Domain = "www.mmbuy.cn";
                myCookie.Expires = DateTime.Now.AddYears(1);//Cookie过期时间
                myCookie.Value = customerID + "," + DateTime.Now.ToString(AppConst.DateFormatLong);
                Page.Response.Cookies.Add(myCookie);//添加到页面cookie中

                //定义一个用户对象并赋值
                CustomerInfo oCustomer = new CustomerInfo();
                //-----基础的三个信息，用户名，密码，邮箱---//
                oCustomer.CustomerID = txtName.Text.Trim();
                oCustomer.Pwd = txtPwd.Text.Trim();
                oCustomer.Email = txtEmail.Text.Trim();

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
                oCustomer.LastLoginIP = Request.UserHostAddress;

                oCustomer.ValidScore = 0;
                oCustomer.TotalScore = 0;
                oCustomer.ValidFreeShipFee = 0;
                oCustomer.TotalFreeShipFee = 0;


                //注册操作
                CustomerManager.GetInstance().Insert(oCustomer);

                IcsonSessionInfo oSession = (IcsonSessionInfo)Session["IcsonSessionInfo"];
                if (oSession == null)
                {
                    oSession = new IcsonSessionInfo();
                    Session["IcsonSessionInfo"] = oSession;
                }
                //指定当前用户为注册的用户
                oSession.sCustomer = oCustomer;

                isOk = true;



            }
            catch (BizException exp)
            {
                lbMsg.Text = exp.Message;
            }
            catch (Exception ex)
            {
                ErrorLog.GetInstance().Write(ex.ToString());
                string url = "../CustomError.aspx?msg=" + Server.UrlEncode("用户注册失败！");
                Response.Redirect(url);

            }

            if (isOk)
            {
                //Response.Redirect("../Customer/NewCustomer.aspx?Type=success");
                lbMsg.Text = "注册成功";
                //lblErrlMsg.Text = "恭喜您，注册成功！<br/>";
                //lblErrlMsg.Text += "<a href='../Account/AccountCenter.aspx'><span style='color:#FF298F'>请点击进入用户中心！</ span></ a>";

                //Response.Redirect("../Account/AccountCenter.aspx");
            }
        }

        /// <summary>
        /// 通用正则
        /// </summary>
        /// <param name="num">待验证信息</param>
        /// <param name="match">正则表达式</param>
        /// <returns>通过与否 true or false</returns>
        protected bool IsValidNum(string num, string match)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(num, match);
        }
    }
}