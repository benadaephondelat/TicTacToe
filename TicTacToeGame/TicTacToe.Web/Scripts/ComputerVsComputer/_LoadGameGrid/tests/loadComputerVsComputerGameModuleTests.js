chai.should();

var expect = chai.expect;

describe('loadComputerVsComputerGameModule', function () {

    describe('module should exist', function () {
        it('loadComputerVsComputerGameModule should not be undefined', function () {
            loadComputerVsComputerGameModule.should.not.equal('undefined');
        });

        it('loadComputerVsComputerGameModule should be an object', function () {
            var isModuleObject = typeof loadComputerVsComputerGameModule === 'object';

            isModuleObject.should.equal(true);
        });

        it('loadComputerVsComputerGameModule should have an object named init', function () {
            var initFunction = loadComputerVsComputerGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof loadComputerVsComputerGameModule.init;

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