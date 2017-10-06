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
        initializeModule;

    /* cached dom objects */
    var $gameId = $('#gameId'),
        $newGameContainer = $('#game-container'),
        $emptyGameTiles = $(".tile[data-isEmpty='True']"),
        $fullGameTiles = $(".tile[data-isEmpty='False']"),
        turnHolderId = $('#userId').attr('value'),
        computerId = 'computer-id',
        _antiForgeryToken = $('#place-turn-token').attr('value'),
        _computerTurnDelayInMiliseconds = 1500;

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

    /**
    * Checks if it's the computer's turn
    * @returns {Boolean}
    */
    function _isTheComputerTurn() {
        if (turnHolderId === computerId) {
            return true;
        }

        return false;
    }
    
    /**
    * Places a computer turn by making an ajax call to the server with a certain delay 
    */
    function _placeComputerTurn() {
        setTimeout(function () {
            var data = _getComputerTurnData();

            ajaxCallsModule.humanVsComputerCalls.placeComputerTurn(_antiForgeryToken, data).done(function (result) {
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

        if (_isTheComputerTurn()) {
            _placeComputerTurn();
        } else {
            gameBoardClickHandler();
        }
    };

    return {
        init: initializeModule
    }

})(jQuery || {}, ajaxCallsModule || {}, gameModule || {});

humanVsComputerGameModule.init();