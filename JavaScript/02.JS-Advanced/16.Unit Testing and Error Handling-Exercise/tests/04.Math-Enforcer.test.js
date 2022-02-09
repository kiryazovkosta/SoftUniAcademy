const expect = require("chai").expect;
const mathEnforcer = require('../src/04.Math-Enforcer');

describe("Check for MathEnforcer Tests", () => {
    let instance = null;

    beforeEach(() => {
        instance = mathEnforcer;
    });
    describe('mathEnforcer', () => {
        it('Returns valid object icremented with five', () => {
            expect(instance).be.a('object').with.property('addFive');
            expect(instance).be.a('object').with.property('subtractTen');
            expect(instance).be.a('object').with.property('sum');
        });
    });
    describe('addFive', () => {
        it('Returns argument icremented with five', () => {
            expect(instance.addFive(0)).to.be.equal(5);
            expect(instance.addFive(-5)).to.be.equal(0);
            expect(instance.addFive(1.5)).to.be.closeTo(6.5, 0.01);
        });
        it('Returns undefined when argument is not a number', () => {
            expect(instance.addFive('2')).to.be.undefined;
            expect(instance.addFive([1])).to.be.undefined;
            expect(instance.addFive({Number: 1})).to.be.undefined;
        });
    });
    describe('subtractTen', () => {
        it('Returns argument decrement with ten', () => {
            expect(instance.subtractTen(12)).to.be.equal(2);
            expect(instance.subtractTen(6)).to.be.equal(-4);
            expect(instance.subtractTen(-5)).to.be.equal(-15);
            expect(instance.subtractTen(0.05)).to.be.closeTo(-9.95, 0.01);
        });
        it('Returns undefined when argument is not a number', () => {
            expect(instance.subtractTen('2')).to.be.undefined;
            expect(instance.subtractTen([1])).to.be.undefined;
            expect(instance.subtractTen({Number: 1})).to.be.undefined;
        });
    });
    describe('sum', () => {
        it('Returns valid sum', () => {
            expect(instance.sum(1, 2)).to.be.equal(3);
            expect(instance.sum(6, -3)).to.be.equal(3);
            expect(instance.sum(-3, 0)).to.be.equal(-3);
            expect(instance.sum(0.05, 2)).to.be.closeTo(2.05, 0.01);
            expect(instance.sum(0.05, 0.1)).to.be.closeTo(0.15, 0.01);
        });
        it('Returns undefined when any of arguments is not a number', () => {
            expect(instance.sum('2', 5)).to.be.undefined;
            expect(instance.sum([1], 5)).to.be.undefined;
            expect(instance.sum({Number: 1}, 5)).to.be.undefined;
            expect(instance.sum(5, '2')).to.be.undefined;
            expect(instance.sum(5, [2])).to.be.undefined;
            expect(instance.sum(5, {Number: 2})).to.be.undefined;
        });
    });
});