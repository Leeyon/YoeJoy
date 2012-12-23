using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper;
using System.Collections;

using Icson.Utils;
using Icson.Objects.Online;
using Icson.BLL;
using Icson.BLL.Basic;
using Icson.BLL.Online;
using Icson.Objects;
using Icson.Objects.Sale;
using Icson.Objects.Basic;
using Icson.BLL.Sale;

namespace YoeJoyWeb.Controls
{
    public partial class OnlieShoppingCart : System.Web.UI.UserControl
    {

        protected string SiteBaseURL
        {
            get
            {
                return YoeJoyConfig.SiteBaseURL;
            }
        }

        protected string OnlieShoppingCartHTML { get; set; }

        protected Hashtable newHt = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CommonUtility.GetUserSession(Context).sCustomer != null)
            {
                Hashtable ht = new Hashtable();

                if (newHt.Count == 0)
                {
                    ht = CartManager.GetInstance().GetCartHash();
                }
                else
                {
                    ht = newHt;
                }

                if (ht == null || ht.Count == 0)
                {
                    OnlieShoppingCartHTML = String.Empty;
                }
                else
                {
                    OnlieShoppingCartHTML = CustomerHelper.GetCustomerShoppingCart(ht);
                }
            }
            else
            {
                OnlieShoppingCartHTML=String.Empty;
            }
        }
    }
}