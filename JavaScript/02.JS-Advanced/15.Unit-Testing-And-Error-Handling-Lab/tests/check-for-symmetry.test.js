const expect =require("chai").expect;
const isSymmetric = require('../src/05.check-for-symmetry');

describe("Check for Symmetry Tests", () => {
    it("Returns true for symmetric array", () => {
        expect(isSymmetric([1, 2, 3, 2, 1])).to.be.true;
        expect(isSymmetric([1, 2, 2, 1])).to.be.true;
        expect(isSymmetric(['1', '2', '2', '1'])).to.be.true;
        expect(isSymmetric([1])).to.be.true;
        expect(isSymmetric([])).to.be.true;
    });
    it("Returns false for non symmetric array", () => {
        expect(isSymmetric([1, 2, 3])).to.be.false;
        expect(isSymmetric(['a', 'b', 'b', 'c'])).to.be.false;
    });
    it("Returns false for invalid argument", () => {
        expect(isSymmetric(5)).to.be.false;
        expect(isSymmetric('hello')).to.be.false;
        expect(isSymmetric({name: 'Ivan'})).to.be.false;
    });
    it("Returns false array elements are from different type", () => {
        expect(isSymmetric([1, 2, 2, '1'])).to.be.false;
    });
})