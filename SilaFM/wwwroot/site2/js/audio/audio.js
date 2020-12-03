
$(document).ready(function () {
    $("#menu").on("click", "a", function (event) {
        event.preventDefault();
        var id = $(this).attr('href'),
            top = $(id).offset().top - 70;
        $('body,html').animate({ scrollTop: top }, 1600);
    });

    $(".counter").counterUp({ delay: 10, time: 1000 })
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


});
//fonts
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
//
function mouseOver1() {
    document.getElementById("base-block1").style.color = "#C7DEE1";
    document.getElementById("base-text1").style.color = "#C7DEE1";
    document.getElementById("btn-audio-page").style.color = "#C7DEE1";
    document.getElementById("svg1").style.stroke = "#C7DEE1";
    document.getElementById("base-svg1").style.display = "block";
}
function mouseOut1() {
    document.getElementById("base-block1").style.color = "#404263";
    document.getElementById("base-text1").style.color = "#404263";
    document.getElementById("btn-audio-page").style.color = "#404263";
    document.getElementById("svg1").style.stroke = "#404263";
    document.getElementById("base-svg1").style.display = "none";
}

function mouseOver2() {
    document.getElementById("base-blockk2").style.color = "#C7DEE1";
    document.getElementById("base-text2").style.color = "#C7DEE1";
    document.getElementById("btn-audio-page2").style.color = "#C7DEE1";
    document.getElementById("svg2").style.stroke = "#C7DEE1";
    document.getElementById("base-svg2").style.display = "block";
}
function mouseOut2() {
    document.getElementById("base-blockk2").style.color = "#404263";
    document.getElementById("base-text2").style.color = "#404263";
    document.getElementById("btn-audio-page2").style.color = "#404263";
    document.getElementById("svg2").style.stroke = "#404263";
    document.getElementById("base-svg2").style.display = "none";
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

//burger menu
function openNav() {
    document.getElementById("myNav").style.width = "100%";
    document.getElementById("myNav").style.height = "500px";
    document.getElementById("menufixed").style.zIndex = "0";
    document.getElementById("Btn-home").style.opacity = "0";
    document.getElementById("slider-au").style.opacity = "0";
    document.getElementById("home-text").style.opacity = "0";
}

function closeNav() {
    document.getElementById("myNav").style.width = "0%";
    document.getElementById("menufixed").style.zIndex = "1";
    document.getElementById("Btn-home").style.opacity = "1";
    document.getElementById("slider-au").style.opacity = "1";
    document.getElementById("home-text").style.opacity = "1";

}
// for fixed left menu
// window.onscroll = function () { scrollFunction() };
// function scrollFunction() {
//     if (document.documentElement.scrollTop > 800) {
//         document.getElementById("menufixed").style.position = "fixed";
//         document.getElementById("menufixed").style.marginTop = "-1100px";
//         var mql = window.matchMedia('all and (min-height: 400px)');
//         if (mql.matches) {
//           document.getElementById("menufixed").style.marginTop = "-850px";
//         } 
//         var mql = window.matchMedia('all and (min-height: 600px)');
//         if (mql.matches) {
//           document.getElementById("menufixed").style.marginTop = "-1060px";
//         } 
//         var mql = window.matchMedia('all and (max-height: 667px)');
//         if (mql.matches) {
//           document.getElementById("menufixed").style.marginTop = "-1060px";
//         } 
//         var mql = window.matchMedia('all and (max-width: 470px)');
//         if (mql.matches) {
//           document.getElementById("menufixed").style.marginTop = "-790px";
//         } 

//     } else {
//         document.getElementById("menufixed").style.position = "absolute";
//         document.getElementById("menufixed").style.marginTop = "0px";
//     }
// }
window.onscroll = function () { scrollFunction() };
function scrollFunction() {
    if (document.documentElement.scrollTop > 750) {
        document.getElementById("menufixed").style.position = "fixed";
        document.getElementById("menufixed").style.marginTop = "-390px";
        var mql = window.matchMedia('all and (max-height: 1522px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-450px";
        }
        var mql = window.matchMedia('all and (max-height: 1322px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-560px";
        }
        var mql = window.matchMedia('all and (max-height: 1104px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-660px";
        }
        var mql = window.matchMedia('all and (max-height: 922px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-760px";
        }
        var mql = window.matchMedia('all and (max-height: 601px)');
        if (mql.matches) {
            document.getElementById("menufixed").style.marginTop = "-790px";
        }

    } else {
        document.getElementById("menufixed").style.position = "absolute";
        document.getElementById("menufixed").style.marginTop = "0px";
    }




}
//menu-speaker-page

//playlist
now_playing = document.querySelector(".now-playing");
playpause_btn = document.querySelector(".playpause-track");
playrepeat_btn = document.querySelector(".playrepeat-track");

seek_slider = document.querySelector(".seek_slider");
volume_slider = document.querySelector(".volume_slider");

track_index = 0;
isPlaying = false;
updateTimer;
curr_track = document.createElement('audio');
repeat = document.createElement('audio');

track_list = [
    {
        path: "/site2/mp3/music1.mp3"
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
    playpause_btn.innerHTML = '<img src="/site2/img/icon-stop.png">';
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
    playpause_btn.innerHTML = '<img src="/site2/img/play.png">';
}

function seekTo() {
    seekto = curr_track.duration * (seek_slider.value / 100);
    curr_track.currentTime = seekto;


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

//preloader
function loadData() {
    return new Promise((resolve, reject) => {
        setTimeout(resolve, 2000);
    })
}

loadData()
    .then(() => {
        let preloaderEl = document.getElementById('preloader');
        preloaderEl.classList.add('hidden');
        preloaderEl.classList.remove('visible');
    });


//first-items player
let now_playing1 = document.querySelector(".now-playing1");
let playpause_btn1 = document.querySelector(".playpause-track1");
let playrepeat_btn1 = document.querySelector(".playrepeat-track1");

let seek_slider1 = document.querySelector(".seek_slider1");
let volume_slider1 = document.querySelector(".volume_slider1");

let track_index1 = 0;
let isPlaying1 = false;
let updateTimer1;
let curr_track1 = document.createElement('audio');
let repeat1 = document.createElement('audio');

let track_list1 = [
    {
        path: "/site2/mp3/music1.mp3"
    }
];

function loadTrack1(track_index1) {
    resetValues1();
    curr_track1.src = track_list1[track_index1].path;
    curr_track1.load();
    updateTimer1 = setInterval(seekUpdate1, 1000);
}
function resetValues1() {
    seek_slider1.value = 0;
}

function playpauseTrack1() {
    if (!isPlaying1) playTrack1();
    else pauseTrack1();
}
function playTrack1() {
    curr_track1.play();
    isPlaying1 = true;
    playpause_btn1.innerHTML = '<img src="/site2/img/icon-stop.png">';
}

var repIcon = document.querySelector('.repeat')
function handleRepeat() {
    if (curr_track1.loop == true) {
        curr_track1.loop = false
        repIcon.classList.toggle('active')
    }
    else {
        curr_track1.loop = true
        repIcon.classList.toggle('active')
    }
}
function prevTrack1() {
    if (track_index1 > 0)
        track_index1 -= 1;
    else track_index1 = track_list1.length;
    loadTrack1(track_index1);
    playTrack1();
}
function pauseTrack1() {
    curr_track1.pause();
    isPlaying1 = false;
    playpause_btn1.innerHTML = '<img src="/site2/img/play.png">';
}

function seekTo1() {
    seekto1 = curr_track1.duration * (seek_slider1.value / 100);
    curr_track1.currentTime = seekto1;


}
function setVolume1() {
    curr_track1.volume = volume_slider1.value / 100;
}

function seekUpdate1() {
    let seekPosition1 = 0;

    if (!isNaN(curr_track1.duration)) {
        seekPosition1 = curr_track1.currentTime * (100 / curr_track1.duration);
        seek_slider1.value = seekPosition1;
    }
}
loadTrack1(track_index1);


