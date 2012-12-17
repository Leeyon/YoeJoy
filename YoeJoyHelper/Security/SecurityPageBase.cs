using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

using Icson.Utils;
using Icson.Objects.Online;
using Icson.BLL.Online;

namespace YoeJoyHelper.Security
{
    /// <summary>
    /// 安全页面基础类型
    /// 后台用户中心必须继承这个page类
    /// </summary>
    public class SecurityPageBase : System.Web.UI.Page
    {
        protected void CheckProfile(HttpContext context)
        {
            if (!IsPostBack)
            {
                IcsonSessionInfo oSession = CommonUtility.GetUserSession(context);
                if (oSession.sCustomer == null)
                {
                    string loginUrl = String.Concat(YoeJoyConfig.SiteBaseURL, "User/Login.aspx");
                    Response.Redirect(loginUrl);
                }
            }
        }

    }
}
