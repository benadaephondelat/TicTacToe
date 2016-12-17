chai.should();

describe('authenticatedUserIndexModule', function () {

    describe('module dependencies should be in place', function () {
        it('jQuery must be present', function () {
            var isJqueryAvailable = typeof jQuery !== 'undefined';

            isJqueryAvailable.should.equal(true);
        });
    });

    describe('module should exist', function () {
        it('authenticatedUserIndexModule should not be undefined', function () {
            authenticatedUserIndexModule.should.not.equal('undefined');
        });

        it('authenticatedUserIndexModule should be an object', function () {
            var authenticatedUserIndexModuleType = typeof authenticatedUserIndexModule === 'object';

            authenticatedUserIndexModuleType.should.equal(true);
        });

        it('authenticatedUserIndexModule should have an object named init', function () {
            var initFunction = authenticatedUserIndexModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof authenticatedUserIndexModule.init;

            typeofInit.should.equal('function');
        });
    });

    describe('ajax calls tests', function () {
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

        it('humanVsHumanAjaxCall should not be undefined', function () {
            var isUndefined = typeof authenticatedUserIndexModule.humanVsHumanAjaxCall === 'undefined';

            isUndefined.should.equal(false);
        });

        it('humanVsHumanAjaxCall should be a function', function () {
            var type = typeof authenticatedUserIndexModule.humanVsHumanAjaxCall;

            type.should.equal('function');
        });

        it('humanVsHumanAjaxCall function should make a GET request to Home/HumanVsHuman', function (done) {
            authenticatedUserIndexModule.humanVsHumanAjaxCall().done(function () {
                done();
            });

            this.requests[0].method.should.equal('GET');
            this.requests[0].url.should.equal('/Home/HumanVsHuman');
            
            done();
        });
    });
});