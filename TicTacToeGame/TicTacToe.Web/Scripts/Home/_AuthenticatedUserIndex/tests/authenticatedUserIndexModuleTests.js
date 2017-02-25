chai.should();

describe('authenticatedUserIndexModule', function () {

    describe('module should exist', function () {
        it('authenticatedUserIndexModule should not be undefined', function () {
            authenticatedUserIndexModule.should.not.equal('undefined');
        });

        it('authenticatedUserIndexModule should be an object', function () {
            var authenticatedUserIndexModuleType = typeof authenticatedUserIndexModule === 'object';

            authenticatedUserIndexModuleType.should.equal(true);
        });

        it('authenticatedUserIndexModule should have an object named init', function () {
            var initFunction = authenticatedUserIndexModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof authenticatedUserIndexModule.init;

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