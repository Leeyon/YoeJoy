<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="SubProductList2.aspx.cs" Inherits="YoeJoyWeb.SubProductList2" %>

<%@ Register Src="../Controls/CategoryNavigation.ascx" TagName="CategoryNavigation"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SubCategoryNavigation.ascx" TagName="SubCategoryNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link type="text/css" rel="Stylesheet" href="../static/css/productSort.css" />
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
        <span>您在:</span> <b>首页</b> <span>&gt;</span> <span id="c1"></span>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="LeftBigModule" runat="server">
    <div class="left">
        <uc2:SubCategoryNavigation ID="SubCategoryNavigation1" runat="server" />
        <dl class="ranking">
            <dt><i></i><b>本周销量排行</b><strong></strong></dt>
            <dd>
                <%=C1WeeklyBestSaledProductsHTML%>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="RightBigModule" runat="server">
    <div class="bigRight">
        <div class="clear">
            <div id="adShow">
                <a class="show" href="product.html">
                    <img alt="主题广告" src="../static/images/gg1.jpg" width="780" height="277"></a>
                <a href="product.html">
                    <img alt="主题广告" src="../static/images/gg2.jpg" width="780" height="277"></a>
                <a href="product.html">
                    <img alt="主题广告" src="../static/images/gg3.jpg" width="780" height="277"></a>
                <div class="btItem">
                    <a class="selected" href="javascript:">1</a> <a href="javascript:">2</a> <a href="javascript:">
                        3</a>
                </div>
            </div>
            <dl id="Discount">
                <dt><i></i><b>清库产品</b><strong></strong></dt>
                <%=C1EmptyInventoryProductsHTML%>
            </dl>
        </div>
        <%=C1ProductsDisplayHTML%>
    </div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="BackupContent1" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="HomeMiddleContent" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="BackupContent2" runat="server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $c1Name = $("#foodImport").children("h2").eq(0).children("b").eq(0).html();
            $("#position").children("span[id='c1']").html($c1Name);
        });
    </script>
</asp:Content>
