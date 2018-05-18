/*
 * @file HTML Buttons plugin for CKEditor
 * Copyright (C) 2012 Alfonso Martínez de Lizarrondo
 * A simple plugin to help create custom buttons to insert HTML blocks
 * Version 1.1 and up Modified by Eric Arnol-Martin (http://eamster.tk)  
 * Added in Version 1.1:  New HTML inserts work properly when selecting elements
 * Added in Version 1.2:  Inline HTML is not lost when selections are modified
 * Added in Version 1.3:  Turned off debugging and fixed a few selection bugs within text blocks   
 */

CKEDITOR.plugins.add( 'htmlbuttons',
{
	init : function( editor )
	{
		var buttonsConfig = editor.config.htmlbuttons;
		if (!buttonsConfig)
			return;

		function createCommand( definition )
		{
			return {
				exec: function( editor ) {
				
				  // Build list of block elements to be replaced
				  
				  var blockElems=new Array();
          blockElems.push('address');
          blockElems.push('article'); 
          blockElems.push('aside'); 
          blockElems.push('audio'); 
          blockElems.push('blockquote'); 
          blockElems.push('canvas'); 
          blockElems.push('dd'); 
          blockElems.push('div'); 
          blockElems.push('dl'); 
          blockElems.push('fieldset'); 
          blockElems.push('figcaption'); 
          blockElems.push('figure'); 
          blockElems.push('figcaption'); 
          blockElems.push('footer'); 
          blockElems.push('form'); 
          blockElems.push('h1'); 
          blockElems.push('h2');
          blockElems.push('h3');
          blockElems.push('h4');
          blockElems.push('h5');
          blockElems.push('h6');
          blockElems.push('header');
          blockElems.push('hgroup');
          blockElems.push('hr');
          blockElems.push('noscript');
          blockElems.push('ol');
          blockElems.push('output');
          blockElems.push('p');
          blockElems.push('pre');
          blockElems.push('section');
          blockElems.push('table');
          blockElems.push('tfoot');
          blockElems.push('ul');
          blockElems.push('video'); 
           
				
          // Debug option
          var debugOn = 0;
          var replacementStr = '';
          var strToLook = '> </';
          var code = definition.html.toString();
          
          // Check to see if we have selected text:
          var theSelectedText = editor.getSelection().getNative().toString();
          var selectedElem = editor.getSelection();
          
          // Used to reset focus
          // Found from this most helpful guide:  http://stackoverflow.com/questions/15718880/refocus-ckeditor-at-correct-cursor-position 
          var range = editor.getSelection().getRanges()[0];
          
          if(selectedElem && code.indexOf(strToLook) != -1 && selectedElem.getNative().toString() !== null && selectedElem.getNative().toString() !== '' && selectedElem.getNative().toString().length > 0){
             
            // Get HTML and Text from selection
            var ranges = selectedElem.getRanges();
            var el = new CKEDITOR.dom.element("div");
            for (var i = 0, len = ranges.length; i < len; ++i) {
              el.append(ranges[i].cloneContents());
            }
            selectedElem = el.getHtml().toString();    
              
            // Debug
            if(debugOn == 1){
              alert(selectedElem);
            }
                          
            // Replace block elements from html
            for(var i = 0; i < blockElems.length; i++){
              var pattern = '(<' + blockElems[i] + '[^>]*>|<\/' + blockElems[i] + '>)';
              var re = new RegExp(pattern, 'gi');
              selectedElem = selectedElem.replace(re, '');
            }
              
            replacementStr = '>' + selectedElem + '</'; 
              
            // Get rid of breaks if there are any
            code = code.replace('<br />','');
            code = code.replace('<br>','');
                  
            // Do the actual replacing
            if(replacementStr != ""){
              code = code.replace(strToLook, replacementStr); 
            }
              
            // Debug
            if(debugOn == 1){
              alert(code);
            }
              
            // Create a new element which contains our wrapped code
            var newElement = CKEDITOR.dom.element.createFromHtml( code, editor.document );    
                  
            // Remove initial element
            if(editor.getSelection().getSelectedElement() != null && editor.getSelection().getSelectedElement().toString().length > 0){ 
              var elemRemove = editor.getSelection().getSelectedElement();
                        
              // Debug
              if(debugOn == 1){
                alert(elemRemove);
              }
                        
              elemRemove.remove();
            }  
            
            // Select our original range before inserting the elemnt
            range.select();
            
            // Insert the new element.
        		editor.insertElement(newElement);
               
          }else{
            // Insert just the code snippet
            editor.insertHtml(code);
              
            // Debug
            if(debugOn == 1){
              alert(code);
            }
          }
        } 
			};
		}

		// Create the command for each button
		for(var i=0; i<buttonsConfig.length; i++)
		{      
      
			var button = buttonsConfig[ i ];
			var commandName = button.name;
			editor.addCommand( commandName, createCommand(button, editor) );

			editor.ui.addButton( commandName,
			{
				label : button.title,
				command : commandName,
				icon : this.path + button.icon
			});
		}
	} //Init

} );



/**
 * An array of buttons to add to the toolbar.
 * Each button is an object with these properties:
 *	name: The name of the command and the button (the one to use in the toolbar configuration)
 *	icon: The icon to use. Place them in the plugin folder
 *	html: The HTML to insert when the user clicks the button
 *	title: Title that appears while hovering the button
 *
 * Default configuration with some sample buttons:
 */
 
 // Put a space between element opening tags and closing tags if you want selected text to be placed within these elements.
 // example:  html:'<p class="titleMostImportant"> </p>',
  
CKEDITOR.config.htmlbuttons =  [
	{
		name:'button1',
		icon:'icon1.png',
		html:'<a href="http://www.google.com">Search something</a>',
		title:'A link to Google'
	},
	{
		name:'button2',
		icon:'icon2.png',
		html:'<table style="min-width:200px"><tr><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td>&nbsp;</td><td>&nbsp;</td></tr></table>',
		title:'A simple table'
	},
	{
		name:'button3',
		icon:'icon3.png',
		html:'<ol><li>Item 1 <ol><li>Sub item 1</li><li>Sub item 2</li></ol></li></ol>',
		title:'A nested list'
	}
];
 
 
