$(".custom-selects").each(function() {
  var classes = $(this).attr("class"),
      id      = $(this).attr("id"),
      name    = $(this).attr("name");
  var template =  '<div class="' + classes + '">';
      template += '<span class="custom-select-trigger">' + $(this).attr("placeholder") + '</span>';
      template += '<div class="custom-options">';
      $(this).find("option").each(function() {
        template += '<span class="custom-option ' + $(this).attr("class") + '" data-value="' + $(this).attr("value") + '">' + $(this).html() + '</span>';
      });
  template += '</div></div>';
  
  $(this).wrap('<div class="custom-select-wrapper"></div>');
  $(this).hide();
  $(this).after(template);
});
$(".custom-option:first-of-type").hover(function() {
  $(this).parents(".custom-options").addClass("option-hover");
}, function() {
  $(this).parents(".custom-options").removeClass("option-hover");
});
$(".custom-select-trigger").on("click", function() {
  $('html').one('click',function() {
    $(".custom-selects").removeClass("opened");
  });
  $(this).parents(".custom-selects").toggleClass("opened");
  event.stopPropagation();
});
$(".custom-option").on("click", function() {
  $(this).parents(".custom-select-wrapper").find("select").val($(this).data("value"));
  $(this).parents(".custom-options").find(".custom-option").removeClass("selection");
  $(this).addClass("selection");
  $(this).parents(".custom-selects").removeClass("opened");
  $(this).parents(".custom-selects").find(".custom-select-trigger").text($(this).text());
});
//popup OnlineCalculator
var elementtss = $('.modal-overlay-calculator, .modal-calculator');

$('.modal-btn-calculator').click(function () {
  elementtss.addClass('active-calculator');
});

$('.close-modal-calculator').click(function () {
  elementtss.removeClass('active-calculator');
});
var elementtss = $('.modal-overlay-speakers, .modal-speakers');

$('.modal-btn-speakers').click(function () {
  elementtss.addClass('active-speakers');
});

$('.close-modal-speakers').click(function () {
  elementtss.removeClass('active-speakers');
});
//make an order
var elementtsm = $('.modal-overlay-order, .modal-order');

$('.modal-btn-order').click(function () {
  elementtsm.addClass('active-order');
});

$('.close-modal-order').click(function () {
  elementtsm.removeClass('active-order');
});

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


  function openNav() {
    document.getElementById("myNav").style.width = "100%";
    document.getElementById("myNav").style.height = "560px";
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
  playpause_btn1.innerHTML = '<img src="../img/table-stop.png">';
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
  playpause_btn1.innerHTML = '<img src="../img/table-play.png">';
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
    playpause_btn2.innerHTML = '<img src="../img/table-stop.png">';
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
    playpause_btn2.innerHTML = '<img src="../img/table-play.png">';
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
     playpause_btn3.innerHTML = '<img src="../img/table-stop.png">';
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
     playpause_btn3.innerHTML = '<img src="../img/table-play.png">';
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
      playpause_btn4.innerHTML = '<img src="../img/table-stop.png">';
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
      playpause_btn4.innerHTML = '<img src="../img/table-play.png">';
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
      playpause_btn5.innerHTML = '<img src="../img/table-stop.png">';
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
      playpause_btn5.innerHTML = '<img src="../img/table-play.png">';
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
      playpause_btn6.innerHTML = '<img src="../img/table-stop.png">';
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
      playpause_btn6.innerHTML = '<img src="../img/table-play.png">';
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
    //seven-items player
    let now_playing7 = document.querySelector(".now-playing7");
    let playpause_btn7 = document.querySelector(".playpause-track7");
    let playrepeat_btn7 = document.querySelector(".playrepeat-track7");
    
    let seek_slider7 = document.querySelector(".seek_slider7");
    let volume_slider7 = document.querySelector(".volume_slider7");
    
    let track_index7= 0;
    let isPlaying7 = false;
    let updateTimer7;
    let curr_track7 = document.createElement('audio');
    let repeat7= document.createElement('audio');
    
    let track_list7 = [
      {
        path: "../mp3/music1.mp3"
      }
    ];
    
    function loadTrack7(track_index7) {
      resetValues7();
      curr_track7.src = track_list7[track_index7].path;
      curr_track7.load();
      updateTimer7 = setInterval(seekUpdate7, 1000);
    }
    function resetValues7() {
      seek_slider7.value = 0;
    }
    
    function playpauseTrack7() {
      if (!isPlaying7) playTrack7();
      else pauseTrack7();
    }
    function playTrack7() {
      curr_track7.play();
      isPlaying7 = true;
      playpause_btn7.innerHTML = '<img src="../img/table-stop.png">';
    }
   
    var repIcon7 = document.querySelector('.repeat7')
    function handleRepeat7() {
        if (curr_track7.loop == true) {
          curr_track7.loop = false
            repIcon7.classList.toggle('active7')
        }
        else {
          curr_track7.loop = true
            repIcon7.classList.toggle('active7')
        }
    }
 
    function pauseTrack7() {
      curr_track7.pause();
      isPlaying7 = false;
      playpause_btn7.innerHTML = '<img src="../img/table-play.png">';
    }
    
    function seekTo7() {
      seekto7 = curr_track7.duration * (seek_slider7.value / 100);
      curr_track7.currentTime = seekto7;
      
    
    }
    function setVolume7() {
      curr_track7.volume = volume_slider7.value / 100;
    }
 
    function seekUpdate7() {
      let seekPosition7 = 0;
    
      if (!isNaN(curr_track7.duration)) {
        seekPosition7 = curr_track7.currentTime * (100 / curr_track7.duration);
        seek_slider7.value = seekPosition7;
      }
    }
    loadTrack7(track_index7);
        //eight-items player
        let now_playing8 = document.querySelector(".now-playing8");
        let playpause_btn8 = document.querySelector(".playpause-track8");
        let playrepeat_btn8 = document.querySelector(".playrepeat-track8");
        
        let seek_slider8= document.querySelector(".seek_slider8");
        let volume_slider8 = document.querySelector(".volume_slider8");
        
        let track_index8= 0;
        let isPlaying8 = false;
        let updateTimer8;
        let curr_track8 = document.createElement('audio');
        let repeat8= document.createElement('audio');
        
        let track_list8 = [
          {
            path: "../mp3/music1.mp3"
          }
        ];
        
        function loadTrack8(track_index8) {
          resetValues8();
          curr_track8.src = track_list8[track_index8].path;
          curr_track8.load();
          updateTimer8 = setInterval(seekUpdate8, 1000);
        }
        function resetValues8() {
          seek_slider8.value = 0;
        }
        
        function playpauseTrack8() {
          if (!isPlaying8) playTrack8();
          else pauseTrack8();
        }
        function playTrack8() {
          curr_track8.play();
          isPlaying8 = true;
          playpause_btn8.innerHTML = '<img src="../img/table-stop.png">';
        }
       
        var repIcon8 = document.querySelector('.repeat8')
        function handleRepeat8() {
            if (curr_track8.loop == true) {
              curr_track8.loop = false
                repIcon8.classList.toggle('active8')
            }
            else {
              curr_track8.loop = true
                repIcon8.classList.toggle('active8')
            }
        }
     
        function pauseTrack8() {
          curr_track8.pause();
          isPlaying8 = false;
          playpause_btn8.innerHTML = '<img src="../img/table-play.png">';
        }
        
        function seekTo8() {
          seekto8 = curr_track8.duration * (seek_slider8.value / 100);
          curr_track8.currentTime = seekto8;
          
        
        }
        function setVolume8() {
          curr_track8.volume = volume_slider8.value / 100;
        }
     
        function seekUpdate8() {
          let seekPosition8 = 0;
        
          if (!isNaN(curr_track8.duration)) {
            seekPosition8 = curr_track8.currentTime * (100 / curr_track8.duration);
            seek_slider8.value = seekPosition8;
          }
        }
        loadTrack8(track_index8);

   //nine-items player
      let now_playing9 = document.querySelector(".now-playing9");
      let playpause_btn9 = document.querySelector(".playpause-track9");
      let playrepeat_btn9 = document.querySelector(".playrepeat-track9");
      
      let seek_slider9= document.querySelector(".seek_slider9");
      let volume_slider9 = document.querySelector(".volume_slider9");
      
      let track_index9= 0;
      let isPlaying9 = false;
      let updateTimer9;
      let curr_track9 = document.createElement('audio');
      let repeat9= document.createElement('audio');
      
      let track_list9 = [
        {
          path: "../mp3/music1.mp3"
        }
      ];
      
      function loadTrack9(track_index9) {
        resetValues9();
        curr_track9.src = track_list9[track_index9].path;
        curr_track9.load();
        updateTimer9 = setInterval(seekUpdate9, 1000);
      }
      function resetValues9() {
        seek_slider9.value = 0;
      }
      
      function playpauseTrack9() {
        if (!isPlaying9) playTrack9();
        else pauseTrack9();
      }
      function playTrack9() {
        curr_track9.play();
        isPlaying9 = true;
        playpause_btn9.innerHTML = '<img src="../img/table-stop.png">';
      }
     
      var repIcon9 = document.querySelector('.repeat9')
      function handleRepeat9() {
          if (curr_track9.loop == true) {
            curr_track9.loop = false
              repIcon9.classList.toggle('active9')
          }
          else {
            curr_track9.loop = true
              repIcon9.classList.toggle('active9')
          }
      }
   
      function pauseTrack9() {
        curr_track9.pause();
        isPlaying9 = false;
        playpause_btn9.innerHTML = '<img src="../img/table-play.png">';
      }
      
      function seekTo9() {
        seekto9 = curr_track9.duration * (seek_slider9.value / 100);
        curr_track9.currentTime = seekto9;
        
      
      }
      function setVolume9() {
        curr_track9.volume = volume_slider9.value / 100;
      }
   
      function seekUpdate9() {
        let seekPosition9 = 0;
      
        if (!isNaN(curr_track9.duration)) {
          seekPosition9 = curr_track9.currentTime * (100 / curr_track9.duration);
          seek_slider9.value = seekPosition9;
        }
      }
      loadTrack9(track_index9);
//ten items
let now_playing10 = document.querySelector(".now-playing10");
let playpause_btn10 = document.querySelector(".playpause-track10");
let playrepeat_btn10 = document.querySelector(".playrepeat-track10");

let seek_slider10= document.querySelector(".seek_slider10");
let volume_slider10 = document.querySelector(".volume_slider10");

let track_index10= 0;
let isPlaying10 = false;
let updateTimer10;
let curr_track10 = document.createElement('audio');
let repeat10= document.createElement('audio');

let track_list10 = [
  {
    path: "../mp3/music1.mp3"
  }
];

function loadTrack10(track_index10) {
  resetValues10();
  curr_track10.src = track_list10[track_index10].path;
  curr_track10.load();
  updateTimer10 = setInterval(seekUpdate10, 1000);
}
function resetValues10() {
  seek_slider10.value = 0;
}

function playpauseTrack10() {
  if (!isPlaying10) playTrack10();
  else pauseTrack10();
}
function playTrack10() {
  curr_track10.play();
  isPlaying10 = true;
  playpause_btn10.innerHTML = '<img src="../img/table-stop.png">';
}

var repIcon10 = document.querySelector('.repeat10')
function handleRepeat10() {
    if (curr_track10.loop == true) {
      curr_track10.loop = false
        repIcon10.classList.toggle('active10')
    }
    else {
      curr_track10.loop = true
        repIcon10.classList.toggle('active10')
    }
}

function pauseTrack10() {
  curr_track10.pause();
  isPlaying10 = false;
  playpause_btn10.innerHTML = '<img src="../img/table-play.png">';
}

function seekTo10() {
  seekto10 = curr_track10.duration * (seek_slider10.value / 100);
  curr_track10.currentTime = seekto10;
  

}
function setVolume10() {
  curr_track10.volume = volume_slider10.value / 100;
}

function seekUpdate10() {
  let seekPosition10 = 0;

  if (!isNaN(curr_track10.duration)) {
    seekPosition10 = curr_track10.currentTime * (100 / curr_track10.duration);
    seek_slider10.value = seekPosition10;
  }
}
loadTrack10(track_index10);

//11 items
let now_playing11 = document.querySelector(".now-playing11");
let playpause_btn11 = document.querySelector(".playpause-track11");
let playrepeat_btn11 = document.querySelector(".playrepeat-track11");

let seek_slider11= document.querySelector(".seek_slider11");
let volume_slider11 = document.querySelector(".volume_slider11");

let track_index11= 0;
let isPlaying11 = false;
let updateTimer11;
let curr_track11 = document.createElement('audio');
let repeat11= document.createElement('audio');

let track_list11 = [
  {
    path: "../mp3/music1.mp3"
  }
];

function loadTrack11(track_index11) {
  resetValues11();
  curr_track11.src = track_list11[track_index11].path;
  curr_track11.load();
  updateTimer11 = setInterval(seekUpdate11, 1000);
}
function resetValues11() {
  seek_slider11.value = 0;
}

function playpauseTrack11() {
  if (!isPlaying11) playTrack11();
  else pauseTrack11();
}
function playTrack11() {
  curr_track11.play();
  isPlaying11 = true;
  playpause_btn11.innerHTML = '<img src="../img/table-stop.png">';
}

var repIcon11 = document.querySelector('.repeat11')
function handleRepeat11() {
    if (curr_track11.loop == true) {
      curr_track11.loop = false
        repIcon11.classList.toggle('active11')
    }
    else {
      curr_track11.loop = true
        repIcon11.classList.toggle('active11')
    }
}

function pauseTrack11() {
  curr_track11.pause();
  isPlaying11 = false;
  playpause_btn11.innerHTML = '<img src="../img/table-play.png">';
}

function seekTo11() {
  seekto11 = curr_track11.duration * (seek_slider11.value / 100);
  curr_track11.currentTime = seekto11;
  

}
function setVolume11() {
  curr_track11.volume = volume_slider11.value / 100;
}

function seekUpdate11() {
  let seekPosition11 = 0;

  if (!isNaN(curr_track11.duration)) {
    seekPosition11 = curr_track11.currentTime * (100 / curr_track11.duration);
    seek_slider11.value = seekPosition11;
  }
}
loadTrack11(track_index11);

//12items
let now_playing12 = document.querySelector(".now-playing12");
let playpause_btn12 = document.querySelector(".playpause-track12");
let playrepeat_btn12 = document.querySelector(".playrepeat-track12");

let seek_slider12= document.querySelector(".seek_slider12");
let volume_slider12 = document.querySelector(".volume_slider12");

let track_index12= 0;
let isPlaying12 = false;
let updateTimer12;
let curr_track12 = document.createElement('audio');
let repeat12= document.createElement('audio');

let track_list12 = [
  {
    path: "../mp3/music1.mp3"
  }
];

function loadTrack12(track_index12) {
  resetValues12();
  curr_track12.src = track_list12[track_index12].path;
  curr_track12.load();
  updateTimer12 = setInterval(seekUpdate12, 1000);
}
function resetValues12() {
  seek_slider12.value = 0;
}

function playpauseTrack12() {
  if (!isPlaying12) playTrack12();
  else pauseTrack12();
}
function playTrack12() {
  curr_track12.play();
  isPlaying12 = true;
  playpause_btn12.innerHTML = '<img src="../img/table-stop.png">';
}

var repIcon12 = document.querySelector('.repeat12')
function handleRepeat12() {
    if (curr_track12.loop == true) {
      curr_track12.loop = false
        repIcon12.classList.toggle('active12')
    }
    else {
      curr_track12.loop = true
        repIcon12.classList.toggle('active12')
    }
}

function pauseTrack12() {
  curr_track12.pause();
  isPlaying12 = false;
  playpause_btn12.innerHTML = '<img src="../img/table-play.png">';
}

function seekTo12() {
  seekto12 = curr_track12.duration * (seek_slider12.value / 100);
  curr_track12.currentTime = seekto12;
  

}
function setVolume12() {
  curr_track12.volume = volume_slider12.value / 100;
}

function seekUpdate12() {
  let seekPosition12 = 0;

  if (!isNaN(curr_track12.duration)) {
    seekPosition12 = curr_track12.currentTime * (100 / curr_track12.duration);
    seek_slider12.value = seekPosition12;
  }
}
loadTrack12(track_index12);

function speakerHover(){
  document.getElementById("speaker1").style.background = "#B6E1E8";
  document.getElementById("speaker2").style.background = "#B6E1E8";
  document.getElementById("speaker3").style.background = "#B6E1E8";
  document.getElementById("speaker4").style.background = "#B6E1E8";
  document.getElementById("speaker6").style.background = "#B6E1E8";
  document.getElementById("speaker5").style.background = "#B6E1E8";
  document.getElementById("speaker7").style.background = "#B6E1E8";
  document.getElementById("speaker8").style.background = "#B6E1E8";

}
function speakerOut(){
  document.getElementById("speaker1").style.background = "white";
  document.getElementById("speaker2").style.background = "white";
  document.getElementById("speaker3").style.background = "white";
  document.getElementById("speaker4").style.background = "white";
  document.getElementById("speaker5").style.background = "white";
  document.getElementById("speaker6").style.background = "white";
  document.getElementById("speaker7").style.background = "white";
  document.getElementById("speaker8").style.background = "white";

}
function speakerHover2(){
  document.getElementById("speaker1s").style.background = "#B6E1E8";
  document.getElementById("speaker2s").style.background = "#B6E1E8";
  document.getElementById("speaker3s").style.background = "#B6E1E8";
  document.getElementById("speaker4s").style.background = "#B6E1E8";
  document.getElementById("speaker6s").style.background = "#B6E1E8";
  document.getElementById("speaker5s").style.background = "#B6E1E8";
  document.getElementById("speaker7s").style.background = "#B6E1E8";
  document.getElementById("speaker8s").style.background = "#B6E1E8";
}
function speakerOut2(){
  document.getElementById("speaker1s").style.background = "white";
  document.getElementById("speaker2s").style.background = "white";
  document.getElementById("speaker3s").style.background = "white";
  document.getElementById("speaker5s").style.background = "white";
  document.getElementById("speaker6s").style.background = "white";
  document.getElementById("speaker4s").style.background = "white";
  document.getElementById("speaker7s").style.background = "white";
  document.getElementById("speaker8s").style.background = "white";
}
function speakerHover3(){
  document.getElementById("speaker1sp").style.background = "#B6E1E8";
  document.getElementById("speaker2sp").style.background = "#B6E1E8";
  document.getElementById("speaker3sp").style.background = "#B6E1E8";
  document.getElementById("speaker4sp").style.background = "#B6E1E8";
  document.getElementById("speaker6sp").style.background = "#B6E1E8";
  document.getElementById("speaker5sp").style.background = "#B6E1E8";
  document.getElementById("speaker7sp").style.background = "#B6E1E8";
  document.getElementById("speaker8sp").style.background = "#B6E1E8";
}
function speakerOut3(){
  document.getElementById("speaker1sp").style.background = "white";
  document.getElementById("speaker2sp").style.background = "white";
  document.getElementById("speaker3sp").style.background = "white";
  document.getElementById("speaker5sp").style.background = "white";
  document.getElementById("speaker6sp").style.background = "white";
  document.getElementById("speaker4sp").style.background = "white";
  document.getElementById("speaker7sp").style.background = "white";
  document.getElementById("speaker8sp").style.background = "white";
}
function speakerHover4(){
  document.getElementById("speaker1spe").style.background = "#B6E1E8";
  document.getElementById("speaker2spe").style.background = "#B6E1E8";
  document.getElementById("speaker3spe").style.background = "#B6E1E8";
  document.getElementById("speaker4spe").style.background = "#B6E1E8";
  document.getElementById("speaker6spe").style.background = "#B6E1E8";
  document.getElementById("speaker5spe").style.background = "#B6E1E8";
  document.getElementById("speaker7spe").style.background = "#B6E1E8";
  document.getElementById("speaker8spe").style.background = "#B6E1E8";
}
function speakerOut4(){
  document.getElementById("speaker1spe").style.background = "white";
  document.getElementById("speaker2spe").style.background = "white";
  document.getElementById("speaker3spe").style.background = "white";
  document.getElementById("speaker5spe").style.background = "white";
  document.getElementById("speaker6spe").style.background = "white";
  document.getElementById("speaker4spe").style.background = "white";
  document.getElementById("speaker7spe").style.background = "white";
  document.getElementById("speaker8spe").style.background = "white";
}
function speakerHover5(){
  document.getElementById("speaker1spea").style.background = "#B6E1E8";
  document.getElementById("speaker2spea").style.background = "#B6E1E8";
  document.getElementById("speaker3spea").style.background = "#B6E1E8";
  document.getElementById("speaker4spea").style.background = "#B6E1E8";
  document.getElementById("speaker6spea").style.background = "#B6E1E8";
  document.getElementById("speaker5spea").style.background = "#B6E1E8";
  document.getElementById("speaker7spea").style.background = "#B6E1E8";
  document.getElementById("speaker8spea").style.background = "#B6E1E8";
}
function speakerOut5(){
  document.getElementById("speaker1spea").style.background = "white";
  document.getElementById("speaker2spea").style.background = "white";
  document.getElementById("speaker3spea").style.background = "white";
  document.getElementById("speaker5spea").style.background = "white";
  document.getElementById("speaker6spea").style.background = "white";
  document.getElementById("speaker4spea").style.background = "white";
  document.getElementById("speaker7spea").style.background = "white";
  document.getElementById("speaker8spea").style.background = "white";
}
function speakerHover6(){
  document.getElementById("speakerelem1").style.background = "#B6E1E8";
  document.getElementById("speakerelem2").style.background = "#B6E1E8";
  document.getElementById("speakerelem3").style.background = "#B6E1E8";
  document.getElementById("speakerelem4").style.background = "#B6E1E8";
  document.getElementById("speakerelem5").style.background = "#B6E1E8";
  document.getElementById("speakerelem6").style.background = "#B6E1E8";
  document.getElementById("speakerelem7").style.background = "#B6E1E8";
  document.getElementById("speakerelem8").style.background = "#B6E1E8";
}
function speakerOut6(){
  document.getElementById("speakerelem1").style.background = "white";
  document.getElementById("speakerelem2").style.background = "white";
  document.getElementById("speakerelem3").style.background = "white";
  document.getElementById("speakerelem4").style.background = "white";
  document.getElementById("speakerelem5").style.background = "white";
  document.getElementById("speakerelem6").style.background = "white";
  document.getElementById("speakerelem7").style.background = "white";
  document.getElementById("speakerelem8").style.background = "white";
}
function speakerHover7(){
  document.getElementById("speakerelem1e").style.background = "#B6E1E8";
  document.getElementById("speakerelem2e").style.background = "#B6E1E8";
  document.getElementById("speakerelem3e").style.background = "#B6E1E8";
  document.getElementById("speakerelem4e").style.background = "#B6E1E8";
  document.getElementById("speakerelem5e").style.background = "#B6E1E8";
  document.getElementById("speakerelem6e").style.background = "#B6E1E8";
  document.getElementById("speakerelem7e").style.background = "#B6E1E8";
  document.getElementById("speakerelem8e").style.background = "#B6E1E8";
}
function speakerOut7(){
  document.getElementById("speakerelem1e").style.background = "white";
  document.getElementById("speakerelem2e").style.background = "white";
  document.getElementById("speakerelem3e").style.background = "white";
  document.getElementById("speakerelem4e").style.background = "white";
  document.getElementById("speakerelem5e").style.background = "white";
  document.getElementById("speakerelem6e").style.background = "white";
  document.getElementById("speakerelem7e").style.background = "white";
  document.getElementById("speakerelem8e").style.background = "white";
}
function speakerHover8(){
  document.getElementById("speakerelem1el").style.background = "#B6E1E8";
  document.getElementById("speakerelem2el").style.background = "#B6E1E8";
  document.getElementById("speakerelem3el").style.background = "#B6E1E8";
  document.getElementById("speakerelem4el").style.background = "#B6E1E8";
  document.getElementById("speakerelem5el").style.background = "#B6E1E8";
  document.getElementById("speakerelem6el").style.background = "#B6E1E8";
  document.getElementById("speakerelem7el").style.background = "#B6E1E8";
  document.getElementById("speakerelem8el").style.background = "#B6E1E8";
}
function speakerOut8(){
  document.getElementById("speakerelem1el").style.background = "white";
  document.getElementById("speakerelem2el").style.background = "white";
  document.getElementById("speakerelem3el").style.background = "white";
  document.getElementById("speakerelem4el").style.background = "white";
  document.getElementById("speakerelem5el").style.background = "white";
  document.getElementById("speakerelem6el").style.background = "white";
  document.getElementById("speakerelem7el").style.background = "white";
  document.getElementById("speakerelem8el").style.background = "white";
}
function speakerHover9(){
  document.getElementById("speakerelem1ele").style.background = "#B6E1E8";
  document.getElementById("speakerelem2ele").style.background = "#B6E1E8";
  document.getElementById("speakerelem3ele").style.background = "#B6E1E8";
  document.getElementById("speakerelem4ele").style.background = "#B6E1E8";
  document.getElementById("speakerelem5ele").style.background = "#B6E1E8";
  document.getElementById("speakerelem6ele").style.background = "#B6E1E8";
  document.getElementById("speakerelem7ele").style.background = "#B6E1E8";
  document.getElementById("speakerelem8ele").style.background = "#B6E1E8";
}
function speakerOut9(){
  document.getElementById("speakerelem1ele").style.background = "white";
  document.getElementById("speakerelem2ele").style.background = "white";
  document.getElementById("speakerelem3ele").style.background = "white";
  document.getElementById("speakerelem4ele").style.background = "white";
  document.getElementById("speakerelem5ele").style.background = "white";
  document.getElementById("speakerelem6ele").style.background = "white";
  document.getElementById("speakerelem7ele").style.background = "white";
  document.getElementById("speakerelem8ele").style.background = "white";
}
function speakerHover10(){
  document.getElementById("speakerelem1elem").style.background = "#B6E1E8";
  document.getElementById("speakerelem2elem").style.background = "#B6E1E8";
  document.getElementById("speakerelem3elem").style.background = "#B6E1E8";
  document.getElementById("speakerelem4elem").style.background = "#B6E1E8";
  document.getElementById("speakerelem5elem").style.background = "#B6E1E8";
  document.getElementById("speakerelem6elem").style.background = "#B6E1E8";
  document.getElementById("speakerelem7elem").style.background = "#B6E1E8";
  document.getElementById("speakerelem8elem").style.background = "#B6E1E8";
}
function speakerOut10(){
  document.getElementById("speakerelem1elem").style.background = "white";
  document.getElementById("speakerelem2elem").style.background = "white";
  document.getElementById("speakerelem3elem").style.background = "white";
  document.getElementById("speakerelem4elem").style.background = "white";
  document.getElementById("speakerelem5elem").style.background = "white";
  document.getElementById("speakerelem6elem").style.background = "white";
  document.getElementById("speakerelem7elem").style.background = "white";
  document.getElementById("speakerelem8elem").style.background = "white";
}
function speakerHover11(){
  document.getElementById("elemsp1").style.background = "#B6E1E8";
  document.getElementById("elemsp2").style.background = "#B6E1E8";
  document.getElementById("elemsp3").style.background = "#B6E1E8";
  document.getElementById("elemsp4").style.background = "#B6E1E8";
  document.getElementById("elemsp5").style.background = "#B6E1E8";
  document.getElementById("elemsp6").style.background = "#B6E1E8";
  document.getElementById("elemsp7").style.background = "#B6E1E8";
  document.getElementById("elemsp8").style.background = "#B6E1E8";
}
function speakerOut11(){
  document.getElementById("elemsp1").style.background = "white";
  document.getElementById("elemsp2").style.background = "white";
  document.getElementById("elemsp3").style.background = "white";
  document.getElementById("elemsp4").style.background = "white";
  document.getElementById("elemsp5").style.background = "white";
  document.getElementById("elemsp6").style.background = "white";
  document.getElementById("elemsp7").style.background = "white";
  document.getElementById("elemsp8").style.background = "white";
}
function speakerHover12(){
  document.getElementById("elemspe1").style.background = "#B6E1E8";
  document.getElementById("elemspe2").style.background = "#B6E1E8";
  document.getElementById("elemspe3").style.background = "#B6E1E8";
  document.getElementById("elemspe4").style.background = "#B6E1E8";
  document.getElementById("elemspe5").style.background = "#B6E1E8";
  document.getElementById("elemspe6").style.background = "#B6E1E8";
  document.getElementById("elemspe7").style.background = "#B6E1E8";
  document.getElementById("elemspe8").style.background = "#B6E1E8";
}
function speakerOut12(){
  document.getElementById("elemspe1").style.background = "white";
  document.getElementById("elemspe2").style.background = "white";
  document.getElementById("elemspe3").style.background = "white";
  document.getElementById("elemspe4").style.background = "white";
  document.getElementById("elemspe5").style.background = "white";
  document.getElementById("elemspe6").style.background = "white";
  document.getElementById("elemspe7").style.background = "white";
  document.getElementById("elemspe8").style.background = "white";
}