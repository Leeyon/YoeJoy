﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper;

using Icson.Utils;
using Icson.Objects.Online;
using Icson.BLL.Online;

namespace YoeJoyWeb
{
    public partial class Site : System.Web.UI.MasterPage
    {
        //判断是否是主页
        public bool IsHomePage { get; set; }

        protected string LeftTopDivTag { get; set; }

        protected string SiteBaseURLSearch
        {
            get
            {
                return String.Concat(YoeJoyConfig.SiteBaseURL, "Pages/Search.aspx");
            }
        }

        protected string SiteBaseURL
        {
            get
            {
                return YoeJoyConfig.SiteBaseURL;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsHomePage)
            {
                LeftTopDivTag = "<div class='left'>";
            }
            else
            {
                LeftTopDivTag = "<div class='left ItemSort1' id='ItemSortCon'>";
            }
        }
    }
}