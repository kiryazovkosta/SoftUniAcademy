function flowers(params) {
    let type = params[0];
    let count = Number(params[1]);
    let budget = Number(params[2]);

    let price = 0.0;
    if (type === "Roses") {
        price = count * 5.00;
        if (count > 80) {
            price -= (price * 0.1);
        }
    } else if (type == "Dahlias") {
        price = count * 3.80;
        if (count > 90) {
            price -= (price * 0.15);
        }
    } else if (type == "Tulips") {
        price = count * 2.80;
        if (count > 80) {
            price -= (price * 0.15);
        }
    } else if (type === "Narcissus") {
        if (count < 120) {
            price = count * (3.00 + (3.00 * 0.15));
        } else {
            price = count * 3;
        }
    } else if (type === "Gladiolus") {
        if (count < 80) {
            price = count * (2.50 + (2.50 * 0.20));
        } else {
            price = count * 2.50;
        }
    }

    if (budget >= price) {
        console.log(`Hey, you have a great garden with ${count} ${type} and ${(budget-price).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money, you need ${(price - budget).toFixed(2)} leva more.`);
    }
}

flowers(["Roses","55","250"]);
flowers(["Tulips","88","260"]);
flowers(["Narcissus","119","360"]);