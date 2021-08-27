function rentPrice(params) {
    let budget = Number(params[0]);
    let season = params[1];
    let fishermans = Number(params[2]);

    let price = 3000;
    if (season === "Summer" || season === "Autumn") {
        price = 4200;
    } else if (season === "Winter") {
        price = 2600;
    }

    if (fishermans >= 7 && fishermans <= 11) {
        price -= price * 0.15;
    } else if (fishermans >= 12) {
        price -= price * 0.25;
    } else {
        price -= price * 0.1;
    }

    if (season !== "Autumn" && fishermans % 2 === 0) {
        price -= price * 0.05;
    }

    if (budget >= price ) {
        console.log(`Yes! You have ${(budget-price).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money! You need ${(price-budget).toFixed(2)} leva.`);
    }
}