﻿/**
 * Contains the JavaScript code to be used in the HumanVsComputerController's NewGame view.
 * @dependencies: jQuery, ajaxCallsModule and gameModule
 * @param {function} jQuery
 * @param {Module} ajaxCallsModule.js
 */
var humanVsComputerNewGameModule = (function (jQuery, ajaxCallsModule, newGameModule) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    if (typeof ajaxCallsModule === 'undefined') {
        throw new Error('ajaxCallsModule is not found.');
    }

    if (typeof newGameModule === 'undefined') {
        throw new Error('newGameModule is not found.');
    }

    /* function declarations */
    var initializeModule,
        getOponentsDropdown;

    getOponentsDropdown = ajaxCallsModule.humanVsComputerCalls.getOponentsDropdown;
    
    initializeModule = function () {
        newGameModule.init(getOponentsDropdown);
    };

    return {
        init: initializeModule
    }

})(jQuery || {}, ajaxCallsModule || {}, newGameModule || {});

humanVsComputerNewGameModule.init();