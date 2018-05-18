CKEDITOR.dialog.add('pras_furnitureSizes', function (editor) {
    return {       
        title: 'Вставка предмета мебели с размерами',
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
                        label: 'Название предмета мебели*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Название должно быть заполнено")
                    },
                    {
                        type: 'text',
                        id: 'height',
                        label: 'Высота*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Высота должна быть заполнена")
                    },
                    {
                        type: 'text',
                        id: 'width',
                        label: 'Ширина*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Ширина должна быть заполнена")
                    },
                    {
                        type: 'text',
                        id: 'depth',
                        label: 'Глубина*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Глубина должна быть заполнена")
                    }
                ]
            }
        ],
        onOk: function () {
            var dialog = this;
            var insert = '';

            var title = dialog.getValueOf('tab-basic', 'title');
            var height = dialog.getValueOf('tab-basic', 'height');
            var width = dialog.getValueOf('tab-basic', 'width');
            var depth = dialog.getValueOf('tab-basic', 'depth');


            insert = '<span class="product-size__title">'+title+':</span>' +
                '<ul class="product-size__list-size">' +
                '<li>'+height+'</li>' +
                '<li>'+width+'</li>' +
                '<li>'+depth+'</li>' +
                '</ul>';

            editor.insertHtml(insert);
        }
    };
});