/* motion */
//jQuery.easing.motion = function (x, t, b, c, d) { if (t == 0) return b; if (t == d) return b + c; if ((t /= d / 2) < 1) return c / 2 * Math.pow(2, 10 * (t - 1)) + b; return c / 2 * (-Math.pow(2, -10 * --t) + 2) + b; }

/* current OS */
var isPositionFixed = 1; // IE6ê³?ëª¨ë°”??iOS?ì„œ ?¬ì???Fixed ê°?ë¬´ì‹œ??
var isMobile = 0; // ?¤ë§ˆ?¸í°?¸ê²½??var isIE6=0; // ?¹ë¸Œ?¼ìš°??ie6??ê²½ìš°

// document ready


$(window).load(function (e) {

    scrollAnimation();
});
/* resize event */

/* scroll event */
$(window).scroll(function (e) {
    if (!navigator.userAgent.match(/MSIE/i)) {  changeSubmenuHighlight(); }
});


/* scroll animation */
function scrollAnimation() {
    if (isMobile == 0) {
        $('a[href*=#wrap], a[href*=#slide_content01], a[href*=#slide_content02], a[href*=#slide_content03], a[href*=#slide_content04], a[href*=#slide_content05], a[href*=#slide_content06], a[href*=#slide_content07], a[href*=#slide_content08], area[href*=#wrap], area[href*=#slide_content01], area[href*=#slide_content02], area[href*=#slide_content03], area[href*=#slide_content04], area[href*=#slide_content05], area[href*=#slide_content06], area[href*=#slide_content07], area[href*=#slide_content08]').click(function () {
            debugger;
            if (navigator.userAgent.match(/MSIE/i)) {
                initSubmenuHighlight();
                $(this).addClass("on");
            }

            if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
                var $target = $(this.hash);
                $target = $target.length && $target || jQuery('[name=' + this.hash.slice(1) + ']');
                if ($target.length) {
                    var targetOffset = $target.offset().top;
                    jQuery('html,body').animate({ scrollTop: targetOffset }, { duration: 500, easing: 'motion' });
                    return false;
                } else {
                    return true;
                }
            } else {
                return true;
            }
        });
    } else {
        debugger;
        $('a[href*=#wrap]').click(function () { goToMyId('wrap'); });
        $('a[href*=#slide_content01]').click(function () { goToMyId('slide_content01'); });
        $('a[href*=#slide_content02]').click(function () { goToMyId('slide_content02'); });
        $('a[href*=#slide_content03]').click(function () { goToMyId('slide_content03'); });
        $('a[href*=#slide_content04]').click(function () { goToMyId('slide_content04'); });
        $('a[href*=#slide_content05]').click(function () { goToMyId('slide_content05'); });
        $('a[href*=#slide_content06]').click(function () { goToMyId('slide_content06'); });
        $('a[href*=#slide_content07]').click(function () { goToMyId('slide_content07'); });
        $('a[href*=#slide_content08]').click(function () { goToMyId('slide_content08'); });
        $('area[href*=#wrap]').click(function () { goToMyId('wrap'); });
        $('area[href*=#slide_content01]').click(function () { goToMyId('slide_content01'); });
        $('area[href*=#slide_content02]').click(function () { goToMyId('slide_content02'); });
        $('area[href*=#slide_content03]').click(function () { goToMyId('slide_content03'); });
        $('area[href*=#slide_content04]').click(function () { goToMyId('slide_content04'); });
        $('area[href*=#slide_content05]').click(function () { goToMyId('slide_content05'); });
        $('area[href*=#slide_content06]').click(function () { goToMyId('slide_content06'); });
        $('area[href*=#slide_content07]').click(function () { goToMyId('slide_content07'); });
        $('area[href*=#slide_content08]').click(function () { goToMyId('slide_content08'); });
        if (!location.hash || location.hash == "#wrap") {
            setTimeout(scrollTo, 0, 0, 1);
        } else {
            if (location.hash == "#slide_content01") { goToMyId('slide_content01'); }
            if (location.hash == "#slide_content02") { goToMyId('slide_content02'); }
            if (location.hash == "#slide_content03") { goToMyId('slide_content03'); }
            if (location.hash == "#slide_content04") { goToMyId('slide_content04'); }
            if (location.hash == "#slide_content05") { goToMyId('slide_content05'); }
            if (location.hash == "#slide_content06") { goToMyId('slide_content06'); }
            if (location.hash == "#slide_content07") { goToMyId('slide_content07'); }
            if (location.hash == "#slide_content08") { goToMyId('slide_content08'); }
        }
    }
}
function goToMyId(myid) { // ?´ë‹¹ IDê°’ìœ¼ë¡?ì§ì§„, ?´ë™?˜ê³  ?˜ë©´, ?¬ì????•ë¦¬??
    var target = $('div[id=' + myid + ']');
    if (target.length) {
        var top = target.offset().top;
        $('html,body').animate({ scrollTop: top }, {
            duration: 1000, easing: 'motion', complete: function () {
                changeSubmenuHighlight();
            }
        });
        return false;
    }
}
/* fix position:fixed */
function fixedPosition() {
    var w = parseInt(($(window).width() - 940) / 2);
    if (w < 0) w = 0;
    if ($(window).scrollTop() > 413) {
        if (isPositionFixed == 0) {
            $(".wrap .floating_cubemenu").css("position", "absolute");
            //$(".wrap .floating_cubemenu").css("left",w+11);
        } else {
            $(".wrap .floating_cubemenu").css("position", "fixed");
            //$(".wrap .floating_cubemenu").css("left",w+11);
        }
    } else {
        $(".wrap .floating_cubemenu").css("position", "absolute");
        //$(".wrap .floating_cubemenu").css("left",w-1+11);
    }

}
function fixedPositionScroll() {
    var w = parseInt(($(window).width() - 940) / 2);
    if (w < 0) w = 0;
    if ($(window).scrollTop() >= 95) {
        if (isPositionFixed == 0) $(".wrap .floating_cubemenu").css("top", $(window).scrollTop() - 95);
        else $(".wrap .floating_cubemenu").css("top", 0);
    } else {
        $(".wrap .floating_cubemenu").css("top", 0);
    }
}

function initSubmenuHighlight() {
    for (var i = 0; i < $(".submenu a").length; i++) {
        $(".submenu a").eq(i).removeClass("on");
    }
}
function changeSubmenuHighlight() {
    if (document.getElementById("wrap") || document.getElementById("general")) {
        for (var i = 0; i < $(".submenu a").length; i++) {
            if ($(".submenu a").eq(i).attr("href") != "#") {
                var tmp = $(".submenu a").eq(i).attr("href").split("#");
                var tmpz = $(".submenu a").eq(0).attr("href").split("#");
                if ($(window).scrollTop() >= $("#" + tmp[1]).offset().top - 95) {
                    initSubmenuHighlight();
                    if ($(window).scrollTop() >= 95) {
                        $(".submenu a").eq(i).addClass("on");
                    }
                }
            }
        }
    }
}


