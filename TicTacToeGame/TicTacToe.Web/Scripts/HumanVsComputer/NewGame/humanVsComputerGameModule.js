/**
 * Contains the JavaScript code to be used in the HumanVsComputerController's NewGame view.
 * @dependencies: jQuery, ajaxCallsModule and gameModule
 * @param {function} jQuery
 * @param {Module} ajaxCallsModule.js
 * @param {Module} gameModule.js
 */
var humanVsComputerGameModule = (function (jQuery, ajaxCallsModule, gameModule) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    if (typeof ajaxCallsModule === 'undefined') {
        throw new Error('ajaxCallsModule is not found.');
    }

    if (typeof gameModule === 'undefined') {
        throw new Error('gameModule is not found.');
    }

    /* function declarations */
    var gameBoardClickHandler,
        initiliazieModule;

    /* cached dom objects */
    var $gameId = $('#gameId'),
        $newGameContainer = $('#game-container'),
        $emptyGameTiles = $(".tile[data-isEmpty='True']"),
        $fullGameTiles = $(".tile[data-isEmpty='False']"),
        _antiForgeryToken = $('#place-turn-token').attr('value');

    /**
    * When the user clicks on the board make an ajax call to the server
    * and append the partialview result to the DOM
    */
    gameBoardClickHandler = function() {
        $emptyGameTiles.on('click', function () {
            var data = gameModule.getData($gameId, $(this));

            ajaxCallsModule.humanVsComputerCalls.placeTurn(_antiForgeryToken, data).done(function (result) {
                $newGameContainer.html(result);
            });
        });
    };

    initiliazieModule = function () {
        gameBoardClickHandler();
        gameModule.gameBoardColouringHandler($fullGameTiles);
    };

    return {
        init: initiliazieModule
    }

})(jQuery || {}, ajaxCallsModule || {}, gameModule || {});

humanVsComputerGameModule.init();