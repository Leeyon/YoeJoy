<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="YoeJoyWeb.Default" %>

<%@ Register Src="Controls/CategoryNavigation.ascx" TagName="CategoryNavigation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="NavigationModuleContent" runat="server">
    <uc1:CategoryNavigation ID="CategoryNavigation1" runat="server" IsHomePage="true" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PanicBuyingMdouleContent" runat="server">
    <!--限时抢购模块-->
    <div id="xsqg">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src="../static/images/xsqg.png" alt="限时抢购" />
                </td>
            </tr>
            <tr>
                <td class="content">
                    <%=PanicBuyingHTML%>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="../static/images/yjd.gif" alt="圆角底" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopLeftModuleContent" runat="server">
    <!--导航下广告-->
    <div class="ad02">
        <img src="./static/images/gg2.jpg" alt="广告" />
    </div>
    <!--促销商品-->
    <div class="mlist">
        <table width="100%" class="listtitle" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src="./static/images/cuxiao.png" />
                </td>
                <td align="right">
                    <a href="#">更多〉〉</a>
                </td>
            </tr>
        </table>
        <%=PromoHTML%>
    </div>
    <!--新品上市-->
    <div class="mlist">
        <table width="100%" class="listtitle" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src="./static/images/xingping.png" />
                </td>
                <td align="right">
                    <a href="#">更多〉〉</a>
                </td>
            </tr>
        </table>
        <%=InComingProducts%>
    </div>
    <!--品牌旗舰-->
    <div class="brand">
        <table border="0" cellpadding="0" cellspacing="0" height="35">
            <tr>
                <td width="96" bgcolor="#F0F0F0" class="brandtitle" align="center">
                    品牌旗舰店
                </td>
                <td>
                    <%=HomeBrandsHTML %>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopRightMdouleContent" runat="server">
    <!--攸怡快报-->
    <div class="r_class kuaibao">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img src="./static/images/kuaibao.png" />
                </td>
            </tr>
            <tr>
                <td class="content" valign="top">
                    <%=HomeWebBulletinListHTML%>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="./static/images/yjd01.gif" alt="圆角底" />
                </td>
            </tr>
        </table>
    </div>
    <!--快报下广告210X90-->
    <div class="ad03">
        <%=ADBelowNewsHTML %>
    </div>
    <!--团购-->
    <div class="r_class tuan">
        <div>
            <img src="./static/images/tuan.png" /></div>
        <div class="content">
            <div class="tuantime">
                <span>365</span>天<span>24</span>时<span>59</span>分<span>59</span>秒</div>
            <a href="products/tuan.html">
                <img src="./static/images/tuansp01.jpg" />
                <p>
                    商品名称商品名称商品名称商品名称商品名称商品名称</p>
            </a>
            <div class="tuanprice">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="139">
                            <span>1000.0</span>
                        </td>
                        <td>
                            <a href="#">
                                <img src="./static/images/tuanbuttom.png" /></a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="content">
            <div class="tuantime">
                <span>365</span>天<span>24</span>时<span>59</span>分<span>59</span>秒</div>
            <a href="products/tuan.html">
                <img src="./static/images/tuansp01.jpg" />
                <p>
                    商品名称商品名称商品名称商品名称商品名称商品名称</p>
            </a>
            <div class="tuanprice">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="139">
                            <span>1000.0</span>
                        </td>
                        <td>
                            <a href="#">
                                <img src="./static/images/tuanbuttom.png" /></a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <img src="./static/images/yjd01.gif" /></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyContent" runat="server">
    <!--上半区域下广告-->
    <div class="ad04">
        <%=ADCenterLeft%><%=ADCenterRight%></div>
    <!--IT数码-->
    <div class="integrate itsm">
        <!--导购文-->
        <div class="dgwz">
            <img src="./static/images/it.png" />
            <!--主要导购文-->
            <%=ADCategoryLeftOne %>
            <!--次要导购文-->
            <ul>
                <li><a href="#">IT相关导购文</a></li>
                <li><a href="#">IT相关导购文</a></li>
                <li><a href="#">IT相关导购文</a></li>
                <li><a href="#">IT相关导购文</a></li>
            </ul>
        </div>
        <!--IT数码商品列表-->
        <%=CategoryProductsOneHTML%>
        <div class="intright">
            <!--分类品牌-->
            <div class="ppfl">
                <img src="./static/images/flpp.gif" />
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <%=CategoryProductsBrandsOneHTML%>
                </table>
            </div>
            <!--品牌下广告-->
            <div class="ad05">
                <%=ADCategoryRightOne %></div>
            <!--评论与新闻-->
            <div class="comments">
                <ul class="comenu">
                    <li>用户评论</li>
                    <li>销量排行</li>
                </ul>
                <div class="combox">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="60">
                                <img src="./static/images/plsp.jpg" />
                            </td>
                            <td valign="top">
                                <p align="left">
                                    <a href="#">商品名称</a></p>
                                <a href="#"><span class="plnum">321</span></a>条
                            </td>
                        </tr>
                    </table>
                    <p align="left" class="pltext">
                        评论内容评论内容评论内容评论内容评论内容评论内容</p>
                    会员:<span class="plname">l***o</span>
                </div>
            </div>
        </div>
    </div>
    <!--家居用品-->
    <div class="integrate home">
        <!--导购文-->
        <div class="dgwz">
            <img src="./static/images/home.png" />
            <!--主要导购文-->
            <%=ADCategoryLeftTwo %>
            <!--次要导购文-->
            <ul>
                <li><a href="#">IT相关导购文</a></li>
                <li><a href="#">IT相关导购文</a></li>
                <li><a href="#">IT相关导购文</a></li>
                <li><a href="#">IT相关导购文</a></li>
            </ul>
        </div>
        <!--IT数码商品列表-->
        <%=CategoryProductsTwoHTML %>
        <div class="intright">
            <!--分类品牌-->
            <div class="ppfl">
                <img src="./static/images/flpp.gif" />
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <%=CategoryProductsBrandsTwoHTML%>
                </table>
            </div>
            <!--品牌下广告-->
            <div class="ad05">
                <%=ADCategoryRightTwo %>
                <!--评论与新闻-->
                <div class="comments">
                    <ul class="comenu">
                        <li>用户评论</li>
                        <li>销量排行</li>
                    </ul>
                    <div class="combox sort">
                        <ul>
                            <li><span class="sortsp"><span class="sortnum">1</span><a href="#">商品名称</a></span><span
                                class="sortprice">￥238.5</span></li>
                            <li><span class="sortsp"><span class="sortnum">2</span><a href="#">商品名称</a></span><span
                                class="sortprice">￥238.5</span></li>
                            <li><span class="sortsp"><span class="sortnum">3</span><a href="#">商品名称</a></span><span
                                class="sortprice">￥238.5</span></li>
                            <li><span class="sortsp"><span class="sortnum">4</span><a href="#">商品名称</a></span><span
                                class="sortprice">￥238.5</span></li>
                            <li><span class="sortsp"><span class="sortnum">5</span><a href="#">商品名称</a></span><span
                                class="sortprice">￥238.5</span></li>
                            <li><span class="sortsp"><span class="sortnum">6</span><a href="#">商品名称</a></span><span
                                class="sortprice">￥238.5</span></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ExtenalContent" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(function () {

            $("body").removeAttr("id").attr({ "id": "home" });

            $("#container li").each(function (index) {
                var $this = $(this);
                var startTime = new Date();
                var $endTime = Date.parse($this.children("input").val());
                var remainSecond = (($endTime - startTime.getTime()) / 1000);
                var $timeDiv = $this.children("div[class='time']");
                var InterValObj = window.setInterval(function () {
                    if (remainSecond > 0) {
                        remainSecond = remainSecond - 1;
                        var second = Math.floor(remainSecond % 60);
                        var minite = Math.floor((remainSecond / 60) % 60);
                        var hour = Math.floor((remainSecond / 3600) % 24);
                        var day = Math.floor((remainSecond / 3600) / 24);
                        $timeDiv.html("<span class='qgtime'>" + day + "</span>天<span class='qgtime'>" + hour + "</span>小时<span class='qgtime'>" + minite + "</span>分<span" +
                                        " class='qgtime'>" + second + "</span>秒");
                    }
                    else {
                        window.clearInterval(InterValObj);
                    }
                }, 1000);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
