/**
 * Contains the JavaScript code to be used HumanVsHuman Controller's _LoadGameGrid partial view
 * @dependencies: jQuery, ajaxCallsModule, loadGameRequest
 * @param {function} jQuery
 * @param {Module} ajaxCallsModule.js
 * @param {Module} loadGameGridModule - contains common functionality to be re-used for loading a game
 */
var loadHumanVsHumanGameModule = (function (jQuery, ajaxCallsModule, loadGameGridModule) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    if (typeof ajaxCallsModule === 'undefined') {
        throw new Error('ajaxCallsModule is not found.');
    }

    if (typeof loadGameGridModule === 'undefined') {
        throw new Error('loadGameRequest is not found.');
    }

    /* function declarations */
    var loadGameRequest,
        initiliazieModule;
        
    /* cached DOM objects*/
    var $gameContainer = $('#game-container'),
        _antiForgeryToken = $('#load-game-token').attr('value');

    /**
    * Calls humanVsHumanCalls.loadGameAjaxCall and appends the result to the DOM
    */
    loadGameRequest = function (data) {
        ajaxCallsModule.humanVsHumanCalls.loadGame(_antiForgeryToken, data).done(function (result) {
            $gameContainer.html(result);
        });
    };

    initiliazieModule = function () {
        loadGameGridModule.init(loadGameRequest);
    };

    return {
        init: initiliazieModule
    }

})(jQuery || {}, ajaxCallsModule || {}, loadGameGridModule || {});

loadHumanVsHumanGameModule.init();