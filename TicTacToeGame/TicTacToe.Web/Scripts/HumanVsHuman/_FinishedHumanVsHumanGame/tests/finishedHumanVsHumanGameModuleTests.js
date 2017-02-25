chai.should();

var expect = chai.expect;

describe('finishedHumanVsHumanGameModule', function () {

    describe('module should exist', function () {
        it('finishedHumanVsHumanGameModule should not be undefined', function () {
            finishedHumanVsHumanGameModule.should.not.equal('undefined');
        });

        it('finishedHumanVsHumanGameModule should be an object', function () {
            var isOfExpectedType = typeof finishedHumanVsHumanGameModule === 'object';

            isOfExpectedType.should.equal(true);
        });

        it('finishedHumanVsHumanGameModule should have an object named init', function () {
            var initFunction = finishedHumanVsHumanGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof finishedHumanVsHumanGameModule.init;

            typeofInit.should.equal('function');
        });
    });
});