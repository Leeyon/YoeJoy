using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Icson.Utils;
using Icson.Objects.Online;
using Icson.BLL.Online;

namespace YoeJoyWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 用户的Session
        /// </summary>
        public IcsonSessionInfo UserSession
        {
            get
            {
                IcsonSessionInfo oSession = (IcsonSessionInfo)Session["IcsonSessionInfo"];
                if (oSession == null)
                {
                    oSession = new IcsonSessionInfo();
                    Session["IcsonSessionInfo"] = oSession;
                }
                return oSession;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.sCustomer == null)
            {
                ///TODO: add logic here for user scenarios
            }
        }
    }
}