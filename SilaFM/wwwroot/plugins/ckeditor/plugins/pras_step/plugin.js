CKEDITOR.plugins.add('pras_step', {
    icons: 'pras_step',
    init: function (editor) {
        editor.addCommand('pras_stepDialog', new CKEDITOR.dialogCommand('pras_stepDialog'));
        editor.ui.addButton('Pras_step', {
            label: 'Вставить шаг',
            command: 'pras_stepDialog'
        });
    }
});
CKEDITOR.dialog.add('pras_stepDialog', 'plugins/pras_step/dialogs/pras_step.js');