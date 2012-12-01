<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="YoeJoyWeb.Default1" %>

<%@ Register Src="Controls/CategoryNavigation.ascx" TagName="CategoryNavigation"
    TagPrefix="uc1" %>
<%@ Register Src="Controls/OnlineStaticAD.ascx" TagName="OnlineStaticAD" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link type="text/css" rel="Stylesheet" href="static/css/head.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftTopModule" runat="server">
    <uc1:CategoryNavigation ID="CategoryNavigation1" runat="server" />
    <uc2:OnlineStaticAD ID="ADBelowNavigation" ADPositionID="2" ADCSSClass="ad" Width="208"
        Height="80" runat="server" />
    <div class="panic">
        <h3>
            <em></em><strong><b>限时抢购</b><span>Panic-Bu ying</span></strong> <i></i>
        </h3>
        <div class="panicContentt">
            <h2>
                <span>剩余 </span>&nbsp;<img alt="钟" src="static/images/time.png" width="15" height="18">
                <b>23</b> <em>小时</em> <b>55</b> <em>分</em> <b>33</b> <em>秒</em>
            </h2>
            <a class="phone" href="#">
                <img alt="商品图片" src="static/images/sp.jpg" width="100" height="100"></a> <a class="word"
                    href="#">商品名称商品名称商品名称商品名称商品名称商品名称商品名称 </a><b class="price">¥1500</b>
            <p class="hr">
            </p>
            <h2>
                <span>剩余</span>
                <img alt="钟" src="static/images/time.png" width="15" height="18">
                <b>23</b> <em>小时</em> <b>55</b> <em>分</em> <b>33</b> <em>秒</em>
            </h2>
            <a class="phone" href="#">
                <img alt="商品图片" src="static/images/sp.jpg" width="100" height="100"></a> <a class="word"
                    href="#">商品名称商品名称商品名称商品名称商品名称商品名称商品名称 </a><b class="price">¥1500</b>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightTopModule" runat="server">
    <div id="count">
        <div id="chart">
            <span>购物车:<b>12</b>件 </span>
            <img alt="购物车" src="static/images/gwcbt0.png" width="39" height="32">
            <a href="process1.html">结算</a>
        </div>
        <div id="chartContent">
            <img alt="背景" src="static/images/gwctop.png" width="374" height="18">
            <div class="shopping">
                <p class="l">
                    <a href="product.html">
                        <img alt="产品" src="static/images/char.jpg" width="30" height="30"></a><a class="goodsName"
                            href="product.html">全脂牛奶全脂牛奶全脂牛奶全脂牛奶</a><b>￥15000.00</b>
                </p>
                <div class="r">
                    <a class="sub" href="javascript:void(0)">-</a>
                    <input class="num" maxlength="3" value="1" type="text">
                    <a class="add" href="javascript:void(0)">+</a>
                    <p>
                        删除</p>
                </div>
            </div>
            <div class="payNow">
                <div class="l">
                    共<b>12</b>件商品
                </div>
                <div class="r">
                    <p>
                        合计：<b>￥1900.9</b></p>
                    <a href="process1.html">
                        <img alt="结算" src="static/images/jsbt.png" width="61" height="25"></a>
                </div>
            </div>
        </div>
    </div>
    <div id="ServiceLine">
        <span>021-64681500&nbsp;(9:30~18:30)</span> <font>9914838&nbsp;(9:30~22:00)</font>
    </div>
    <dl id="notes">
        <dt><a class="adone sel" href="#"><span>公告</span> </a><a class="adtwo" href="#"><span>
            动态</span> </a></dt>
        <dd>
            <p style="display: block;">
                <%=HomeWebBulletinListHTML %>
            </p>
            <p style="display: none;">
                <%=HomeWebBulletinListHTML %>
            </p>
        </dd>
    </dl>
    <uc2:OnlineStaticAD ID="ADBelowNews" ADPositionID="3" ADCSSClass="ad" Width="192"
        Height="106" runat="server" />
    <div class="GroupPurchase">
        <h5 class="mytitles">
            <em></em><strong><b>团购</b><span>Group-Buying</span></strong> <i></i>
        </h5>
        <div class="dd">
            <p class="day">
                <span>6</span> <span>6</span> <b>天</b> <span>6</span> <span>6</span> <b>时</b> <span>
                    6</span> <span>6</span> <b>分</b>
            </p>
            <p class="ad2">
                <a href="#">
                    <img src="static/images/dishes.jpg">
                </a>
            </p>
            <a class="word" href="#">商品名称商品名称商品名称商品名称商品名称商品名称 </a><a class="join" href="#">¥1000.0
            </a>
            <p class="hr">
            </p>
            <p class="day">
                <span>6</span> <span>6</span> <b>天</b> <span>6</span> <span>6</span> <b>时</b> <span>
                    6</span> <span>6</span> <b>分</b>
            </p>
            <p class="ad2">
                <a href="#">
                    <img src="static/images/dishes.jpg">
                </a>
            </p>
            <a class="word" href="#">商品名称商品名称商品名称商品名称商品名称商品名称 </a><a class="join" href="#">¥1000.0
            </a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MiddleTopModule" runat="server">
    <dl id="Search">
        <dt><a href="index.html">首页</a> <a href="grounp.html">团购</a> </dt>
        <dd>
            <p id="HotWord">
                <span>热门搜索:</span> <a href="search.html">ＩＴ数码</a> <a href="search.html">巧克力</a>
                <a href="search.html">进口糖果</a>
            </p>
            <div id="SearchBox">
                <p>
                    <input value="数码产品" type="text">
                    <button>
                    </button>
                </p>
            </div>
        </dd>
    </dl>
    <dl id="focus">
        <dt><a style="display: none;" href="#">
            <img src="static/images/gg1.jpg"></a> <a style="display: none;" href="#">
                <img src="static/images/gg2.jpg"></a> <a style="display: inline-block;" href="#">
                    <img src="static/images/gg3.jpg"></a> <a style="display: none;" href="#">
                        <img src="static/images/gg4.jpg"></a> <a style="display: none;" href="#">
                            <img src="static/images/gg5.jpg"></a> </dt>
        <dd>
            <a style="opacity: 0.5;" href="#">沙漠风暴底价大促开启</a> <a style="opacity: 0.5;" href="#">沙漠风暴底价大促开启</a>
            <a style="opacity: 1;" href="#">沙漠风暴底价大促开</a> <a style="opacity: 0.5;" href="#">沙漠风暴底价大促开</a>
            <a style="opacity: 0.5;" href="#">沙漠风暴底价大促开</a>
        </dd>
    </dl>
    <dl class="Promotions">
        <dt><a class="prom" href="#">
            <img alt="图标" src="static/images/szj.png" width="8" height="8">
            <b>商品促销</b> <span>promotions</span> </a><a class="more" href="#">更多&gt;&gt; </a>
        </dt>
        <dd>
            <ul class="product products">
                <li>
                    <h3>
                        <a href="#">
                            <img alt="产品图片" src="static/images/product.jpg" width="140" height="140"></a></h3>
                    <p>
                        <a href="product.html">商品名称商品名称商品名称商品名称商品名称商品商品名称</a></p>
                    <b>￥1500</b> </li>
                <li>
                    <h3>
                        <a href="#">
                            <img alt="产品图片" src="static/images/product.jpg" width="140" height="140"></a></h3>
                    <p>
                        <a href="product.html">商品名称商品名称商品名称商品名称商品名称商品商品名称</a></p>
                    <b>￥1500</b> </li>
                <li>
                    <h3>
                        <a href="#">
                            <img alt="产品图片" src="static/images/product.jpg" width="140" height="140"></a></h3>
                    <p>
                        <a href="product.html">商品名称商品名称商品名称商品名称商品名称商品商品名称</a></p>
                    <b>￥1500</b> </li>
                <li>
                    <h3>
                        <a href="#">
                            <img alt="产品图片" src="static/images/product.jpg" width="140" height="140"></a></h3>
                    <p>
                        <a href="product.html">商品名称商品名称商品名称商品名称商品名称商品商品名称</a></p>
                    <b>￥1500</b> </li>
            </ul>
        </dd>
    </dl>
    <dl class="Promotions">
        <!--新品上市-->
        <dt><a class="prom" href="#">
            <img alt="图标" src="static/images/szj.png" width="8" height="8">
            <b>商品促销</b> <span>promotions</span> </a><a class="more" href="#">更多&gt;&gt; </a>
        </dt>
        <dd>
            <%=InComingProducts%>
        </dd>
    </dl>
    <div style="margin-top: 7px;" class="band">
        <span>品牌旗舰店</span>
        <%=HomeBrandsHTML %>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SiteNavModule" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="LeftBigModule" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="RightBigModule" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="BackupContent1" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="HomeMiddleContent" runat="server">
    <div id="content">
        <div id="highgoods1" class="area">
            <a class="prev" href="javascript:void(0)"></a>
            <div style="left: 573px;" id="options" class="selectbj">
                <a class="selected" href="javascript:void(0)"></a><a href="javascript:void(0)"></a>
                <a href="javascript:void(0)"></a>
            </div>
            <a class="next" href="javascript:void(0)"></a>
            <div style="width: 3600px;" class="group">
                <div class="item">
                    <img src="static/images/spb3.jpg" width="100" height="100">
                    <ul>
                        <li><a href="products/product.html">
                            <img style="margin-top: 60px;" src="static/images/jp1a.png" width="278" height="265"></a></li>
                        <li><a href="products/product.html">
                            <img style="margin-top: 60px;" src="static/images/jp1a.png" width="278" height="265"></a></li>
                        <li><a href="products/product.html">
                            <img style="margin-top: 60px;" src="static/images/jp1a.png" width="278" height="265"></a></li>
                    </ul>
                </div>
                <div class="item">
                    <img src="static/images/spb3.jpg" width="100">
                    <ul>
                        <li><a href="products/product.html">
                            <img style="margin-top: 60px;" src="static/images/jp1a.png" width="278" height="265"></a></li>
                        <li><a href="products/product.html">
                            <img style="margin-top: 97.5px;" src="static/images/jp1a.png" width="200" height="190"></a></li>
                        <li><a href="products/product.html">
                            <img style="margin-top: 60px;" src="static/images/jp1a.png" width="278" height="265"></a></li>
                    </ul>
                </div>
                <div class="item">
                    <img src="static/images/spb3.jpg" width="100">
                    <ul>
                        <li><a href="products/product.html">
                            <img style="margin-top: 60px;" src="static/images/jp1a.png" width="278" height="265"></a></li>
                        <li><a href="products/product.html">
                            <img style="margin-top: 97.5px;" src="static/images/jp1a.png" width="200" height="190"></a></li>
                        <li><a href="products/product.html">
                            <img style="margin-top: 60px;" src="static/images/jp1a.png" width="278" height="265"></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="highgoods2" class="area">
            <div class="item">
                <div class="slave0">
                    彩绘贴</div>
                <div class="mem0">
                    <img class="prev" src="static/images/hg2prev.png"></div>
                <div class="mem1">
                    <div class="scrollw">
                        <div class="scroll">
                            <div class="photo">
                                <a href="products/product.html">
                                    <img src="static/images/hg2sp0.png"></a></div>
                            <div class="info">
                                <p class="name">
                                    <a href="products/product.html">Gelaskins iPhone 4/4s 艺术彩绘贴</a></p>
                                <p class="price0">
                                    <span class="yen">¥</span>&nbsp;&nbsp;<span class="slave0">148</span></p>
                            </div>
                        </div>
                        <div class="scroll">
                            <div class="photo">
                                <a href="products/product.html">
                                    <img src="static/images/hg2sp0.png"></a></div>
                            <div>
                                <p class="name">
                                    <a href="products/product.html">Gelaskins iPhone 4/4s 艺术彩绘贴</a></p>
                                <p class="price0">
                                    <span class="yen">¥</span>&nbsp;&nbsp;<span class="slave0">148</span></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mem0">
                    <img class="next" src="static/images/hg2next.png"></div>
            </div>
            <div class="item">
                <div class="slave0">
                    彩绘贴</div>
                <div class="mem0">
                    <img class="prev" src="static/images/hg2prev.png"></div>
                <div class="mem1">
                    <div class="scrollw">
                        <div class="scroll">
                            <div class="photo">
                                <a href="products/product.html">
                                    <img src="static/images/hg2sp0.png"></a></div>
                            <div>
                                <p class="name">
                                    <a href="products/product.html">Gelaskins iPhone 4/4s 艺术彩绘贴</a></p>
                                <p class="price0">
                                    <span class="yen">¥</span>&nbsp;&nbsp;<span class="slave0">148</span></p>
                            </div>
                        </div>
                        <div class="scroll">
                            <div class="photo">
                                <a href="products/product.html">
                                    <img src="static/images/hg2sp0.png"></a></div>
                            <div>
                                <p class="name">
                                    <a href="products/product.html">Gelaskins iPhone 4/4s 艺术彩绘贴</a></p>
                                <p class="price0">
                                    <span class="yen">¥</span>&nbsp;&nbsp;<span class="slave0">148</span></p>
                            </div>
                        </div>
                        <div class="scroll">
                            <div class="photo">
                                <a href="products/product.html">
                                    <img src="static/images/hg2sp0.png"></a></div>
                            <div>
                                <p class="name">
                                    <a href="products/product.html">Gelaskins iPhone 4/4s 艺术彩绘贴</a></p>
                                <p class="price0">
                                    <span class="yen">¥</span>&nbsp;&nbsp;<span class="slave0">148</span></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mem0">
                    <img class="next" src="static/images/hg2next.png"></div>
            </div>
            <div class="item">
                <div class="slave0">
                    彩绘贴</div>
                <div class="mem0">
                    <img class="prev" src="static/images/hg2prev.png"></div>
                <div class="mem1">
                    <div class="scrollw">
                        <div class="scroll">
                            <div class="photo">
                                <a href="products/product.html">
                                    <img src="static/images/hg2sp0.png"></a></div>
                            <div>
                                <p class="name">
                                    <a href="products/product.html">Gelaskins iPhone 4/4s 艺术彩绘贴</a></p>
                                <p class="price0">
                                    <span class="yen">¥</span>&nbsp;&nbsp;<span class="slave0">148</span></p>
                            </div>
                        </div>
                        <div class="scroll">
                            <div class="photo">
                                <a href="products/product.html">
                                    <img src="static/images/hg2sp0.png"></a></div>
                            <div>
                                <p class="name">
                                    <a href="products/product.html">Gelaskins iPhone 4/4s 艺术彩绘贴</a></p>
                                <p class="price0">
                                    <span class="yen">¥</span>&nbsp;&nbsp;<span class="slave0">148</span></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mem0">
                    <img class="next" src="static/images/hg2next.png"></div>
            </div>
        </div>
        <div id="centerAdWrapper">
            <uc2:OnlineStaticAD ID="OnlineStaticAD1" ADPositionID="4" ADCSSClass="ad1" runat="server" />
            <uc2:OnlineStaticAD ID="OnlineStaticAD2" ADPositionID="5" ADCSSClass="ad1" runat="server" />
            <div style="clear: left;" />
        </div>
        <div class="ThreeRow">
            <div class="bigLeft">
                <div class="It">
                    <a class="Header" href="#">
                        <img src="static/images/it.png" /></a>
                    <uc2:OnlineStaticAD ID="C1LeftAD1" ADPositionID="6" Width="208" Height="278" ADCSSClass="Header" runat="server" />
                    <p>
                        <a href="#">IT相关导购文</a></p>
                    <p>
                        <a href="#">IT相关导购文</a></p>
                    <p>
                        <a href="#">IT相关导购文</a></p>
                    <p>
                        <a href="#">IT相关导购文</a></p>
                    <p>
                        <a href="#">IT相关导购文</a></p>
                </div>
                <%=CategoryProductsOneHTML%>
            </div>
            <div class="right">
                <div class="brand">
                    <a class="h" href="#">
                        <img src="static/images/brand.gif" width="192" height="40"></a>
                    <%=CategoryProductsBrandsOneHTML%>
                </div>
                <div class="discus">
                    <h2 id="phone1">
                        <span><a href="#">用户评论</a></span> <span><a href="#">销量排行</a></span>
                    </h2>
                    <div id="phoneCon1">
                        <dl style="display: block;" class="discsPhone">
                            <dt>
                                <h2>
                                    <a href="#">
                                        <img alt="商品图片" src="static/images/sp.jpg" width="130" height="130"></a>
                                </h2>
                                <p>
                                    <a href="#">商品名称商品名称商品名称商品名称</a> <span><b>332</b>条</span>
                                </p>
                            </dt>
                            <dd class="hrs">
                                <p>
                                    <img src="static/images/alert.png">评论内容评论内容评论内容评论内容评论内容评论内容</p>
                                <span><em>会员:</em>l***o</span>
                            </dd>
                            <dt>
                                <h2>
                                    <a href="#">
                                        <img alt="商品图片" src="static/images/sp.jpg" width="130" height="130"></a>
                                </h2>
                                <p>
                                    <a href="#">商品名称商品名称商品名称商品名称</a> <span><b>332</b>条</span>
                                </p>
                            </dt>
                            <dd>
                                <p>
                                    <img src="static/images/alert.png">评论内容评论内容评论内容评论内容评论内容评论内容</p>
                                <span><em>会员:</em>l***o</span>
                            </dd>
                        </dl>
                        <dl style="display: none;" class="discusSell">
                            <dd>
                                <span>1</span> <b>
                                    <img src="static/images/fire.jpg"></b> <a href="#">商品名称商品名称商称商称 <em>¥238.5</em>
                                </a>
                            </dd>
                            <dd>
                                <span>2</span> <b>
                                    <img src="static/images/fire.jpg"></b> <a href="#">商品名称商品名称商称商称 <em>¥238.5</em>
                                </a>
                            </dd>
                            <dd>
                                <span>3</span> <b>
                                    <img src="static/images/fire.jpg"></b> <a href="#">商品名称商品名称商称商称 <em>¥238.5</em>
                                </a>
                            </dd>
                            <dd class="last">
                                <span>4</span> <b>
                                    <img src="static/images/fire.jpg"></b> <a href="#">商品名称商品名称商称商称 <em>¥238.5</em>
                                </a>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>
        </div>
        <div style="margin-top: 10px;" class="ThreeRow">
            <div class="bigLeft">
                <div class="It">
                    <a class="Header" href="#">
                        <img src="static/images/home.png"></a> 
                        <uc2:OnlineStaticAD ID="C1LeftAD2" ADPositionID="7" ADCSSClass="Header" Width="208" Height="278" runat="server" />
                    <p>
                        <a href="#">IT相关导购文</a></p>
                    <p>
                        <a href="#">IT相关导购文</a></p>
                    <p>
                        <a href="#">IT相关导购文</a></p>
                    <p>
                        <a href="#">IT相关导购文</a></p>
                    <p>
                        <a href="#">IT相关导购文</a></p>
                </div>
                <%=CategoryProductsTwoHTML%>
            </div>
            <div class="right">
                <div class="brand">
                    <a class="h" href="#">
                        <img src="static/images/brand.gif"></a>
                    <%=CategoryProductsBrandsTwoHTML%>
                </div>
                <div class="discus">
                    <h2 id="phone2">
                        <span><a href="#">用户评论</a></span> <span><a href="#">销量排行</a></span>
                    </h2>
                    <div id="phoneCon2">
                        <dl style="display: block;" class="discsPhone">
                            <dt>
                                <h2>
                                    <a href="#">
                                        <img alt="商品图片" src="static/images/sp.jpg" width="130" height="130"></a>
                                </h2>
                                <p>
                                    <a href="#">商品名称商品名称商品名称商品名称</a> <span><b>332</b>条</span>
                                </p>
                            </dt>
                            <dd class="hrs">
                                <p>
                                    <img src="static/images/alert.png">评论内容评论内容评论内容评论内容评论内容评论内容</p>
                                <span><em>会员:</em>l***o</span>
                            </dd>
                            <dt>
                                <h2>
                                    <a href="#">
                                        <img alt="商品图片" src="static/images/sp.jpg" width="130" height="130"></a>
                                </h2>
                                <p>
                                    <a href="#">商品名称商品名称商品名称商品名称</a> <span><b>332</b>条</span>
                                </p>
                            </dt>
                            <dd>
                                <p>
                                    <img src="static/images/alert.png">评论内容评论内容评论内容评论内容评论内容评论内容</p>
                                <span><em>会员:</em>l***o</span>
                            </dd>
                        </dl>
                        <dl style="display: none;" class="discusSell">
                            <dd>
                                <span>1</span> <b>
                                    <img src="static/images/fire.jpg"></b> <a href="#">商品名称商品名称商称商称 <em>¥238.5</em>
                                </a>
                            </dd>
                            <dd>
                                <span>1</span> <b>
                                    <img src="static/images/fire.jpg"></b> <a href="#">商品名称商品名称商称商称 <em>¥238.5</em>
                                </a>
                            </dd>
                            <dd>
                                <span>1</span> <b>
                                    <img src="static/images/fire.jpg"></b> <a href="#">商品名称商品名称商称商称 <em>¥238.5</em>
                                </a>
                            </dd>
                            <dd class="last">
                                <span>1</span> <b>
                                    <img src="static/images/fire.jpg"></b> <a href="#">商品名称商品名称商称商称 <em>¥238.5</em>
                                </a>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="BackupContent2" runat="server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(function () {

        });
    </script>
</asp:Content>
