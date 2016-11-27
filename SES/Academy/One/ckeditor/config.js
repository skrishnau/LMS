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
   
};
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
