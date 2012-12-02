<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="SubProductList2.aspx.cs" Inherits="YoeJoyWeb.SubProductList2" %>

<%@ Register Src="../Controls/CategoryNavigation.ascx" TagName="CategoryNavigation"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SubCategoryNavigation.ascx" TagName="SubCategoryNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link type="text/css" rel="Stylesheet" href="../static/css/layout.css" />
    <link type="text/css" rel="Stylesheet" href="../static/css/class.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftTopModule" runat="server">
    <uc1:CategoryNavigation ID="CategoryNavigation1" runat="server" IsHomePage="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightTopModule" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MiddleTopModule" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SiteNavModule" runat="server">
    <div id="position">
        <span>您在:</span> <b>首页</b> <span>&gt;</span> <span id="c1"><b></b></span><span>&gt;</span>
        <span id="c3"></span>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="LeftBigModule" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="RightBigModule" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="BackupContent1" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="HomeMiddleContent" runat="server">
    <div class="mix">
        <div class="l_module">
            <uc2:SubCategoryNavigation ID="SubCategoryNavigation1" runat="server" />
            <div id="hotComments" class="l_class area">
                <div class="title">
                    <div class="mem0">
                    </div>
                    <h3>
                        产品热评</h3>
                    <div class="mem1">
                    </div>
                </div>
                <div class="group">
                    <div class="item">
                        <a class="photo" href="product.html">
                            <img alt="商品名称商品名称商品名称商品名称商品名称" src="../static/images/plsp.jpg" width="60" height="60"></a>
                        <h2 class="goodsName">
                            <a href="product.html">商品名称商品名称商品名称商品名称商品名称</a></h2>
                        <p class="mast" align="right">
                            ¥1500</p>
                        <p class="slave" align="right">
                            会员:l***o</p>
                        <p class="pltext" align="left">
                            评论内容评论内容评论内容评论内容评论内容评论内容</p>
                    </div>
                    <div class="item">
                        <a class="photo" href="product.html">
                            <img alt="商品名称商品名称商品名称商品名称商品名称" src="../static/images/plsp.jpg" width="60" height="60"></a>
                        <h2 class="goodsName">
                            <a href="product.html">商品名称商品名称商品名称商品名称商品名称</a></h2>
                        <p class="mast" align="right">
                            ¥1500</p>
                        <p class="slave" align="right">
                            会员:l***o</p>
                        <p class="pltext" align="left">
                            评论内容评论内容评论内容评论内容评论内容评论内容</p>
                    </div>
                    <div class="item">
                        <a class="photo" href="product.html">
                            <img alt="商品名称商品名称商品名称商品名称商品名称" src="../static/images/plsp.jpg" width="60" height="60"></a>
                        <h2 class="goodsName">
                            <a href="product.html">商品名称商品名称商品名称商品名称商品名称</a></h2>
                        <p class="mast" align="right">
                            ¥1500</p>
                        <p class="slave" align="right">
                            会员:l***o</p>
                        <p class="pltext" align="left">
                            评论内容评论内容评论内容评论内容评论内容评论内容</p>
                    </div>
                    <div class="item">
                        <a class="photo" href="product.html">
                            <img alt="商品名称商品名称商品名称商品名称商品名称" src="../static/images/plsp.jpg" width="60" height="60"></a>
                        <h2 class="goodsName">
                            <a href="product.html">商品名称商品名称商品名称商品名称商品名称</a></h2>
                        <p class="mast" align="right">
                            ¥1500</p>
                        <p class="slave" align="right">
                            会员:l***o</p>
                        <p class="pltext" align="left">
                            评论内容评论内容评论内容评论内容评论内容评论内容</p>
                    </div>
                    <div class="item">
                        <a class="photo" href="product.html">
                            <img alt="商品名称商品名称商品名称商品名称商品名称" src="../static/images/plsp.jpg" width="60" height="60"></a>
                        <h2 class="goodsName">
                            <a href="product.html">商品名称商品名称商品名称商品名称商品名称</a></h2>
                        <p class="mast" align="right">
                            ¥1500</p>
                        <p class="slave" align="right">
                            会员:l***o</p>
                        <p class="pltext" align="left">
                            评论内容评论内容评论内容评论内容评论内容评论内容</p>
                    </div>
                    <div class="item">
                        <a class="photo" href="product.html">
                            <img alt="商品名称商品名称商品名称商品名称商品名称" src="../static/images/plsp.jpg" width="60" height="60"></a>
                        <h2 class="goodsName">
                            <a href="product.html">商品名称商品名称商品名称商品名称商品名称</a></h2>
                        <p class="mast" align="right">
                            ¥1500</p>
                        <p class="slave" align="right">
                            会员:l***o</p>
                        <p class="pltext" align="left">
                            评论内容评论内容评论内容评论内容评论内容评论内容</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="r_mix">
            <!--热卖推荐Begin-->
            <div id="recommend">
                <div class="group">
                    <ul class="item">
                        <li>
                            <img alt="商品名称商品名称商品名称商品名称" src="../static/images/sp.jpg" width="90" height="90">
                            <p class="goodsName">
                                <a href="product.html">商品名称商品名称商品名称商品名称</a></p>
                            <p class="slave">
                                攸怡价:<span class="mast">¥1500.00</span></p>
                            <a class="bt1" href="javascript:void(0)">立即购买</a> </li>
                        <li>
                            <img alt="商品名称商品名称商品名称商品名称" src="../static/images/sp.jpg" width="90" height="90">
                            <p class="goodsName">
                                <a href="product.html">商品名称商品名称商品名称商品名称</a></p>
                            <p class="slave">
                                攸怡价:<span class="mast">¥1500.00</span></p>
                            <a class="bt1" href="javascript:void(0)">立即购买</a> </li>
                        <li>
                            <img alt="商品名称商品名称商品名称商品名称" src="../static/images/sp.jpg" width="90" height="90">
                            <p class="goodsName">
                                <a href="product.html">商品名称商品名称商品名称商品名称</a></p>
                            <p class="slave">
                                攸怡价:<span class="mast">¥1500.00</span></p>
                            <a class="bt1" href="javascript:void(0)">立即购买</a> </li>
                    </ul>
                    <ul class="title">
                        <li>热</li>
                        <li>卖</li>
                        <li>推</li>
                        <li>荐</li>
                    </ul>
                </div>
            </div>
            <!--热卖推荐End-->
            <!--筛选条件Begin-->
            <div id="screening">
                <div class="title">
                </div>
                <%=C3ProductFilterHTML%>
                <div class="more">
                    <div class="item0">
                    </div>
                    <div class="item1">
                        <a href="javascript:void(0)">更多筛选</a></div>
                </div>
            </div>
            <iframe id="ProductIframe" frameborder="0" scrolling="no" width="1001px" height="750px">
            </iframe>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="BackupContent2" runat="server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">

        function getAttributionIds() {
            var productFilterCount = $("#screening").children("div[class='attr']").length;
            var selectedAIds = new Array();
            for (var i = 0; i < productFilterCount; i++) {
                var attrId = $("#screening").children("div[class='attr']").eq(i).children("input[class='selectedValue']").eq(0).val();
                if (attrId != "0") {
                    selectedAIds[i] = attrId;
                }
            }
            return YoeJoy.Site.Utility.ReplaceEmptyItem(selectedAIds);
        }

        $(function () {

            var c1 = YoeJoy.Site.Utility.GetQueryString("c1");
            var c2 = YoeJoy.Site.Utility.GetQueryString("c2");
            var c3 = YoeJoy.Site.Utility.GetQueryString("c3");

            var $c1Name = $("#foodImport").children("h2").eq(0).children("b").eq(0).html();
            $("#position").children("span[id='c1']").children("b").html($c1Name);
            var $c3Name = $(".listOut li p a input[value=" + c3 + "]").siblings("input").val();
            $("#position").children("span[id='c3']").html($c3Name);
            $("#screening").children(".title").eq(0).html($c3Name + "－商品筛选");

            var productListBaseURL = "ProductList.aspx?c1=" + c1 + "&c2=" + c2 + "&c3=" + c3 + "&attrIds=";
            $("#ProductIframe").attr({ "src": productListBaseURL });

            $("#screening").children("div[class='attr']").each(function (index) {

                var $attrItem = $(this);
                $attrItem.children(".all").click(function (event) {
                    $attrItem.children("input[class='selectedValue']").val("0");
                    var aIds = getAttributionIds();
                    var url = productListBaseURL + aIds;
                    $("#ProductIframe").attr({ "src": url });
                });

                $attrItem.children("strong").eq(0).children("span").each(function (index1) {
                    var $attrItemSpan = $(this);
                    $attrItemSpan.click(function (event) {
                        var selectedAId = $attrItemSpan.children("input").val();
                        $attrItem.children("input[class='selectedValue']").val(selectedAId);
                        var aIds = getAttributionIds();
                        var url = productListBaseURL + aIds;
                        $("#ProductIframe").attr({ "src": url });
                    });
                });

            });

        });
    </script>
</asp:Content>
