CKEDITOR.plugins.add('pras_image', {
    icons: 'pras_image',
    init: function (editor) {
        editor.addCommand('pras_imageDialog', new CKEDITOR.dialogCommand('pras_imageDialog'));
        editor.ui.addButton('Pras_image', {
            label: 'Вставить изображение с обводкой и описанием',
            command: 'pras_imageDialog'
        });
    }
});
CKEDITOR.dialog.add('pras_imageDialog', 'plugins/pras_image/dialogs/pras_image.js');