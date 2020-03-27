//появление меню после прокрутки 300 пикселей вниз с фейдом в 400мс
jQuery(function (f) {
    var element = f('#navigationMenu');
    f(window).scroll(function () {
        element['fade' + (f(this).scrollTop() > 300 ? 'In' : 'Out')](400);
    });
});

var menu = new cbpHorizontalSlideOutMenu(document.getElementById('cbp-hsmenu-wrapper'));

// анимация счетчика
$(document).ready(function () {
    'use strict';
    var show = true;
    var countbox = "#counts";
    if ($(countbox).length) {
        $(window).on("scroll load resize",
            function () {
                if (!show) return false; // Отменяем показ анимации, если она уже была выполнена

                var w_top = $(window).scrollTop(); // Количество пикселей на которое была прокручена страница
                var e_top = $(countbox).offset().top; // Расстояние от блока со счетчиками до верха всего документа

                var w_height = $(window).height(); // Высота окна браузера
                var d_height = $(document).height(); // Высота всего документа

                var e_height = $(countbox).outerHeight(); // Полная высота блока со счетчиками

                if (w_top + 400 >= e_top || w_height + w_top == d_height || e_height + e_top < w_height) {
                    $(".spincrement").spincrement({
                        thousandSeparator: "",
                        duration: 1200
                    });

                    show = false;
                }
            });
    }

    if ($('table.features-table').length) {
        $('table.features-table').each(function (i, el) {
            var options = {
                "language": {
                    "search": "Поиск:",
                    "zeroRecords": "Ничего не найдено, измените запрос"
                },
                "order": [
                    [0, 'asc'],
                    [1, 'asc']
                ],
                "info": false,
                "paging": false
            };

            if ($(el).is('.search-bottom'))
                options.dom = '<"top"i>rt<"bottom"flp><"clear">';

            $(el).DataTable(options);
        });

    }

    if ($('.datetimepicker').length) {
        $('.datetimepicker').datetimepicker({
            locale: 'ru',
            format: 'DD.MM.YYYY'
        });
    }

    $("#wanted_time").click(function () {
        $("#hronotime").attr('disabled', !$("#hronotime").attr('disabled'));
        console.log(!$("#hronotime").attr('disabled'));
    });

    $("#clear_btn").click(function () {
        $("#edit").val('');
    })

    $("a.anketa-modal").click(function (e) {
        e.preventDefault();
        $("#modal-1").modal('show');
    })
});