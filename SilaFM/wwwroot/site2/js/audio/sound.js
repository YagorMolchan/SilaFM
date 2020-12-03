let playpause_btn = document.querySelector(".playpause-track");
let seek_slider = document.querySelector(".seek_slider");
let track_index = 0;
let isPlaying = false;
let curr_track = document.createElement('audio');

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

function pauseTrack() {
    curr_track.pause();
    isPlaying = false;
    playpause_btn.innerHTML = '<img src="../img/play.png">';
}
 

loadTrack(track_index);

//
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