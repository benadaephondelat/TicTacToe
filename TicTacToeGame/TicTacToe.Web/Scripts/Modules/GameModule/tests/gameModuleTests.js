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

    describe('getTileIndex tests', function () {
        it('getTileIndex should exist', function () {
            var isUndefined = typeof gameModule.getTileIndex === 'undefined';

            isUndefined.should.equal(false);
        });

        it('getTileIndex should be a function', function () {
            var type = typeof gameModule.getTileIndex;

            type.should.equal('function');
        });

        it('getTileIndex should accept one parameter', function () {
            var parametersCount = gameModule.getTileIndex.length;

            parametersCount.should.equal(1);
        });

        it('getTileIndex should throw error if the parameter is not valid HTML element', function () {
            expect(function () {
                gameModule.getTileIndex("NOT AN ELEMENT");
            }).to.throw('Invalid HTML element');
        });

        it('getTileIndex should throw error if tile index is NOT between 0 and 8', function () {
            expect(function () {
                gameModule.getTileIndex($('#valid-dom-element-with-invalid-data-value'));
            }).to.throw('Invalid Tile Index');
        });

        it('getTileIndex should return a number if tile index is valid', function () {
            var result = gameModule.getTileIndex($('#valid-dom-element-with-valid-data-value'));

            var isNumber = typeof result === 'number';

            isNumber.should.equal(true);
        });
        
    });

    describe('getData tests', function () {
        it('getData should exist', function () {
            var isUndefined = typeof gameModule.getData === 'undefined';

            isUndefined.should.equal(false);
        });

        it('getData should be a function', function () {
            var type = typeof gameModule.getData;

            type.should.equal('function');
        });

        it('getData should accept two parameters', function () {
            var parametersCount = gameModule.getData.length;

            parametersCount.should.equal(2);
        });

        it('getData should throw error if the first parameter is not a valid HTML element', function () {
            expect(function () {
                gameModule.getData("NOT AN ELEMENT", $('#valid-dom-element-with-valid-data-value'));
            }).to.throw('Invalid HTML element');
        });

        it('getData should throw error if the second parameter is not a valid HTML element', function () {
            expect(function () {
                gameModule.getData($('#valid-dom-element'), 'NOT AN ELEMENT');
            }).to.throw('Invalid HTML element');
        });

        it('getData should throw error if tile index is NOT between 0 and 8', function () {
            expect(function () {
                gameModule.getData($('#valid-dom-element'), $('#valid-dom-element-with-invalid-data-value'));
            }).to.throw('Invalid Tile Index');
        });

        it('getData should return valid JSON object with two properties if input parameters are valid', function () {
            var result = gameModule.getData($('#valid-dom-element'), $('#valid-dom-element-with-valid-data-value'));

            var resultAsJSON = JSON.parse(result);

            var isObject = typeof resultAsJSON === 'object';
            
            isObject.should.equal(true);
            resultAsJSON['gameId'].should.equal('123');
            resultAsJSON['tileIndex'].should.equal(0);
        });
    });

    describe('gameBoardColouringHandler tests', function () {
        it('gameBoardColouringHandler should exist', function () {
            var isUndefined = typeof gameModule.gameBoardColouringHandler === 'undefined';

            isUndefined.should.equal(false);
        });

        it('gameBoardColouringHandler should be a function', function () {
            var type = typeof gameModule.gameBoardColouringHandler;

            type.should.equal('function');
        });

        it('gameBoardColouringHandler should accept one parameter', function () {
            var parametersCount = gameModule.gameBoardColouringHandler.length;

            parametersCount.should.equal(1);
        });

        it('gameBoardColouringHandler should throw error if the parameter is not a valid HTML element', function () {
            expect(function () {
                gameModule.gameBoardColouringHandler("NOT AN ELEMENT");
            }).to.throw('Invalid HTML element');
        });

        it('gameBoardColouringHandler shoud not add (.red or .blue) css classes if the outer text is not X or 0', function () {
            var emptyTile = [$('#empty-tile')];

            gameModule.gameBoardColouringHandler(emptyTile);

            var elementCssClass = $('#empty-tile').attr('class');

            var isBlueClassMissing = elementCssClass.toString().indexOf('blue') === -1;

            isBlueClassMissing.should.equal(true);

            var isRedClassMissing = elementCssClass.toString().indexOf('red') === -1;

            isRedClassMissing.should.equal(true);
        });

        it('gameBoardColouringHandler shoud add css class - "red" if the outer text equals X', function () {
            var xTile = [$('#X-tile')];

            gameModule.gameBoardColouringHandler(xTile);

            var elementCssClass = $('#X-tile').attr('class');

            var isRedClassInPlace = new RegExp('\\bred\\b', 'i').test(elementCssClass);

            isRedClassInPlace.should.equal(true);
        });

        it('gameBoardColouringHandler shoud add css class - "blue" if the outer text equals O', function () {
            var oTile = [$('#O-tile')];

            gameModule.gameBoardColouringHandler(oTile);

            var elementCssClass = $('#O-tile').attr('class');

            var isBlueClassInPlace = new RegExp('\\bblue\\b', 'i').test(elementCssClass);

            isBlueClassInPlace.should.equal(true);
        });
    });
});