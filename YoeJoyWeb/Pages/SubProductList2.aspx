﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
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
        <span>您在:</span> <b><a href="../Default.aspx">首页</a></b> <span>&gt;</span> <span id="c1"><b><a href='javascript:void(0);'></a></b></span><span>&gt;</span>
        <span id="c2"></span>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="LeftBigModule" runat="server">
    <div class="left">
        <uc2:SubCategoryNavigation ID="SubCategoryNavigation1" runat="server" />
        <dl class="ranking">
            <dt><i></i><b>本周销量排行</b><strong></strong></dt>
            <dd>
                <%=C2WeeklyBestSaledProductsHTML%>
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="RightBigModule" runat="server">
    <div class="bigRight">
        <div class="clear">
           <%=C2SlideAdHTML%>
            <dl id="Discount">
                <dt><i></i><b>清库产品</b><strong></strong></dt>
                <%=C2EmptyInventoryProductsHTML%>
            </dl>
        </div>
        <%=C2ProductsDisplayHTML%>
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

            var c1 = YoeJoy.Site.Utility.GetQueryString("c1");
            var c2 = YoeJoy.Site.Utility.GetQueryString("c2");
            var siteBaseURL = $("#siteBaseURL").val().toString()
            var $c1Name = $("#foodImport").children("h2").eq(0).children("b").eq(0).html();
            $("#position").children("span[id='c1']").children("b").children("a").html($c1Name);
            $("#position").children("span[id='c1']").children("b").children("a").click(function (event) {
                window.location.href = siteBaseURL + "Pages/SubProductList1.aspx?c1=" + c1;
            });
            var $c2Name = $(".listOut li input[value=" + c2 + "]").siblings("h3").text();
            $("#position").children("span[id='c2']").text($c2Name);
        });
    </script>
</asp:Content>
