using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper;
using Icson.Objects;
using Icson.Objects.Online;

namespace YoeJoyWeb.User
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected string MyProfileHTML { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var cInfo = ((Site)this.Master).UserSession.sCustomer;
            MyProfileHTML = CustomerHelper.GetCustomerBasicInfo(cInfo);
        }
    }
}