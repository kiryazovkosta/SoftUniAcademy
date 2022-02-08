const expect =require("chai").expect;
const { beforeEach, it } = require("mocha");
const createCalculator = require('../src/07-add-subtract');

describe("Check for Add/Subtract Tests", () => {

    let calculator = null;

    beforeEach(() => {
        calculator = createCalculator();
    }); 

    it('Returns valid object', () => {
        expect(calculator).to.be.a('object').with.property('add');
        expect(calculator).to.be.a('object').with.property('subtract');
        expect(calculator).to.be.a('object').with.property('get');
    });

    it('Add successffuly numbers', () => {
        expect(calculator.get()).to.be.equals(0);
        calculator.add(1);
        expect(calculator.get()).to.be.equals(1);
        calculator.add(2);
        calculator.add(3);
        expect(calculator.get()).to.be.equals(6);
    })

    it('Add successffuly numbers as string', () => {
        calculator.add('1');
        expect(calculator.get()).to.be.equals(1);
        calculator.add('2');
        calculator.add(3);
        expect(calculator.get()).to.be.equals(6);
    })

})