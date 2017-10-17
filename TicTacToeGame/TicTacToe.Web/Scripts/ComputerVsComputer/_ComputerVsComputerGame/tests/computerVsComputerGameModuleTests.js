chai.should();

var expect = chai.expect;

describe('computerVsComputerGameModule', function () {

    describe('module should exist', function () {
        it('computerVsComputerGameModule should not be undefined', function () {
            computerVsComputerGameModule.should.not.equal('undefined');
        });

        it('computerVsComputerGameModule should be an object', function () {
            var moduleType = typeof computerVsComputerGameModule === 'object';

            moduleType.should.equal(true);
        });

        it('computerVsComputerGameModule should have an object named init', function () {
            var initFunction = computerVsComputerGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof computerVsComputerGameModule.init;

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