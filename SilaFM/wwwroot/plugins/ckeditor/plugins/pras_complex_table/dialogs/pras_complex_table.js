CKEDITOR.dialog.add('pras_complexTable', function (editor) {
    return {       
        title: 'Вставка сложной стилизованной таблицы',
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
                        id: 'top_title',
                        label: 'Заголовок вверху*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Заголовок вверху должен быть заполнен")
                    },
                    {
                        type: 'text',
                        id: 'left_title',
                        label: 'Заголовок слева*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Заголовок слева должен быть заполнен")
                    },
                    {
                        type: 'text',
                        id: 'rows',
                        label: 'Количество строк*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Количество строк должно быть заполнено")
                    },
                    {
                        type: 'text',
                        id: 'cols',
                        label: 'Количество столбцов*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Количество столбцов должно быть заполнено")
                    }
                ]
            }
        ],
        onOk: function () {
            var dialog = this;
            var insert = '';

            var cols = dialog.getValueOf('tab-basic', 'cols');
            var rows = dialog.getValueOf('tab-basic', 'rows');


            insert = '<table class="table-style table-style-row">';
            insert += "<thead><tr><th class='no-color'></th><th colspan=" + (cols - 1) + ">" + dialog.getValueOf('tab-basic', 'top_title') + "</th></tr><tr>";
            for (var i = 0; i < cols; i++) {
                if (i==0) {
                    insert += "<th class='no-border'>" + dialog.getValueOf('tab-basic', 'left_title') + "</th>";
                }
                else {
                    insert += "<th>header" + i + "</th>";
                }
            }
            insert += "</tr></thead><tbody>";
            
            for (var i = 0; i < rows - 1; i++) {
                insert += "<tr>";
                for (var j = 0; j < cols; j++) {
                    if (j == 0) {
                        insert += "<th>&nbsp;</th>";
                    } else {
                        insert += "<td>&nbsp;</td>";
                    }
                }
                insert += "</tr>";
            }
            insert += "</tbody></table>";

            editor.insertHtml(insert);
        }
    };
});