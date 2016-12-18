chai.should();

var expect = chai.expect;

describe('humanVsHumanNewGameModule', function () {

    describe('module should exist', function () {
        it('humanVsHumanNewGameModule should not be undefined', function () {
            humanVsHumanNewGameModule.should.not.equal('undefined');
        });

        it('humanVsHumanNewGameModule should be an object', function () {
            var humanVsHumanNewGameModuleType = typeof humanVsHumanNewGameModule === 'object';

            humanVsHumanNewGameModuleType.should.equal(true);
        });

        it('humanVsHumanNewGameModule should have an object named init', function () {
            var initFunction = humanVsHumanNewGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof humanVsHumanNewGameModule.init;

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