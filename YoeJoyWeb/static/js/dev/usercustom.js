// JavaScript Document
$(function () {
    var flmenu_li = $('.flmenu li');
    var classitem_td = $('.classitem .item');
    var fdj = $('.fdj');
    var fdck = $('.fdck');
    var x, y, top, left;
    $('#itsm ul:gt(0)').hide();
    $('#jjyp ul:gt(0)').hide();
    $('.spzh>div:gt(0)').hide();
    $('.fdmenu').hide();
    $('#gwqd').hide();
    $('.classmenu .allclass').hide();
    $('.fdj').hide();
    $('.fdck').hide();

    $('.sxtj ul li').click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
    });

    $('.dzp').html($('.xzp li a span').eq(0).html());

    $('.dzp').hover(function (event) {
        x = event.offsetX;
        y = event.offsetY;
        fdj.show();
        fdj.css('top', y - 97 + 'px');
        fdj.css('left', x - 97 + 'px');
    });

    fdj.mousemove(function (event) {
        var ox = fdj.position().left + (event.offsetX - 77);
        var oy = fdj.position().top + (event.offsetY - 77);
        if (ox < 0) ox = 0
        else if (ox > 173) ox = 173;
        if (oy < 0) oy = 0
        else if (oy > 173) oy = 173;
        fdj.css('top', oy + 'px');
        fdj.css('left', ox + 'px');
        fdck.show().css('background', 'url(' + $('.dzp img').attr('src') + ') ' + (0 - ox * 2) + 'px ' + (0 - oy * 2) + 'px no-repeat #fff');
    });

    fdj.mouseout(function () {
        fdj.hide();
        fdck.hide();
    });

    $('.xzp li a').mouseover(function () {
        $('.dzp').html($(this).children('span').html());
    });

    $('.spzl label').click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
    });

    $('.add').click(function () {
        var num_val = Number($('.num').val());
        $('.num').attr('value', num_val + 1);
    });
    $('.sub').click(function () {
        var num_val = Number($('.num').val());
        if (num_val > 1)
            $('.num').attr('value', num_val - 1);
    });

    $('.spzhcd li').click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var spzhcd_li_index = $('.spzhcd li').index(this);
        $('.spzh div').eq(spzhcd_li_index).show().siblings().hide();
    });

    $('.classmenu').hover(
	    function () {
	        $(this).children('.allclass').show();
	        $(this).addClass('open').removeClass('close');
	    },
		function () {
		    $(this).children('.allclass').hide();
		    $(this).addClass('close').removeClass('open');
		}
	);

    $('#gwc .blank').hover(
	    function () {
	        $('#gwc').removeClass('xl').addClass('white');
	        $('#gwqd').show();
	    },
		function () {
		    $('#gwc').removeClass('white').addClass('xl');
		    $('#gwqd').hide();
		}
	);

    $('#gwqd').hover(
	    function () {
	        $('#gwc').removeClass('xl').addClass('white');
	        $('#gwqd').show();
	    },
		function () {
		    $('#gwc').removeClass('white').addClass('xl');
		    $('#gwqd').hide();
		}
	);

    classitem_td.hover(
		function () {
		    $(this).children('.item1').removeClass('item0').addClass('fdul');
		    $(this).children('.fdmenu').show();
		},
		function () {
		    $(this).children('.item1').removeClass('fdul').addClass('item0');
		    $(this).children('.fdmenu').hide();
		});

    $('.fdmenu').hover(
			function () { $(this).show(); },
			function () { $(this).hide(); });

    flmenu_li.mouseover(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var flmenu_li_index = flmenu_li.index(this);
        $('.fllist ul').eq(flmenu_li_index).show().siblings().hide();
    });

    $('.splb .list ul:gt(0)').hide();
    $('.pxtjitem li').click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var _index = $('.pxtjitem ul li').index(this);
        $('.splb .list ul').eq(_index).show().siblings().hide();
    });

    $('.combox div:odd').hide();
    $('.comenu li').mouseover(
	    function () {
	        $(this).addClass('selected').siblings().removeClass('selected');
	        var _index = $('.comenu li').index(this);
	        $('.combox>div').eq(_index).show().siblings().hide();
	    }
	);

    var cartcheck = $('#cartCheck');
    var _docheight = $(document).height();
    var _height = cartcheck.outerHeight();
    cartcheck.css('top', (_docheight - _height) / 2 - 140);
    cartcheck.hide()
    var dot = $('#cartCheck .dot span');
    var prev = $('#cartCheck .prev a');
    var next = $('#cartCheck .next a');
    var hxzsc = $('#cartCheck .hxzsc ul');
    var _tatol = dot.length;
    prev.hide();
    dot.click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var _index = dot.index(this);
        var _left = -_index * 408;
        if (_index == 0) { prev.hide(); next.show(); }
        if (_index == _tatol - 1) { next.hide(); prev.show(); }
        hxzsc.animate({ 'left': _left }, 'slow');
    });
    prev.click(function () {
        var _index = $('#cartCheck .dot .selected').index();
        if (_index == 1)
            prev.hide();
        next.show();
        dot.eq(_index - 1).addClass('selected').siblings().removeClass('selected');
        hxzsc.animate({ 'left': (1 - _index) * 408 }, 'slow');
    });
    next.click(function () {
        var _index = $('#cartCheck .dot .selected').index();
        var _last = _tatol - 2;
        if (_index == _last)
            next.hide();
        prev.show();
        dot.eq(_index + 1).addClass('selected').siblings().removeClass('selected');
        hxzsc.animate({ 'left': (-1 - _index) * 408 }, 'slow');
    });
    $('#cartCheck .close0').click(function () {
        cartcheck.hide();
    });
    $('.gmtj .gwcbt').click(function () {
        cartcheck.show();
    });

    //流程脚本
    $('#order>div:gt(0)>div').hide();
    $('#order>div:eq(0) .form1').hide();
    $('#order #consignee .form0>div').hide();
    $('#pay .form0>div').hide();
    $('#order #invoice .form0>p:eq(2)').hide();

    $('#order .newAdd').click(function () {
        $('#order #consignee .form0>div').show();
    });
    $('#order #consignee .save').click(function () {
        $('#order #consignee .form0>div').hide();
    });
    $('#order #consignee .form0>p input').focus(function () {
        $('#order #consignee .form0').hide();
        $('#order #consignee .form1').show();
        $('#order #pay .form0').show();
    });
    $('#pay .webPay').click(function () {
        $('#pay .form0>div').show();
    });
    $('#order #cash').focus(function () {
        $('#order #pay .form0>div').hide();
    });
    $('#pay .form0>div input').focus(function () {
        $('#pay .form0>div').hide();
        var _src = $(this).parent('li').children('img').attr("src");
        $('#pay .form0 .bank').attr("src", _src);
    });
    $('#order #pay .save').click(function () {
        var _src = $('#order #pay .form0 .bank').attr("src");
        $('#order #pay .form1 .bank').attr("src", _src);
    });
    $('#order #delivery .form0>input').focus(function () {
        $(this).next('div').show();
        $(this).siblings().next('div').hide();
    });
    $('#order .save').click(function () {
        $(this).parent('.form0').hide();
        $(this).parent('.form0').siblings('.form1').show();
        $(this).parent('.form0').parent('div').next('div').children('.form0').show();
        $('#order #list .form1').show();
    });
    $('#order #invoice .form0>p:eq(1) input').focus(function () {
        var _index = $(this).index();
        if (_index == 1) $('#order #invoice .form0>p:eq(2)').show()
        else $('#order #invoice .form0>p:eq(2)').hide();
    });
    $('#order .modify a').click(function () {
        $(this).closest('.form1').hide();
        $(this).closest('.form1').next('.form0').show();
    });
});