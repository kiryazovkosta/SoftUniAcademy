const expect =require("chai").expect;
const sum = require('../src/04.sumNumbers');

describe("Check for SumNumbers Tests", () => {
    it("Array of numbers returns valid sum", () => {
        expect(sum([1, 2, 3])).to.be.equal(6);
    });
    it("Array contains NaN elements so method returns NaN", () => {
        expect(sum([1, 2, 'a'])).to.be.NaN;
    });
})
