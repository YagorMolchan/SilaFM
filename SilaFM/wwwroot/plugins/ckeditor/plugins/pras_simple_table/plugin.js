CKEDITOR.plugins.add('pras_simple_table', {
    
    init: function (editor) {
        editor.addCommand('pras_simpleTable', new CKEDITOR.dialogCommand('pras_simpleTable'));
        editor.ui.addButton('Pras_simpleTable', {
            label: 'Вставить простую стилизованную таблицу',
            command: 'pras_simpleTable',
            icon: this.path + '/icons/little.png',
        });
    }
});
CKEDITOR.dialog.add('pras_simpleTable', 'plugins/pras_simple_table/dialogs/pras_simple_table.js');