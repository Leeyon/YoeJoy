<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="YoeJoyWeb.Search" %>

<%@ Register Src="../Controls/CategoryNavigation.ascx" TagName="CategoryNavigation"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SubCategoryNavigation.ascx" TagName="SubCategoryNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .sxtj
        {
            width: 998px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationModuleContent" runat="server">
    <uc1:CategoryNavigation ID="CategoryNavigation1" runat="server" />
    <%--<uc2:SubCategoryNavigation ID="SubCategoryNavigation1" runat="server" />--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanicBuyingMdouleContent" runat="server">
    <div id="cprp" class="l_class">
        <img src="../static/images/cprp.png">
        <div class="item">
            <table border="0" cellspacing="0" cellpadding="0" width="180">
                <tbody>
                    <tr>
                        <td width="62">
                            <img src="../static/images/plsp.jpg">
                        </td>
                        <td valign="top" width="118" align="right">
                            <p align="left">
                                <a href="#">商品名称</a></p>
                            <a href="#"><span class="plnum">321</span></a>条
                        </td>
                    </tr>
                </tbody>
            </table>
            <p class="pltext" align="left">
                评论内容评论内容评论内容评论内容评论内容评论内容</p>
            会员:<span class="plname">l***o</span>
        </div>
        <div class="item">
            <table border="0" cellspacing="0" cellpadding="0" width="180">
                <tbody>
                    <tr>
                        <td width="62">
                            <img src="../static/images/plsp.jpg">
                        </td>
                        <td valign="top" width="118" align="right">
                            <p align="left">
                                <a href="#">商品名称</a></p>
                            <a href="#"><span class="plnum">321</span></a>条
                        </td>
                    </tr>
                </tbody>
            </table>
            <p class="pltext" align="left">
                评论内容评论内容评论内容评论内容评论内容评论内容</p>
            会员:<span class="plname">l***o</span>
        </div>
        <div class="item">
            <table border="0" cellspacing="0" cellpadding="0" width="180">
                <tbody>
                    <tr>
                        <td width="62">
                            <img src="../static/images/plsp.jpg">
                        </td>
                        <td valign="top" width="118" align="right">
                            <p align="left">
                                <a href="#">商品名称</a></p>
                            <a href="#"><span class="plnum">321</span></a>条
                        </td>
                    </tr>
                </tbody>
            </table>
            <p class="pltext" align="left">
                评论内容评论内容评论内容评论内容评论内容评论内容</p>
            会员:<span class="plname">l***o</span>
        </div>
        <div class="item">
            <table border="0" cellspacing="0" cellpadding="0" width="180">
                <tbody>
                    <tr>
                        <td width="62">
                            <img src="../static/images/plsp.jpg">
                        </td>
                        <td valign="top" width="118" align="right">
                            <p align="left">
                                <a href="#">商品名称</a></p>
                            <a href="#"><span class="plnum">321</span></a>条
                        </td>
                    </tr>
                </tbody>
            </table>
            <p class="pltext" align="left">
                评论内容评论内容评论内容评论内容评论内容评论内容</p>
            会员:<span class="plname">l***o</span>
        </div>
        <div class="item">
            <table border="0" cellspacing="0" cellpadding="0" width="180">
                <tbody>
                    <tr>
                        <td width="62">
                            <img src="../static/images/plsp.jpg">
                        </td>
                        <td valign="top" width="118" align="right">
                            <p align="left">
                                <a href="#">商品名称</a></p>
                            <a href="#"><span class="plnum">321</span></a>条
                        </td>
                    </tr>
                </tbody>
            </table>
            <p class="pltext" align="left">
                评论内容评论内容评论内容评论内容评论内容评论内容</p>
            会员:<span class="plname">l***o</span>
        </div>
        <img src="../static/images/yj02.png">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopLeftModuleContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="TopRightMdouleContent" runat="server">
    <!--洋葱导航条-->
    <div class="ycdh">
        <a href="../Default.aspx"><b>首页</b></a></div>
    <!--热卖推荐-->
    <table class="rmtj" border="0" cellspacing="0" cellpadding="0" width="1000">
        <tbody>
            <tr>
                <td valign="top" width="38">
                    <img src="../static/images/rmtj.png">
                </td>
                <td class="list">
                    <ul>
                        <li><a href="#">
                            <p>
                                <img src="../static/images/sp02.jpg"><span class="price">1000元</span></p>
                            <span>商品名称</span></a></li>
                        <li><a href="#">
                            <p>
                                <img src="../static/images/sp02.jpg"><span class="price">1000元</span></p>
                            <span>商品名称</span></a></li>
                        <li><a href="#">
                            <p>
                                <img src="../static/images/sp02.jpg"><span class="price">1000元</span></p>
                            <span>商品名称</span></a></li>
                        <li><a href="#">
                            <p>
                                <img src="../static/images/sp02.jpg"><span class="price">1000元</span></p>
                            <span>商品名称</span></a></li>
                    </ul>
                </td>
            </tr>
        </tbody>
    </table>
    <div class="sxtj">
        <table border="0" cellspacing="0" cellpadding="0" width="792">
            <%=Search1C3Filter%>
        </table>
    </div>
    <!--商品列-->
    <iframe id="ProductIframe" frameborder="0" scrolling="no" width="1001px" height="1200px">
    </iframe>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyContent" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ExtenalContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">

        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) {
                return unescape(r[2]);
            }
            return null;
        }

        $(function () {
            $("body").removeAttr("id").attr({ "id": "class" });
            var keyWords = getQueryString("q");
            var serachDetailBaseURL = "SearchDetail.aspx?c1=";

            $("#filterTable li").each(function (index) {
                $(this).click(function () {

                    var c1 = $(this).children("input").eq(0).val();
                    var c2 = $(this).children("input").eq(1).val();
                    var c3 = $(this).children("input").eq(2).val();
                    var searchDetailURL = serachDetailBaseURL + c1 + "&c2=" + c2 + "&c3=" + c3 + "&q=" + escape(keyWords);
                    window.location.href = searchDetailURL;
                });
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
