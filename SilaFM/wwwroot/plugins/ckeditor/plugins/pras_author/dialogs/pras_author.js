CKEDITOR.dialog.add('pras_authorDialog', function (editor) {
    return {       
        title: 'Вставка информации об авторе',
        minWidth: 400,
        minHeight: 200,
        contents:
        [
            {
                id: 'tab-basic',
                label: 'Basic Settings',
                elements:
                [
                    {
                        type: 'text',
                        id: 'path-file',
                        label: 'Путь до изображения',
                        validate: CKEDITOR.dialog.validate.notEmpty("Изображение должно быть выбрано")
                    },
                    {
                        type: 'button',
                        id: 'path-file-btn',
                        label: 'Выбрать на сервере*',
                        filebrowser: 'tab-basic:path-file',
                        style: 'float:right'
                    },
                    {
                        type: 'text',
                        id: 'last-name',
                        label: 'Фамилия*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Фамилия должна быть написана")
                    },
                    {
                        type: 'text',
                        id: 'first-middle-name',
                        label: 'Имя и Отчество*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Имя и Отчество должны быть написаны")
                    },
                    {
                        type: 'text',
                        id: 'position',
                        label: 'Должность'
                    }
                ]
            }
        ],
        onOk: function () {
            var dialog = this;
            var insert =
                '<div class="leader">' +
                    '<div class="img">' +
                        '<img src="' + dialog.getValueOf('tab-basic', 'path-file') + '">' +
                    '</div>' +
                    '<div class="description">' +
                        '<p class="fio"><span>' + dialog.getValueOf('tab-basic', 'last-name') + '</span>' + dialog.getValueOf('tab-basic', 'first-middle-name') + '</p>';
                        if (dialog.getValueOf('tab-basic', 'position') != "") insert += '<p class="info">' + dialog.getValueOf('tab-basic', 'position') + '</p>';
            insert +=
                    '</div>' +
                '</div>';
            editor.insertHtml(insert);
        }
    };
});