CKEDITOR.plugins.add('pras_quote', {
    icons: 'pras_quote',
    init: function (editor) {
        editor.addCommand('pras_quoteDialog', new CKEDITOR.dialogCommand('pras_quoteDialog'));
        editor.ui.addButton('Pras_quote', {
            label: 'Вставить цитату',
            command: 'pras_quoteDialog'
        });
    }
});
CKEDITOR.dialog.add('pras_quoteDialog', 'plugins/pras_quote/dialogs/pras_quote.js');