/**
 * Contains all ajax calls used by the application
 * @dependencies: jQuery
 * @param {function} jQuery
 * @returns Objects that contain ajax calls functions relative to each ASP.NET MVC Controller
 */
var ajaxCallsModule = (function (jQuery) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    /* return objects declarations */
    var humanVsHumanCalls,
        humanVsComputerCalls,
        computerVsComputerCalls;

    /**
    * Human vs Human Ajax call to place a turn.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}
    */
    var humanVsHumanPlaceTurnAjaxCall = function(token, data) {
        var requestUrl = '/HumanVsHuman/PlaceTurn';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Human Ajax call to load a game.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}
    */
    var humanVsHumanLoadGameAjaxCall = function(token, data) {
        var requestUrl = '/HumanVsHuman/LoadGame';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Human Ajax call to replay a game.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}
    */
    var humanVsHumanReplayGameAjaxCall = function(token, data) {
        var requestUrl = '/HumanVsHuman/ReplayGame';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Human Ajax call
    * @returns {Function}
    */
    var humanVsHumanAjaxCall = function() {
        var requestUrl = '/Home/HumanVsHuman';

        var ajaxCall = _createGetRequestAjaxCall(requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Computer Ajax call to place a turn.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}    
    */
    var humanVsComputerPlaceTurnAjaxCall = function(token, data) {
        var requestUrl = '/HumanVsComputer/PlaceTurn';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Computer Ajax call to place a computer's turn.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}    
    */
    var humanVsComputerPlaceComputerTurnAjaxCall = function (token, data) {
        var requestUrl = '/HumanVsComputer/PlaceComputerTurn';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Computer Ajax call to load a game.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}
    */
    var humanVsComputerLoadGameAjaxCall = function (token, data) {
        var requestUrl = '/HumanVsComputer/LoadGame';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Computer Ajax call to Replay a game.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}
    */
    var humanVsComputerReplayGameAjaxCall = function (token, data) {
        var requestUrl = '/HumanVsComputer/ReplayGame';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Computer Ajax call to get the oponents dropdown values based on the selected value of the sides dropdown.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}
    */
    var humanVsComputerGetOponentsDropdown = function (token, data) {
        var requestUrl = '/HumanVsComputer/GetOponentsDropdown';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Human vs Computer Ajax call
    * @returns {Function}
    */
    var humanVsComputerAjaxCall = function() {
        var requestUrl = '/Home/HumanVsComputer';

        var ajaxCall = _createGetRequestAjaxCall(requestUrl);

        return ajaxCall;
    };

    /**
    * Computer vs Computer Ajax call
    * @returns {Function}
    */
    var computerVsComputerAjaxCall = function () {
        var requestUrl = '/Home/ComputerVsComputer';

        var ajaxCall = _createGetRequestAjaxCall(requestUrl);

        return ajaxCall;
    };

    /**
    * Computer vs Computer Ajax call to place a computer's turn.
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @returns {Function}    
    */
    var computerVsComputerPlaceComputerTurnAjaxCall = function (token, data) {
        var requestUrl = '/ComputerVsComputer/PlaceComputerTurn';

        var ajaxCall = _createPostRequestAjaxCall(token, data, requestUrl);

        return ajaxCall;
    };

    /**
    * Creates a post request ajax call
    * @param {String} token: AntiForgeryToken
    * @param {Object} data: Request data as JSON object
    * @param {String} url: Request url
    * @returns {Function} ajax post function
    */
    function _createPostRequestAjaxCall(token, data, url) {
        var ajaxCall = $.ajax({
            url: url,
            type: 'POST',
            headers: { 'RequestVerificationToken': token },
            data: data,
            contentType: 'application/json',
            dataType: 'html',
            async: true
        });

        return ajaxCall;
    }

    /**
    * Creates a get request ajax call
    * @param {String} url: Request url
    * @returns {Function} ajax post function
    */
    function _createGetRequestAjaxCall(url) {
        var ajaxCall = $.ajax({
            url: url,
            type: 'GET',
            dataType: 'html',
            async: true
        });

        return ajaxCall;
    };

    return {
        humanVsHumanCalls: {
            humanVsHuman: humanVsHumanAjaxCall,
            placeTurn: humanVsHumanPlaceTurnAjaxCall,
            loadGame: humanVsHumanLoadGameAjaxCall,
            replayGame: humanVsHumanReplayGameAjaxCall,
        },
        humanVsComputerCalls: {
            humanVsComputer: humanVsComputerAjaxCall,
            placeTurn: humanVsComputerPlaceTurnAjaxCall,
            placeComputerTurn: humanVsComputerPlaceComputerTurnAjaxCall,
            loadGame: humanVsComputerLoadGameAjaxCall,
            replayGame: humanVsComputerReplayGameAjaxCall,
            getOponentsDropdown: humanVsComputerGetOponentsDropdown
        },
        computerVsComputerCalls: {
            computerVsComputer: computerVsComputerAjaxCall,
            placeComputerTurn: computerVsComputerPlaceComputerTurnAjaxCall
        }
    }

})(jQuery || {});