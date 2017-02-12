chai.should();

var expect = chai.expect;

describe('loadGameGridModule', function () {

    describe('module should exist', function () {
        it('loadGameGridModule should not be undefined', function () {
            loadGameGridModule.should.not.equal('undefined');
        });

        it('loadGameGridModule should be an object', function () {
            var isOfExpectedType = typeof loadGameGridModule === 'object';

            isOfExpectedType.should.equal(true);
        });

        it('loadGameGridModule should have an object named init', function () {
            var initFunction = loadGameGridModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof loadGameGridModule.init;

            typeofInit.should.equal('function');
        });
    });

    describe('loadGameGridModule ajax calls tests', function () {
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

        it('loadGameAjaxCall should exist', function () {
            var isUndefined = typeof loadGameGridModule.loadGameAjaxCall === 'undefined';

            isUndefined.should.equal(false);
        });


        it('loadGameAjaxCall should be a function', function () {
            var type = typeof loadGameGridModule.loadGameAjaxCall;

            type.should.equal('function');
        });

        it('loadGameAjaxCall should accept 1 parameter', function () {
            var parametersCount = loadGameGridModule.loadGameAjaxCall.length;

            parametersCount.should.equal(1);
        });

        it('loadGameAjaxCall function should make a POST request to HumanVsHuman/LoadGame', function (done) {
            loadGameGridModule.loadGameAjaxCall().done(function () {
                done();
            });

            this.requests[0].method.should.equal('POST');
            this.requests[0].url.should.equal('/HumanVsHuman/LoadGame');

            done();
        });
    });
});