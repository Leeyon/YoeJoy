using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper;

namespace YoeJoyWeb
{
    public partial class Product : System.Web.UI.Page
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

        protected int ProductSysNo
        {
            get
            {
                if (Request.QueryString["pid"] == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(Request.QueryString["pid"].ToString().Trim());
                }
            }
        }

        protected string ProductDetailImagesHTML { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubCategoryNavigation1.C1CategoryId = C1CategorySysId;
                ProductDetailHelper helper = new ProductDetailHelper(ProductSysNo);
                ProductDetailImagesHTML = helper.GetProductDetailImages();
            }
        }
    }
}