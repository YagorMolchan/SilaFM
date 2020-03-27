CKEDITOR.plugins.add('pras_hideUa', {
    icons: 'pras_hideUa',
    init: function (editor) {
        editor.addCommand('hideUa', {
            exec: function (editor) {
                var commandState = editor.getCommand("hideUa").state;
                if (commandState == CKEDITOR.TRISTATE_OFF) {
                    var selected_text = editor.getSelection().getSelectedText(); // Get Text
                    var newElement = new CKEDITOR.dom.element("span");              // Make Paragraff
                    newElement.setAttributes({ class: 'hideUa' });               // Set Attributes
                    newElement.setText(selected_text);                           // Set text to element
                    editor.insertElement(newElement);                            // Add Element
                } else {
                    var startElement = editor.getSelection().getStartElement();
                    var html = startElement.$.innerHTML;
                    editor.getSelection().getStartElement().remove();
                    editor.insertHtml(html);
                }

            }
        });
        editor.ui.addButton('pras_hideUa', {
            label: 'Скрыть для украинских пользователей',
            command: 'hideUa'
        });
        editor.on('selectionChange',
            function(e) {
                if (e.data.selection.getStartElement().getAttribute("class") === 'hideUa')
                    editor.getCommand('hideUa').setState(CKEDITOR.TRISTATE_ON);
                else
                    editor.getCommand('hideUa').setState(CKEDITOR.TRISTATE_OFF);
            }
        );
    }
});