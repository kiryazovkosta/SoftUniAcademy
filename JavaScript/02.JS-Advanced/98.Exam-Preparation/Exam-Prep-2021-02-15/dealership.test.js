const expect =require("chai").expect;
const dealership = require('./dealership')

describe("Tests dealership", function() {
    describe("newCarCost", function() {

        it("Return new car price without discount", function() {
            expect(dealership.newCarCost('a', 1)).is.equal(1);
            expect(dealership.newCarCost('Audi A4 B8', 30000)).is.equal(15000);
        });
     });
     describe("carEquipment", function() {

        it("Return new car price without discount", function() {
            expect(dealership.carEquipment(['a', 'b', 'c'], [0, 2])).to.deep.equal(['a','c']);
        });
     });
     describe("euroCategory", function() {

        it("Return final price", function() {
            expect(dealership.euroCategory(3)).to.equal('Your euro category is low, so there is no discount from the final price!');
            expect(dealership.euroCategory(4)).to.equal('We have added 5% discount to the final price: 14250.');
            expect(dealership.euroCategory(5)).to.equal('We have added 5% discount to the final price: 14250.');
        });
     });
});
