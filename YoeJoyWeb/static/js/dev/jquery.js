$(document).ready(function () {
    focues();
    notes();
    chart();
    sorts();
    seachBox();
    pro();
    auLabel();
    processChart();
    MyYoyi();
    addNewAdress();
    Meun2();
    onlineComplain();
    History();
    ToLook();
    adItemShow();
});

//横向滚动组件
var scrollItem = function (obj, cLen, cWidth) {
    var prev = obj.find('.scrollItem .prev a');
    var next = obj.find('.scrollItem .next a');
    var showItem = obj.find('.scrollItem ul');
    var column = obj.find('.scrollItem ul li');
    var dot = obj.find('.dot');
    var len = column.length;
    var itemNum = Math.ceil(len / cLen);
    var width = column.outerWidth();
    var itemWidth = itemNum * cWidth;
    showItem.css('width', itemWidth);
    for (var i = 0; i < itemNum; i++) {
        dot.append("<a href='javascript:'></a>");
    }
    dot.children('a').eq(0).addClass('selected');
    if (len > (cLen - 1)) {
        next.show();
    }
    var cDot = dot.children('a');
    cDot.click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var _index = $(this).index();
        var _left = -_index * cWidth;
        if (_index == 0) { prev.hide(); next.show(); }
        if (_index == itemNum - 1) { next.hide(); prev.show(); }
        showItem.animate({ 'left': _left });
    });
    next.click(function () {
        var _index = dot.children('.selected').index();
        var _left = showItem.position().left;
        if (_left == cWidth * 2 - itemWidth) {
            $(this).hide();
        }
        prev.show();
        cDot.eq(_index + 1).addClass('selected').siblings().removeClass('selected');
        showItem.animate({ 'left': _left - cWidth });
    });
    prev.click(function () {
        var _index = dot.children('.selected').index();
        var _left = showItem.position().left;
        if (_left == -cWidth) {
            $(this).hide();
        }
        next.show();
        cDot.eq(_index - 1).addClass('selected').siblings().removeClass('selected');
        showItem.animate({ 'left': _left + cWidth });
    });
}
//大类页主广告滚动脚本
function adItemShow() {
    var bt = $('#adShow .btItem a');
    $('#adShow a:eq(0)').show();
    bt.eq(0).addClass('selected');
    var adSetRoll = setInterval(adRoll, 3000);
    bt.click(function () {
        var _index = $(this).index();
        $(this).addClass('selected').siblings().removeClass('selected');
        $('#adShow a').eq(_index).addClass('show').siblings('#adShow a').removeClass('show');
    });
    $('#adShow').hover(function () { clearInterval(adSetRoll); }, function () { adSetRoll = setInterval(adRoll, 3000); });
    function adRoll() {
        var _index = $('#adShow .show').index();
        if (_index < 2) {
            $('#adShow a').eq(_index + 1).addClass('show').siblings('#adShow a').removeClass('show');
            bt.eq(_index + 1).addClass('selected').siblings().removeClass('selected');
        }
        else {
            $('#adShow a').eq(0).addClass('show').siblings('#adShow a').removeClass('show');
            bt.eq(0).addClass('selected').siblings().removeClass('selected');
        }
    }
}

function ToLook() {
    var ToLook = $('.ToLook');
    ToLook.hover(function () {
        $(this).addClass('selected');
    }, function () {
        $(this).removeClass('selected');
    });
}

function History() {
    var pros = $('#pros');
    var nexts = $('#nexts');
    var NumTitle = $('#NumTitle a');
    var Content = $('.focusContent');
    var Content_i = $('.focusContent i');

    var num = 0;

    var set = window.setInterval(auto, 2000);

    pros.hover(function () { window.clearInterval(set); }, function () { set = window.setInterval(auto, 2000); });
    nexts.hover(function () { window.clearInterval(set); }, function () { set = window.setInterval(auto, 2000); });

    function auto() {
        num < Content_i.length - 1 ? num++ : num = 0;
        Content_i.eq(num).show().siblings().hide();
        NumTitle.eq(num).addClass('sel').siblings().removeClass('sel');
    }

    pros.click(function () {
        Content.animate('slow', function () {
            Content.find('i:first').insertAfter(Content.find('i:last'));
        });

        return false;
    });

    nexts.click(function () {
        Content.animate('slow', function () {
            Content.find('i:last').insertBefore(Content.find('i:first'));
        });
        return false;
    });

}

function onlineComplain() {
    var th = $('#onLineComplain th');
    var one = $('.one1');
    var two = $('.two1');
    var address = $('.addNewAddress');
    var NewAddressContent = $('.NewAddressContent');


    address.click(function () {
        NewAddressContent.css('display', 'block');
    });

    th.click(function () {
        var i = th.index(this);
        th.removeClass('sel');
        $(this).addClass('sel');
        if (i == 0) {
            one.show();
            two.hide();
        }
        else if (i == 1) {
            two.show();
            one.hide();
        }

    });
}

function addNewAdress() {
    var model = $('.model');
    var save = $('.save');
    var save1 = $('.save1');
    var modify = $('.modify');
    var choiced = $('.choiced');
    var ex = $('.useCheck .ex');
    var NewAdressContent = $('#NewAdressContent');
    var myNowAddress = $('.myNowAddress');
    var addNewAddr = $('.addNewAdress');
    var invoiceFill = $('#invoiceFill');

    addNewAddr.click(function () {
        NewAdressContent.css('display', 'block');

    });
    ex.click(function () {
        var _text = $(this).text();
        if (_text == "+") {
            $('.sale').show();
            $(this).text('-');
        } else {
            $('.sale').hide();
            $(this).text('+');
        }
    });

    modify.eq(0).click(function () {
        NewAdressContent.css('display', 'block');
    });
    modify.eq(1).click(function () {
        model.eq(0).css('display', 'block');
    });

    modify.eq(2).click(function () {
        model.eq(1).css('display', 'block');
    });
    modify.eq(3).click(function () {
        NewAdressContent.css('display', 'block');
    });
    modify.eq(4).click(function () {
        model.eq(3).css('display', 'block');
    });


    save.eq(0).click(function () {
        NewAdressContent.css('display', 'none');
        myNowAddress.css('display', 'block');
        model.eq(0).css('display', 'block');
        addNewAddr.css('display', 'none');
    });

    save.eq(1).click(function () {
        model.eq(0).css('display', 'none');
        model.eq(1).css('display', 'block');
        choiced.eq(0).css('display', 'block');
    });
    save.eq(2).click(function () {
        model.eq(1).css('display', 'none');
        model.eq(2).css('display', 'block')
        choiced.eq(1).css('display', 'block');

    });
    save.eq(3).click(function () {
        model.eq(2).css('display', 'none');
        model.eq(3).css('display', 'block');
        choiced.eq(2).css('display', 'block');

    });

    save1.click(function () {
        invoiceFill.css('display', 'none');
    });

}

function MyYoyi() {
    var MyYoyi = $('#MyYoyi');
    var MyYoyis = $('.MyYoyi');
    var newFocus = $('#newFocus');
    MyYoyi.hover(function () {
        MyYoyis.addClass('MyYoyis');
        MyYoyis.find('em').css('display', 'block');
    }, function () {
        MyYoyis.removeClass('MyYoyis');
        MyYoyis.find('em').css('display', 'none');
    });
}

function processChart() {
    var mycart = $('#Mycart');
    var chartContent = $('#chartContent');
    mycart.hover(function () {
        chartContent.css('display', 'block');
    }, function () {
        chartContent.css('display', 'none');
    });
}

function auLabel() {
    var num = 0;
    var num2 = 0;
    var timeout = 2000;
    var phone1 = $('#phone1 a');
    var phonecon1 = $('#phoneCon1 dl');

    var phone2 = $('#phone2 a');
    var phonecon2 = $('#phoneCon2 dl');
    var set = window.setInterval(au, timeout);

    phone1.eq(0).addClass('sel');
    phone2.eq(0).addClass('sel');
    phonecon1.hide();
    phonecon2.hide();

    phonecon1.eq(0).show()
    phonecon2.eq(0).show()

    function au() {
        num < phone1.length - 1 ? num++ : num = 0;
        num2 < phone2.length - 1 ? num2++ : num2 = 0;
        phone1.removeClass('sel');
        phone2.removeClass('sel');
        phone1.eq(num).addClass('sel').siblings().removeClass('sel');
        phone2.eq(num2).addClass('sel').siblings().removeClass('sel');
        phonecon1.eq(num).show().siblings().hide();
        phonecon2.eq(num2).show().siblings().hide();
    }

    phone1.hover(function () {
        window.clearInterval(set);
        var i = phone1.index(this);
        phone1.removeClass('sel');
        phone1.eq(i).addClass('sel').siblings().removeClass('sel');
        phonecon1.eq(i).show().siblings().hide();
    }, function () {
        set = window.setInterval(au, timeout);
    });

    phone2.hover(function () {
        window.clearInterval(set);
        var i = phone2.index(this);
        phone2.removeClass('sel');
        phone2.eq(i).addClass('sel').siblings().removeClass('sel');
        phonecon2.eq(i).show().siblings().hide();
    }, function () {
        set = window.setInterval(au, timeout);
    });

    phonecon1.hover(function () {
        window.clearInterval(set);
    }, function () {
        set = window.setInterval(au, timeout);
    });
    phonecon2.hover(function () {
        window.clearInterval(set);
    }, function () {
        set = window.setInterval(au, timeout);
    });
}

function pro() {

    var $sort1 = $("#content").children(".ThreeRow").eq(0).children(".bigLeft").children(".sort").children("ul[class='sortHeader']");
    var $sort2 = $("#content").children(".ThreeRow").eq(1).children(".bigLeft").children(".sort").children("ul[class='sortHeader']");

    $sort1.attr({ "id": "sort1" });
    $sort2.attr({ "id": "sort2" });

    $sort1.children("li").eq(0).children("a").eq(0).attr({ "class": "sel" });
    $sort2.children("li").eq(0).children("a").eq(0).attr({ "class": "sel" });

    var $list1 = $("#content").children(".ThreeRow").eq(0).children(".bigLeft").children(".sort").children("div[class='main']");
    var $list2 = $("#content").children(".ThreeRow").eq(1).children(".bigLeft").children(".sort").children("div[class='main']");

    $list1.children("div").eq(0).siblings("div").css({ "display": "none" });
    $list2.children("div").eq(0).siblings("div").css({ "display": "none" });

    $list1.children("div").eq(0).css({ "display": "block" });
    $list2.children("div").eq(0).css({ "display": "block" });

    var sort1 = $('#sort1 li a');
    var sort1Con = $('.sort1Con');
    var sort2 = $('#sort2 li a');
    var sort2Con = $list2.children("div[class='sort1Con']");

    sort1.hover(function () {
        var i = sort1.index(this);
        sort1.removeClass('sel');
        sort1.eq(i).addClass('sel');
        sort1Con.eq(i).show().siblings().hide();
    }, function () { });


    sort2.hover(function () {
        var i = sort2.index(this);
        sort2.removeClass('sel');
        sort2.eq(i).addClass('sel');
        sort2Con.eq(i).show().siblings().hide();
    }, function () { });

}

function seachBox() {
    var s = $('#SearchBox input');
    var p = $('#SearchBox p');

    s.focus(function () {
        s.val("");
        s.css('outline', 'none');
        p.addClass('sel');
    });
    s.blur(function () {
        p.removeClass('sel');
    });
}


function sorts() {

    var sorts = $('#ItemSortCon');
    var sortsContent = $('.classMenu');
    var span = $('#ItemSort span b');

    sorts.hover(function () {
        sorts.addClass('ItemSort');
        sortsContent.css('display', 'block');

        if (span.text() == "+") {
            span.text("-");
        }
        else if (span.text() == "-") {
            span.text("+");
        }

    }, function () {
        sorts.removeClass('ItemSort');
        sortsContent.css('display', 'none');
        if (span.text() == "+") {
            span.text("-");
        }
        else if (span.text() == "-") {
            span.text("+");
        }

    });

}


function chart() {
    var char = $('#count img');
    var charf = $('#count');
    var charContent = $('#chartContent');
    var car = $('#chart img');

    char.hover(function () {
        charContent.css('display', 'block');
        car.attr({ 'src': 'static/images/gwcbt1.png' });
    }, function () {
    });

    charf.hover(function () {
    }, function () {
        charContent.css('display', 'none');
        car.attr({ 'src': 'static/images/gwcbt0.png' });
    });

    charContent.hover(function () {
        charContent.show();
        car.attr({ 'src': 'static/images/gwcbt1.png' });
    }, function () {
        charContent.hide();
        car.attr({ 'src': 'static/images/gwcbt0.png' });
    });

}


function Meun2() {
    var Menu = $('#Menu');
    var focusNum = $('#focus dd a');
    var hovers = $('#Menu .hover');
    var liHover = $('.liHover');

    Menu.hover(function () { },
	function () {
	    liHover.removeClass('hov');
	});

    hovers.hover(function () {
        liHover.removeClass('hov');
        $(this).find('.liHover').addClass('hov');
        $(this).find('.Listcontent').show();

    }, function () {
        $(this).find('.Listcontent').hide();
    });
}

function focues() {
    var a = $('#focus dt a');
    var n = $('#focus dd a');
    var num = 0;
    var timeout = 3000;
    var set = window.setInterval(au, timeout);

    a.eq(0).show();
    n.css('opacity', 0.5);
    n.eq(0).addClass('sel').css('opacity', 1);


    n.hover(function () {
        window.clearInterval(set);
        var i = n.index(this);
        n.eq(i).addClass('sel').siblings().removeClass('sel');
        n.eq(i).css('opacity', 1).siblings().css('opacity', 0.5);

        a.eq(i).show().siblings().hide();
    }, function () {
        var maxs = n.length - 1;
        var i = n.index(this);
        if (i < maxs) {
            var ii = i + 1;
        }
        else if (i == maxs) {
            n.eq(0).addClass('sel').siblings().removeClass('sel');
            n.eq(0).css('opacity', 1).siblings().css('opacity', 0.5);
        }

        n.eq(ii).addClass('sel').siblings().removeClass('sel');
        n.eq(ii).css('opacity', 1).siblings().css('opacity', 0.5);
        a.eq(ii).show().siblings().hide();

        set = window.setInterval(function au1() {
            ii < a.length - 1 ? ii++ : ii = 0;
            a.eq(ii).show().siblings().hide();
            n.eq(ii).addClass('sel').siblings().removeClass('sel');
            n.eq(ii).css('opacity', 1).siblings().css('opacity', 0.5);
        }, timeout);
    });




    a.hover(function () {
        window.clearInterval(set);
        var i = a.index(this);
        n.eq(i).addClass('sel').siblings().removeClass('sel');
        n.eq(i).css('opacity', 1).siblings().css('opacity', 0.5);
        a.eq(i).show().siblings().hide();

    }, function () {
        var maxs = a.length - 1;
        var i = a.index(this);
        if (i < maxs) {
            var ii = i + 1;
        }
        else if (i == maxs) {
            n.eq(0).addClass('sel').siblings().removeClass('sel');
            n.eq(0).css('opacity', 1).siblings().css('opacity', 0.5);
        }

        n.eq(ii).addClass('sel').siblings().removeClass('sel');
        n.eq(ii).css('opacity', 1).siblings().css('opacity', 0.5);
        a.eq(ii).show().siblings().hide();

        set = window.setInterval(function au1() {
            ii < a.length - 1 ? ii++ : ii = 0;
            a.eq(ii).show().siblings().hide();
            n.eq(ii).addClass('sel').siblings().removeClass('sel');
            n.eq(ii).css('opacity', 1).siblings().css('opacity', 0.5);
        }, timeout);
    });





    function au() {
        num < a.length - 1 ? num++ : num = 0;
        a.eq(num).show().siblings().hide();
        n.eq(num).addClass('sel').siblings().removeClass('sel');
        n.eq(num).css('opacity', 1).siblings().css('opacity', 0.5);
    }




}

function notes() {
    var a = $('#notes dt a');
    var p = $('#notes dd p');
    p.hide();
    a.eq(0).addClass('sel');
    p.eq(0).show();

    a.hover(function () {
        var i = a.index(this);
        a.removeClass('sel');

        if ($(this).attr('class') == 'adtwo') {
            $(this).addClass('sell');
        }
        else if ($(this).attr('class') == 'adone') {
            $(this).next().removeClass('sell');
            $(this).addClass('sel');
        }

        p.eq(i).show().siblings().hide();

    }, function () {

        if ($(this).attr('class') == 'adtwo') {
            $(this).removeClass('sell');
        }
        if ($(this).attr('class') == 'adone') {
            $(this).removeClass('sel');
        }
    });
}