using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper;
using YoeJoyWeb.Controls;

namespace YoeJoyWeb
{
    public partial class C1ProductList : System.Web.UI.Page
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

        protected string C1ProductsDisplayHTML { get; set; }
        protected string C1EmptyInventoryProductsHTML { get; set; }
        protected string C1LastedDiscountProductsHTML { get; set; }
        protected string C1WeeklyBestSaledProductsHTML { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubCategoryNavigation1.C1CategoryId = C1CategorySysId;
                C1ProductsDisplayHTML = FrontProductsHelper.GetC1ProductsDisplayHTMLWrapper(C1CategorySysId);
                C1EmptyInventoryProductsHTML = FrontProductsHelper.GetC1EmptyInventoryProductsHTMLWrapper(C1CategorySysId);
                C1LastedDiscountProductsHTML = FrontProductsHelper.GetC1LastedDisCountProductsHTMLWrapper(C1CategorySysId);
                C1WeeklyBestSaledProductsHTML = FrontProductsHelper.GetC1WeeklyBestSaledProductsHTMLWrapper(C1CategorySysId);
            }
        }
    }
}