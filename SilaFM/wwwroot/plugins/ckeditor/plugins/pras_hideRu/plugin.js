CKEDITOR.plugins.add('pras_hideRu', {
    icons: 'pras_hideRu',
    init: function (editor) {
        editor.addCommand('hideRu', {
            exec: function (editor) {
                var commandState = editor.getCommand("hideRu").state;
                if (commandState == CKEDITOR.TRISTATE_OFF) {
                    var selected_text = editor.getSelection().getSelectedText(); // Get Text
                    var newElement = new CKEDITOR.dom.element("span");              // Make Paragraff
                    newElement.setAttributes({ class: 'hideRu' });               // Set Attributes
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
        editor.ui.addButton('pras_hideRu', {
            label: 'Скрыть для российских пользователей',
            command: 'hideRu'
        });
        editor.on('selectionChange',
            function(e) {
                if (e.data.selection.getStartElement().getAttribute("class") === 'hideRu')
                    editor.getCommand('hideRu').setState(CKEDITOR.TRISTATE_ON);
                else
                    editor.getCommand('hideRu').setState(CKEDITOR.TRISTATE_OFF);
            }
        );
    }
});