/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
    // Define changes to default configuration here. For example:
    config.language = 'ru';
    // The toolbar groups arrangement, optimized for two toolbar rows.
    config.toolbarGroups = [
		{ name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
		{ name: 'links' },
		{ name: 'others' },
		{ name: 'insert' },
		{ name: 'tools' },
		'/',
		{ name: 'styles' },
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'paragraph', groups: ['list', 'blocks', 'align'] },
		//{ name: 'colors' },
		{ name: 'about' }
    ];
    config.filebrowserBrowseUrl = 'admin/elfinder';
    config.baseHref = document.getElementsByTagName('base')[0].href;
    config.allowedContent = true;
    config.skin = "pras";
    //config.protectedSource.push(/<a[\s\S]*?\>/g);
    //config.protectedSource.push(/<\/a[\s\S]*?\>/g);
    //config.uiColor = '#3c8dbc';
    config.extraPlugins = 'htmlbuttons';
    config.forcePasteAsPlainText = true;
    config.extraPlugins = 'pras_hideRu,pras_hideUa';//'pras_image,pras_gallery,pras_document,pras_author,pras_quote,pras_step,pras_simple_table,pras_complex_table,pras_furniture_sizes';
    config.filebrowserWindowHeight = '505px';

    config.toolbar_Basic = [["Bold", "Italic", "Underline", "pras_hideRu", "pras_hideUa", "-", "Link", "Unlink", "-", "Maximize", "About", '-']];
    //config.toolbar = "Basic";

    // Remove some buttons, provided by the standard plugins, which we don't
    // need to have in the Standard(s) toolbar.
    config.removeButtons = 'Styles,Subscript,Superscript,Image,Save,Templates,Flash,Smiley,ShowBlocks,Font,FontSize,CreateDiv';

    // Se the most common block elements.
    config.format_tags = 'p;h2;h3';
};