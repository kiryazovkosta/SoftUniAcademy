const expect = require("chai").expect;
const assert = require("chai").assert;
const { it } = require("mocha");
const library = require('../library');

describe("Tests library", () => {
    describe("calcPriceOfBook", () => {
        it("Returns valid string with price of the book", () => {
            expect(() => library.calcPriceOfBook(2, 2)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('Test', 'a')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook([], {})).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook('Test', 12.50)).to.throw('Invalid input');
        });

        it("Hello", () => {
            expect(library.calcPriceOfBook('Test', 1979)).to.equal('Price of Test is 10.00');
            expect(library.calcPriceOfBook('Test', 1980)).to.equal('Price of Test is 10.00');
            expect(library.calcPriceOfBook('Test', 1981)).to.equal('Price of Test is 20.00');
        })
     });

     describe("findBook", () => {
        it("Returns message depending on arguments", () => {
            expect(library.findBook(['a', 'b','c'], 'a')).to.equal('We found the book you want.');
            expect(library.findBook([1,2,3], '1')).to.equal('We found the book you want.');
            expect(library.findBook(['a','b','c'], 'd')).to.equal('The book you are looking for is not here!');
            expect(() => library.findBook([], 'A')).to.throw('No books currently available');
        });
     });

     describe("arrangeTheBooks", () => {
        it("Returns valid string", () => {
            expect(library.arrangeTheBooks(0)).to.equal('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(39)).to.equal('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(40)).to.equal('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(41)).to.equal('Insufficient space, more shelves need to be purchased.');
        });

        it("Throws exception on invalid argument", () => {
            expect(() => library.arrangeTheBooks('a')).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks('5')).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks(2.2)).to.throw('Invalid input');
            expect(() => library.arrangeTheBooks(-1)).to.throw('Invalid input');
        });
     });
});
