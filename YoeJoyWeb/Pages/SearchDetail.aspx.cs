using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper;
using YoeJoyHelper.Extension;

namespace YoeJoyWeb.Pages
{
    public partial class SearchDetail : System.Web.UI.Page
    {

        protected int C1CategorySysId
        {
            get
            {
                if (Request.QueryString["c1"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(Request.QueryString["c1"].ToString().Trim());
                }
            }
        }

        protected int C2CategorySysId
        {
            get
            {
                if (Request.QueryString["c2"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(Request.QueryString["c2"].ToString().Trim());
                }
            }
        }

        protected int C3CategorySysId
        {
            get
            {
                if (Request.QueryString["c3"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(Request.QueryString["c3"].ToString().Trim());
                }
            }
        }

        protected string C3ProductFilterHTML { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubCategoryNavigation1.C1SysNo = C1CategorySysId;
                C3ProductFilterHTML = FrontProductsHelper.InitC3ProductFilter(C3CategorySysId);
            }
        }
    }
}