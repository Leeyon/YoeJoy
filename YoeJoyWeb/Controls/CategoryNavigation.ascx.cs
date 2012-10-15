using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper.Model;
using YoeJoyHelper;

namespace YoeJoyWeb.Controls
{
    public partial class CategoryNav : System.Web.UI.UserControl
    {

        public bool IsHomePage { get; set; }

        protected string CategoryNavHTML { get; set; }

        private static readonly string HomePageNavigationHTMLTemplate = @"<div class='l_class' id='classmenu'>
            <table border='0' cellpadding='0' cellspacing='0'>
                <tr>
                    <td height='43'><img src='../static/images/homeclass.png' alt='全部分类' /></td>
                </tr>
                <tr>
                    <td class='allclass'>
                        <table border='0' cellpadding='0' cellspacing='0' class='classitem'>{0}</table>
                    <!--分类下广告170X65-->
                    <div class='ad01'>{1}</div></td>
                </tr>
                <tr>
                    <td height='13'>
                    <img src='../static/images/classfoot.png' alt='分类底' />
                    </td>
                </tr>
            </table></div>";

        private static readonly string OtherPageNavigationHTMLTemplate = @"<div class='classmenu close'>
    <div style='display: none;' class='allclass'>
        <table class='classitem' border='0' cellspacing='0' cellpadding='0'>
            <tbody>
                {0}
                <tr>
                    <td>
                        <!--分类下广告170X65-->
                        <div class='ad01'>
                            {1}
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
        <img alt='分类底' src='../static/images/classfoot.png'/></div>
</div>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryHelper cHelper = new CategoryHelper();
                string categoryADHTML = ADHelper.GetSiteAdWrapper(2);
                string categoryNavHTML = cHelper.InitCategoryNavigationWrapper();
                if (IsHomePage)
                {
                    CategoryNavHTML = String.Format(HomePageNavigationHTMLTemplate, categoryNavHTML, categoryADHTML);
                }
                else
                {
                    CategoryNavHTML = String.Format(OtherPageNavigationHTMLTemplate, categoryNavHTML, categoryADHTML);
                }

            }
        }
    }
}