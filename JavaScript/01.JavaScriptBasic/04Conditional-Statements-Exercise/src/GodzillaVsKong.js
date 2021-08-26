function enoughBudget(input) {
    let budget = Number(input[0]);
    let persons = Number(input[1]);
    let pricePerPerson = Number(input[2]);

    let decorPrice = budget * 0.1;
    let dressPrice = persons * pricePerPerson;
    if (persons > 150) {
        dressPrice -= ( dressPrice * 0.1);
    }

    let totalAmount = decorPrice + dressPrice;
    if (budget >= totalAmount) {
        console.log('Action!');
        console.log(`Wingard starts filming with ${(budget - totalAmount).toFixed(2)} leva left.`);
    } else {
        console.log('Not enough money!');
        console.log(`Wingard needs ${(totalAmount - budget).toFixed(2)} leva more.`);
    }
}

enoughBudget(["20000", "120", "55.5"]);
enoughBudget(["15437.62", "186", "57.99"]);
enoughBudget(["9587.88", "222", "55.68"]);