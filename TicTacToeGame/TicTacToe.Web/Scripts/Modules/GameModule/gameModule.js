/**
 * Contains functions common for all game modes
 * @dependencies: jQuery
 * @param {function} jQuery
 */
var gameModule = (function (jQuery) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    /* function declarations */
    var getGameId,
        getTileIndex,
        getData,
        gameBoardColouringHandler;

    /* private functions */

    /**
     * Checks if an element is valid HTML element, if it's not it throws new Error
     * @param {DOM element} element to check
     */
    function _throwErrorIfElementIsNotValidHtmlElement($element) {
        if ($element instanceof HTMLElement) {
            return false;
        }

        if ($element[0] instanceof HTMLElement) {
            return false;
        }

        throw new Error('Invalid HTML element');
    }

    /**
     * Returns the id of the current game or throws error
     * @param {jQuery DOM element} game-id DOM element
     * @returns {String} game id 
     */
    getGameId = function ($gameId) {
        _throwErrorIfElementIsNotValidHtmlElement($gameId);

        var gameId = $gameId.attr('value');

        if (typeof gameId === 'undefined' || gameId === null) {
            throw new Error('Invalid Game Id');
        }

        return gameId;
    }

    /**
     * Returns the the clicked tile's index or throws error. 
     * @param {jQuery DOM element} tile DOM element
     * @returns {Number} tile id 
     */
    getTileIndex = function($tile) {
        var tileIndex = $tile.data('index');

        if (tileIndex < 0 || tileIndex > 8) {
            throw new Error('Invalid Tile Index');
        }

        return tileIndex;
    }

    /**
     * Returns the current game id and clicked tile index as JSON object or throws error.
     * @param {jQuery DOM element} game-id DOM element
     * @param {jQuery DOM element} tile DOM element
     * @returns {Object} JSON
     */
    getData = function($gameId, $tile) {
        var gameId = getGameId($gameId);
        var tileIndex = getTileIndex($tile);

        var data = JSON.stringify({
            gameId: gameId,
            tileIndex: tileIndex
        });

        return data;
    }

    /**
     * Adds a css class to all not empty tiles based on the tile's value.
     * @param {jQuery DOM element} tiles DOM element
     */
    gameBoardColouringHandler = function ($fullGameTiles) {
        $fullGameTiles.each(function (i, obj) {
            if (obj.outerText === 'X') {
                $(obj).addClass('red');
            } else {
                $(obj).addClass('blue');
            }
        });
    };

    return {
        getGameId: getGameId,
        getTileIndex: getTileIndex,
        getData: getData,
        gameBoardColouringHandler: gameBoardColouringHandler
    }

})(jQuery || {});