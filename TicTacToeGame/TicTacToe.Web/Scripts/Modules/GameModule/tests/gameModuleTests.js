chai.should();

var expect = chai.expect;

describe('gameModuleTests', function () {

    describe('module should exist', function () {
        it('gameModule should not be undefined', function () {
            gameModule.should.not.equal('undefined');
        });

        it('gameModule should return getGameId function', function () {
            var typeofInit = typeof gameModule.getGameId;

            typeofInit.should.equal('function');
        });

        it('gameModule should return getTileIndex function', function () {
            var typeofInit = typeof gameModule.getTileIndex;

            typeofInit.should.equal('function');
        });

        it('gameModule should return getData function', function () {
            var typeofInit = typeof gameModule.getData;

            typeofInit.should.equal('function');
        });

        it('gameModule should return gameBoardColouringHandler function', function () {
            var typeofInit = typeof gameModule.gameBoardColouringHandler;

            typeofInit.should.equal('function');
        });

    });

    describe('getGameId tests', function () {
        it('getGameId should exist', function () {
            var isUndefined = typeof gameModule.getGameId === 'undefined';

            isUndefined.should.equal(false);
        });

        it('getGameId should be a function', function () {
            var type = typeof gameModule.getGameId;

            type.should.equal('function');
        });

        it('getGameId should accept one parameter', function () {
            var parametersCount = gameModule.getGameId.length;

            parametersCount.should.equal(1);
        });

        it('getGameId should throw error if the parameter is not valid HTML element', function () {
            expect(function () {
                gameModule.getGameId("NOT AN ELEMENT");
            }).to.throw('Invalid HTML element');
        });

        it('getGameId should throw error if the parameter is valid HTML element but does not have a value attribute', function () {
            expect(function () {
                gameModule.getGameId($('#valid-dom-element-without-value-attribute'));
            }).to.throw('Invalid Game Id');
        });


        it('getGameId should return valid value if the element has a value attribue', function () {
            var result = gameModule.getGameId($('#valid-dom-element'));

            result.should.equal('123');
        });

        it('getGameId should return a string', function () {
            var result = gameModule.getGameId($('#valid-dom-element'));

            var isString = typeof result === 'string';

            isString.should.equal(true);
        });
       
    });

});