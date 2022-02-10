function createCard(face, suit){
    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let suits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    }

    if (!faces.includes(face) || !Object.keys(suits).includes(suit)) {
        throw new Error();
    }

    return {
        face,
        suit: suits[suit],
        toString() {
            return face + this.suit;
        }
    }
}

console.log(createCard('A', 'S').toString());
console.log(createCard('10', 'H').toString());
console.log(createCard('1', 'C').toString());