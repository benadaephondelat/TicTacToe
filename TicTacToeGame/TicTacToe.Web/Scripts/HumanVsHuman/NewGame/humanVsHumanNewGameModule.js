/**
 * Contains the JavaScript code to be used in the HumanVsHumanController's NewGame view.
 * @dependencies: jQuery
 * @param {function} jQuery
 */
var humanVsHumanNewGameModule = (function (jQuery) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    /* function declarations */
    var gameBoardClickHandler,
        gameBoardColouringHandler,
        initiliazieModule;

    /* cached dom objects */
    var $gameId = $('#gameId'),
        $newGameContainer = $('#game-container'),
        $emptyGameTiles = $(".tile[data-isEmpty='True']"),
        $fullGameTiles = $(".tile[data-isEmpty='False']"),
        _antiForgeryToken = $('#place-turn-token').attr('value');

    /**
    * Ajax call to place a turn.
    * @param token: AntiForgeryToken
    * @param data: Request data as JSON object
    */
    function _placeTurnAjaxCall(token, data) {
        var ajaxCall = $.ajax({
            url: "/HumanVsHuman/PlaceTurn",
            type: 'POST',
            headers: { 'RequestVerificationToken': token },
            data: data,
            contentType: 'application/json',
            dataType: 'html',
            async: true
        });

        return ajaxCall;
    };
    
    /**
     * Returns the id of the current game or throws error.
     * @returns {Number} game id 
     */
    function _getGameId() {
        var gameId = $($gameId).attr('value');

        if (typeof gameId === 'undefined') {
            throw new Error('Invalid Game Id');
        }

        return gameId;
    }

    /**
     * Returns the the clicked tile's index or throws error. 
     * @returns {Number} tile id 
     */
    function _getTileIndex() {
        var tileIndex = $(this).data('index');

        if (tileIndex < 0 || tileIndex > 8) {
            throw new Error('Invalid Tile Index');
        }

        return tileIndex;
    }

    /**
     * Returns the current game id and clicked tile index as JSON object or throws error.
     * @returns {Object} JSON
     */
    function _getData() {
        var gameId = _getGameId();
        var tileIndex = _getTileIndex.call(this);

        var data = JSON.stringify({
            gameId: gameId,
            tileIndex: tileIndex
        });

        return data;
    }

    /**
    * When the user clicks on the board make an ajax call to the server
    * and append the partialview result to the DOM
    */
    gameBoardClickHandler = function() {
        $emptyGameTiles.on('click', function () {
            var data = _getData.call($(this));

            _placeTurnAjaxCall(_antiForgeryToken, data).done(function (result) {
                $newGameContainer.html(result);
            });
        });
    };

    /**
     * Adds a css class to all not empty tiles based on tile's value.
     */
    gameBoardColouringHandler = function() {
        $fullGameTiles.each(function (i, obj) {
            if (obj.outerText === 'X') {
                $(obj).addClass('red');
            } else {
                $(obj).addClass('blue');
            }
        });
    };

    initiliazieModule = function () {
        gameBoardClickHandler();
        gameBoardColouringHandler();
    };

    return {
        init: initiliazieModule,
        placeTurnAjaxCall: _placeTurnAjaxCall
    }

})(jQuery || {});

humanVsHumanNewGameModule.init();