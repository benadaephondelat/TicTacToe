﻿/**
 * Contains the JavaScript to be used in the HumanVsHumanController's _FinishedHumanVsHuman partial view.
 * @dependencies: jQuery and ajaxCallsModule
 * @param {function} jQuery
 * @param {Module} ajaxCallsModule
 */
var finishedHumanVsHumanGameModule = (function (jQuery, ajaxCallsModule) {

    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    if (typeof ajaxCallsModule === 'undefined') {
        throw new Error('ajaxCallsModule is not found.');
    }

    /* function declarations */
    var replayGameButtonClickHandler,
        initiliazieModule;

    /* cached DOM objects */
    var $replayGameButton = $('#replay-game-button'),
        $newGameContainer = $('#game-container'),
        _antiForgeryToken = $('#finished-game-token').attr('value');

    /**
     * When the user clicks on the replay game button
     * get the _HumanVsHumanGame partial view and append it to the DOM
     */
    replayGameButtonClickHandler = function() {
        $replayGameButton.on('click', function() {
            ajaxCallsModule.humanVsHumanCalls.replayGame(_antiForgeryToken, {}).done(function (result) {
                $newGameContainer.html(result);
            });
        });
    };

    initiliazieModule = function () {
        replayGameButtonClickHandler();
    };

    return {
        init: initiliazieModule
    }

})(jQuery || {}, ajaxCallsModule || {});

finishedHumanVsHumanGameModule.init();