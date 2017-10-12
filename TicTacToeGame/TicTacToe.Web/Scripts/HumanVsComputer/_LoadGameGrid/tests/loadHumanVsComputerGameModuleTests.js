chai.should();

var expect = chai.expect;

describe('loadHumanVsComputerGameModule', function () {

    describe('module should exist', function () {
        it('loadHumanVsComputerGameModule should not be undefined', function () {
            loadHumanVsComputerGameModule.should.not.equal('undefined');
        });

        it('loadHumanVsComputerGameModule should be an object', function () {
            var isModuleObject = typeof loadHumanVsComputerGameModule === 'object';

            isModuleObject.should.equal(true);
        });

        it('loadHumanVsComputerGameModule should have an object named init', function () {
            var initFunction = loadHumanVsComputerGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof loadHumanVsComputerGameModule.init;

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