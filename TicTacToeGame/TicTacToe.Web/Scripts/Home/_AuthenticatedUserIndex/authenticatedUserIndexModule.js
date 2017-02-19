/**
 * Contains the JavaScript code to be used in the _AuthenticatedUserIndex partial view.
 * @dependencies: jQuery
 * @param {function} jQuery - jQuery library.
 */
var authenticatedUserIndexModule = (function (jQuery) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    /* function declarations */
    var humanVsHumanButtonClickHandler,
        humanVsComputerButtonClickHandler,
        initiliazieModule;
    
    /* cached dom objects */
    var $contentContainer = $('#main-content'),
        $humanVsHumanButton = $('#human-vs-human-button'),
        $humanVsComputerButton = $('#human-vs-computer-button');
    
    /**
    * Ajax call to get the _HumanVsHuman partial view.
    */
    function _humanVsHumanAjaxCall() {
        var ajaxCall = $.ajax({
            url: '/Home/HumanVsHuman',
            type: 'GET',
            dataType: 'html',
            async: true
        });

        return ajaxCall;
    }

    /**
    * Ajax call to get the _HumanVsComputer partial view.
    */
    function _humanVsComputerAjaxCall() {
        var ajaxCall = $.ajax({
            url: '/Home/HumanVsComputer',
            type: 'GET',
            dataType: 'html',
            async: true
        });

        return ajaxCall;
    }
    
    /**
    * When the user clicks humanVshumanButton make an ajax call to the server
    * and append the result to the DOM
    */
    humanVsHumanButtonClickHandler = function () {
        $humanVsHumanButton.on('click', function () {
            _humanVsHumanAjaxCall().done(function (data) {
                $contentContainer.html(data);
            });
        });
    };

    /**
    * When the user clicks humanVsCompuer Button make an ajax call to the server
    * and append the result to the DOM
    */
    humanVsComputerButtonClickHandler = function () {
        $humanVsComputerButton.on('click', function () {
            _humanVsComputerAjaxCall().done(function (data) {
                $contentContainer.html(data);
            });
        });
    };

    initiliazieModule = function () {
        humanVsHumanButtonClickHandler();
        humanVsComputerButtonClickHandler();
    };

    return {
        init: initiliazieModule,
        humanVsHumanAjaxCall: _humanVsHumanAjaxCall,
        humanVsComputerAjaxCall: _humanVsComputerAjaxCall
    }

})(jQuery || {});

authenticatedUserIndexModule.init();