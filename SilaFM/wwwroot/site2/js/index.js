//c
$(document).ready(function () {
    $("#menu").on("click", "a", function (event) {
        var id = $(this).attr('href');
        if (id && id.startsWith('#')) {
            event.preventDefault();
            top = $(id).offset().top - 70;
            $('body,html').animate({ scrollTop: top }, 1600);
        }
    });

    $(".counter").counterUp({ delay: 10, time: 1000 });
    //popapChronometr
    var elements = $('.modal-overlay, .modal');

    $('.modal-btn').click(function () {
        elements.addClass('active');
    });

    $('.close-modal').click(function () {
        elements.removeClass('active');
    });
    //popup2Pagemeter
    var elementts = $('.modal-overlay-page, .modal-page');

    $('.modal-btn-page').click(function () {
        elementts.addClass('active-page');
    });

    $('.close-modal-page').click(function () {
        elementts.removeClass('active-page');
    });
    //popup OnlineCalculator
    var elementtss = $('.modal-overlay-calculator, .modal-calculator');

    $('.modal-btn-calculator').click(function () {
        elementtss.addClass('active-calculator');
    });

    $('.close-modal-calculator').click(function () {
        elementtss.removeClass('active-calculator');
    });
    //popup Cashpay
    var elementtssc = $('.modal-overlay-cash, .modal-cash');

    $('.modal-btn-cash').click(function () {
        elementtssc.addClass('active-cash');
    });

    $('.close-modal-cash').click(function () {
        elementtssc.removeClass('active-cash');
    });
    //popup bank
    var elementtssb = $('.modal-overlay-bank, .modal-bank');

    $('.modal-btn-bank').click(function () {
        elementtssb.addClass('active-bank');
    });

    $('.close-modal-bank').click(function () {
        elementtssb.removeClass('active-bank');
    });

});
//calculate-slider
var sheet = document.createElement('style'),
    $rangeInput = $('.range input'),
    prefs = ['webkit-slider-runnable-track', 'moz-range-track', 'ms-track'];

document.body.appendChild(sheet);

var getTrackStyle = function (el) {
    var curVal = el.value,
        val = (curVal - 1) * 33.4,
        style = '';

    $('.range-labels li').removeClass('active selected');

    var curLabel = $('.range-labels').find('li:nth-child(' + curVal + ')');

    curLabel.addClass('active selected');
    curLabel.prevAll().addClass('selected');

    for (var i = 0; i < prefs.length; i++) {
        style += '.range {background: linear-gradient(181.59deg, #1E7A89 4.76%, #3F486A 100% ' + val + '%, #B3C2D9; ' + val + '%, #B3C2D9 100%)}';
        style += '.range input::-' + prefs[i] + '{background: linear-gradient(to right, #3F486A 2.5%, #1E7A89 ' + val + '%, #B3C2D9 ' + val + '%, #B3C2D9 100%)}';
    }

    return style;
}

$rangeInput.on('input', function () {
    sheet.textContent = getTrackStyle(this);
});

$('.range-labels li').on('click', function () {
    var index = $(this).index();

    $rangeInput.val(index + 1).trigger('input');

});




function nextSlider() {
    document.getElementById("1").style.backgroundImage = "linear-gradient( 95.63deg,rgba(74, 51, 91, 0.8) -25.44%,rgba(47, 61, 83, 0.8) 11.99%,rgba(17, 48, 62, 0.8) 53.35%,rgba(76, 50, 90, 0.8) 98.56%),url('img/videoimg.png')";
    document.getElementById("slider-elem").style.marginLeft = "-389px";
    document.getElementById("slider-elem").style.border = "2px solid #c7dee1";
    document.getElementById("slider-elem1").style.border = "none";
    document.getElementById("next-slider").style.opacity = "0";
    document.getElementById("prev-slider").style.opacity = "1";
    var mql = window.matchMedia('all and (max-width: 720px)');
    if (mql.matches) {
        document.getElementById("slider-elem").style.marginLeft = "-269px";
    }
    var mql = window.matchMedia('all and (max-width: 500px)');
    if (mql.matches) {
        document.getElementById("slider-elem").style.marginLeft = "-229px";
    }
}
function prevSlider() {
    document.getElementById("1").style.backgroundImage = "linear-gradient( 95.63deg,rgba(74, 51, 91, 0.8) -25.44%,rgba(47, 61, 83, 0.8) 11.99%,rgba(17, 48, 62, 0.8) 53.35%,rgba(76, 50, 90, 0.8) 98.56%),url('img/фото.png')";
    document.getElementById("slider-elem").style.marginLeft = "0px";
    document.getElementById("prev-slider").style.opacity = "0";
    document.getElementById("next-slider").style.opacity = "1";
    document.getElementById("slider-elem").style.border = "none";
    document.getElementById("slider-elem1").style.border = "2px solid #c7dee1";
}


//Fonts
var x, i, j, l, ll, selElmnt, a, b, c;
x = document.getElementsByClassName("custom-select");
l = x.length;
for (i = 0; i < l; i++) {
    selElmnt = x[i].getElementsByTagName("select")[0];
    ll = selElmnt.length;
    a = document.createElement("DIV");
    a.setAttribute("class", "select-selected");
    a.innerHTML = selElmnt.options[selElmnt.selectedIndex].innerHTML;
    x[i].appendChild(a);
    b = document.createElement("DIV");
    b.setAttribute("class", "select-items select-hide");
    for (j = 1; j < ll; j++) {

        c = document.createElement("DIV");
        c.innerHTML = selElmnt.options[j].innerHTML;
        c.addEventListener("click", function (e) {

            var y, i, k, s, h, sl, yl;
            s = this.parentNode.parentNode.getElementsByTagName("select")[0];
            sl = s.length;
            h = this.parentNode.previousSibling;
            for (i = 0; i < sl; i++) {
                if (s.options[i].innerHTML == this.innerHTML) {
                    s.selectedIndex = i;
                    h.innerHTML = this.innerHTML;
                    y = this.parentNode.getElementsByClassName("same-as-selected");
                    yl = y.length;
                    for (k = 0; k < yl; k++) {
                        y[k].removeAttribute("class");
                    }
                    this.setAttribute("class", "same-as-selected");
                    break;
                }
            }
            h.click();
        });
        b.appendChild(c);
    }
    x[i].appendChild(b);
    a.addEventListener("click", function (e) {

        e.stopPropagation();
        closeAllSelect(this);
        this.nextSibling.classList.toggle("select-hide");
        this.classList.toggle("select-arrow-active");
    });
}
function closeAllSelect(elmnt) {

    var x, y, i, xl, yl, arrNo = [];
    x = document.getElementsByClassName("select-items");
    y = document.getElementsByClassName("select-selected");
    xl = x.length;
    yl = y.length;
    for (i = 0; i < yl; i++) {
        if (elmnt == y[i]) {
            arrNo.push(i)
        } else {
            y[i].classList.remove("select-arrow-active");
        }
    }
    for (i = 0; i < xl; i++) {
        if (arrNo.indexOf(i)) {
            x[i].classList.add("select-hide");
        }
    }
}
document.addEventListener("click", closeAllSelect);
//see more - for footer
function seemore() {
    var dots = document.getElementById("dots");
    var moreText = document.getElementById("more");
    var btnText = document.getElementById("myBtn");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "EЩЕ";
        moreText.style.display = "none";

    } else {
        dots.style.display = "none";
        btnText.innerHTML = "МЕНЬШЕ";
        moreText.style.display = "inline";

    }
}

//preloader
function loadData() {
    return new Promise((resolve, reject) => {
        setTimeout(resolve, 2000);
    });
}

loadData()
    .then(() => {
        let preloaderEl = document.getElementById('preloader');
        if (preloaderEl) {
            preloaderEl.classList.add('hidden');
            preloaderEl.classList.remove('visible');
        }
    });

//left-menu
function mouseOverbtn() {
    document.getElementById("btn-elem1").style.opacity = "1";

}
function mouseOutbtn() {
    document.getElementById("btn-elem1").style.opacity = "0";

}
function mouseOver() {
    document.getElementById("demo").style.width = "98%";
    document.getElementById("demo2").style.width = "98%";
    document.getElementById("demo3").style.width = "98%";
    document.getElementById("demo4").style.width = "98%";
}
function mouseOut() {
    document.getElementById("demo").style.width = "27%";
    document.getElementById("demo2").style.width = "27%";
    document.getElementById("demo3").style.width = "27%";
    document.getElementById("demo4").style.width = "27%";
}
function mouseOver1() {
    document.getElementById("base-block1").style.color = "#C7DEE1";
    document.getElementById("base-text1").style.color = "#C7DEE1";
    document.getElementById("btn-base").style.display = "block";
    document.getElementById("base-svg1").style.display = "block";
    // document.getElementById("cont-icon-svg1").style.fill = "#ECF6F8";
    // document.getElementById("cont-icon-svg2").style.fill = "#ECF6F8";
    // document.getElementById("cont-icon-svg3").style.fill = "#ECF6F8";
    // document.getElementById("cont-icon-svg4").style.fill = "#ECF6F8";
}

function mouseOut1() {
    document.getElementById("base-block1").style.color = "#404263";
    document.getElementById("base-text1").style.color = "#404263";
    document.getElementById("btn-base").style.display = "none";
    document.getElementById("base-svg1").style.display = "none";
    // document.getElementById("cont-icon-svg1").style.fill = "#404263";
    // document.getElementById("cont-icon-svg2").style.fill = "#404263";
    // document.getElementById("cont-icon-svg3").style.fill = "#404263";
    // document.getElementById("cont-icon-svg4").style.fill = "#404263";
}
function mouseOver2() {
    document.getElementById("base-blockk2").style.color = "#C7DEE1";
    document.getElementById("base-text2").style.color = "#C7DEE1";
    document.getElementById("btn-base2").style.display = "block";
    document.getElementById("base-svg2").style.display = "block";
}
function mouseOut2() {
    document.getElementById("base-blockk2").style.color = "#404263";
    document.getElementById("base-text2").style.color = "#404263";
    document.getElementById("btn-base2").style.display = "none";
    document.getElementById("base-svg2").style.display = "none";
}
function mouseOver3() {
    document.getElementById("btn-base3").style.display = "block";
    document.getElementById("base-hover1").style.color = "#C7DEE1";
    document.getElementById("base-hoverr2").style.color = "#C7DEE1";
}
function mouseOut3() {
    document.getElementById("btn-base3").style.display = "none";
    document.getElementById("base-hover1").style.color = "#404263";
    document.getElementById("base-hoverr2").style.color = "#454545";
}
function mouseOver4() {
    document.getElementById("btn-base4").style.display = "block";
    document.getElementById("base-hover3").style.color = "#C7DEE1";
    document.getElementById("base-hover4").style.color = "#C7DEE1";
}
function mouseOut4() {
    document.getElementById("btn-base4").style.display = "none";
    document.getElementById("base-hover3").style.color = "#404263";
    document.getElementById("base-hover4").style.color = "#454545";
}
function mouseOver5() {
    document.getElementById("btn-base5").style.display = "block";
    document.getElementById("base-hover5").style.color = "#C7DEE1";
    document.getElementById("base-hover6").style.color = "#C7DEE1";
}
function mouseOut5() {
    document.getElementById("btn-base5").style.display = "none";
    document.getElementById("base-hover5").style.color = "#404263";
    document.getElementById("base-hover6").style.color = "#454545";
}
function mouseOver6() {
    document.getElementById("btn-base6").style.display = "block";
    document.getElementById("base-hover7").style.color = "#C7DEE1";
    document.getElementById("base-hover8").style.color = "#C7DEE1";
}
function mouseOut6() {
    document.getElementById("btn-base6").style.display = "none";
    document.getElementById("base-hover7").style.color = "#404263";
    document.getElementById("base-hover8").style.color = "#454545";
}
function mouseOveraddress() {
    document.getElementById("base-blockk-ad").style.color = "#C7DEE1";
    document.getElementById("base-text-ad").style.color = "#C7DEE1";

    document.getElementById("base-svg-ad").style.display = "block";
}
function mouseOutaddress() {
    document.getElementById("base-blockk-ad").style.color = "#404263";
    document.getElementById("base-text-ad").style.color = "#404263";

    document.getElementById("base-svg-ad").style.display = "none";
}

//playyer
let now_playing = document.querySelector(".now-playing");
let playpause_btn = document.querySelector(".playpause-track");
let playrepeat_btn = document.querySelector(".playrepeat-track");

let seek_slider = document.querySelector(".seek_slider");
let volume_slider = document.querySelector(".volume_slider");

let track_index = 0;
let isPlaying = false;
let updateTimer;
let curr_track = document.createElement('audio');
let repeat = document.createElement('audio');

let track_list = [
    {
        path: "/silaFM/mp3/music1.mp3"
    }
];

function loadTrack(track_index) {
    resetValues();
    curr_track.src = track_list[track_index].path;
    curr_track.load();
    updateTimer = setInterval(seekUpdate, 1000);
}
function resetValues() {
    seek_slider.value = 0;
}

function playpauseTrack() {
    if (!isPlaying) playTrack();
    else pauseTrack();
}
function playTrack() {
    curr_track.play();
    isPlaying = true;
    playpause_btn.innerHTML = '<img src="img/icon-stop.png">';
}
function playTrackRepeat() {
    curr_track.loop = true;
    curr_track.load();
}

function prevTrack() {
    if (track_index > 0)
        track_index -= 1;
    else track_index = track_list.length;
    loadTrack(track_index);
    playTrack();
}
function pauseTrack() {
    curr_track.pause();
    isPlaying = false;
    playpause_btn.innerHTML = '<img src="img/play.png">';
}

function seekTo() {
    seekto = curr_track.duration * (seek_slider.value / 100);
    curr_track.currentTime = seekto;
    document.querySelectorAll("#range-player").forEach(function (el) {
        el.oninput = function () {
            let valPercent = (el.valueAsNumber - parseInt(el.min)) /
                (parseInt(el.max) - parseInt(el.min));
            let style = 'background-image: -webkit-gradient(linear, 0% 0%, 100% 0%, color-stop(' + valPercent + ', white), color-stop(' + valPercent + ',#33556f));';
            el.style = style;
        };
        el.oninput();
    });

}
function setVolume() {
    curr_track.volume = volume_slider.value / 100;
}
// volume white
document.querySelectorAll(".__range").forEach(function (el) {
    el.oninput = function () {
        let valPercent = (el.valueAsNumber - parseInt(el.min)) /
            (parseInt(el.max) - parseInt(el.min));
        let style = 'background-image: -webkit-gradient(linear, 0% 0%, 100% 0%, color-stop(' + valPercent + ', white), color-stop(' + valPercent + ',#33556f));';
        el.style = style;
    };
    el.oninput();
});
function seekUpdate() {
    let seekPosition = 0;

    if (!isNaN(curr_track.duration)) {
        seekPosition = curr_track.currentTime * (100 / curr_track.duration);
        seek_slider.value = seekPosition;
    }
}
loadTrack(track_index);
//burger menu
function openNav() {
    document.getElementById("myNav").style.width = "100%";
    document.getElementById("myNav").style.height = "700px";
    document.getElementById("Btn-home").style.opacity = "0";
    document.getElementById("slider-au").style.opacity = "0";
    document.getElementById("home-text").style.opacity = "0";
    document.getElementById("menufixed").style.zIndex = "0";
}

function closeNav() {
    document.getElementById("myNav").style.width = "0%";
    document.getElementById("menufixed").style.zIndex = "1";
    document.getElementById("Btn-home").style.opacity = "1";
    document.getElementById("slider-au").style.opacity = "1";
    document.getElementById("home-text").style.opacity = "1";

}


//slider About us
function Sim(sldrId) {
    if (sldrId) {
        let id = document.getElementById(sldrId);
        if (id) {
            this.sldrRoot = id;
        }
    } else {
        this.sldrRoot = document.querySelector('.sim-slider');
    };

    this.sldrList = this.sldrRoot.querySelector('.sim-slider-list');
    this.sldrElements = this.sldrList.querySelectorAll('.sim-slider-element');
    this.sldrElemFirst = this.sldrList.querySelector('.sim-slider-element');
    this.leftArrow = this.sldrRoot.querySelector('div.sim-slider-arrow-left');
    this.rightArrow = this.sldrRoot.querySelector('div.sim-slider-arrow-right');
    this.indicatorDots = this.sldrRoot.querySelector('div.sim-slider-dots');


    this.options = Sim.defaults;
    Sim.initialize(this);
};

Sim.defaults = {
    auto: true,
    interval: 5000,
    loop: true,
    arrows: true,
    dots: true
};

Sim.prototype.elemPrev = function (num) {
    num = num || 1;

    let prevElement = this.currentElement;
    this.currentElement -= num;
    if (this.currentElement < 0) this.currentElement = this.elemCount - 1;

    if (!this.options.loop) {
        if (this.currentElement == 0) {
            this.leftArrow.style.display = 'none'
        };
        this.rightArrow.style.display = 'block'
    };

    this.sldrElements[this.currentElement].style.opacity = '1';
    this.sldrElements[prevElement].style.opacity = '0';

    if (this.options.dots) {
        this.dotOn(prevElement); this.dotOff(this.currentElement)
    }
};

Sim.prototype.elemNext = function (num) {
    num = num || 1;

    let prevElement = this.currentElement;
    this.currentElement += num;
    if (this.currentElement >= this.elemCount) this.currentElement = 0;
    this.sldrElements[this.currentElement].style.opacity = '1';
    this.sldrElements[prevElement].style.opacity = '0';

    if (this.options.dots) {
        this.dotOn(prevElement); this.dotOff(this.currentElement)
    }
};

Sim.prototype.dotOn = function (num) {
    this.indicatorDotsAll[num].style.cssText = 'background-color:transparent; cursor:pointer;'
};

Sim.prototype.dotOff = function (num) {
    this.indicatorDotsAll[num].style.cssText = 'background-color:#C7DEE1; cursor:default;'
};

Sim.initialize = function (that) {
    that.elemCount = that.sldrElements.length;
    that.currentElement = 0;
    let bgTime = getTime();

    // Functions
    function getTime() {
        return new Date().getTime();
    };
    function setAutoScroll() {
        that.autoScroll = setInterval(function () {
            let fnTime = getTime();
            if (fnTime - bgTime + 10 > that.options.interval) {
                bgTime = fnTime; that.elemNext()
            }
        }, that.options.interval)
    };
    if (that.elemCount <= 1) {
        that.options.auto = false; that.options.arrows = false; that.options.dots = false;
        that.leftArrow.style.display = 'none'; that.rightArrow.style.display = 'none'
    };
    if (that.elemCount >= 1) {
        that.sldrElemFirst.style.opacity = '1';
    };
    if (!that.options.loop) {
        that.options.auto = false;
    }
    else if (that.options.auto) {
        setAutoScroll();
        that.sldrList.addEventListener('mouseenter', function () { clearInterval(that.autoScroll) }, false);
        that.sldrList.addEventListener('mouseleave', setAutoScroll, false)
    };

    if (that.options.dots) {
        let sum = '', diffNum;
        for (let i = 0; i < that.elemCount; i++) {
            sum += '<span class="sim-dot"></span>'
        };
        that.indicatorDots.innerHTML = sum;
        that.indicatorDotsAll = that.sldrRoot.querySelectorAll('span.sim-dot');

        for (let n = 0; n < that.elemCount; n++) {
            that.indicatorDotsAll[n].addEventListener('click', function () {
                diffNum = Math.abs(n - that.currentElement);
                if (n < that.currentElement) {
                    bgTime = getTime(); that.elemPrev(diffNum)
                }
                else if (n > that.currentElement) {
                    bgTime = getTime(); that.elemNext(diffNum)
                }
            }, false)
        };
        that.dotOff(0);
        for (let i = 1; i < that.elemCount; i++) {
            that.dotOn(i)
        }
    }
};
new Sim();
// for fixed left menu
window.onscroll = function () { scrollFunction() };
function scrollFunction() {
    if (document.documentElement.scrollTop > 1050) {
        document.getElementById("menufixed").style.position = "fixed";
        document.getElementById("menufixed").style.marginTop = "-990px";
        var mql = window.matchMedia('all and (min-height: 400px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-850px";
        }
        var mql = window.matchMedia('all and (min-height: 600px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-1060px";
        }
        var mql = window.matchMedia('all and (max-height: 667px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-1060px";
        }
        var mql = window.matchMedia('all and (max-width: 470px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-790px";
        }
    } else {
        document.getElementById("menufixed").style.position = "absolute";
        document.getElementById("menufixed").style.marginTop = "0px";
    }

    if (document.documentElement.scrollTop > 700) {
        document.getElementById("show").style.opacity = "1";
    } else {
        document.getElementById("show").style.opacity = "0";
    }
    if (document.documentElement.scrollTop > 1500) {
        document.getElementById("showThird").style.opacity = "1";
    } else {
        document.getElementById("showThird").style.opacity = "0";
    }
    if (document.documentElement.scrollTop > 2200) {
        document.getElementById("showFour").style.opacity = "1";
    } else {
        document.getElementById("showFour").style.opacity = "0";
    }
}

//pay
function payFirstover() {
    document.getElementById("svg-pay1").style.display = "block";

}
function payFirstout() {
    document.getElementById("svg-pay1").style.display = "none";

}

function payQiwiover() {
    document.getElementById("svg-pay2").style.display = "block";

}
function payQiwiout() {
    document.getElementById("svg-pay2").style.display = "none";

}
function payAlphaover() {
    document.getElementById("svg-pay3").style.fill = "#C7DEE1"

}
function payAlphaout() {
    document.getElementById("svg-pay3").style.fill = "#3c4a69";

}
function payAlphaover() {
    document.getElementById("svg-pay3").style.fill = "#C7DEE1"

}
function payAlphaout() {
    document.getElementById("svg-pay3").style.fill = "#3c4a69";

}
function payVisaover() {
    document.getElementById("svg-pay4master").style.display = "block";
    document.getElementById("svg-pay4visa").style.display = "block";

}
function payVisaout() {
    document.getElementById("svg-pay4visa").style.display = "none";
    document.getElementById("svg-pay4master").style.display = "none";

}
function payPayPalover() {
    document.getElementById("svg-pay5").style.display = "block";


}
function payPayPalout() {
    document.getElementById("svg-pay5").style.display = "none";


}
function payWebmoneyover() {
    document.getElementById("svg-pay6").style.display = "block";
}
function payWebmoneyout() {
    document.getElementById("svg-pay6").style.display = "none";
}

function paySberover() {
    document.getElementById("svg-pay7").style.display = "block";
}
function paySberout() {
    document.getElementById("svg-pay7").style.display = "none";
}

function paySelect() {
    document.getElementById("svg-pay8").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text").style.color = "#3c4a69";
    document.getElementById("pay-elem8").style.background = "#ECF6F8";
    document.getElementById("qiwi").style.display = "none";
    document.getElementById("text-selected").style.display = "none";
    document.getElementById("jandex").style.display = "block";
    document.getElementById("alpha").style.display = "none";
    document.getElementById("visa").style.display = "none";
    document.getElementById("paypal").style.display = "none";
    document.getElementById("webmoney").style.display = "none";
    document.getElementById("sber").style.display = "none";
}
function paySelectQiwi() {
    document.getElementById("svg-pay8").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text").style.color = "#3c4a69";
    document.getElementById("pay-elem8").style.background = "#ECF6F8";
    document.getElementById("qiwi-img").style.width = "220px";
    document.getElementById("text-selected").style.display = "none";
    document.getElementById("jandex").style.display = "none";
    document.getElementById("alpha").style.display = "none";
    document.getElementById("qiwi").style.display = "block";
    document.getElementById("paypal").style.display = "none";
    document.getElementById("visa").style.display = "none";
    document.getElementById("webmoney").style.display = "none";
    document.getElementById("sber").style.display = "none";
}

function paySelectAlpha() {
    document.getElementById("svg-pay8").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text").style.color = "#3c4a69";
    document.getElementById("pay-elem8").style.background = "#ECF6F8";
    document.getElementById("text-selected").style.display = "none";
    document.getElementById("jandex").style.display = "none";
    document.getElementById("qiwi").style.display = "none";
    document.getElementById("visa").style.display = "none";
    document.getElementById("paypal").style.display = "none";
    document.getElementById("webmoney").style.display = "none";
    document.getElementById("sber").style.display = "none";
    document.getElementById("alpha").style.display = "block";
}
function paySelectVisa() {
    document.getElementById("svg-pay8").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text").style.color = "#3c4a69";
    document.getElementById("pay-elem8").style.background = "#ECF6F8";
    document.getElementById("text-selected").style.display = "none";
    document.getElementById("jandex").style.display = "none";
    document.getElementById("qiwi").style.display = "none";
    document.getElementById("alpha").style.display = "none";
    document.getElementById("paypal").style.display = "none";
    document.getElementById("webmoney").style.display = "none";
    document.getElementById("sber").style.display = "none";
    document.getElementById("visa").style.display = "block";

}
function paySelectPayPal() {
    document.getElementById("svg-pay8").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text").style.color = "#3c4a69";
    document.getElementById("pay-elem8").style.background = "#ECF6F8";
    document.getElementById("text-selected").style.display = "none";
    document.getElementById("jandex").style.display = "none";
    document.getElementById("qiwi").style.display = "none";
    document.getElementById("alpha").style.display = "none";
    document.getElementById("visa").style.display = "none";
    document.getElementById("paypal").style.display = "block";
    document.getElementById("webmoney").style.display = "none";
    document.getElementById("sber").style.display = "none";
}
function paySelectWebmoney() {
    document.getElementById("svg-pay8").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text").style.color = "#3c4a69";
    document.getElementById("pay-elem8").style.background = "#ECF6F8";
    document.getElementById("text-selected").style.display = "none";
    document.getElementById("jandex").style.display = "none";
    document.getElementById("qiwi").style.display = "none";
    document.getElementById("alpha").style.display = "none";
    document.getElementById("visa").style.display = "none";
    document.getElementById("paypal").style.display = "none";
    document.getElementById("sber").style.display = "none";
    document.getElementById("webmoney").style.display = "block";
}
function paySelectSber() {
    document.getElementById("svg-pay8").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text").style.color = "#3c4a69";
    document.getElementById("pay-elem8").style.background = "#ECF6F8";
    document.getElementById("text-selected").style.display = "none";
    document.getElementById("jandex").style.display = "none";
    document.getElementById("qiwi").style.display = "none";
    document.getElementById("alpha").style.display = "none";
    document.getElementById("visa").style.display = "none";
    document.getElementById("paypal").style.display = "none";
    document.getElementById("webmoney").style.display = "none";
    document.getElementById("sber").style.display = "block";
}
function paySelectNoCash() {
    document.getElementById("svg-pay8").style.fill = "#C7DEE1";
    document.getElementById("pay-elem-text").style.color = "#C7DEE1";
    document.getElementById("pay-elem8").style.background = "linear-gradient(21.59deg, #483156 0%, #39516E 80.3%)";
    document.getElementById("jandex").style.display = "none";
    document.getElementById("qiwi").style.display = "none";
    document.getElementById("alpha").style.display = "none";
    document.getElementById("visa").style.display = "none";
    document.getElementById("paypal").style.display = "none";
    document.getElementById("webmoney").style.display = "none";
    document.getElementById("sber").style.display = "none";
    document.getElementById("text-selected").style.display = "flex";
}


//////////////
function payFirstoverUk() {
    document.getElementById("svg-pay1-uk").style.display = "block";

}
function payFirstoutUk() {
    document.getElementById("svg-pay1-uk").style.display = "none";

}

function payQiwioverUk() {
    document.getElementById("svg-pay2-uk").style.display = "block";

}
function payQiwioutUk() {
    document.getElementById("svg-pay2-uk").style.display = "none";

}
function payAlphaoverUk() {
    document.getElementById("svg-pay3-uk").style.fill = "#C7DEE1"

}
function payAlphaoutUk() {
    document.getElementById("svg-pay3-uk").style.fill = "#3c4a69";

}
function payAlphaoverUk() {
    document.getElementById("svg-pay3-uk").style.fill = "#C7DEE1"

}
function payAlphaoutUk() {
    document.getElementById("svg-pay3-uk").style.fill = "#3c4a69";

}
function payVisaoverUk() {
    document.getElementById("svg-pay4master-uk").style.display = "block";
    document.getElementById("svg-pay4visa-uk").style.display = "block";

}
function payVisaoutUk() {
    document.getElementById("svg-pay4visa-uk").style.display = "none";
    document.getElementById("svg-pay4master-uk").style.display = "none";

}
function payPayPaloverUk() {
    document.getElementById("svg-pay5-uk").style.display = "block";


}
function payPayPaloutUk() {
    document.getElementById("svg-pay5-uk").style.display = "none";
}
function payWebmoneyoverUk() {
    document.getElementById("svg-pay6-uk").style.display = "block";
}
function payWebmoneyoutUk() {
    document.getElementById("svg-pay6-uk").style.display = "none";
}
function paySelectUk() {
    document.getElementById("svg-pay8-uk").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text-uk").style.color = "#3c4a69";
    document.getElementById("pay-elem8-uk").style.background = "#ECF6F8";
    document.getElementById("qiwi-uk").style.display = "none";
    document.getElementById("text-selected-uk").style.display = "none";
    document.getElementById("jandex-uk").style.display = "block";
    document.getElementById("visa-uk").style.display = "none";
    document.getElementById("paypal-uk").style.display = "none";
    document.getElementById("webmoney-uk").style.display = "none";

}
function paySelectQiwiUk() {
    document.getElementById("svg-pay8-uk").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text-uk").style.color = "#3c4a69";
    document.getElementById("pay-elem8-uk").style.background = "#ECF6F8";
    document.getElementById("text-selected-uk").style.display = "none";
    document.getElementById("jandex-uk").style.display = "none";
    document.getElementById("paypal-uk").style.display = "none";
    document.getElementById("visa-uk").style.display = "none";
    document.getElementById("webmoney-uk").style.display = "none";
    document.getElementById("qiwi-uk").style.display = "block";
    document.getElementById("qiwi-img-uk").style.width = "220px";
}

function paySelectVisaUk() {
    document.getElementById("svg-pay8-uk").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text-uk").style.color = "#3c4a69";
    document.getElementById("pay-elem8-uk").style.background = "#ECF6F8";
    document.getElementById("text-selected-uk").style.display = "none";
    document.getElementById("jandex-uk").style.display = "none";
    document.getElementById("qiwi-uk").style.display = "none";
    document.getElementById("paypal-uk").style.display = "none";
    document.getElementById("webmoney-uk").style.display = "none";
    document.getElementById("visa-uk").style.display = "block";
}
function paySelectPayPalUk() {
    document.getElementById("svg-pay8-uk").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text-uk").style.color = "#3c4a69";
    document.getElementById("pay-elem8-uk").style.background = "#ECF6F8";
    document.getElementById("text-selected-uk").style.display = "none";
    document.getElementById("jandex-uk").style.display = "none";
    document.getElementById("qiwi-uk").style.display = "none";
    document.getElementById("visa-uk").style.display = "none";
    document.getElementById("paypal-uk").style.display = "block";
    document.getElementById("webmoney-uk").style.display = "none";

}
function paySelectWebmoneyUk() {
    document.getElementById("svg-pay8-uk").style.fill = "#3c4a69";
    document.getElementById("pay-elem-text-uk").style.color = "#3c4a69";
    document.getElementById("pay-elem8-uk").style.background = "#ECF6F8";
    document.getElementById("text-selected-uk").style.display = "none";
    document.getElementById("jandex-uk").style.display = "none";
    document.getElementById("qiwi-uk").style.display = "none";
    document.getElementById("visa-uk").style.display = "none";
    document.getElementById("paypal-uk").style.display = "none";
    document.getElementById("webmoney-uk").style.display = "block";
}

function paySelectNoCashUk() {
    document.getElementById("svg-pay8-uk").style.fill = "#C7DEE1";
    document.getElementById("pay-elem-text-uk").style.color = "#C7DEE1";
    document.getElementById("pay-elem8-uk").style.background = "linear-gradient(21.59deg, #483156 0%, #39516E 80.3%)";
    document.getElementById("text-selected-uk").style.display = "flex";
    document.getElementById("jandex-uk").style.display = "none";
    document.getElementById("qiwi-uk").style.display = "none";
    document.getElementById("visa-uk").style.display = "none";
    document.getElementById("paypal-uk").style.display = "none";
    document.getElementById("webmoney-uk").style.display = "none";
}

//player for speakers
