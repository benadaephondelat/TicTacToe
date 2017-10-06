chai.should();

var expect = chai.expect;

describe('loadGameGridModule', function () {

    describe('module should exist', function () {
        it('loadGameGridModule should not be undefined', function () {
            loadGameGridModule.should.not.equal('undefined');
        });

        it('loadGameGridModule should be an object', function () {
            var isOfExpectedType = typeof loadGameGridModule === 'object';

            isOfExpectedType.should.equal(true);
        });

        it('loadGameGridModule should have an object named init', function () {
            var initFunction = loadGameGridModule.init;

            initFunction.should.not.equal('undefined');
        });

        it('init should be a function', function () {
            var typeofInit = typeof loadGameGridModule.init;

            typeofInit.should.equal('function');
        });

        it('init should accept one parameter', function () {
            var parametersCount = loadGameGridModule.init.length;

            parametersCount.should.equal(1);
        });
    });
});