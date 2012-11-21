using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper;
using Icson.Objects;
using Icson.Utils;

namespace YoeJoyWeb
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Request["name"].ToString().Trim();
                string password = Request["pass"].ToString().Trim();

                string msg=String.Empty;

                bool result = CustomerHelper.CustomerLogin(Context, name, password, out msg);

                if (result)
                {
                    System.Web.HttpCookie mycookie = new System.Web.HttpCookie("LoginInfo");	//申明新的COOKIE变量
                    mycookie.Domain = YoeJoyConfig.SiteBaseURL;
                    mycookie.Expires = DateTime.Now.AddYears(1);
                    mycookie.Value = name + "," + DateTime.Now.ToString(AppConst.DateFormatLong);
                    Response.Cookies.Add(mycookie);
                }

                Response.Write(JsonContentTransfomer<object>.GetJsonContent(new { IsSuccess = result, Msg = msg }));

            }
        }
    }
}