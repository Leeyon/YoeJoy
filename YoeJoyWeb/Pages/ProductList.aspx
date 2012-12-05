<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="YoeJoyWeb.ProductList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link type="text/css" rel="Stylesheet" href="../static/css/layout.css" />
    <link type="text/css" rel="Stylesheet" href="../static/css/class.css" />
    <script type="text/javascript" src="../static/js/dev/YoeJoy.Namespace.js"></script>
    <script type="text/javascript" src="../static/js/dev/jquery-1.8.1.js"></script>
    <script type="text/javascript" src="../static/js/dev/jquery.js"></script>
    <script type="text/javascript" src="../static/js/dev/usercustom.js"></script>
    <script type="text/javascript" src="../static/js/dev/Yoejoy.Site.js"></script>
</head>
<body>
    <div id="showList">
        <!--排序条件Begin-->
        <div class="sort">
            <div class="item0">
                <div>
                    <span>排序：</span>
                    <select id="orderSelect">
                        <option value="1">价格从低到高</option>
                        <option value="2">价格从高到低</option>
                        <option value="3">销量从高到低</option>
                        <option value="4">评论从高到低</option>
                        <option selected="selected" value="0">默认排序</option>
                    </select>
                </div>
                <ul id="orderBy">
                    <li><a href="javascript:void(0)">销量</a><input type="hidden" value="3" /></li>
                    <li><a href="javascript:void(0)">价格</a><input type="hidden" value="2" /></li>
                    <li><a href="javascript:void(0)">评论</a><input type="hidden" value="5" /></li>
                    <li><a href="javascript:void(0)">上架时间</a><input type="hidden" value="4" /></li>
                </ul>
            </div>
            <div class="item1">
            </div>
        </div>
        <!--排序条件End-->
        <!--显示商品列表Begin-->
        <div id="productList" class="list">
        </div>
    </div>
    <!--商品列表页码-->
    <%=C3ProductListFooterHTML %>
    <script type="text/javascript">

        var c1 = YoeJoy.Site.Utility.GetQueryString("c1");
        var c2 = YoeJoy.Site.Utility.GetQueryString("c2");
        var c3 = YoeJoy.Site.Utility.GetQueryString("c3");
        var attrIds = YoeJoy.Site.Utility.GetQueryString("attrIds");
        //分页起始标识
        var startIndex = 1;
        //总页数
        var totalPageCount = parseInt($("#totalPageCount").val());
        //当前页码标识
        var currentPageIndex = 1;
        var handlerBaseURL = "../Service/GetProductListItem.aspx";
        var order = "DESC";
        var orderOption = 1;
        var pageSeed = parseInt($("#pageSeed").val());

        function getProductListItem(callbackHandler) {
            //Use random number in query string to avoid the Ajax get handler browser cache
            var handlerURL = handlerBaseURL + "?c1=" + c1 + "&c2=" + c2 + "&c3=" + c3 + "&startIndex=" + startIndex + "&orderBy=" + orderOption + "&attrIds=" + attrIds + "&order=" + order + "&random=" + Math.random();
            //var handlerURL = handerBaseURL + "?c1=" + c1 + "&c2=" + c2 + "&c3=" + c3 + "&startIndex=" + currentPageIndex + "&orderBy=" + orderOption + "&attrIds=" + attributionIds;
            $.get(handlerURL, function (data) {
                $("#productList").empty().append(data);
                callbackHandler();
            });
        };


        function locateToPage(pageNum) {
            var stepSeed = Math.abs((pageNum - currentPageIndex));
            if (pageNum > currentPageIndex) {
                currentPageIndex = currentPageIndex + stepSeed
                startIndex = startIndex + stepSeed * pageSeed;
            }
            else {
                currentPageIndex = currentPageIndex - stepSeed
                startIndex = startIndex - stepSeed * pageSeed;
            }
            getProductListItem(function () {
                pageNum--;
                $("#pageNumNav").children("a").removeClass("current");
                $("#pageNumNav").children("a").eq(pageNum).addClass("current");
            });
        };

        function changeOrderByList(orderTag) {
            orderTag = parseInt(orderTag);
            startIndex = 1;
            $("#orderBy").children("li").removeClass("selected");
            currentPageIndex = 1;
            if (orderTag == 0) {
                order = "DESC";
                orderOption = 1;
            }
            else if (orderTag == 1) {
                order = "ASC";
                orderOption = 2;
                $("#orderBy").children("li").eq(1).addClass("selected");
            }
            else if (orderTag == 2) {
                order = "DESC";
                orderOption = 2;
                $("#orderBy").children("li").eq(1).addClass("selected");
            }
            else if (orderTag == 3) {
                order = "DESC";
                orderOption = 3;
                $("#orderBy").children("li").eq(0).addClass("selected");
            }
            else if (orderTag == 4) {
                order = "DESC";
                orderOption = 4;
                $("#orderBy").children("li").eq(2).addClass("selected");
            }
            getProductListItem(function () {
                $("#pageNumNav").children("a").eq(0).addClass("current");
            });
        };

        function changeOrderByTab(orderTag) {
            orderTag = parseInt(orderTag);
            startIndex = 1;
            $("#orderSelect").children("option[selected='selected']").removeAttr("selected");
            currentPageIndex = 1;
            if (orderTag == 0) {
                order = "DESC";
                orderOption = 3;
            }
            else if (orderTag == 1) {
                order = "ASC";
                orderOption = 2;
                $("#orderBy").children("li").eq(1).addClass("selected");
            }
            else if (orderTag == 2) {
                order = "DESC";
                orderOption = 4;
                $("#orderBy").children("li").eq(1).addClass("selected");
            }
            else if (orderTag == 5) {
                return;
            }
            getProductListItem(function () {
                $("#pageNumNav").children("a").eq(0).addClass("current");
            });
        };

        $(function () {

            getProductListItem(function () {
                $("#pageNumNav").children("a").eq(0).addClass("current");
            });

            $("#prev").click(function () {
                if (currentPageIndex > 1) {
                    locateToPage(currentPageIndex - 1);
                }
            });

            $("#next").click(function () {
                if (currentPageIndex < totalPageCount) {
                    locateToPage(currentPageIndex + 1);
                }
            });

            $("#pageNumNav").children("a").each(function (index) {
                $(this).click(function (event) {
                    locateToPage(index + 1);
                });
            });

            $("#btnLocate").click(function () {
                var pageNumInput = parseInt($("#txtIndex").val());
                if (pageNumInput == '') {
                    return;
                }
                else {
                    if (pageNumInput > totalPageCount || pageNumInput <= 0) {
                        alert("输入值越界");
                    }
                    else if (pageNumInput == currentPageIndex) {
                        return;
                    }
                    else {
                        locateToPage(pageNumInput);
                    }
                }
            });

            $("#orderSelect").change(function (event) {
                var $option = $(this);
                var optionValue = $option.val();
                changeOrderByList(optionValue);
            });

            $("#orderBy").children("li").each(function (index) {
                $(this).click(function (event) {
                    $("#orderBy").children("li").removeClass("selected");
                    $(this).addClass("selected");
                    changeOrderByTab(index);
                });
            });

        });

    </script>
</body>
</html>
