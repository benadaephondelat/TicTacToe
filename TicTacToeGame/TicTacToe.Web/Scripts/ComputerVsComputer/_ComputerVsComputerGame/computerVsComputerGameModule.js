/**
 * Contains the JavaScript code to be used in the ComputerVsComputerController's _ComputerVsComputerGame partial view.
 * @dependencies: jQuery, ajaxCallsModule and gameModule
 * @param {function} jQuery
 * @param {Module} ajaxCallsModule.js
 * @param {Module} gameModule.js
 */
var computerVsComputerGameModule = (function (jQuery, ajaxCallsModule, gameModule) {
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
    var placeTurnButtonClickHandler,
        initializeModule;

    /* cached dom objects */
    var $gameId = $('#gameId'),
        $newGameContainer = $('#game-container'),
        $fullGameTiles = $(".tile[data-isEmpty='False']"),
        $placeTurnButton = $('#place-computer-vs-computer-turn'),
        _antiForgeryToken = $('#place-turn-token').attr('value'),
        _computerTurnDelayInMiliseconds = 0;

    /**
    * Places a computer turn by making an ajax call to the server with a certain delay 
    */
    placeTurnButtonClickHandler = function () {
        debugger;
        $placeTurnButton.on('click', function () {
            _placeComputerTurn();
        });
    }

    /**
    * Places a computer turn by making an ajax call to the server with a certain delay 
    */
    function _placeComputerTurn() {
        setTimeout(function () {
            var data = _getComputerTurnData();

            ajaxCallsModule.computerVsComputerCalls.placeComputerTurn(_antiForgeryToken, data).done(function (result) {
                $newGameContainer.html(result);
            });
        }, _computerTurnDelayInMiliseconds);
    }

    /**
    * Gets the data needed for the computer's turn ajax call
    * @returns {JSON Object}
    */
    function _getComputerTurnData() {
        var data = JSON.stringify({
            gameId: $gameId.attr('value'),
        });
        
        return data;
    }

    initializeModule = function () {
        gameModule.gameBoardColouringHandler($fullGameTiles);
        placeTurnButtonClickHandler();
    };

    return {
        init: initializeModule
    }

})(jQuery || {}, ajaxCallsModule || {}, gameModule || {});

computerVsComputerGameModule.init();