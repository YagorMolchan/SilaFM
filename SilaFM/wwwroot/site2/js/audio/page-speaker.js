
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
    var elementts = $('.modal-overlay-page, .modal-page');
     
    $('.modal-btn-page').click(function(){
        elementts.addClass('active-page');
    });
    
    $('.close-modal-page').click(function(){
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
      document.getElementById("base-block1").style.color= "#C7DEE1";
      document.getElementById("base-text1").style.color= "#C7DEE1";
      document.getElementById("btn-audio-page").style.color= "#C7DEE1";
      document.getElementById("svg1").style.stroke= "#C7DEE1";
      document.getElementById("base-svg1").style.display= "block";
    }
    function mouseOut1() {
      document.getElementById("base-block1").style.color = "#404263";
      document.getElementById("base-text1").style.color = "#404263";
      document.getElementById("btn-audio-page").style.color= "#404263";
      document.getElementById("svg1").style.stroke= "#404263";
      document.getElementById("base-svg1").style.display= "none";
    }
  
    function mouseOver2() {
      document.getElementById("base-blockk2").style.color= "#C7DEE1";
      document.getElementById("base-text2").style.color= "#C7DEE1";
      document.getElementById("btn-audio-page2").style.color= "#C7DEE1";
      document.getElementById("svg2").style.stroke= "#C7DEE1";
      document.getElementById("base-svg2").style.display= "block";
    }
    function mouseOut2() {
      document.getElementById("base-blockk2").style.color = "#404263";
      document.getElementById("base-text2").style.color = "#404263";
      document.getElementById("btn-audio-page2").style.color= "#404263";
      document.getElementById("svg2").style.stroke= "#404263";
      document.getElementById("base-svg2").style.display= "none";
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
      document.getElementById("menufixed").style.zIndex = "0";
      document.getElementById("Btn-home").style.opacity = "0";
      document.getElementById("slider-au").style.opacity = "0";
      document.getElementById("home-text").style.opacity = "0";
  }
  
  function closeNav() {
    document.getElementById("menufixed").style.zIndex = "1";
      document.getElementById("myNav").style.width = "0%";
      document.getElementById("Btn-home").style.opacity = "1";
      document.getElementById("slider-au").style.opacity = "1";
      document.getElementById("home-text").style.opacity = "1";
  
  }

  window.onscroll = function () { scrollFunction() };
    function scrollFunction() {
        if (document.documentElement.scrollTop > 400) {
            document.getElementById("menufixed").style.position = "fixed";
            document.getElementById("menufixed").style.marginTop = "-390px";
            var mql = window.matchMedia('all and (max-height: 1522px)');
            if (mql.matches) {
              document.getElementById("menufixed").style.marginTop = "-450px";
            } 
            var mql = window.matchMedia('all and (max-height: 1322px)');
            if (mql.matches) {
              document.getElementById("menufixed").style.marginTop = "-460px";
            } 
            var mql = window.matchMedia('all and (max-height: 1104px)');
            if (mql.matches) {
              document.getElementById("menufixed").style.marginTop = "-500px";
            } 
            var mql = window.matchMedia('all and (max-height: 922px)');
            if (mql.matches) {
              document.getElementById("menufixed").style.marginTop = "-550px";
            } 
            var mql = window.matchMedia('all and (max-height: 601px)');
            if (mql.matches) {
              document.getElementById("menufixed").style.marginTop = "-580px";
            } 
           
        } else {
            document.getElementById("menufixed").style.position = "absolute";
            document.getElementById("menufixed").style.marginTop = "0px";
        }
  
  
  
        
    }
   //menu-speaker-page
  
  //playlist
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
      path: "../mp3/music1.mp3"
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
    playpause_btn.innerHTML = '<img src="../img/icon-stop.png">';
  }
  function playTrackRepeat() {
  curr_track.loop=true;
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
    playpause_btn.innerHTML = '<img src="../img/play.png">';
  }
  
  function seekTo() {
    seekto = curr_track.duration * (seek_slider.value / 100);
    curr_track.currentTime = seekto;
   
  
  }
  function setVolume() {
    curr_track.volume = volume_slider.value / 100;
  }
  // volume white
  document.querySelectorAll(".__range").forEach(function(el) {       
  el.oninput =function(){            
  let valPercent = (el.valueAsNumber  - parseInt(el.min)) / 
                  (parseInt(el.max) - parseInt(el.min));
  let style = 'background-image: -webkit-gradient(linear, 0% 0%, 100% 0%, color-stop('+ valPercent+', white), color-stop('+ valPercent+',#33556f));';
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
      path: "../mp3/music1.mp3"
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
    playpause_btn1.innerHTML = '<img src="../img/icon-stop.png">';
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
    playpause_btn1.innerHTML = '<img src="../img/play.png">';
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
  
  
  
    //second-items player
    let now_playing2 = document.querySelector(".now-playing2");
    let playpause_btn2 = document.querySelector(".playpause-track2");
    let playrepeat_btn2 = document.querySelector(".playrepeat-track2");
    
    let seek_slider2 = document.querySelector(".seek_slider2");
    let volume_slider2 = document.querySelector(".volume_slider2");
    
    let track_index2 = 0;
    let isPlaying2 = false;
    let updateTimer2;
    let curr_track2 = document.createElement('audio');
    let repeat2 = document.createElement('audio');
    
    let track_list2 = [
      {
        path: "../mp3/music1.mp3"
      }
    ];
    
    function loadTrack2(track_index2) {
      resetValues2();
      curr_track2.src = track_list2[track_index2].path;
      curr_track2.load();
      updateTimer2 = setInterval(seekUpdate2, 1000);
    }
    function resetValues2() {
      seek_slider2.value = 0;
    }
    
    function playpauseTrack2() {
      if (!isPlaying2) playTrack2();
      else pauseTrack2();
    }
    function playTrack2() {
      curr_track2.play();
      isPlaying2 = true;
      playpause_btn2.innerHTML = '<img src="../img/icon-stop.png">';
    }
   
    var repIcon2 = document.querySelector('.repeat2')
    function handleRepeat2() {
        if (curr_track2.loop == true) {
          curr_track2.loop = false
            repIcon2.classList.toggle('active2')
        }
        else {
          curr_track2.loop = true
            repIcon2.classList.toggle('active2')
        }
    }
    function prevTrack2() {
    if (track_index2 > 0)
      track_index2 -= 1;
    else track_index2 = track_list2.length;
    loadTrack2(track_index2);
    playTrack2();
    }
    function pauseTrack2() {
      curr_track2.pause();
      isPlaying2 = false;
      playpause_btn2.innerHTML = '<img src="../img/play.png">';
    }
    
    function seekTo2() {
      seekto2 = curr_track2.duration * (seek_slider2.value / 100);
      curr_track2.currentTime = seekto2;
      
    
    }
    function setVolume2() {
      curr_track2.volume = volume_slider2.value / 100;
    }
    function seekUpdate2() {
      let seekPosition2 = 0;
    
      if (!isNaN(curr_track2.duration)) {
        seekPosition2 = curr_track2.currentTime * (100 / curr_track2.duration);
        seek_slider2.value = seekPosition2;
      }
    }
    loadTrack2(track_index2);
  
  
     //third-items player
     let now_playing3 = document.querySelector(".now-playing3");
     let playpause_btn3 = document.querySelector(".playpause-track3");
     let playrepeat_btn3 = document.querySelector(".playrepeat-track3");
     
     let seek_slider3 = document.querySelector(".seek_slider3");
     let volume_slider3 = document.querySelector(".volume_slider3");
     
     let track_index3 = 0;
     let isPlaying3 = false;
     let updateTimer3;
     let curr_track3 = document.createElement('audio');
     let repeat3= document.createElement('audio');
     
     let track_list3 = [
       {
         path: "../mp3/music1.mp3"
       }
     ];
     
     function loadTrack3(track_index3) {
       resetValues3();
       curr_track3.src = track_list3[track_index3].path;
       curr_track3.load();
       updateTimer3 = setInterval(seekUpdate3, 1000);
     }
     function resetValues3() {
       seek_slider3.value = 0;
     }
     
     function playpauseTrack3() {
       if (!isPlaying3) playTrack3();
       else pauseTrack3();
     }
     function playTrack3() {
       curr_track3.play();
       isPlaying3 = true;
       playpause_btn3.innerHTML = '<img src="../img/icon-stop.png">';
     }
    
     var repIcon3 = document.querySelector('.repeat3')
     function handleRepeat3() {
         if (curr_track3.loop == true) {
           curr_track3.loop = false
             repIcon3.classList.toggle('active3')
         }
         else {
           curr_track3.loop = true
             repIcon3.classList.toggle('active3')
         }
     }
     function prevTrack3() {
      if (track_index3 > 0)
        track_index3 -= 1;
      else track_index3 = track_list3.length;
      loadTrack3(track_index3);
      playTrack3();
      }
     function pauseTrack3() {
       curr_track3.pause();
       isPlaying3 = false;
       playpause_btn3.innerHTML = '<img src="../img/play.png">';
     }
     
     function seekTo3() {
       seekto3 = curr_track3.duration * (seek_slider3.value / 100);
       curr_track3.currentTime = seekto3;
       
     
     }
     function setVolume3() {
       curr_track3.volume = volume_slider3.value / 100;
     }
  
     function seekUpdate3() {
       let seekPosition3 = 0;
     
       if (!isNaN(curr_track3.duration)) {
         seekPosition3 = curr_track3.currentTime * (100 / curr_track3.duration);
         seek_slider3.value = seekPosition3;
       }
     }
     loadTrack3(track_index3);
  
      //four-items player
      let now_playing4 = document.querySelector(".now-playing4");
      let playpause_btn4 = document.querySelector(".playpause-track4");
      let playrepeat_btn4 = document.querySelector(".playrepeat-track4");
      
      let seek_slider4 = document.querySelector(".seek_slider4");
      let volume_slider4 = document.querySelector(".volume_slider4");
      
      let track_index4 = 0;
      let isPlaying4 = false;
      let updateTimer4;
      let curr_track4 = document.createElement('audio');
      let repeat4= document.createElement('audio');
      
      let track_list4 = [
        {
          path: "../mp3/music1.mp3"
        }
      ];
      
      function loadTrack4(track_index4) {
        resetValues4();
        curr_track4.src = track_list4[track_index4].path;
        curr_track4.load();
        updateTimer4 = setInterval(seekUpdate4, 1000);
      }
      function resetValues4() {
        seek_slider4.value = 0;
      }
      
      function playpauseTrack4() {
        if (!isPlaying4) playTrack4();
        else pauseTrack4();
      }
      function playTrack4() {
        curr_track4.play();
        isPlaying4 = true;
        playpause_btn4.innerHTML = '<img src="../img/icon-stop.png">';
      }
     
      var repIcon4 = document.querySelector('.repeat4')
      function handleRepeat4() {
          if (curr_track4.loop == true) {
            curr_track4.loop = false
              repIcon4.classList.toggle('active4')
          }
          else {
            curr_track4.loop = true
              repIcon4.classList.toggle('active4')
          }
      }
   
      function pauseTrack4() {
        curr_track4.pause();
        isPlaying4 = false;
        playpause_btn4.innerHTML = '<img src="../img/play.png">';
      }
      
      function seekTo4() {
        seekto4 = curr_track4.duration * (seek_slider4.value / 100);
        curr_track4.currentTime = seekto4;
        
      
      }
      function setVolume4() {
        curr_track4.volume = volume_slider4.value / 100;
      }
   
      function seekUpdate4() {
        let seekPosition4 = 0;
      
        if (!isNaN(curr_track4.duration)) {
          seekPosition4 = curr_track4.currentTime * (100 / curr_track4.duration);
          seek_slider4.value = seekPosition4;
        }
      }
      loadTrack4(track_index4);
      //five-items player
      let now_playing5 = document.querySelector(".now-playing5");
      let playpause_btn5 = document.querySelector(".playpause-track5");
      let playrepeat_btn5 = document.querySelector(".playrepeat-track5");
      
      let seek_slider5 = document.querySelector(".seek_slider5");
      let volume_slider5 = document.querySelector(".volume_slider5");
      
      let track_index5 = 0;
      let isPlaying5 = false;
      let updateTimer5;
      let curr_track5 = document.createElement('audio');
      let repeat5= document.createElement('audio');
      
      let track_list5 = [
        {
          path: "../mp3/music1.mp3"
        }
      ];
      
      function loadTrack5(track_index5) {
        resetValues5();
        curr_track5.src = track_list5[track_index5].path;
        curr_track5.load();
        updateTimer5 = setInterval(seekUpdate5, 1000);
      }
      function resetValues5() {
        seek_slider5.value = 0;
      }
      
      function playpauseTrack5() {
        if (!isPlaying5) playTrack5();
        else pauseTrack5();
      }
      function playTrack5() {
        curr_track5.play();
        isPlaying5 = true;
        playpause_btn5.innerHTML = '<img src="../img/icon-stop.png">';
      }
     
      var repIcon5 = document.querySelector('.repeat5')
      function handleRepeat5() {
          if (curr_track5.loop == true) {
            curr_track5.loop = false
              repIcon5.classList.toggle('active5')
          }
          else {
            curr_track5.loop = true
              repIcon5.classList.toggle('active5')
          }
      }
   
      function pauseTrack5() {
        curr_track5.pause();
        isPlaying5 = false;
        playpause_btn5.innerHTML = '<img src="../img/play.png">';
      }
      
      function seekTo5() {
        seekto5 = curr_track5.duration * (seek_slider5.value / 100);
        curr_track5.currentTime = seekto5;
        
      
      }
      function setVolume5() {
        curr_track5.volume = volume_slider5.value / 100;
      }
   
      function seekUpdate5() {
        let seekPosition5 = 0;
      
        if (!isNaN(curr_track5.duration)) {
          seekPosition5 = curr_track5.currentTime * (100 / curr_track5.duration);
          seek_slider5.value = seekPosition5;
        }
      }
      loadTrack5(track_index5);
  
      //six-items player
      let now_playing6 = document.querySelector(".now-playing6");
      let playpause_btn6 = document.querySelector(".playpause-track6");
      let playrepeat_btn6 = document.querySelector(".playrepeat-track6");
      
      let seek_slider6 = document.querySelector(".seek_slider6");
      let volume_slider6 = document.querySelector(".volume_slider6");
      
      let track_index6 = 0;
      let isPlaying6 = false;
      let updateTimer6;
      let curr_track6 = document.createElement('audio');
      let repeat6= document.createElement('audio');
      
      let track_list6 = [
        {
          path: "../mp3/music1.mp3"
        }
      ];
      
      function loadTrack6(track_index6) {
        resetValues6();
        curr_track6.src = track_list6[track_index6].path;
        curr_track6.load();
        updateTimer6 = setInterval(seekUpdate6, 1000);
      }
      function resetValues6() {
        seek_slider6.value = 0;
      }
      
      function playpauseTrack6() {
        if (!isPlaying6) playTrack6();
        else pauseTrack6();
      }
      function playTrack6() {
        curr_track6.play();
        isPlaying6 = true;
        playpause_btn6.innerHTML = '<img src="../img/icon-stop.png">';
      }
     
      var repIcon6 = document.querySelector('.repeat6')
      function handleRepeat6() {
          if (curr_track6.loop == true) {
            curr_track6.loop = false
              repIcon6.classList.toggle('active6')
          }
          else {
            curr_track6.loop = true
              repIcon6.classList.toggle('active6')
          }
      }
   
      function pauseTrack6() {
        curr_track6.pause();
        isPlaying6 = false;
        playpause_btn6.innerHTML = '<img src="../img/play.png">';
      }
      
      function seekTo6() {
        seekto6 = curr_track6.duration * (seek_slider6.value / 100);
        curr_track6.currentTime = seekto6;
        
      
      }
      function setVolume6() {
        curr_track6.volume = volume_slider6.value / 100;
      }
   
      function seekUpdate6() {
        let seekPosition6 = 0;
      
        if (!isNaN(curr_track6.duration)) {
          seekPosition6 = curr_track6.currentTime * (100 / curr_track6.duration);
          seek_slider6.value = seekPosition6;
        }
      }
      loadTrack6(track_index6);
  
  
      //homervoise
   
  let now_playingh = document.querySelector(".now-playingh");
  let playpause_btnh = document.querySelector(".playpause-trackh");
  let playrepeat_btnh = document.querySelector(".playrepeat-trackh");
  
  let seek_sliderh = document.querySelector(".seek_sliderh");
  let volume_sliderh = document.querySelector(".volume_sliderh");
  
  let track_indexh = 0;
  let isPlayingh = false;
  let updateTimerh;
  let curr_trackh = document.createElement('audio');
  let repeath = document.createElement('audio');
  
  let track_listh = [
    {
      path: "../mp3/music1.mp3"
    }
  ];
  
  function loadTrackh(track_indexh) {
    resetValuesh();
    curr_trackh.src = track_listh[track_indexh].path;
    curr_trackh.load();
    updateTimerh = setInterval(seekUpdateh, 1000);
  }
  function resetValuesh() {
    seek_sliderh.value = 0;
  }
  
  function playpauseTrackh() {
    if (!isPlayingh) playTrackh();
    else pauseTrackh();
  }
  function playTrackh() {
    curr_trackh.play();
    isPlayingh = true;
    playpause_btnh.innerHTML = '<img src="../img/icon-stop.png">';
  }
  
  function prevTrackh() {
  if (track_indexh > 0)
    track_indexh -= 1;
  else track_indexh = track_listh.length;
  loadTrackh(track_indexh);
  playTrackh();
  }
  function pauseTrackh() {
    curr_trackh.pause();
    isPlayingh = false;
    playpause_btnh.innerHTML = '<img src="../img/play.png">';
  }
  
  function seekToh() {
    seektoh = curr_trackh.duration * (seek_sliderh.value / 100);
    curr_trackh.currentTime = seektoh;
    
  
  }
  function setVolumeh() {
    curr_trackh.volume = volume_sliderh.value / 100;
  }
  
  function seekUpdateh() {
    let seekPositionh = 0;
  
    if (!isNaN(curr_trackh.duration)) {
      seekPositionh = curr_trackh.currentTime * (100 / curr_trackh.duration);
      seek_sliderh.value = seekPositionh;
    }
  }
  loadTrackh(track_indexh);
  


  let playpause_btnJeck = document.querySelector(".playpause-trackJeck");
let seek_sliderJeck = document.querySelector(".seek_sliderJeck");
let track_indexJeck = 0;
let isPlayingJeck = false;
let curr_trackJeck = document.createElement('audio');

let track_listJeck = [
    {
        path: "../mp3/music1.mp3"
    }
];

function loadTrackJeck(track_indexJeck) {
    resetValuesJeck();
    curr_trackJeck.src = track_listJeck[track_indexJeck].path;
    curr_trackJeck.load();
    updateTimer = setInterval(seekUpdate, 1000);
}
function resetValuesJeck() {
    seek_sliderJeck.value = 0;
}

function playpauseTrackJeck() {
    if (!isPlayingJeck) playTrackJeck();
    else pauseTrackJeck();
}
function playTrackJeck() {
    curr_trackJeck.play();
    isPlayingJeck = true;
    playpause_btnJeck.innerHTML = '<img src="../img/icon-stop.png">';
}

function pauseTrackJeck() {
    curr_trackJeck.pause();
    isPlayingJeck = false;
    playpause_btnJeck.innerHTML = '<img src="../img/play.png">';
}
 

loadTrackJeck(track_indexJeck);

//Торето
let playpause_btnTor = document.querySelector(".playpause-trackTor");
let seek_sliderTor = document.querySelector(".seek_sliderTor");
let track_indexTor = 0;
let isPlayingTor = false;
let curr_trackTor = document.createElement('audio');

let track_listTor = [
    {
        path: "../mp3/music1.mp3"
    }
];

function loadTrackTor(track_indexTor) {
  resetValuesTor();
  curr_trackTor.src = track_listTor[track_indexTor].path;
  curr_trackTor.load();
  updateTimer = setInterval(seekUpdate, 1000);
}
function resetValuesTor() {
  seek_sliderTor.value = 0;
}

function playpauseTrackTor() {
  if (!isPlayingTor) playTrackTor();
  else pauseTrackTor();
}
function playTrackTor() {
  curr_trackTor.play();
  isPlayingTor = true;
  playpause_btnTor.innerHTML = '<img src="../img/icon-stop.png">';
}

function pauseTrackTor() {
  curr_trackTor.pause();
  isPlayingTor = false;
  playpause_btnTor.innerHTML = '<img src="../img/play.png">';
}

loadTrackTor(track_indexTor);

//shrek
let playpause_btnsh = document.querySelector(".playpause-tracksh");
let seek_slidersh = document.querySelector(".seek_slidersh");
let track_indexsh = 0;
let isPlayingsh = false;
let curr_tracksh= document.createElement('audio');

let track_listsh = [
    {
        path: "../mp3/music1.mp3"
    }
];

function loadTracksh(track_indexsh) {
  resetValuessh();
  curr_tracksh.src = track_listsh[track_indexsh].path;
  curr_tracksh.load();
  updateTimer = setInterval(seekUpdate, 1000);
}
function resetValuessh() {
  seek_slidersh.value = 0;
}

function playpauseTracksh() {
  if (!isPlayingsh) playTracksh();
  else pauseTracksh();
}
function playTracksh() {
  curr_tracksh.play();
  isPlayingsh = true;
  playpause_btnsh.innerHTML = '<img src="../img/icon-stop.png">';
}

function pauseTracksh() {
  curr_tracksh.pause();
  isPlayingsh = false;
  playpause_btnsh.innerHTML = '<img src="../img/play.png">';
}

loadTracksh(track_indexsh);
//kit
let playpause_btnKit = document.querySelector(".playpause-trackKit");
let seek_sliderKit = document.querySelector(".seek_sliderKit");
let track_indexKit = 0;
let isPlayingKit = false;
let curr_trackKit= document.createElement('audio');

let track_listKit = [
    {
        path: "../mp3/music1.mp3"
    }
];

function loadTrackKit(track_indexKit) {
  resetValuesKit();
  curr_trackKit.src = track_listKit[track_indexKit].path;
  curr_trackKit.load();
  updateTimer = setInterval(seekUpdate, 1000);
}
function resetValuesKit() {
  seek_sliderKit.value = 0;
}

function playpauseTrackKit() {
  if (!isPlayingKit) playTrackKit();
  else pauseTrackKit();
}
function playTrackKit() {
  curr_trackKit.play();
  isPlayingKit = true;
  playpause_btnKit.innerHTML = '<img src="../img/icon-stop.png">';
}

function pauseTrackKit() {
  curr_trackKit.pause();
  isPlayingKit = false;
  playpause_btnKit.innerHTML = '<img src="../img/play.png">';
}

loadTrackKit(track_indexKit);

