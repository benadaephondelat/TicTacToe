chai.should();

var expect = chai.expect;

describe('finishedHumanVsHumanGameModule', function () {

    describe('module should exist', function () {
        it('finishedHumanVsHumanGameModule should not be undefined', function () {
            finishedHumanVsHumanGameModule.should.not.equal('undefined');
        });

        it('finishedHumanVsHumanGameModule should be an object', function () {
            var isOfExpectedType = typeof finishedHumanVsHumanGameModule === 'object';

            isOfExpectedType.should.equal(true);
        });

        it('finishedHumanVsHumanGameModule should have an object named init', function () {
            var initFunction = finishedHumanVsHumanGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof finishedHumanVsHumanGameModule.init;

            typeofInit.should.equal('function');
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
        
        it('humanVsHumanReplayGameAjaxCall ajax call should exist', function () {
            var isUndefined = typeof finishedHumanVsHumanGameModule.humanVsHumanReplayGameAjaxCall === 'undefined';

            isUndefined.should.equal(false);
        });


        it('humanVsHumanReplayGameAjaxCall should be a function', function () {
            var type = typeof finishedHumanVsHumanGameModule.humanVsHumanReplayGameAjaxCall;

            type.should.equal('function');
        });

        it('humanVsHumanReplayGameAjaxCall should accept NO parameters', function () {
            var parametersCount = finishedHumanVsHumanGameModule.humanVsHumanReplayGameAjaxCall.length;

            parametersCount.should.equal(0);
        });

        it('humanVsHumanReplayGameAjaxCall function should make a POST request to HumanVsHuman/ReplayGame', function (done) {
            finishedHumanVsHumanGameModule.humanVsHumanReplayGameAjaxCall().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsHuman/ReplayGame');

            done();
        });
    });
});