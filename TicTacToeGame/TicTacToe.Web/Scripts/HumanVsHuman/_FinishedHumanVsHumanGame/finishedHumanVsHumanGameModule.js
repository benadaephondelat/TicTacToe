/**
 * Contains the JavaScript to be used in the HumanVsHumanController's ReplayGame partial view.
 * @dependencies: jQuery
 * @param {function} jQuery
 */
var finishedHumanVsHumanGameModule = (function (jQuery) {

    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    /* function declarations */
    var replayGameButtonClickHandler,
        initiliazieModule;

    /* cached DOM objects */
    var $replayGameButton = $('#replay-game-button'),
        $newGameContainer = $('#new-game-container'),
        _antiForgeryToken = $('#finished-game-token').attr('value');

    /**
    * Ajax call to place a turn.
    * @param token: AntiForgeryToken
    * @param data: Request data as JSON object
    */
    function humanVsHumanReplayGameAjaxCall() {
        var ajaxCall = $.ajax({
            url: "/HumanVsHuman/ReplayGame",
            type: 'POST',
            headers: { 'RequestVerificationToken': _antiForgeryToken },
            dataType: 'html',
            async: true
        });

        return ajaxCall;
    };

    /**
     * When the user clicks on the replay game button
     * get the _HumanVsHumanGame partial view and append it to the DOM
     */
    replayGameButtonClickHandler = function() {
        $replayGameButton.on('click', function() {
            humanVsHumanReplayGameAjaxCall().done(function(result) {
                $newGameContainer.html(result);
            });
        });
    };

    initiliazieModule = function () {
        replayGameButtonClickHandler();
    };

    return {
        init: initiliazieModule,
        humanVsHumanReplayGameAjaxCall: humanVsHumanReplayGameAjaxCall
    }

})(jQuery || {});

finishedHumanVsHumanGameModule.init();