chai.should();

var expect = chai.expect;

describe('finishedComputerVsComputerGameModule', function () {

    describe('module should exist', function () {

        it('finishedComputerVsComputerGameModule should not be undefined', function () {
            finishedComputerVsComputerGameModule.should.not.equal('undefined');
        });

        it('finishedComputerVsComputerGameModule should be an object', function () {
            var isOfExpectedType = typeof finishedComputerVsComputerGameModule === 'object';

            isOfExpectedType.should.equal(true);
        });

        it('finishedComputerVsComputerGameModule should have an object named init', function () {
            var initFunction = finishedComputerVsComputerGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof finishedComputerVsComputerGameModule.init;

            typeofInit.should.equal('function');
        });
    });
});