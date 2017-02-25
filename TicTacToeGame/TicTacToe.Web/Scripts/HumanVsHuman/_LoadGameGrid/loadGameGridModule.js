/**
 * Contains the JavaScript to be used in the HumanVsHumanController's _LoadGameGrid partial view.
 * @dependencies: jQuery and ajaxCallsModule
 * @param {function} jQuery
 * @param {Module} ajaxCallsModule.js
 */
var loadGameGridModule = (function (jQuery, ajaxCallsModule) {

    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    if (typeof ajaxCallsModule === 'undefined') {
        throw new Error('ajaxCallsModule is not found.');
    }

    /* function declarations */
    var createButtons,
        loadGameRequest,
        gridRowClickHandler,
        initiliazieModule;

    /* cached DOM objects */
    var $gridRows = $('.mvc-grid tbody tr'),
        $gameContainer = $('#game-container'),
        _antiForgeryToken = $('#load-game-token').attr('value');

    /**
    * Checks if the grid is empty.
    * If the first row contains the text - "No data found" returns true. 
    * @param gridRow: Grid Row as html object
    */
    function _gridIsEmpty(gridRow) {
        if (gridRow.innerText.indexOf('No data found') !== -1) {
            return true;
        }

        return false;
    };

    /**
    * Appends a html button to a given DOM element
    */
    createButtons = function () {
        $(this).append('<button id="load-game-button" class="btn btn-success">Load</button>');
    };

    /**
    * Calls loadGameAjaxCall and appends the result to the DOM
    */
    loadGameRequest = function (data) {
        ajaxCallsModule.humanVsHumanCalls.loadGame(_antiForgeryToken, data).done(function (result) {
            $gameContainer.html(result);
        });
    };

    /**
    * Attaches an event handler to a given grid row.
    */
    gridRowClickHandler = function () {
        var currentGridRow = $(this);

        $(currentGridRow).on('click', function (event) {
            var clickedElement = event.target.id;

            if (clickedElement === 'load-game-button') {
                var gameId = $(currentGridRow).find('td.game-id').html();

                var data = JSON.stringify({
                    gameId: gameId
                });

                loadGameRequest(data);
            }
        });
    };

    initiliazieModule = function () {
        $gridRows.each(function (index, currentGridRow) {
            if (_gridIsEmpty(currentGridRow)) {
                return false;
            }

            createButtons.call(currentGridRow);

            gridRowClickHandler.call(currentGridRow);
        });
    };

    return {
        init: initiliazieModule
    }

})(jQuery || {}, ajaxCallsModule || {});

loadGameGridModule.init();