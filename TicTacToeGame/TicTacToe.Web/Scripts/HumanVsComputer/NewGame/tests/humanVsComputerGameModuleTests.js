chai.should();

var expect = chai.expect;

describe('humanVsComputerGameModule', function () {

    describe('module should exist', function () {
        it('humanVsComputerGameModule should not be undefined', function () {
            humanVsComputerGameModule.should.not.equal('undefined');
        });

        it('humanVsComputerGameModule should be an object', function () {
            var humanVsComputerGameModuleType = typeof humanVsComputerGameModule === 'object';

            humanVsComputerGameModuleType.should.equal(true);
        });

        it('humanVsComputerGameModule should have an object named init', function () {
            var initFunction = humanVsComputerGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof humanVsComputerGameModule.init;

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