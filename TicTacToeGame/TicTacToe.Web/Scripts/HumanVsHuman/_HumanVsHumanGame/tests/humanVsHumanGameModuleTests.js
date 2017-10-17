chai.should();

var expect = chai.expect;

describe('humanVsHumanGameModule', function () {

    describe('module should exist', function () {
        it('humanVsHumanGameModule should not be undefined', function () {
            humanVsHumanGameModule.should.not.equal('undefined');
        });

        it('humanVsHumanGameModule should be an object', function () {
            var humanVsHumanNewGameModuleType = typeof humanVsHumanGameModule === 'object';

            humanVsHumanNewGameModuleType.should.equal(true);
        });

        it('humanVsHumanGameModule should have an object named init', function () {
            var initFunction = humanVsHumanGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof humanVsHumanGameModule.init;

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