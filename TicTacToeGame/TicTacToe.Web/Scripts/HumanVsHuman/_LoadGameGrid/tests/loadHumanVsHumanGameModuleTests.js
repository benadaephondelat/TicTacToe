chai.should();

var expect = chai.expect;

describe('loadHumanVsHumanGameModule', function () {

    describe('module should exist', function () {
        it('loadHumanVsHumanGameModule should not be undefined', function () {
            loadHumanVsHumanGameModule.should.not.equal('undefined');
        });

        it('loadHumanVsHumanGameModule should be an object', function () {
            var isModuleObject = typeof loadHumanVsHumanGameModule === 'object';

            isModuleObject.should.equal(true);
        });

        it('loadHumanVsHumanGameModule should have an object named init', function () {
            var initFunction = loadHumanVsHumanGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof loadHumanVsHumanGameModule.init;

            typeofInit.should.equal('function');
        });
    });

    describe('module dependencies should be in place', function () {
        it('jQuery must be present', function () {
            var isJqueryAvailable = typeof jQuery !== 'undefined';

            isJqueryAvailable.should.equal(true);
        });
    });
});