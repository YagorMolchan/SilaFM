$(document).ready(function () {

    $('*').tooltip({
        items: "[data-tooltip]",
        position: { my: "center top+5", at: "center bottom", collision: "flipfit" }
    });

    ////file manager
    //var elf = $('.file-manager').elfinder({
    //    url: 'elfinder.connector'  // connector URL (REQUIRED)
    //}).elfinder('instance');

    $('[data-translit]').on('click', function () {
        $($(this).data('source')).translit('send', $(this).data('translit'));
    });

    if ($('.colorpicker-element').length) {
        $('.colorpicker-element').colorpicker();
    }

    //datetimepicker
    if ($(".datetimepicker").length) {
        $(".datetimepicker").each(function (i, e) {
            $(e).datetimepicker({
                locale: 'ru',
                showClose: true
            }).on("dp.hide", function () {
                $(e).change();
            });
        });
    }

    //datatables
    if ($(".table:not([datatable])").length) {
        var language = {
            "sSearch": "_INPUT_",
            //search: "_INPUT_",
            "sSearchPlaceholder": "Введите слова для поиска",
            "sInfo": "Показываются с _START_ по _END_ из _TOTAL_ записей",
            "sZeroRecords": "Ничего не найдено",
            "sInfoEmpty": "Записи с 0 до 0 из 0 записей",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Первая",
                "sPrevious": "Предыдущая",
                "sNext": "Следующая",
                "sLast": "Последняя"
            },
            "sEmptyTable": "Таблица пустая",
            "sInfoFiltered": "Поиск по _MAX_ записям",
            "sInfoPostFix": "",
            "sInfoThousands": ",",
            "sLengthMenu": "Показать _MENU_ записей",
            "sLoadingRecords": "Загрузка...",
            "sProcessing": "Подождите...",
            "oAria": {
                "sSortAscending": ": сортировать по возрастанию",
                "sSortDescending": ": сортировать по убыванию"
            }
        };

        $('.table:not([datatable])').each(function (i, e) {
            var oColumn = $(e).data("ordercolumn") ? $(e).data("ordercolumn") : 0;
            var oDir = $(e).data("orderdir") ? $(e).data("orderdir") : "asc";
            var ordering = ($(e).hasClass("table-nosortable")) ? false : true;
            var searching = ($(e).hasClass("table-nosearch")) ? false : true;
            var ajax = ($(e).hasClass("table-ajax")) ? true : false;
            if (ajax) {
                var url = $(e).data("url");
                $(e).DataTable({
                    "responsive": true,
                    "processing": true,
                    "serverSide": true,
                    "ajax": {
                        "url": url,
                        "data": function (d) {
                            d.page = $(e).DataTable().page.info().page;
                            d.filter = d.search.value;
                            d.orderby = d.order.column;
                            d.orderdir = d.order.dir;
                        }
                    },
                    "paging": searching,
                    "oLanguage": language,
                    "searching": searching,
                    "ordering": ordering,
                    "fnDrawCallback": function (oSettings) {
                        //iCheck for checkbox and radio inputs
                        $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                            checkboxClass: 'icheckbox_minimal-blue',
                            radioClass: 'iradio_minimal-blue'
                        });
                    }
                });
            }
            else {
                $(e).DataTable({
                    "responsive": true,
                    "paging": searching,
                    //"lengthChange": false,
                    "oLanguage": language,
                    "searching": searching,
                    "ordering": ordering,
                    //"info": true,
                    //"autoWidth": false
                    "fnDrawCallback": function (oSettings) {
                        //iCheck for checkbox and radio inputs
                        $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                            checkboxClass: 'icheckbox_minimal-blue',
                            radioClass: 'iradio_minimal-blue'
                        });
                    }
                });
            }
        });
        $('.dataTables_filter label').addClass('input-group');
        $('.dataTables_filter input[type=search]').removeClass('input-sm').after(
            '<div class="input-group-addon">' +
            '<i id="preloader" class="fa fa-repeat" style="display: none;"></i>' +
            '<i id="loop" class="fa fa-search"></i>' +
            '</div>');
    }
    
    $('.ck-basic').each(function (index, value) {
        CKEDITOR.replace(value.id,
            {
                toolbar: 'Basic',
                height:$(value).data('height')||150
            });
    });

    $.ajax({
        type: "GET",
        url: "https://pras.by/api/getnews/be",
        xhrFields: {
            withCredentials: true
        },
        success: function (data) {
            data.forEach(function (element, index, array) {
                var newsPrasBy = "";
                newsPrasBy = '<span class="block-title">' + element.title + '</span><div class="news-block">';
                element.news.forEach(function (item, index, array) {
                    newsPrasBy += '<div class="box-content">' +
                        '<span class="news-title">' +
                        '<a href="' + item.link_to_new + '" target="_blank">' + item.title + '</a>' +
                        '</span>';
                    newsPrasBy += '<div class="news-body">';
                    if (item.image)
                        newsPrasBy += '<div><img src="' + item.image + '"/></div>';
                    newsPrasBy += '<p>' + item.summary + '</p></div></div>';
                });
                newsPrasBy += '</div>';
                $("#pras-tape>.box-body").append(newsPrasBy);
            });
        },
        error: function () {
            $("#pras-tape").remove();
        }
    });

    //iCheck for checkbox and radio inputs
    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
        checkboxClass: 'icheckbox_minimal-blue',
        radioClass: 'iradio_minimal-blue'
    });
    //Red color scheme for iCheck
    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
        checkboxClass: 'icheckbox_minimal-red',
        radioClass: 'iradio_minimal-red'
    });
    //Flat red color scheme for iCheck
    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green'
    });

    $(".menu-tabs").on("click", "li:not(.active)", function () {
        $(".menu-tabs li, .content-tabs li").removeClass("active");
        $(this).addClass("active");
        $("#item-" + $(this).attr("for-item")).addClass("active");
    });

    //sidebar-collapse
    if ($.cookie("tapeclass")) {
        var tapeclass = $.cookie("tapeclass");
        if (tapeclass != "noclass")
            $('#pras-tape').addClass(tapeclass);
        else
            $('#pras-tape').removeClass("collapsed-box");
    }
    $('[data-widget="collapse"]').on("mousedown", function (e) {
        if ($('#pras-tape').hasClass("collapsed-box"))
            $.cookie("tapeclass", "noclass", { path: '/' });
        else {
            $.cookie("tapeclass", "collapsed-box", { path: '/' });
        }
    });

    openMenuParents($('.treeview-menu li.active'));

    //hide alerts
    if ($(".alert:not(.angular)").length) {
        setTimeout(function () {
            $(".alert").remove();
        }, 5000);
    }
});

function openMenuParents(element) {
    if ($(element).length) {
        var el = $(element).parents('.treeview');
        el.addClass('active');
        openMenuParents(el);
    }
}

function viewPreloader(isView) {
    if (isView) {
        $("#loop").hide();
        $("#preloader").show();
    } else {
        $("#preloader").hide();
        $("#loop").show();
    }
}
function viewPreloaderText(isView) {
    if (isView) $(".preloader-text").show();
    else $(".preloader-text").hide();
}

function updateCkeditor(name, item, event) {
    var editor = CKEDITOR.instances[name];
    if (!editor) {
        CKEDITOR.replace(name);
        $(event.target).text('Скрыть редактор');
    }
    else {
        editor.destroy(true);
        $(event.target).text('Показать редактор');
    }
}

var canSubmit = true;
function fnCheckUrl(url, where, id, lang) {
    $.ajax({
        type: 'PUT',
        async: false,
        url: where,
        data: { 'url': $("#" + url).val(), 'id': $("#" + id).val(), 'lang': $("#" + lang).val() },
        beforeSend: function () {
            //viewPreloader(true);
        },
        success: function (data) {
            canSubmit = data;
            if (data == false) {
                alert("Выберите другое имя url-адреса.");
            }
        },
        complete: function () {
            //viewPreloader(false);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Ошибка. Обратитесь к администратору");
            alert(textStatus + "\n" + errorThrown);
            return false;
        }
    });

    return canSubmit;
}


var dec2hex = function (d) {
    if (d > 15) {
        return d.toString(16);
    } else {
        return "0" + d.toString(16);
    }
}
var rgb = function (color) {
    return "#" + dec2hex(color[0]) + dec2hex(color[1]) + dec2hex(color[2]);
};

//open window for the file manager
loadElfinder = function ($id) {
    $('<div\>').dialog({
        modal: true,
        width: "80%",
        height: "500",
        dialogClass: "elfinder-dialog",
        title: "Выбор файла",
        create: function (event, ui) {
            $(this).elfinder({
                resizable: false,
                url: "file/connector",
                getFileCallback: function (urlObject) {
                    if (!urlObject.locked) {
                        var element = $('#' + $id);
                        var src = urlObject.path.replace('Главная/', urlObject.baseUrl);
                        element.val(src).change();
                        $("#view-" + $id).attr("src", src);
                        $('.ui-dialog-titlebar-close').click();
                    } else {
                        alert("Этот файл нельзя выбрать");
                    }
                }
            }).elfinder('instance');
        },
        close: function (event, ui) {
            $(this).dialog('destroy').remove();
        }
    });
};

//default settings for the form using jQuery validate
if ($.validator) {
    $.validator.methods.date = function (value, element) {
        return this.optional(element) || Globalize.parseDate(value) !== null;
    };
    $.validator.setDefaults({
        highlight: function (element) {
            if (!$(element).is(".not-validation")) {
                elemForm = $(element).closest('.form-group');
                elemForm.removeClass("has-success");
                elemFormLabel = elemForm.children(".control-label");
                elemFormLabel.children(".fa-check").remove();

                elemForm.addClass('has-error');
                if (!elemFormLabel.children(".fa-times-circle-o").length) {
                    elemFormLabel.prepend("<i class=\"fa fa-times-circle-o\"></i> ");
                }
            }
        },
        unhighlight: function (element) {
            if (!$(element).is(".not-validation")) {
                $(element).closest('.form-group').removeClass('has-error').addClass("has-success");
                elemForm = $(element).closest('.form-group');
                elemForm.removeClass("has-error");
                elemFormLabel = elemForm.children(".control-label");
                elemFormLabel.children(".fa-times-circle-o").remove();

                elemForm.addClass('has-success');
                if (!elemFormLabel.children(".fa-check").length) {
                    elemFormLabel.prepend("<i class=\"fa fa-check\"></i> ");
                }
            }
        },
        errorElement: 'span',
        errorClass: 'field-validation-error',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        ignore: ".not-validation"
    });
}