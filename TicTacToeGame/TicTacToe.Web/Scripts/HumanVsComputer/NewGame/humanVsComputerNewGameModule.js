/**
 * Contains the JavaScript code to be used in the HumanVsComputerController's NewGame view.
 * @dependencies: jQuery, ajaxCallsModule and gameModule
 * @param {function} jQuery
 * @param {Module} ajaxCallsModule.js
 */
var humanVsComputerNewGameModule = (function (jQuery, ajaxCallsModule) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    if (typeof ajaxCallsModule === 'undefined') {
        throw new Error('ajaxCallsModule is not found.');
    }

    /* function declarations */
    var chooseSidesDropdownChangeHandler,
        initializeModule;

    /* cached dom objects */
    var $sidesDropdown = $('#sides-dropdown'),
        $oponentsDropdown = $('#oponents-dropdown'),
        _antiForgeryToken = $('#choose-sides-dropdown-token').attr('value'),

    /**
    * When the user clicks on the board make an ajax call to the server
    * and append the partialview result to the DOM
    */
    chooseSidesDropdownChangeHandler = function() {
        $sidesDropdown.on('change', function () {
            var data = _stringifyData($(this).val());

            ajaxCallsModule.humanVsComputerCalls.getOponentsDropdown(_antiForgeryToken, data).done(function (result) {
                $oponentsDropdown.empty();

                $(JSON.parse(result)).each(function (i, obj) {
                    _appendResultsToOponentsDropdown(obj['Text']);
                });
            });
        });
    };

    /**
    * Stringify's the dropdown's selected value
    * @param {String} startingFirstDropdownValue
    * @returns {JSON Object}
    */
    function _stringifyData(startingFirstDropdownValue) {
        var data = JSON.stringify({
            startingFirst: startingFirstDropdownValue,
        });
        
        return data;
    }

    /**
    * Appends each new option to the #sides-dropdown
    * @param {String} dropdownOptionText
    */
    function _appendResultsToOponentsDropdown(dropdownOptionText) {
        $(document.createElement('option'))
                  .attr('value', dropdownOptionText)
                  .text(dropdownOptionText)
                  .appendTo($oponentsDropdown);
    }

    initializeModule = function () {
        chooseSidesDropdownChangeHandler();
    };

    return {
        init: initializeModule
    }

})(jQuery || {}, ajaxCallsModule || {});

humanVsComputerNewGameModule.init();