const expect = require("chai").expect;
const lookupChar = require('../src/03.Char-Lookup');

describe("Check for CharLookup Tests", () => {
    it('Returns char at specific index', () => {
        expect(lookupChar('test', 0)).to.be.equal('t');
        expect(lookupChar('test', 3)).to.be.equal('t');
        expect(lookupChar('test', 1)).to.be.equal('e');
    });
    it('Returns undefined when input parameter is invalid', () => {
        expect(lookupChar({name: 'name'}, 5)).to.be.undefined;
        expect(lookupChar(5, 3)).to.be.undefined;
        expect(lookupChar('test', '23')).to.be.undefined;
        expect(lookupChar('test', 2.5)).to.be.undefined;
    });
    it('Returns Incorrect index when argument is out of range;', () => {
        expect(lookupChar('test', 4)).to.be.equal("Incorrect index");
        expect(lookupChar('test', -1)).to.be.equal("Incorrect index");
    });
});