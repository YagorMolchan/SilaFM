CKEDITOR.plugins.add('pras_complex_table', {
    
    init: function (editor) {
        editor.addCommand('pras_complexTable', new CKEDITOR.dialogCommand('pras_complexTable'));
        editor.ui.addButton('Pras_complexTable', {
            label: 'Вставить сложную стилизованную таблицу',
            command: 'pras_complexTable',
            icon: this.path + '/icons/big.png',
        });
    }
});
CKEDITOR.dialog.add('pras_complexTable', 'plugins/pras_complex_table/dialogs/pras_complex_table.js');