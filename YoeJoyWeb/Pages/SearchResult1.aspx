<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResult1.aspx.cs" Inherits="YoeJoyWeb.SearchResult1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link type="text/css" rel="Stylesheet" href="../static/css/layout.css" />
    <link type="text/css" rel="Stylesheet" href="../static/css/layout1020.css" />
    <style type="text/css">
        body
        {
            background: none;
        }
        
        .enableArrow
        {
            display: inline-block;
            cursor: pointer;
            background-image: url('../static/images/hy2.gif');
            background-repeat: no-repeat;
            width: 18px;
            height: 18px;
            margin: 0px 3px;
        }
        .disableArrow
        {
            display: inline-block;
            background-image: url('../static/images/qy1.gif');
            background-repeat: no-repeat;
            width: 18px;
            height: 18px;
            margin: 0px 3px;
        }
        .pagenum
        {
            cursor: pointer;
        }
        #listHeaderLeft li
        {
            cursor: pointer;
        }
        .next1
        {
            cursor: pointer;
        }
    </style>
    <script type="text/javascript" src="../static/js/dev/jquery-1.8.1.js"></script>
</head>
<body>
    <div class="splb">
        <!--排序条件-->
        <div class="pxtjitem">
            <ul id="listHeaderLeft">
                <li class="selected">默认排序<input type="hidden" value="1" /></li>
                <li>价格<input type="hidden" value="2" /></li>
                <li>销量<input type="hidden" value="3" /></li>
                <li>上架时间<input type="hidden" value="4" /></li>
                <li>评价<input type="hidden" value="5" /></li>
            </ul>
            <div id="listHeaderRight">
                <%=C3ProductListHeaderHTML%>
            </div>
        </div>
        <div id="productList" class="list">
        </div>
    </div>
    <%=C3ProductListFooterHTML%>
    <script type="text/javascript">

        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) {
                return unescape(r[2]);
            }
            return null;
        }

        function getProductListItem(callbackHandler) {
            var handerBaseURL = "../Service/GetProductListItem.aspx";
            var c1 = getQueryString("c1");
            var c2 = getQueryString("c2");
            var c3 = getQueryString("c3");
            var currentPageIndex = parseInt($("#currentPageIndex").val());
            var orderOption = $("#listHeaderLeft .selected").children("input").val();
            var attributionIds = getQueryString("attrIds");
            var handlerURL = handerBaseURL + "?c1=" + c1 + "&c2=" + c2 + "&c3=" + c3 + "&startIndex=" + currentPageIndex + "&orderBy=" + orderOption + "&attrIds=" + attributionIds + "&random=" + Math.random();
            $.get(handlerURL, function (data) {
                $("#productList").empty().append(data);
                callbackHandler();
            });
        }

        function locateToPage(pageNum) {
            var pagedSeed = parseInt($("#pagedSeed").val());
            var currentPageIndex = parseInt($("#currentPageIndex").val());
            var seed = parseInt($("#seed").val());
            var stepSeed = Math.abs((pageNum - pagedSeed));
            if (pageNum > pagedSeed) {
                $("#currentPageIndex").val(currentPageIndex + stepSeed * seed);
            }
            else {
                $("#currentPageIndex").val(currentPageIndex - stepSeed * seed);
            }
            getProductListItem(function () {
                $("#pagedSeed").val(pageNum);
                $("#currentPageNum").empty().html(pageNum);
                $("#listFooter .pagenum").removeClass("selected");
                $("#listFooter .pagenum").eq(pageNum - 1).addClass("selected");
                var totalPageCount = parseInt($("#totalPagedCount").val());
                if (pageNum == 1) {
                    $("#prevArrow").removeClass().addClass("disableArrow");
                    $("#nextArrow").removeClass().addClass("enableArrow");
                    $("#nextBtn").removeClass("prev0").addClass("next1");
                    $("#prevBtn").removeClass("next1").addClass("prev0");
                }
                else if (pageNum == totalPageCount) {
                    $("#nextArrow").removeClass().addClass("disableArrow");
                    $("#prevArrow").removeClass().addClass("enableArrow");
                    $("#nextBtn").removeClass("next1").addClass("prev0");
                    $("#prevBtn").removeClass("prev0").addClass("next1");
                }
                else {
                    $("#prevArrow").removeClass().addClass("enableArrow");
                    $("#nextArrow").removeClass().addClass("enableArrow");
                    $("#nextBtn").removeClass("prev0").addClass("next1");
                    $("#prevBtn").removeClass("prev0").addClass("next1");
                }
            });
        }

        $(function () {

            var totalPagedCount = parseInt($("#totalPagedCount").val());
            var seed = parseInt($("#seed").val());

            getProductListItem(function () {
                var pagedSeed = parseInt($("#pagedSeed").val());
                if (pagedSeed == totalPagedCount) {
                    $("#nextArrow").removeClass("enableArrow").addClass("disableArrow");
                }
                $("#listFooter .pagenum").eq(0).addClass("selected");
            });

            $("#prevArrow").click(function () {
                if ($(this).hasClass("disableArrow")) {
                    return;
                }
                else {
                    var currentPageIndex = parseInt($("#currentPageIndex").val());
                    $("#currentPageIndex").val(currentPageIndex - seed);

                    getProductListItem(function () {
                        var pagedSeed = parseInt($("#pagedSeed").val());
                        $("#pagedSeed").val(pagedSeed - 1);
                        pagedSeed -= 1;
                        $("#currentPageNum").empty().html(pagedSeed);
                        $("#listFooter .pagenum").removeClass("selected");
                        $("#listFooter .pagenum").eq(pagedSeed - 1).addClass("selected");
                        if (pagedSeed > 1) {
                            $("#prevArrow").removeClass().addClass("enableArrow");
                            $("#nextArrow").removeClass().addClass("enableArrow");
                            $("#nextBtn").removeClass("prev0").addClass("next1");
                            $("#prevBtn").removeClass("prev0").addClass("next1");
                        }
                        else {
                            $("#prevArrow").removeClass().addClass("disableArrow");
                            $("#nextArrow").removeClass().addClass("enableArrow");
                            $("#nextBtn").removeClass("prev0").addClass("next1");
                            $("#prevBtn").removeClass("next1").addClass("prev0");
                        }
                    });
                }
            });

            $("#nextArrow").click(function () {
                if ($(this).hasClass("disableArrow")) {
                    return;
                }
                else {
                    var currentPageIndex = parseInt($("#currentPageIndex").val());
                    $("#currentPageIndex").val(currentPageIndex + seed);
                    getProductListItem(function () {
                        var pagedSeed = parseInt($("#pagedSeed").val());
                        $("#pagedSeed").val(pagedSeed + 1);
                        pagedSeed += 1;
                        $("#currentPageNum").empty().html(pagedSeed);
                        $("#listFooter .pagenum").removeClass("selected");
                        $("#listFooter .pagenum").eq(pagedSeed - 1).addClass("selected");
                        if (pagedSeed < totalPagedCount) {
                            $("#nextArrow").removeClass().addClass("enableArrow");
                            $("#prevArrow").removeClass().addClass("enableArrow");
                            $("#nextBtn").removeClass("prev0").addClass("next1");
                            $("#prevBtn").removeClass("prev0").addClass("next1");
                        }
                        else {
                            $("#nextArrow").removeClass().addClass("disableArrow");
                            $("#prevArrow").removeClass().addClass("enableArrow");
                            $("#nextBtn").removeClass("next1").addClass("prev0");
                            $("#prevBtn").removeClass("prev0").addClass("next1");
                        }
                    });
                }
            });

            $("#listHeaderLeft li").each(function (index) {
                $(this).click(function () {
                    $(this).siblings("li").removeClass("selected");
                    $(this).addClass("selected");
                    $("#currentPageIndex").val('1');
                    $("#currentPageNum").empty().html('1');
                    getProductListItem(function () {
                        $("#pagedSeed").val('1');
                        $("#listFooter .pagenum").removeClass("selected");
                        $("#listFooter .pagenum").eq(0).addClass("selected");
                        if (totalPagedCount == 1) {
                            $("#prevArrow").removeClass().addClass("disableArrow");
                            $("#nextArrow").removeClass().addClass("disableArrow");
                        }
                        else {
                            $("#prevArrow").removeClass().addClass("disableArrow");
                            $("#nextArrow").removeClass().addClass("enableArrow");
                        }
                    });
                });
            });

            $("#listFooter .pagenum").each(function (index) {
                $(this).click(function () {
                    if ($(this).hasClass("selected")) {
                        return;
                    }
                    else {
                        $(this).siblings(".pagenum").removeClass("selected");
                        $(this).addClass("selected");
                        var pageNum = parseInt($(this).html());
                        var pagedSeed = parseInt($("#pagedSeed").val());
                        if (pageNum == pagedSeed) {
                            return;
                        }
                        else {
                            locateToPage(pageNum);
                        }
                    }
                });
            });

            $("#prevBtn").click(function () {
                if ($(this).hasClass("prev0")) {
                    return;
                } else {
                    $("#prevArrow").click();
                }
            });

            $("#nextBtn").click(function () {
                if ($(this).hasClass("prev0")) {
                    return;
                } else {
                    $("#nextArrow").click();
                }
            });

            $("#btnPageNum").click(function () {
                var pageNumInput = $("#txtPageNum").val();
                var pagedSeed = parseInt($("#pagedSeed").val());
                if (pageNumInput > totalPagedCount || pageNumInput <= 0) {
                    alert("输入值越界");
                }
                else if (pageNumInput == pagedSeed) {
                    return;
                }
                else {
                    locateToPage(parseInt(pageNumInput));
                }
            });

        });

    </script>
</body>
</html>
