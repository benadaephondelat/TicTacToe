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
    var humanVsHumanButtonsClickHandler,
        initiliazieModule;
    
    /* configuration variables */
    var humanVsHumanAjaxCallUrl = '/Home/HumanVsHuman';
       
    /* cached dom objects */
    var $contentContainer = $('#main-content'),
        $humanVshumanButton = $('#human-vs-human-button');
    
    /**
    * Ajax call to get the _HumanVsHuman partial view.
    */
    function _humanVsHumanAjaxCall() {
        var ajaxCall = $.ajax({
            url: humanVsHumanAjaxCallUrl,
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
    humanVsHumanButtonsClickHandler = function () {
        $($humanVshumanButton).on('click', function () {
            _humanVsHumanAjaxCall().done(function (data) {
                $contentContainer.html(data);
            }).fail(function (error) {
                console.dir(error);
            });
        });
    };

    initiliazieModule = function () {
        humanVsHumanButtonsClickHandler();
    };

    return {
        init: initiliazieModule,
        humanVsHumanAjaxCall: _humanVsHumanAjaxCall
    }

})(jQuery || {});

authenticatedUserIndexModule.init();