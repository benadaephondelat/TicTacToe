/**
 * Contains common functionality to be re-used for all modules responsible for loading a game
 * @dependencies: jQuery, ajaxCallsModule
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
        gridRowClickHandler,
        initiliazieModule;

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
    * Attaches an event handler to a given grid row.
    * @param gridRow {jQuery DOM object} Grid Row as html object
    * @param loadGameRequest {function} A function that exeutes a specific request to the server
    */
    gridRowClickHandler = function (currentGridRow, loadGameRequest) {
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

    /**
    * Initializes the module
    * @param loadGameRequest {function} A function that exeutes a specific request to the server
    */
    initiliazieModule = function (loadGameRequest) {
        if (typeof loadGameRequest === 'undefined') {
            throw new Error('loadGameRequest is not found.');
        }

        $('.mvc-grid tbody tr').each(function (index, currentGridRow) {
            if (_gridIsEmpty(currentGridRow)) {
                return false;
            }

            createButtons.call(currentGridRow);

            gridRowClickHandler(currentGridRow, loadGameRequest);
        });
    };

    return {
        init: initiliazieModule
    }

})(jQuery || {}, ajaxCallsModule || {});