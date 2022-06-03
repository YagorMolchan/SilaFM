const body = $('body');

document.addEventListener('play', function (e) {
    var audios = document.getElementsByTagName('input');
    for (var i = 0, len = audios.length; i < len; i++) {
        $(document).ready(function () {
            $('.modal-btn').click(function () {
                elements.addClass('active');
                body.addClass('ov-h');
            });

            $('.close-modal').click(function () {
                elements.removeClass('active');
                body.removeClass('ov-h');
            });
            //popup2Pagemeter
            var elementts = $('.modal-overlay-page, .modal-page');

            $('.modal-btn-page').click(function () {
                elementts.addClass('active-page');
                body.addClass('ov-h');
            });

            $('.close-modal-page').click(function () {
                elementts.removeClass('active-page');
                body.removeClass('ov-h');
            });

        })
    }
}