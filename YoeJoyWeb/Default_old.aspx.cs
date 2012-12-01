using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoeJoyHelper;
using YoeJoyHelper.Model;

namespace YoeJoyWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected string PromoHTML { get; set; }
        protected string PanicBuyingHTML { get; set; }
        protected string InComingProducts { get; set; }
        protected string HomeBrandsHTML { get; set; }
        protected string HomeWebBulletinListHTML { get; set; }
        protected string ADBelowNewsHTML { get; set; }
        protected string ADCenterLeft { get; set; }
        protected string ADCenterRight { get; set; }
        protected string ADCategoryLeftOne { get; set; }
        protected string ADCategoryLeftTwo { get; set; }
        protected string ADCategoryRightOne { get; set; }
        protected string ADCategoryRightTwo { get; set; }
        protected string CategoryProductsOneHTML { get; set; }
        protected string CategoryProductsTwoHTML { get; set; }
        protected string CategoryProductsBrandsOneHTML { get; set; }
        protected string CategoryProductsBrandsTwoHTML { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            PromoHTML = PromotionProductsHelper.GetPromotionProductsForHome();
            PanicBuyingHTML = PanicBuyingHelper.GetPanicProductsForHome();
            InComingProducts = InComingProductHelper.GetInComingProductForHomeWrapper();
            HomeBrandsHTML = BrandsHelper.GetBrandsForHomeWrapper(5);
            HomeWebBulletinListHTML = WebBulletinHelper.GetWebBulletinListForHomeWrapper(5);
            //ADBelowNewsHTML = ADHelper.GetSiteAdWrapper(3);
            //ADCenterLeft = ADHelper.GetSiteAdWrapper(4);
            //ADCenterRight = ADHelper.GetSiteAdWrapper(5);
            //ADCategoryLeftOne = ADHelper.GetSiteAdWrapper(6);
            //ADCategoryLeftTwo = ADHelper.GetSiteAdWrapper(7);
            //ADCategoryRightOne = ADHelper.GetSiteAdWrapper(8);
            //ADCategoryRightTwo = ADHelper.GetSiteAdWrapper(9);
            CategoryProductsOneHTML = FrontProductsHelper.GetHomeCategoryOneProductsDisplayHTMLWrapper(YoeJoyConfig.HomeDisplayCategoryID1);
            CategoryProductsTwoHTML = FrontProductsHelper.GetHomeCategoryOneProductsDisplayHTMLWrapper(YoeJoyConfig.HomeDisplayCategoryID2);
            CategoryProductsBrandsOneHTML = BrandsHelper.GetBrandsForCategoryOneProductsWrapper(YoeJoyConfig.HomeDisplayCategoryID1);
            CategoryProductsBrandsTwoHTML = BrandsHelper.GetBrandsForCategoryOneProductsWrapper(YoeJoyConfig.HomeDisplayCategoryID2);
        }
    }
}