chai.should();

var expect = chai.expect;

describe('ajaxCallsModule', function () {

    describe('module should exist', function () {
        it('ajaxCallsModule should not be undefined', function () {
            ajaxCallsModule.should.not.equal('undefined');
        });

        it('ajaxCallsModule should return humanVsHumanCalls object', function () {
            var typeofInit = typeof ajaxCallsModule.humanVsHumanCalls;

            typeofInit.should.equal('object');
        });

        it('ajaxCallsModule should return humanVsComputerCalls object', function () {
            var typeofInit = typeof ajaxCallsModule.humanVsComputerCalls;

            typeofInit.should.equal('object');
        });
    });

    describe('humanVsHuman tests', function () {
        beforeEach(function () {
            this.xhr = sinon.useFakeXMLHttpRequest();

            this.requests = [];

            this.xhr.onCreate = function (xhr) {
                this.requests.push(xhr);
            }.bind(this);

        });

        afterEach(function () {
            this.xhr.restore();
        });

        it('humanVsHuman should exist', function () {
            var isUndefined = typeof ajaxCallsModule.humanVsHumanCalls.humanVsHuman === 'undefined';

            isUndefined.should.equal(false);
        });


        it('humanVsHuman should be a function', function () {
            var type = typeof ajaxCallsModule.humanVsHumanCalls.humanVsHuman;

            type.should.equal('function');
        });

        it('humanVsHuman should accept no parameters', function () {
            var parametersCount = ajaxCallsModule.humanVsHumanCalls.humanVsHuman.length;

            parametersCount.should.equal(0);
        });

        it('humanVsHuman function should make a GET request to /Home/HumanVsHuman', function (done) {
            ajaxCallsModule.humanVsHumanCalls.humanVsHuman().done(function () {
                done();
            });

            this.requests[0].method.should.equal('GET');
            this.requests[0].url.should.equal('/Home/HumanVsHuman');

            done();
        });
    });

    describe('humanVsHumanPlaceTurnAjaxCall tests', function () {
        beforeEach(function () {
            this.xhr = sinon.useFakeXMLHttpRequest();

            this.requests = [];

            this.xhr.onCreate = function (xhr) {
                this.requests.push(xhr);
            }.bind(this);

        });

        afterEach(function () {
            this.xhr.restore();
        });

        it('humanVsHuman should exist', function () {
            var isUndefined = typeof ajaxCallsModule.humanVsHumanCalls.placeTurn === 'undefined';

            isUndefined.should.equal(false);
        });


        it('humanVsHuman should be a function', function () {
            var type = typeof ajaxCallsModule.humanVsHumanCalls.placeTurn;

            type.should.equal('function');
        });

        it('humanVsHuman should accept 2 parameters', function () {
            var parametersCount = ajaxCallsModule.humanVsHumanCalls.placeTurn.length;

            parametersCount.should.equal(2);
        });

        it('humanVsHuman function should make a POST request to /HumanVsHuman/PlaceTurn', function (done) {
            ajaxCallsModule.humanVsHumanCalls.placeTurn().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsHuman/PlaceTurn');

            done();
        });
    });

    describe('humanVsHumanLoadGameAjaxCall tests', function () {
        beforeEach(function () {
            this.xhr = sinon.useFakeXMLHttpRequest();

            this.requests = [];

            this.xhr.onCreate = function (xhr) {
                this.requests.push(xhr);
            }.bind(this);

        });

        afterEach(function () {
            this.xhr.restore();
        });

        it('humanVsHumanLoadGameAjaxCall should exist', function () {
            var isUndefined = typeof ajaxCallsModule.humanVsHumanCalls.loadGame === 'undefined';

            isUndefined.should.equal(false);
        });

        it('humanVsHumanLoadGameAjaxCall should be a function', function () {
            var type = typeof ajaxCallsModule.humanVsHumanCalls.loadGame;

            type.should.equal('function');
        });

        it('humanVsHumanLoadGameAjaxCall should accept 2 parameters', function () {
            var parametersCount = ajaxCallsModule.humanVsHumanCalls.loadGame.length;

            parametersCount.should.equal(2);
        });

        it('humanVsHumanLoadGameAjaxCall function should make a POST request to /HumanVsHuman/LoadGame', function (done) {
            ajaxCallsModule.humanVsHumanCalls.loadGame().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsHuman/LoadGame');

            done();
        });
    });

    describe('humanVsHumanReplayGameAjaxCall tests', function () {
        beforeEach(function () {
            this.xhr = sinon.useFakeXMLHttpRequest();

            this.requests = [];

            this.xhr.onCreate = function (xhr) {
                this.requests.push(xhr);
            }.bind(this);

        });

        afterEach(function () {
            this.xhr.restore();
        });

        it('humanVsHumanReplayGameAjaxCall should exist', function () {
            var isUndefined = typeof ajaxCallsModule.humanVsHumanCalls.replayGame === 'undefined';

            isUndefined.should.equal(false);
        });


        it('humanVsHumanReplayGameAjaxCall should be a function', function () {
            var type = typeof ajaxCallsModule.humanVsHumanCalls.replayGame;

            type.should.equal('function');
        });

        it('humanVsHumanReplayGameAjaxCall should accept 2 parameters', function () {
            var parametersCount = ajaxCallsModule.humanVsHumanCalls.replayGame.length;

            parametersCount.should.equal(2);
        });

        it('humanVsHumanReplayGameAjaxCall function should make a POST request to /HumanVsHuman/ReplayGame', function (done) {
            ajaxCallsModule.humanVsHumanCalls.replayGame().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsHuman/ReplayGame');

            done();
        });
    });

    describe('humanVsComputer tests', function () {
        beforeEach(function () {
            this.xhr = sinon.useFakeXMLHttpRequest();

            this.requests = [];

            this.xhr.onCreate = function (xhr) {
                this.requests.push(xhr);
            }.bind(this);

        });

        afterEach(function () {
            this.xhr.restore();
        });

        it('humanVsComputer should exist', function () {
            var isUndefined = typeof ajaxCallsModule.humanVsComputerCalls.humanVsComputer === 'undefined';

            isUndefined.should.equal(false);
        });


        it('humanVsComputer should be a function', function () {
            var type = typeof ajaxCallsModule.humanVsComputerCalls.humanVsComputer;

            type.should.equal('function');
        });

        it('humanVsComputer should accept no parameters', function () {
            var parametersCount = ajaxCallsModule.humanVsComputerCalls.humanVsComputer.length;

            parametersCount.should.equal(0);
        });

        it('humanVsComputer function should make a GET request to /Home/HumanVsComputer', function (done) {
            ajaxCallsModule.humanVsComputerCalls.humanVsComputer().done(function () {
                done();
            });

            this.requests[0].method.should.equal('GET');
            this.requests[0].url.should.equal('/Home/HumanVsComputer');

            done();
        });
    });

    describe('humanVsComputerPlaceTurnAjaxCall tests', function () {
        beforeEach(function () {
            this.xhr = sinon.useFakeXMLHttpRequest();

            this.requests = [];

            this.xhr.onCreate = function (xhr) {
                this.requests.push(xhr);
            }.bind(this);

        });

        afterEach(function () {
            this.xhr.restore();
        });

        it('humanVsComputerPlaceTurnAjaxCall should exist', function () {
            var isUndefined = typeof ajaxCallsModule.humanVsComputerCalls.placeTurn === 'undefined';

            isUndefined.should.equal(false);
        });


        it('humanVsComputerPlaceTurnAjaxCall should be a function', function () {
            var type = typeof ajaxCallsModule.humanVsComputerCalls.placeTurn;

            type.should.equal('function');
        });

        it('humanVsComputerPlaceTurnAjaxCall should accept 2 parameters', function () {
            var parametersCount = ajaxCallsModule.humanVsComputerCalls.placeTurn.length;

            parametersCount.should.equal(2);
        });

        it('humanVsComputerPlaceTurnAjaxCall function should make a POST request to /HumanVsComputer/PlaceTurn', function (done) {
            ajaxCallsModule.humanVsComputerCalls.placeTurn().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsComputer/PlaceTurn');

            done();
        });
    });

    describe('humanVsComputerPlaceComputerTurnAjaxCall tests', function () {
        beforeEach(function () {
            this.xhr = sinon.useFakeXMLHttpRequest();

            this.requests = [];

            this.xhr.onCreate = function (xhr) {
                this.requests.push(xhr);
            }.bind(this);

        });

        afterEach(function () {
            this.xhr.restore();
        });

        it('humanVsComputerPlaceComputerTurnAjaxCall should exist', function () {
            var isUndefined = typeof ajaxCallsModule.humanVsComputerCalls.placeComputerTurn === 'undefined';

            isUndefined.should.equal(false);
        });

        it('humanVsComputerPlaceComputerTurnAjaxCall should be a function', function () {
            var type = typeof ajaxCallsModule.humanVsComputerCalls.placeComputerTurn;

            type.should.equal('function');
        });

        it('humanVsComputerPlaceComputerTurnAjaxCall should accept 2 parameters', function () {
            var parametersCount = ajaxCallsModule.humanVsComputerCalls.placeComputerTurn.length;

            parametersCount.should.equal(2);
        });

        it('humanVsComputerPlaceComputerTurnAjaxCall function should make a POST request to /HumanVsComputer/PlaceComputerTurn', function (done) {
            ajaxCallsModule.humanVsComputerCalls.placeComputerTurn().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsComputer/PlaceComputerTurn');

            done();
        });
    });

    describe('humanVsComputerReplayGameAjaxCall tests', function () {
        beforeEach(function () {
            this.xhr = sinon.useFakeXMLHttpRequest();

            this.requests = [];

            this.xhr.onCreate = function (xhr) {
                this.requests.push(xhr);
            }.bind(this);

        });

        afterEach(function () {
            this.xhr.restore();
        });

        it('humanVsComputerReplayGameAjaxCall should exist', function () {
            var isUndefined = typeof ajaxCallsModule.humanVsComputerCalls.replayGame === 'undefined';

            isUndefined.should.equal(false);
        });


        it('humanVsComputerReplayGameAjaxCall should be a function', function () {
            var type = typeof ajaxCallsModule.humanVsComputerCalls.replayGame;

            type.should.equal('function');
        });

        it('humanVsComputerReplayGameAjaxCall should accept 2 parameters', function () {
            var parametersCount = ajaxCallsModule.humanVsComputerCalls.replayGame.length;

            parametersCount.should.equal(2);
        });

        it('humanVsComputerReplayGameAjaxCall function should make a POST request to /HumanVsComputer/ReplayGame', function (done) {
            ajaxCallsModule.humanVsComputerCalls.replayGame().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsComputer/ReplayGame');

            done();
        });
    });
});