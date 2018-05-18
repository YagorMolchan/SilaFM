CKEDITOR.dialog.add('pras_quoteDialog', function (editor) {
    return {
        title: 'Вставка цитаты',
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
                        id: 'text-quote',
                        label: 'Цитата',
                        validate: CKEDITOR.dialog.validate.notEmpty("Цитата должна быть написана")
                    }
                ]
            }
        ],
        onOk: function () {
            var dialog = this;
            var insert = '';
            insert = '<blockquote>' + dialog.getValueOf('tab-basic', 'text-quote') + '</blockquote>';
            editor.insertHtml(insert);
        }
    };
});