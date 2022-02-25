const expect = require("chai").expect; 
const flowerShop = require('./flowerShop');

describe("Tests flowerShop", function () {
    describe("calcPriceOfFlowers", function () {
        it("When argument in not valid need th throw an exception", function () {
            expect(() => flowerShop.calcPriceOfFlowers(1,1,1)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers({flower: 'f'},1,1)).to.throw('Invalid input!');

            expect(() => flowerShop.calcPriceOfFlowers('f','a',1)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('f',{}, 1)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('f', 1.5, 1)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('f', '1', 1)).to.throw('Invalid input!');

            expect(() => flowerShop.calcPriceOfFlowers('f', 1, 'a')).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('f', 1, [])).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('f', 1, 1.5)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('f', 1, '1')).to.throw('Invalid input!');
        });
        it("Return valid", function() {
            expect(flowerShop.calcPriceOfFlowers('f', 5, 1)).to.equal('You need $5.00 to buy f!');
            expect(flowerShop.calcPriceOfFlowers('f', -5, 1)).to.equal('You need $-5.00 to buy f!');
            expect(flowerShop.calcPriceOfFlowers('f', 5, -1)).to.equal('You need $-5.00 to buy f!');
        });
    });

    describe("checkFlowersAvailable", function () {
        it("Return exists", function() {
            expect(flowerShop.checkFlowersAvailable('a', ['a', 'b', 'c'])).to.equal('The a are available!');
        });
        it("Return does not exists", function() {
            expect(flowerShop.checkFlowersAvailable('d', ['a', 'b', 'c'])).to.equal('The d are sold! You need to purchase more!');
        });
    });

    describe("sellFlowers(gardenArr, space)", function () {
        it("When argument in not valid need th throw an exception", function () {
            //space < 0 || space >= gardenArr.length) {
            
            expect(() => flowerShop.sellFlowers(1, 1)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers({arr: []}, 1)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers('text', 1)).to.throw('Invalid input!');

            expect(() => flowerShop.sellFlowers(['a', 'b', 'c'], 'a')).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a', 'b', 'c'], {})).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a', 'b', 'c'], [])).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a', 'b', 'c'], '1')).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a', 'b', 'c'], 2.2)).to.throw('Invalid input!');

            expect(() => flowerShop.sellFlowers(['a', 'b', 'c'], -1)).to.throw('Invalid input!');

            expect(() => flowerShop.sellFlowers(['a', 'b', 'c'], 3)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a', 'b', 'c'], 10)).to.throw('Invalid input!');
        });
        it("Return valid", function() {
            expect(flowerShop.sellFlowers(['a', 'b', 'c'], 2)).to.equal('a / b');
            expect(flowerShop.sellFlowers(['a', 'b', 'c'], 1)).to.equal('a / c');
            expect(flowerShop.sellFlowers(['a', 'b', 'c'], 0)).to.equal('b / c');
        });
    });
});