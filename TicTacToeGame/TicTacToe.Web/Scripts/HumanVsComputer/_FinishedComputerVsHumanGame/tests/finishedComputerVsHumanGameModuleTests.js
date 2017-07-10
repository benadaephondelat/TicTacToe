chai.should();

var expect = chai.expect;

describe('finishedComputerVsHumanGameModule', function () {

    describe('module should exist', function () {

        it('finishedComputerVsHumanGameModule should not be undefined', function () {
            finishedComputerVsHumanGameModule.should.not.equal('undefined');
        });

        it('finishedComputerVsHumanGameModule should be an object', function () {
            var isOfExpectedType = typeof finishedComputerVsHumanGameModule === 'object';

            isOfExpectedType.should.equal(true);
        });

        it('finishedComputerVsHumanGameModule should have an object named init', function () {
            var initFunction = finishedComputerVsHumanGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof finishedComputerVsHumanGameModule.init;

            typeofInit.should.equal('function');
        });
    });
});