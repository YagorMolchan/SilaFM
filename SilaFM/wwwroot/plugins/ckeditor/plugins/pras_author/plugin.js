CKEDITOR.plugins.add('pras_author', {
    icons: 'pras_author',
    init: function (editor) {
        editor.addCommand('pras_authorDialog', new CKEDITOR.dialogCommand('pras_authorDialog'));
        editor.ui.addButton('Pras_author', {
            label: 'Вставить информацию об авторе',
            command: 'pras_authorDialog'
        });
    }
});
CKEDITOR.dialog.add('pras_authorDialog', 'plugins/pras_author/dialogs/pras_author.js');