
$(document).ready(function(){
    $("#menu").on("click", "a", function (event) {
      event.preventDefault();
      var id = $(this).attr('href'),
          top = $(id).offset().top - 70;
      $('body,html').animate({ scrollTop: top }, 1600);
    });
    
    $(".counter").counterUp({delay:10,time:1000})
    //popapChronometr
    var elements = $('.modal-overlay, .modal');
     
    $('.modal-btn').click(function(){
        elements.addClass('active');
    });
    
    $('.close-modal').click(function(){
        elements.removeClass('active');
    });
    //popup2Pagemeter
    var elementtsp = $('.modal-overlay-page, .modal-page');
     
    $('.modal-btn-page').click(function(){
        elementtsp.addClass('active-page');
    });
    
    $('.close-modal-page').click(function(){
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


    function mouseOver1() {
        document.getElementById("base-block1").style.color = "#C7DEE1";
        document.getElementById("base-text1").style.color = "#C7DEE1";
        document.getElementById("btn-base").style.display = "block";
        document.getElementById("base-svg1").style.display = "block";
        document.getElementById("cont-icon-svg1").style.fill = "#ECF6F8";
        document.getElementById("cont-icon-svg2").style.fill = "#ECF6F8";
        document.getElementById("cont-icon-svg3").style.fill = "#ECF6F8";
        document.getElementById("cont-icon-svg4").style.fill = "#ECF6F8";
      }
      
      function mouseOut1() {
        document.getElementById("base-block1").style.color = "#404263";
        document.getElementById("base-text1").style.color = "#404263";
        document.getElementById("btn-base").style.display = "none";
        document.getElementById("base-svg1").style.display = "none";
        document.getElementById("cont-icon-svg1").style.fill = "#404263";
        document.getElementById("cont-icon-svg2").style.fill = "#404263";
        document.getElementById("cont-icon-svg3").style.fill = "#404263";
        document.getElementById("cont-icon-svg4").style.fill = "#404263";
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
      document.getElementById("myNav").style.height = "700px";
      document.getElementById("Btn-home").style.opacity = "0";
      document.getElementById("slider-au").style.opacity = "0";
      document.getElementById("home-text").style.opacity = "0";
  }
  
  function closeNav() {
      document.getElementById("myNav").style.width = "0%";
      document.getElementById("Btn-home").style.opacity = "1";
      document.getElementById("slider-au").style.opacity = "1";
      document.getElementById("home-text").style.opacity = "1";
  
  }

  // slider

 
  function person1() {
    document.getElementById("person3").style.height = "319px";
    document.getElementById("person3").style.marginTop = "0";
    document.getElementById("person3").style.background = "url(../img/person3.png)";
    document.getElementById("person4").style.height = "319px";
    document.getElementById("person4").style.marginTop = "0";
    document.getElementById("person4").style.background = "url(../img/person4.png)";
    document.getElementById("person1").style.height = "519px";
    document.getElementById("person1").style.background = "url(../img/person1ch.png)";
    document.getElementById("person1").style.marginTop = "-200px";
    document.getElementById("change-info3").style.display = "none";
    document.getElementById("change-info1").style.display = "block";
    document.getElementById("change-info2").style.display = "none";
    document.getElementById("person2").style.height = "319px";
    document.getElementById("person2").style.background = "url(../img/person2.png)";
    document.getElementById("person2").style.marginTop = "0";
    document.getElementById("change-info4").style.display = "none";
  }
  function person2() {
    document.getElementById("person3").style.height = "319px";
    document.getElementById("person3").style.marginTop = "0";
    document.getElementById("person3").style.background = "url(../img/person3.png)";
    document.getElementById("person4").style.height = "319px";
    document.getElementById("person4").style.marginTop = "0";
    document.getElementById("person4").style.background = "url(../img/person4.png)";
    document.getElementById("person1").style.height = "319px";
    document.getElementById("person1").style.background = "url(../img/person1.png)";
    document.getElementById("person1").style.marginTop = "0";
    document.getElementById("person2").style.height = "519px";
    document.getElementById("person2").style.background = "url(../img/person2ch.png)";
    document.getElementById("person2").style.marginTop = "-200px";
    document.getElementById("change-info3").style.display = "none";
    document.getElementById("change-info1").style.display = "none";
    document.getElementById("change-info2").style.display = "block";
    document.getElementById("change-info4").style.display = "none";
  }
  function person3() {
    document.getElementById("person4").style.height = "319px";
    document.getElementById("person4").style.marginTop = "0";
    document.getElementById("person4").style.background = "url(../img/person4.png)";
    document.getElementById("person3").style.height = "519px";
    document.getElementById("person3").style.marginTop = "-200px";
    document.getElementById("person3").style.background = "url(../img/person3ch.png)";
    document.getElementById("person1").style.height = "319px";
    document.getElementById("person1").style.background = "url(../img/person1.png)";
    document.getElementById("person1").style.marginTop = "0";
    document.getElementById("person2").style.height = "319px";
    document.getElementById("person2").style.background = "url(../img/person2.png)";
    document.getElementById("person2").style.marginTop = "0";
    document.getElementById("change-info3").style.display = "block";
    document.getElementById("change-info1").style.display = "none";
    document.getElementById("change-info2").style.display = "none";
    document.getElementById("change-info4").style.display = "none";
  }
  function person4() {
    document.getElementById("person3").style.height = "319px";
    document.getElementById("person3").style.marginTop = "0";
    document.getElementById("person3").style.background = "url(../img/person3.png)";
    document.getElementById("person4").style.height = "519px";
    document.getElementById("person4").style.marginTop = "-200px";
    document.getElementById("person4").style.background = "url(../img/person4ch.png)";
    document.getElementById("person1").style.height = "319px";
    document.getElementById("person1").style.background = "url(../img/person1.png)";
    document.getElementById("person1").style.marginTop = "0";
    document.getElementById("person2").style.height = "319px";
    document.getElementById("person2").style.background = "url(../img/person2.png)";
    document.getElementById("person2").style.marginTop = "0";
    document.getElementById("change-info3").style.display = "none";
    document.getElementById("change-info1").style.display = "none";
    document.getElementById("change-info2").style.display = "none";
    document.getElementById("change-info4").style.display = "block";
  }
  function prev(){
   
     func2=person2;
  func2();
  }
   function next(){
    func4=person4;
 func4();
 }

  // for fixed left menu
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
            document.getElementById("menufixed").style.marginTop = "-720px";
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
 
  

   //preloader
  //  function loadData() {
  //   return new Promise((resolve, reject) => {
  //       setTimeout(resolve, 2000);
  //   })
  // }
  
  // loadData()
  //   .then(() => {
  //     let preloaderEl = document.getElementById('preloader');
  //     preloaderEl.classList.add('hidden');
  //     preloaderEl.classList.remove('visible');
  //   });
    