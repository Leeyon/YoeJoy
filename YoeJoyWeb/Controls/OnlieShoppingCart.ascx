<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OnlieShoppingCart.ascx.cs"
    Inherits="YoeJoyWeb.Controls.OnlieShoppingCart" %>
<div id="count">
    <div id="chart">
        <span>购物车:<b><a href="<%=SiteBaseURL %>Shopping/ShoppingCart.aspx">0</a></b> 件
        </span>
        <img alt="购物车" src="../static/images/gwcbt0.png" width="39" height="32" />
        <a href="<%=SiteBaseURL %>Shopping/ShoppingCart.aspx">结算</a>
    </div>
    <div id="chartContent">
        <img alt="背景" src="../static/images/gwctop.png" width="374" height="18" />
        <div id="myShoppingCart" class="shopping">
            <%=OnlieShoppingCartHTML%>
        </div>
        <div class="payNow">
            <div class="l">
                共<b><a href="<%=SiteBaseURL %>Shopping/ShoppingCart.aspx">0</a></b>件商品
            </div>
            <div class="r">
                <p>
                    合计：<b>￥0</b></p>
                <a href="<%=SiteBaseURL %>Shopping/ShoppingCart.aspx">
                    <img alt="结算" src="../static/images/jsbt.png" width="61" height="25" /></a>
            </div>
        </div>
    </div>
</div>
