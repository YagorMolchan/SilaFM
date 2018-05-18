CKEDITOR.plugins.add('pras_furniture_sizes', {
    
    init: function (editor) {
        editor.addCommand('pras_furnitureSizes', new CKEDITOR.dialogCommand('pras_furnitureSizes'));
        editor.ui.addButton('Pras_furnitureSizes', {
            label: 'Вставить предмет мебели с размерами',
            command: 'pras_furnitureSizes',
            icon: this.path + '/icons/big.png',
        });
    }
});
CKEDITOR.dialog.add('pras_furnitureSizes', 'plugins/pras_furniture_sizes/dialogs/pras_furniture_sizes.js');