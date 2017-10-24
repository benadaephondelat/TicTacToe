chai.should();

var expect = chai.expect;

describe('computerVsComputerNewGameModule', function () {

    describe('module should exist', function () {
        it('computerVsComputerNewGameModule should not be undefined', function () {
            computerVsComputerNewGameModule.should.not.equal('undefined');
        });

        it('computerVsComputerNewGameModule should be an object', function () {
            var type = typeof computerVsComputerNewGameModule === 'object';

            type.should.equal(true);
        });

        it('computerVsComputerNewGameModule should have an object named init', function () {
            var initFunction = computerVsComputerNewGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof computerVsComputerNewGameModule.init;

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