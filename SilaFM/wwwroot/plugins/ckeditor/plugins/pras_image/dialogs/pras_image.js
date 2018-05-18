CKEDITOR.dialog.add('pras_imageDialog', function (editor) {
    return {       
        title: 'Вставка изображения с обводкой и описанием',
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
                        label: 'Путь до изображения*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Изображение должно быть выбрано")
                    },
                    {
                        type: 'button',
                        id: 'path-file-btn',
                        label: 'Выбрать на сервере',
                        filebrowser: 'tab-basic:path-file',
                        style: 'float:right'
                    },
                    {
                        type: 'text',
                        id: 'summary',
                        label: 'Описание'
                    },
                    {
                        type: 'text',
                        id: 'alter',
                        label: 'Альтернативный текст',
                        validate: CKEDITOR.dialog.validate.notEmpty("Альтернативный текст должен быть написан")
                    }
                ]
            }
        ],
        onOk: function () {
            var dialog = this;
            var insert = '';
            insert =
                '<figure>' +
                    '<img src="' + dialog.getValueOf('tab-basic', 'path-file') + '" alt="' + dialog.getValueOf('tab-basic', 'alter') + '" style="width:400px;">';
                    if (dialog.getValueOf('tab-basic', 'summary') != "") insert += '<figcaption>' + dialog.getValueOf('tab-basic', 'summary') + '</figcaption>';
            insert +=
                '</figure>';
            editor.insertHtml(insert);
        }
    };
});