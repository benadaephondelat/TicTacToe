﻿/**
 * Contains the JavaScript code to be used in the _AuthenticatedUserIndex partial view.
 * @dependencies: jQuery and ajaxCallsModule
 * @param {function} jQuery
 * @param {Module} ajaxCallsModule
 */
var authenticatedUserIndexModule = (function (jQuery, ajaxCallsModule) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    if (typeof ajaxCallsModule === 'undefined') {
        throw new Error('ajaxCallsModule is not found.');
    }

    /* function declarations */
    var humanVsHumanButtonClickHandler,
        humanVsComputerButtonClickHandler,
        computerVsComputerButtonClickHandler,
        initiliazieModule;
    
    /* cached dom objects */
    var $contentContainer = $('#main-content'),
        $humanVsHumanButton = $('#human-vs-human-button'),
        $humanVsComputerButton = $('#human-vs-computer-button'),
        $computerVsComputerButton = $('#computer-vs-computer-button');
    
    /**
    * When the user clicks human vs human Button make an ajax call to the server
    * and append the result to the DOM
    */
    humanVsHumanButtonClickHandler = function () {
        $humanVsHumanButton.on('click', function () {
            ajaxCallsModule.humanVsHumanCalls.humanVsHuman().done(function (data) {
                $contentContainer.html(data);
            });
        });
    };

    /**
    * When the user clicks human vs computer Button make an ajax call to the server
    * and append the result to the DOM
    */
    humanVsComputerButtonClickHandler = function () {
        $humanVsComputerButton.on('click', function () {
            ajaxCallsModule.humanVsComputerCalls.humanVsComputer().done(function (data) {
                $contentContainer.html(data);
            });
        });
    };

    /**
    * When the user clicks computer-vs-computer Button make an ajax call to the server
    * and append the result to the DOM
    */
    computerVsComputerButtonClickHandler = function () {
        $computerVsComputerButton.on('click', function () {
            ajaxCallsModule.computerVsComputerCalls.computerVsComputer().done(function (data) {
                $contentContainer.html(data);
            });
        });
    };

    initiliazieModule = function () {
        humanVsHumanButtonClickHandler();
        humanVsComputerButtonClickHandler();
        computerVsComputerButtonClickHandler();
    };

    return {
        init: initiliazieModule
    }

})(jQuery || {}, ajaxCallsModule || {});

authenticatedUserIndexModule.init();