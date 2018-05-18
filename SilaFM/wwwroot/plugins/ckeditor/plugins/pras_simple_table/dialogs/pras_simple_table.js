CKEDITOR.dialog.add('pras_simpleTable', function (editor) {
    return {       
        title: 'Вставка простой стилизованной таблицы',
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
                        id: 'rows',
                        label: 'Количество строк*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Количество строк должно быть заполнено")
                    },
                    {
                        type: 'text',
                        id: 'cols',
                        label: 'Количество столбцов*',
                        validate: CKEDITOR.dialog.validate.notEmpty("Количество столбцов должно быть заполнено")
                    },
                    {
                        type: 'text',
                        id: 'small',
                        label: 'Номера узких колонок через запятую'
                    },
                    {
                        type: 'text',
                        id: 'medium',
                        label: 'Номера средних колонок через запятую'
                    }
                ]
            }
        ],
        onOk: function () {
            var dialog = this;
            var insert = '';

            var cols = dialog.getValueOf('tab-basic', 'cols');
            var rows = dialog.getValueOf('tab-basic', 'rows');
            var small = dialog.getValueOf('tab-basic', 'small').split('/\s*,\s*/');
            var medium = dialog.getValueOf('tab-basic', 'medium').split('/\s*,\s*/');


            insert = '<table class="table-style">';
            insert += "<thead><tr>";
            for (var i = 0; i < cols; i++) {
                if (small.indexOf((i + 1).toString()) != -1) {
                    insert += "<th class='col-small'>header" + (i + 1) + "</th>";
                }
                else if (medium.indexOf((i + 1).toString()) != -1) {
                    insert += "<th class='col-medium'>header" + (i + 1) + "</th>";
                }
                else {
                    insert += "<th>header" + (i + 1) + "</th>";
                }
            }
            insert += "</tr></thead><tbody>";
            
            for (var i = 0; i < rows - 1; i++) {
                insert += "<tr>";
                for (var j = 0; j < cols; j++) {
                    insert += "<td>&nbsp;</td>";
                }
                insert += "</tr>";
            }
            insert += "</tbody></table>";

            editor.insertHtml(insert);
        }
    };
});