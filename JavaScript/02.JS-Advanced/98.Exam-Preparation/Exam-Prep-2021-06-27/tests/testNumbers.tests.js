const expect = require("chai").expect; 
const testNumbers = require('../testNumbers');

describe("Tests testNumbers", function() {
    describe("sumNumbers", function() {
        it("Return sum of two numbers rounded to second digit", function() {
            expect(testNumbers.sumNumbers(1, 1)).to.equal('2.00');
            expect(testNumbers.sumNumbers(-1, 3)).to.equal('2.00');
            expect(testNumbers.sumNumbers(1.111, 0.666)).to.equal('1.78');
        });
        it("Return undefined when argument is not a number", function() {
            expect(testNumbers.sumNumbers(1, '1')).to.undefined;
            expect(testNumbers.sumNumbers('1', 2)).to.undefined;
            expect(testNumbers.sumNumbers('1', '1')).to.undefined;
        });
     });
     describe("numberChecker", function() {
        it("Returns odd", function() {
            expect(testNumbers.numberChecker(1)).to.equal('The number is odd!');
            expect(testNumbers.numberChecker(1.5)).to.equal('The number is odd!');
        });
        it("Returns even", function() {
            expect(testNumbers.numberChecker(2)).to.equal('The number is even!');
            expect(testNumbers.numberChecker('')).to.equal('The number is even!');
            expect(testNumbers.numberChecker(-2)).to.equal('The number is even!');
        });
        it("Throws error", function() {
            expect(() => testNumbers.numberChecker({})).to.throw('The input is not a number!');
            expect(() => testNumbers.numberChecker('test')).to.throw('The input is not a number!');
        });
     });
     describe("averageSumArray", function() {
        it("TODO …", function() {
            // TODO: …
        });
     });
});
