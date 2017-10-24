chai.should();

var expect = chai.expect;

describe('newGameModule', function () {

    describe('module should exist', function () {
        it('newGameModule should not be undefined', function () {
            newGameModule.should.not.equal('undefined');
        });

        it('newGameModule should be an object', function () {
            var newGameModuleType = typeof newGameModule === 'object';

            newGameModuleType.should.equal(true);
        });

        it('newGameModule should have an object named init', function () {
            var initFunction = newGameModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof newGameModule.init;

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