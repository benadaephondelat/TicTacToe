chai.should();

var expect = chai.expect;

describe('humanVsHumanNewGameModule', function () {

    describe('module should exist', function () {
        it('humanVsHumanNewGameModule should not be undefined', function () {
            humanVsHumanNewGameModule.should.not.equal('undefined');
        });

        it('humanVsHumanNewGameModule should be an object', function () {
            var humanVsHumanNewGameModuleType = typeof humanVsHumanNewGameModule === 'object';

            humanVsHumanNewGameModuleType.should.equal(true);
        });

        it('humanVsHumanNewGameModule should have an object named init', function () {
            var initFunction = humanVsHumanNewGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof humanVsHumanNewGameModule.init;

            typeofInit.should.equal('function');
        });
    });

    describe('module dependencies should be in place', function () {
        it('jQuery must be present', function () {
            var isJqueryAvailable = typeof jQuery !== 'undefined';

            isJqueryAvailable.should.equal(true);
        });
    });

    describe('placeTurnAjaxCall tests', function() {
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
        
        it('placeTurn ajax call should exist', function() {
            var isUndefined = typeof humanVsHumanNewGameModule.placeTurnAjaxCall === 'undefined';

            isUndefined.should.equal(false);
        });


        it('placeTurn should be a function', function () {
            var type = typeof humanVsHumanNewGameModule.placeTurnAjaxCall;

            type.should.equal('function');
        });

        it('placeTurn should accept two parameters', function () {
            var parametersCount = humanVsHumanNewGameModule.placeTurnAjaxCall.length;

            parametersCount.should.equal(2);
        });



        it('placeTurn function should make a POST request to HumanVsHuman/PlaceTurn', function (done) {
            humanVsHumanNewGameModule.placeTurnAjaxCall().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsHuman/PlaceTurn');

            done();
        });
    });
});