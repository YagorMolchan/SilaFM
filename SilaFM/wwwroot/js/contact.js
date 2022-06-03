$('.images-slide').hover(
    function () {
        $(this).find("img:first").fadeToggle();
    }
);

const body = $('body');

$(document).ready(function () {
    $("#menu").on("click", "a", function (event) {
        $(document).ready(function () {

            $('.modal-btn').click(function () {
                elements.addClass('active');
                body.addClass('active');
            });

            $('.close-modal').click(function () {
                elements.removeClass('active');
                body.removeClass('active');
            });

            var elementtsp = $('.modal-overlay-page, .modal-page');

            $('.modal-btn-page').click(function () {
                elementtsp.addClass('active-page');
                body.addClass('ov-h');
            });

            $('.close-modal-page').click(function () {
                elementtsp.removeClass('active-page');
                body.removeClass('ov-h');
            });

            var elementtss = $('.modal-overlay-calculator, .modal-calculator');

            $('.modal-btn-calculator').click(function () {
                elementtss.addClass('active-calculator');
                body.addClass('ov-h');
            });

            $('.close-modal-calculator').click(function () {
                elementtss.removeClass('active-calculator');
                body.removeClass('ov-h');
            });
        })
    }
}