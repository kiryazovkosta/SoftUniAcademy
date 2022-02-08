function printDeckOfCards(cards) {
    let deck = [];
    for (let i = 0; i < cards.length; i++) {
        const card = cards[i];
        let face = card.slice(0, card.length - 1);
        let suit = card.slice(card.length - 1);
        try {
            let cardObj = createCard(face, suit);
            deck.push(cardObj);
        } catch (error) {
            console.log(`Invalid card: ${card}`);
            return;
        }
    }

    console.log(deck.join(' '));

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
  }
  
  printDeckOfCards(['AS', '10D', 'KH', '2C']);
  printDeckOfCards(['5S', '3D', 'QD', '1C']);