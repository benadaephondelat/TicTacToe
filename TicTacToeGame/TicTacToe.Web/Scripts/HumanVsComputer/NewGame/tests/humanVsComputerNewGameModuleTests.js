chai.should();

var expect = chai.expect;

describe('humanVsComputerNewGameModule', function () {

    describe('module should exist', function () {
        it('humanVsComputerNewGameModule should not be undefined', function () {
            humanVsComputerNewGameModule.should.not.equal('undefined');
        });

        it('humanVsComputerNewGameModule should be an object', function () {
            var humanVsComputerNewGameModuleType = typeof humanVsComputerNewGameModule === 'object';

            humanVsComputerNewGameModuleType.should.equal(true);
        });

        it('humanVsComputerNewGameModule should have an object named init', function () {
            var initFunction = humanVsComputerNewGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof humanVsComputerNewGameModule.init;

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