const expect =require("chai").expect;
const isOddOrEven = require('../src/02-Even-Or-Odd');

describe("Check for IsEvenOrOdd Tests", () => {
    it('Returns valid text depending of the argument\'s length', () => {
        expect(isOddOrEven('a')).to.be.equal('odd');
        expect(isOddOrEven('abc')).to.be.equal('odd');
        expect(isOddOrEven('12345')).to.be.equal('odd');
        expect(isOddOrEven('aa')).to.be.equal('even');
        expect(isOddOrEven('abbc')).to.be.equal('even');
        expect(isOddOrEven('')).to.be.equal('even');
    });
    it('Returns undefined when input argument is invalid', () => {
        expect(isOddOrEven(1)).to.be.undefined;
        expect(isOddOrEven([1, 2 , 3])).to.be.undefined;
        expect(isOddOrEven(['ps4'])).to.be.undefined;
        expect(isOddOrEven({ prop: 'prop'})).to.be.undefined;
    });
});
