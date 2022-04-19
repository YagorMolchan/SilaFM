function openMenu() {
    let burger = document.querySelector('.iconmenu'),
        body = document.querySelector('body');

    if (burger) {
        burger.onclick = function () {
            body.classList.add('open-menu');
        }
    }
}

function closeMenu() {
    let closeBtn = document.querySelector('.closebtn'),
        body = document.querySelector('body');

    if (closeBtn) {
        closeBtn.onclick = function () {
            body.classList.remove('open-menu');
        }
    }
}

function scrollFunction() {
    let leftMenu = document.querySelector('.left-menu');

    if (document.documentElement.scrollTop > 750 && leftMenu) {
        leftMenu.classList.add('fixed');
    } else {
        leftMenu.classList.remove('fixed');
    }
}

let musicInners = document.querySelectorAll('.js_music-inner');

if (musicInners) {
    musicInners.forEach(function (item) {
        audioPlayer(item);
    });
}

function audioPlayer(block, index) {
    const playIconContainer = block.querySelector('.js_play'),
        audioPlayerContainer = block,
        seekSlider = block.querySelector('.js_range-track'),
        volumeSlider = block.querySelector('.js_range-volume'),
        muteIconContainer = block.querySelector('.js_volume'),
        audio = block.querySelector('audio');

    let raf = null,
        repeatBtn = block.querySelector('.playrepeat-track');

    if(repeatBtn) {
        repeatBtn.onclick = function(e) {
            audio.toggleAttribute('loop');
        }
    }

    const setSliderMax = () => {
        seekSlider.max = Math.floor(audio.duration);
    }

    const displayBufferedAmount = () => {
        const bufferedAmount = Math.floor(audio.buffered.end(audio.buffered.length - 1));
        audioPlayerContainer.style.setProperty('--buffered-width', `${(bufferedAmount / seekSlider.max) * 100}%`);
    }

    const whilePlaying = () => {
        seekSlider.value = Math.floor(audio.currentTime);
        audioPlayerContainer.style.setProperty('--seek-before-width', `${seekSlider.value / seekSlider.max * 100}%`);
        raf = requestAnimationFrame(whilePlaying);
    }

    playIconContainer.addEventListener('click', (e) => {
        let sectionParent = e.target.closest('.js_music-inner');

        if (sectionParent) {
            let playState = sectionParent.getAttribute('data-play-state');

            if (playState) {
                if (playState === 'play') {
                    audio.play();
                    requestAnimationFrame(whilePlaying);
                    sectionParent.setAttribute('data-play-state', 'pause');

                    //e.target.style.backgroundImage = 'url(img/table-stop.png)';
                    e.target.classList.add('play');
                    e.target.classList.remove('pause');

                    musicInners.forEach(function (item) {
                        if (item !== block) {
                            item.setAttribute('data-play-state', 'play');
                            item.setAttribute('data-mute-state', 'unmute');

                            let audio = item.querySelector('audio'),
                                button = item.querySelector('.js_play');
                            audio.muted = false;

                            //button.style.backgroundImage = 'url(img/table-play.png)';

                            button.classList.remove('play');
                            button.classList.add('pause');
                        }
                    });

                } else {
                    audio.pause();
                    cancelAnimationFrame(raf);
                    sectionParent.setAttribute('data-play-state', 'play');
                    //e.target.style.backgroundImage = 'url(img/table-play.png)';
                    e.target.classList.remove('play');
                    e.target.classList.add('pause');
                }
            }
        }
    });

    muteIconContainer.addEventListener('click', (e) => {
        let sectionParent = e.target.closest('.js_music-inner');

        if (sectionParent) {
            let muteState = sectionParent.getAttribute('data-mute-state');

            if (muteState === 'unmute') {
                audio.muted = true;
                sectionParent.setAttribute('data-mute-state', 'mute');

                volumeSlider.setAttribute('data-old-volume-value', volumeSlider.value);
                volumeSlider.value = 0;

                audioPlayerContainer.style.setProperty(
                    '--volume-before-width',
                    '0%'
                );
            } else {
                audio.muted = false;
                sectionParent.setAttribute('data-mute-state', 'unmute');

                let oldValue = volumeSlider.getAttribute('data-old-volume-value');
                volumeSlider.value = oldValue ? oldValue : 100;

                audioPlayerContainer.style.setProperty(
                    '--volume-before-width',
                    '100%'
                );
            }
        }
    });

    const showRangeProgress = (rangeInput) => {
        if (rangeInput === seekSlider) {
            audioPlayerContainer.style.setProperty(
                '--seek-before-width',
                rangeInput.value / rangeInput.max * 100 + '%'
            );
        } else {
            audioPlayerContainer.style.setProperty(
                '--volume-before-width',
                rangeInput.value / rangeInput.max * 100 + '%'
            );
        }
    }

    seekSlider.addEventListener('input', (e) => {
        showRangeProgress(e.target);
    });

    volumeSlider.addEventListener('input', (e) => {
        showRangeProgress(e.target);
    });

    if (audio.readyState > 0) {
        setSliderMax();
        displayBufferedAmount();
    } else {
        audio.addEventListener('loadedmetadata', () => {
            setSliderMax();
            displayBufferedAmount();
        });
    }

    audio.addEventListener('progress', displayBufferedAmount);

    seekSlider.addEventListener('input', () => {
        if (!audio.paused) {
            cancelAnimationFrame(raf);
        }
    });

    seekSlider.addEventListener('change', () => {
        audio.currentTime = seekSlider.value;
        if (!audio.paused) {
            requestAnimationFrame(whilePlaying);
        }
    });

    volumeSlider.addEventListener('input', (e) => {
        const value = e.target.value;

        audio.volume = value / 100;
    });
}

function openModal() {
    let btnsTrigger = document.querySelectorAll('.js_open-modal');

    if (btnsTrigger) {
        btnsTrigger.forEach(function(item) {
            item.onclick = function(e) {
                let modal = document.querySelector('.js_modal'),
                    body = document.querySelector('body');

                if (modal) {
                    body.classList.add('open-panel');
                }
            }
        });
    }
}

function closeModal() {
    let btnsClose = document.querySelectorAll('.js_close-modal');

    if (btnsClose) {
        btnsClose.forEach(function(item) {
            item.onclick = function(e) {
                let body = document.querySelector('body');

                body.classList.remove('open-panel');
            }
        });
    }
}



window.onscroll = function () {
    scrollFunction();
};

window.onload = function () {
    openMenu();
    closeMenu();
    openModal();
    closeModal();
}