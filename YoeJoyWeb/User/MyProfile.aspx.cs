using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper.Security;
using YoeJoyHelper;

namespace YoeJoyWeb.User
{
    public partial class MyProfile : SecurityPageBase
    {
        /// <summary>
        /// 用户的基本信息
        /// </summary>
        protected string MyProfileHTML { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckProfile(Context);
            if (!IsPostBack)
            {
                var cInfo = CommonUtility.GetUserSession(Context).sCustomer;
                MyProfileHTML = CustomerHelper.GetCustomerBasicInfo(cInfo);
            }
        }
    }
}