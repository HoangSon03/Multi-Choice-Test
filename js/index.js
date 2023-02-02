//import { timeStamp } from "console";

//Các Lễ Hội
jQuery(document).ready(function ($) {
    $('.content').isotope({
        itemSelector: '.sl',
        filter: '.sl-show'
    });
    $('.menu__htgv-item').click(function (event) {
        // var type = $(this).attr('data-type');
        var type = $(this).data('type');
        // console.log(type);
        var ten_loai = $(this).text();
        $('.event__title').text(ten_loai);
        type = '.' + type;
        $('.content').isotope({
            filter: type
        });
    });
});

//$(document).ready(function () {
//    $(".check__main").click(function () {
//        $(".main-df").("none__block");
//    })

//})



//scroll
function scrollTopAnimated() {
    $("html, body").animate(
        { scrollTop: "0" }, 1500);
}

//Menu

(function ($) {
    "use strict";

    $(function () {
        var header = $(".start-style");
        $(window).scroll(function () {
            var scroll = $(window).scrollTop();

            if (scroll >= 10) {
                header.removeClass('start-style').addClass("scroll-on");
            } else {
                header.removeClass("scroll-on").addClass('start-style');
            }
        });
    });

    //Animation

    $(document).ready(function () {
        $('body.hero-anime').removeClass('hero-anime');
    });

    //Menu On Hover

    //$('body').on('mouseenter mouseleave', '.nav-item', function (e) {
    //    if ($(window).width() > 750) {
    //        var _d = $(e.target).closest('.nav-item'); _d.addClass('show');
    //        setTimeout(function () {
    //            _d[_d.is(':hover') ? 'addClass' : 'removeClass']('show');
    //        }, 1);
    //    }
    //});


    //scroll top
    $(window).scroll(function () {
        if ($(this).scrollTop() > 80) {

            $('.navigation-wrap').addClass('fixed-top');
        } else {

            $('.navigation-wrap').removeClass('fixed-top');
        }
    });

    //WOW JS
    new WOW().init();
})

//Menu
const $dropdown = $(".dropdown");
const $dropdownToggle = $(".dropdown-toggle");
const $dropdownMenu = $(".dropdown-menu");
const showClass = "show";

$(window).on("load resize", function () {
    if (this.matchMedia("(min-width: 768px)").matches) {
        $dropdown.hover(
            function () {
                const $this = $(this);
                $this.addClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "true");
                $this.find($dropdownMenu).addClass(showClass);
            },
            function () {
                const $this = $(this);
                $this.removeClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "false");
                $this.find($dropdownMenu).removeClass(showClass);
            }
        );
    } else {
        $dropdown.off("mouseenter mouseleave");
    }
});


//Timer

var h = null; // Giờ
var m = null; // Phút
var s = null; // Giây

var timeout = null; // Timeout

function start() {
    /*BƯỚC 1: LẤY GIÁ TRỊ BAN ĐẦU*/
    if (h === null) {
        h = parseInt(document.getElementById('h_val').value);
        m = parseInt(document.getElementById('m_val').value);
        s = parseInt(document.getElementById('s_val').value);
    }

    /*BƯỚC 1: CHUYỂN ĐỔI DỮ LIỆU*/
    // Nếu số giây = -1 tức là đã chạy ngược hết số giây, lúc này:
    //  - giảm số phút xuống 1 đơn vị
    //  - thiết lập số giây lại 59
    if (s === -1) {
        m -= 1;
        s = 59;
    }

    // Nếu số phút = -1 tức là đã chạy ngược hết số phút, lúc này:
    //  - giảm số giờ xuống 1 đơn vị
    //  - thiết lập số phút lại 59
    if (m === -1) {
        h -= 1;
        m = 59;
    }

    // Nếu số giờ = -1 tức là đã hết giờ, lúc này:
    //  - Dừng chương trình
    if (h == -1) {
        clearTimeout(timeout);
        alert('Hết giờ');
        return false;
    }

    /*BƯỚC 1: HIỂN THỊ ĐỒNG HỒ*/
    document.getElementById('h').innerText = h.toString();
    document.getElementById('m').innerText = m.toString();
    document.getElementById('s').innerText = s.toString();

    /*BƯỚC 1: GIẢM PHÚT XUỐNG 1 GIÂY VÀ GỌI LẠI SAU 1 GIÂY */
    timeout = setTimeout(function () {
        s--;
        start();
    }, 1000);
}

function stop() {
    clearTimeout(timeout);
}
////Count timeStamp
//function minusTime() {
//    // debugger;
//    let timeStart = 15 * 60;
//    var test = document.getElementById("ten-countdown").innerHTML.split(':');
//    var seconds1 = test[0] * 60;
//    var seconds2 = test[1];
//    seconds2 = parseInt(seconds2)
//    var timeFinish = seconds1 + seconds2
//    const times = timeStart - timeFinish;
//    alert(times)
//}




//function countdown(elementName, minutes, seconds) {
//    var element, endTime, hours, mins, msLeft, time;

//    function twoDigits(n) {
//        return (n <= 9 ? "0" + n : n);
//    }

//    function updateTimer() {
//        msLeft = endTime - (+new Date);
//        if (msLeft < 1000) {
//            element.innerHTML = "00:00";
//        } else {
//            time = new Date(msLeft);
//            hours = time.getUTCHours();
//            mins = time.getUTCMinutes();
//            element.innerHTML = (hours ? hours + ':' + twoDigits(mins) : mins) + ':' + twoDigits(time.getUTCSeconds());
//            setTimeout(updateTimer, time.getUTCMilliseconds() + 500);
//        }
//    }

//    element = document.getElementById(elementName);
//    endTime = (+new Date) + 1000 * (60 * minutes + seconds) + 500;
//    updateTimer();
//}

//countdown("ten-countdown", 2, 0);

