var galleryRight = new Swiper('.image-slider', {
    loop: true,
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
    },
    slidesPerView: 1,
    pagination: {
        el: '.right-slide-item'
    }
});
$('.images-slide').hover(function () {
    $(this).find("img:first").fadeToggle();
});


$(document).ready(function () {
    $("#menu").on("click", "a", function (event) {
        event.preventDefault();
        var id = $(this).attr('href'),
            top = $(id).offset().top - 70;
        $('body,html').animate({scrollTop: top}, 1600);
    });

    $(".counter").counterUp({delay: 10, time: 1000})
    //popapChronometr
    var elements = $('.modal-overlay, .modal');

    $('.modal-btn').click(function () {
        elements.addClass('active');
    });

    $('.close-modal').click(function () {
        elements.removeClass('active');
    });
    //popup2Pagemeter
    var elementtsp = $('.modal-overlay-page, .modal-page');

    $('.modal-btn-page').click(function () {
        elementtsp.addClass('active-page');
    });

    $('.close-modal-page').click(function () {
        elementtsp.removeClass('active-page');
    });
    //calcu
    var elementtss = $('.modal-overlay-calculator, .modal-calculator');

    $('.modal-btn-calculator').click(function () {
        elementtss.addClass('active-calculator');
    });

    $('.close-modal-calculator').click(function () {
        elementtss.removeClass('active-calculator');
    });
});
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


function prev() {

    func2 = person2;
    func2();
}

function next() {
    func4 = person4;
    func4();
}

document.addEventListener('play', function (e) {
    var audios = document.getElementsByTagName('audio');
    for (var i = 0, len = audios.length; i < len; i++) {
        if (audios[i] != e.target) {
            audios[i].pause();
        }
    }
}, true);

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