/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.enterMode = CKEDITOR.ENTER_DIV;
    //config.extraPlugins = 'wordcount,notification';
    //config.extraPlugins = 'notification';
    //config.extraPlugins = 'wordcount';
    //config.extraPlugins = 'wordcount,notification'; 
    //config.plugins = 'wordcount';
    //alert(CKEDITOR.version);


    config.toolbar = 'MyToolbarRecommended';
    config.toolbar_MyToolbarRecommended =
	[
		{ name: 'document', items: ['Source', 'NewPage', 'Preview'] },
		{ name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
		{ name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },

        {
            name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'
                   , 'Iframe']
        },

        { name: 'tools', items: ['Maximize', '-', 'About'] },

        '/',

        { name: 'paragraph', items: ['list', 'NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', '-', 'align'] },
        //{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
		
        { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] },
        '/',

		{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
		{ name: 'basicstyles', items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] }
        
	];

    config.toolbar_MyToolbar =
   [
       { name: 'document', items: ['NewPage', 'Preview'] },
       { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
       { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
       {
           name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'
                  , 'Iframe']
       },
               '/',
       { name: 'styles', items: ['Styles', 'Format'] },
       { name: 'basicstyles', items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] },
       { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
       { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
       { name: 'tools', items: ['Maximize', '-', 'About'] }
   ];

    config.toolbar_Basic =
    [
	    ['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink', '-', 'About']
    ];

     //Toolbar configuration.
    config.toolbar_Group = [
     { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
     { name: 'editing', groups: ['find', 'selection', 'spellchecker'], items: ['Scayt'] },
     { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
     { name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'SpecialChar'] },
     { name: 'tools', items: ['Maximize'] },
     { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source'] },
     { name: 'others', items: ['-'] },
     '/',
     { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] },
     { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
     { name: 'styles', items: ['Styles', 'Format'] },
     { name: 'about', items: ['About'] }
    ];

};

//config.toolbar = [
// { name: 'document', items: ['Source', '-', 'NewPage', 'Preview', '-', 'Templates'] },
// { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
// '/',
// { name: 'basicstyles', items: ['Bold', 'Italic'] }
//];




//CKEDITOR.replace('editor1',
//{
//    toolbar: 'Basic'
//});

//config.toolbarGroups = [
//   { name: 'clipboard', groups: ['clipboard', 'undo'] },
//   { name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
//   { name: 'links' },
//   { name: 'insert' },
//   { name: 'forms' },
//   { name: 'tools' },
//   { name: 'document', groups: ['mode', 'document', 'doctools'] },
//   { name: 'others' },
//   '/',
//   { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
//   { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
//   { name: 'styles' },
//   { name: 'colors' },
//   { name: 'about' }
//];


//CKEDITOR.editorConfig = function (config) {
//    config.extraPlugins = 'wordcount,notification';
//    //    config.toolbar [
//    //    et cetera . . .
//    //];
//};

//CKEDITOR.editorConfig = function( config ) {
//    config.extraPlugins = 'wordcount,notification';
////    config.toolbar [
////    //et cetera . . .
////];
//};


////Word count
//config.wordcount = {

//    // Whether or not you want to show the Paragraphs Count
//    showParagraphs: true,

//    // Whether or not you want to show the Word Count
//    showWordCount: true,

//    // Whether or not you want to show the Char Count
//    showCharCount: false,

//    // Whether or not you want to count Spaces as Chars
//    countSpacesAsChars: true,

//    // Whether or not to include Html chars in the Char Count
//    countHTML: false,

//    // Maximum allowed Word Count, -1 is default for unlimited
//    maxWordCount: -1,

//    // Maximum allowed Char Count, -1 is default for unlimited
//    maxCharCount: -1,

//    // Add filter to add or remove element before counting (see CKEDITOR.htmlParser.filter), Default value : null (no filter)
//    filter: new CKEDITOR.htmlParser.filter({
//        elements: {
//            div: function (element) {
//                if (element.attributes.class == 'mediaembed') {
//                    return false;
//                }
//            }
//        }
//    })
//};
