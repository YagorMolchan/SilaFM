CKEDITOR.dialog.add('pras_stepDialog', function (editor) {
    return {
        title: 'Вставка шага',
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
                        id: 'title',
                        label: 'Название',
                        validate: CKEDITOR.dialog.validate.notEmpty("Название должно быть написано")
                    },
                    {
                        type: 'textarea',
                        id: 'text',
                        label: 'Текст',
                        validate: CKEDITOR.dialog.validate.notEmpty("Текст должен быть написан")
                    }
                ]
            }
        ],
        onOk: function () {
            var dialog = this;
            var insert = '<li><h3>' + dialog.getValueOf('tab-basic', 'title') + '</h3><p>' + dialog.getValueOf('tab-basic', 'text') + '</p></li>'
            editor.insertHtml(insert);
        }
    };
});