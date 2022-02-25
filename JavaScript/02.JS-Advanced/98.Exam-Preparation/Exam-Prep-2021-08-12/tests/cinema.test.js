const expect = require("chai").expect;
const cinema = require('../cinema');

describe("Tests cinema", function() {
    describe("showMovies", function() {
        it("Returns", function() {
            expect(cinema.showMovies(['King Kong', 'The Tomorrow War', 'Joker'])).to.equal('King Kong, The Tomorrow War, Joker');
            expect(cinema.showMovies([])).to.equal('There are currently no movies to show.');

        });
     });
     
     describe("ticketPrice", function() {
        it("Returns", function() {
            expect(cinema.ticketPrice('Premiere')).to.equal(12.00);
            expect(cinema.ticketPrice('Normal')).to.equal(7.50);
            expect(cinema.ticketPrice('Discount')).to.equal(5.50);
            expect(() => cinema.ticketPrice('Unknown')).to.throw('Invalid projection type.');
        });
     });

     describe("swapSeatsInHall", function() {
        it("Valid", function() {
            expect(cinema.swapSeatsInHall(5, 10)).to.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(5, 20)).to.equal('Successful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(20, 5)).to.equal('Successful change of seats in the hall.');
        });
        it("Invalid", function() {
            expect(cinema.swapSeatsInHall('5', 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall('5.2', 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall('a', 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-1, 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(0, 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(21, 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, '5')).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, '5.2')).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, 'a')).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, -1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, 0)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, 21)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(5, 5)).to.equal('Unsuccessful change of seats in the hall.');
        });
        it("Invalid", function() {
            expect(cinema.swapSeatsInHall('5', 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall('5.2', 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall('a', 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(-1, 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(0, 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(21, 10)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, '5')).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, '5.2')).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, 'a')).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, -1)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, 0)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(10, 21)).to.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(5, 5)).to.equal('Unsuccessful change of seats in the hall.');
        });
     });
});
