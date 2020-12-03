function openNav() {
  document.getElementById("myNav").style.width = "100%";
  document.getElementById("myNav").style.height = "560px";
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
