class SummerCamp {
    constructor(organizer, location ) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {"child": 150, "student": 300, "collegian": 500 }
        this.listOfParticipants = [];
    }

    registerParticipant (name, condition, money) {
        if (!this.priceForTheCamp[condition]) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.some(c => c.name == name)) {
            return `The ${name} is already registered at the camp.`;
        }

        money = Number(money);
        let stayPrice = this.priceForTheCamp[condition];
        if (money < stayPrice) {
            return `The money is not enough to pay the stay at the camp.`;
        } else {
            this.listOfParticipants.push({
                name,
                condition,
                power: 100,
                wins: 0,
            });
            return `The ${name} was successfully registered.`;
        }
    }

    unregisterParticipant (name) {
        let index = -1;
        for (let i = 0; i < this.listOfParticipants.length; i++) {
            const element = this.listOfParticipants[i];
            if (element.name === name) {
                index = i;
                break;
            }
        } 

        if (index >= 0) {
            this.listOfParticipants.splice(index, 1);
            return `The ${name} removed successfully.`;
        } else {
            throw new Error(`The ${name} is not registered in the camp.`);
        }
    }

    timeToPlay (typeOfGame, participant1, participant2) {
        
        if (typeOfGame === 'WaterBalloonFights') {
            let firstPlayer = this.listOfParticipants.find(p => p.name == participant1);
            let secondPlayer = this.listOfParticipants.find(p => p.name == participant2);

            if (firstPlayer == undefined || secondPlayer == undefined) {
                throw new Error('Invalid entered name/s.');
            } 

            if (firstPlayer.condition !== secondPlayer.condition) {
                throw new Error('Choose players with equal condition.');
            }

            if (firstPlayer.power > secondPlayer.power) {
                firstPlayer.wins++;
                return `The ${firstPlayer.name} is winner in the game ${typeOfGame}.`;
            } else if (secondPlayer.power > firstPlayer.power) {
                secondPlayer.wins++;
                return `The ${secondPlayer.name} is winner in the game ${typeOfGame}.`;
            } else {
                return `There is no winner.`;
            }
        } else if (typeOfGame === 'Battleship') {
            let firstPlayer = this.listOfParticipants.find(p => p.name === participant1);
            if (firstPlayer === undefined) {
                throw new Error('Invalid entered name/s.');
            }

            firstPlayer.power += 20;
            return `The ${firstPlayer.name} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString () {
        let output = [];
        output.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);
        this.listOfParticipants.sort((a,b) => { b.wins - a.wins }).forEach(el => output.push(`${el.name} - ${el.condition} - ${el.power} - ${el.wins}`));
        return output.join('\n');
    }
}

// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.unregisterParticipant("Petar"));
// console.log(summerCamp.unregisterParticipant("Petar Petarson"));

// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
// console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
// console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson 2"));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());
