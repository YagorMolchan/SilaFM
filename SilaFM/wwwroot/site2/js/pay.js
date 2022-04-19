/*window.onscroll = function () { scrollFunction() };
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
}*/

document.addEventListener('play', function(e){
  var audios = document.getElementsByTagName('audio');
  for(var i = 0, len = audios.length; i < len;i++){
      if(audios[i] != e.target){
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