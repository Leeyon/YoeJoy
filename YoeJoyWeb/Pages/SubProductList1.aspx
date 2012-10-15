<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="SubProductList1.aspx.cs" Inherits="YoeJoyWeb.C1ProductList" %>

<%@ Register Src="../Controls/SubCategoryNavigation.ascx" TagName="SubCategoryNavigation"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/CategoryNavigation.ascx" TagName="CategoryNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="NavigationModuleContent" runat="server">
    <uc2:CategoryNavigation ID="CategoryNavigation1" runat="server" />
    <uc1:SubCategoryNavigation ID="SubCategoryNavigation1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PanicBuyingMdouleContent" runat="server">
    <div id="bzxlph" class="l_class">
        <img src="../static/images/bzxlph.png"/>
        <%=C1WeeklyBestSaledProductsHTML %>
        <img src="../static/images/yjd05.png">
    </div>
    <div id="zxjj" class="l_class">
        <img src="../static/images/zxjj.png">
        <%=C1LastedDiscountProductsHTML%>
        <img src="../static/images/yjd.gif" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopLeftModuleContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopRightMdouleContent" runat="server">
    <div class="r_module">
        <!--洋葱导航条-->
        <div class="ycdh">
            <a href="../index.html"><b>首页</b></a>&gt;<span></span></div>
        <!--导航下区域-->
        <table cellspacing="0" cellpadding="0">
            <tbody>
                <tr>
                    <td width="790">
                        <img alt="广告" src="../static/images/gg2.jpg">
                    </td>
                    <td valign="top" width="210">
                        <!--清库产品-->
                        <div id="qkcp">
                            <img src="../static/images/qkcp.png" />
                            <%=C1EmptyInventoryProductsHTML %>
                            <img src="../static/images/yjd01.gif" /></div>
                    </td>
                </tr>
            </tbody>
        </table>
        <!--三级商品列表-->
        <%=C1ProductsDisplayHTML%>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyContent" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ExtenalContent" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PopupContent" runat="server">
    <script type="text/javascript">
        $(function () {

            $("body").removeAttr("id").attr({ "id": "class" });
            var $c1Name = $(".flbt").html();
            $(".ycdh").children("span").html($c1Name);
        });
    </script>
</asp:Content>
