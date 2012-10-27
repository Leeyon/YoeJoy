<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="Product.aspx.cs" Inherits="YoeJoyWeb.Product" %>

<%@ Register Src="../Controls/SubCategoryNavigation.ascx" TagName="SubCategoryNavigation"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/CategoryNavigation.ascx" TagName="CategoryNavigation"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationModuleContent" runat="server">
    <uc2:CategoryNavigation ID="CategoryNavigation1" runat="server" />
    <uc1:SubCategoryNavigation ID="SubCategoryNavigation1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanicBuyingMdouleContent" runat="server">
    <div id="zjll" class="l_class area">
        <img src="../static/images/zjll.png">
        <ul>
            <li><a href="#">
                <img src="../static/images/sp.jpg"><p>
                    飞利浦（Philips） HD3038/05 电脑型电饭煲 5L</p>
            </a><span>¥88.8</span></li>
            <li><a href="#">
                <img src="../static/images/sp.jpg"><p>
                    飞利浦（Philips） HD3038/05 电脑型电饭煲 5L</p>
            </a><span>¥88.8</span></li>
        </ul>
        <img src="../static/images/yjd.png"/>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopLeftModuleContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="TopRightMdouleContent" runat="server">
    <div class="spgm">
        <!--商品照片展示开始-->
        <div class="zpzs">
            <div class="dzp">
                <img src="../static/images/spb4.jpg" /></div>
            <div style="left: 323px; top: 152px; display: block;" class="fdj">
                <img src="../static/images/fangdajing.png" /></div>
            <div class="xzp">
                <table border="0" cellspacing="0" cellpadding="0" height="55">
                    <tbody>
                        <tr>
                            <td class="prev0" width="17">
                                <a href="#">
                                    <img src="../static/images/zpprev0.png"></a>
                            </td>
                            <td width="296">
                                <%=ProductDetailImagesHTML%>
                            </td>
                            <td class="next1" width="17">
                                <a href="#">
                                    <img src="../static/images/zpnext1.png"></a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div style='background: url("../static/images/spb4.jpg") no-repeat 0px -284px rgb(255, 255, 255);
            display: none;' class="fdck">
        </div>
        <!--商品购买信息区-->
        <div class="gmxx">
            <h1>
                科奈信(cannice)蓝牙耳机 iblue2（黑）</h1>
            <h5>
                商品编号:56672</h5>
            <p>
                攸怡评论:共<a href="#">30</a>条</p>
            <h5>
                市场价:¥<span class="yprice">150</span></h5>
            <p>
                攸怡价:¥<span class="yyj">108</span></p>
            <p>
                库存状况:有货</p>
            <p>
                送至:<select><option>上海</option>
                    <option>北京</option>
                    <option>天津</option>
                </select></p>
            <div class="gmtj">
                <p class="spzl">
                    颜色:<label class="selected">黑色</label><label>白色</label></p>
                <p class="spsl">
                    我要:<a class="sub" href="javascript:void(0)"><img src="../static/images/sub.png"></a><input
                        class="num" maxlength="3" value="1" type="text"><a class="add" href="javascript:void(0)"><img
                            src="../static/images/add.png"></a>个</p>
                <a href="../useradmin/cart.html">
                    <img src="../static/images/gmbt.png"></a><a class="gwcbt" href="javascript:void(0);"><img
                        src="../static/images/gwcbt.png"></a>
            </div>
        </div>
    </div>
    <div id="tltj" class="area">
        <p class="title">
            浏览过该商品的用户还看过</p>
        <ul class="list">
            <li><a href="products/product.html">
                <p>
                    <img class="photo" src="../static/images/sp02.jpg"></p>
                <div>
                    <span>商品名称商品名称商品名称商品名称商品名称商品商品名称</span></div>
            </a><span class="price">¥1500</span> </li>
            <li><a href="products/product.html">
                <p>
                    <img class="photo" src="../static/images/sp02.jpg"></p>
                <div>
                    <span>商品名称商品名称商品名称商品名称商品名称商品商品名称</span></div>
            </a><span class="price">¥1500</span> </li>
            <li><a href="products/product.html">
                <p>
                    <img class="photo" src="../static/images/sp02.jpg"></p>
                <div>
                    <span>商品名称商品名称商品名称商品名称商品名称商品商品名称</span></div>
            </a><span class="price">¥1500</span> </li>
            <li><a href="products/product.html">
                <p>
                    <img class="photo" src="../static/images/sp02.jpg"></p>
                <div>
                    <span>商品名称商品名称商品名称商品名称商品名称商品商品名称</span></div>
            </a><span class="price">¥1500</span> </li>
            <li><a href="products/product.html">
                <p>
                    <img class="photo" src="../static/images/sp02.jpg"></p>
                <div>
                    <span>商品名称商品名称商品名称商品名称商品名称商品商品名称</span></div>
            </a><span class="price">¥1500</span> </li>
        </ul>
    </div>
    <ul class="spzhcd">
        <li class="selected">商品介绍</li>
        <li>规格参数</li>
        <li>包装清单</li>
        <li>商品评价</li>
    </ul>
    <div class="spzh">
        <!--商品介绍Begin-->
        <div style="display: block;">
            商品介绍</div>
        <!--商品介绍End-->
        <!--规格参数Begin-->
        <div style="display: none;">
            规格参数</div>
        <!--规格参数End-->
        <!--包装清单Begin-->
        <div style="display: none;">
            包装清单</div>
        <!--包装清单End-->
        <!--商品评价Begin-->
        <div style="display: none;" class="sppj">
            <table cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <td class="hyxx" width="100" align="center">
                            <img src="../static/images/tx01.jpg"><p>
                                李白</p>
                            <span>(西安)<br>
                                购买日期<br>
                                0210-08-04</span>
                        </td>
                        <td valign="top" width="819">
                            <table class="item0" cellspacing="0" cellpadding="0" width="818" height="40">
                                <tbody>
                                    <tr>
                                        <td width="43">
                                            <img src="../static/images/pljt.png">
                                        </td>
                                        <td class="member" width="592">
                                            <a href="#">商品名称</a>
                                        </td>
                                        <td class="member" width="160" align="right">
                                            评论日期:0210-08-06 18:26
                                        </td>
                                        <td width="23">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="item1" cellspacing="0" cellpadding="0" width="800" height="76">
                                <tbody>
                                    <tr>
                                        <td width="25">
                                        </td>
                                        <td valign="top" width="678">
                                            差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评啊啊啊啊啊啊啊啊啊啊啊啊啊
                                        </td>
                                        <td valign="top" align="right">
                                            <a href="#">
                                                <img src="../static/images/hfbt.jpg"></a>
                                        </td>
                                        <td width="23">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <td class="hyxx" width="100" align="center">
                            <img src="../static/images/tx01.jpg"><p>
                                李白</p>
                            <span>(西安)<br>
                                购买日期<br>
                                0210-08-04</span>
                        </td>
                        <td valign="top" width="819">
                            <table class="item0" cellspacing="0" cellpadding="0" width="818" height="40">
                                <tbody>
                                    <tr>
                                        <td width="43">
                                            <img src="../static/images/pljt.png">
                                        </td>
                                        <td class="member" width="592">
                                            <a href="#">商品名称</a>
                                        </td>
                                        <td class="member" width="160" align="right">
                                            评论日期:0210-08-06 18:26
                                        </td>
                                        <td width="23">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="item1" cellspacing="0" cellpadding="0" width="800" height="76">
                                <tbody>
                                    <tr>
                                        <td width="25">
                                        </td>
                                        <td valign="top" width="678">
                                            差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评啊啊啊啊啊啊啊啊啊啊啊啊啊
                                        </td>
                                        <td valign="top" align="right">
                                            <a href="#">
                                                <img src="../static/images/hfbt.jpg"></a>
                                        </td>
                                        <td width="23">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <td class="hyxx" width="100" align="center">
                            <img src="../static/images/tx01.jpg"><p>
                                李白</p>
                            <span>(西安)<br>
                                购买日期<br>
                                0210-08-04</span>
                        </td>
                        <td valign="top" width="819">
                            <table class="item0" cellspacing="0" cellpadding="0" width="818" height="40">
                                <tbody>
                                    <tr>
                                        <td width="43">
                                            <img src="../static/images/pljt.png">
                                        </td>
                                        <td class="member" width="592">
                                            <a href="#">商品名称</a>
                                        </td>
                                        <td class="member" width="160" align="right">
                                            评论日期:0210-08-06 18:26
                                        </td>
                                        <td width="23">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="item1" cellspacing="0" cellpadding="0" width="800" height="76">
                                <tbody>
                                    <tr>
                                        <td width="25">
                                        </td>
                                        <td valign="top" width="678">
                                            差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评差评啊啊啊啊啊啊啊啊啊啊啊啊啊
                                        </td>
                                        <td valign="top" align="right">
                                            <a href="#">
                                                <img src="../static/images/hfbt.jpg"></a>
                                        </td>
                                        <td width="23">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <!--商品评价End-->
    </div>
    <!--购物车确认窗口Begin-->
    <div id="cartCheck">
        <div class="title0">
            <table width="100%" height="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="50%" valign="middle">
                        1件商品加入购物车
                    </td>
                    <td width="50%" align="right">
                        <a href="javascript:void(0)" class="close0">
                            <img src="../static/images/close.png" /></a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="group0">
            <div class="item0">
                <img src="../static/images/sp.jpg" /></div>
            <div class="item1">
                <div class="member0">
                    <h1>
                        顶级音乐大屏智能手机！Motorola 摩托罗拉 XT550交响黑 WCDMA</h1>
                    <p>
                        加入数量：<span>1</span></p>
                    <p>
                        总计金额：<span>&yen;5298</span></p>
                </div>
                <div class="member1">
                    <a href="javascript:void(0)" class="close0">
                        <img src="../static/images/jxgwbt.jpg" /></a>&nbsp;&nbsp;<a href="../useradmin/cart.html"><img
                            src="../static/images/qjsbt.jpg" /></a></div>
            </div>
        </div>
        <!--购买了此商品的用户还买了Begin-->
        <div class="group1">
            <h1>
                购买了此商品的用户还买了：</h1>
            <div class="item0">
                <div class="member0 dot">
                    <span class="selected"></span><span></span>
                </div>
                <div class="prev">
                    <a href="javascript:void(0);"></a>
                </div>
                <div class="member1 hxzsc">
                    <ul>
                        <li><a href="#">
                            <img src="../static/images/sp.jpg" width="118" /><p>
                                Kingston 金士顿 8G class4 TF</p>
                        </a><span>&yen;100.0</span></li>
                        <li><a href="#">
                            <img src="../static/images/sp.jpg" width="118" /><p>
                                Kingston 金士顿 8G class4 TF</p>
                        </a><span>&yen;100.0</span></li>
                        <li><a href="#">
                            <img src="../static/images/sp.jpg" width="118" /><p>
                                Kingston 金士顿 8G class4 TF</p>
                        </a><span>&yen;100.0</span></li>
                        <li><a href="#">
                            <img src="../static/images/sp.jpg" width="118" /><p>
                                Kingston 金士顿 8G class4 TF</p>
                        </a><span>&yen;100.0</span></li>
                        <li><a href="#">
                            <img src="../static/images/sp.jpg" width="118" /><p>
                                Kingston 金士顿 8G class4 TF</p>
                        </a><span>&yen;100.0</span></li>
                        <li><a href="#">
                            <img src="../static/images/sp.jpg" width="118" /><p>
                                Kingston 金士顿 8G class4 TF</p>
                        </a><span>&yen;100.0</span></li>
                    </ul>
                </div>
                <div class="next">
                    <a href="javascript:void(0);"></a>
                </div>
            </div>
        </div>
        <!--购买了此商品的用户还买了End-->
    </div>
    <!--购物车确认窗口End-->
    <!--页脚-->
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyContent" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ExtenalContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">

        $(function () {
            $("body").removeAttr("id").attr({ "id": "class" });
        });

    </script>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
