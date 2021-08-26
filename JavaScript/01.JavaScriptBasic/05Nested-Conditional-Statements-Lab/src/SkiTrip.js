function tripPrice(input) {
    let days = Number(input[0]);
    let room = input[1];
    let feedback = input[2];

    let nights = days - 1;
    let price = 0.0;
    let discount = 0.0;
    if (room === "room for one person") {
        price = 18.00;
    } else if (room === "apartment") {
        price = 25.00;
        if (days < 10) {
            discount = 0.30;
        } else if (days >= 10 && days <= 15) {
            discount = 0.35;
        } else {
            discount = 0.50;
        }
    } else {
        price = 35.00;
        if (days < 10) {
            discount = 0.10;
        } else if (days >= 10 && days <= 15) {
            discount = 0.15;
        } else {
            discount = 0.20;
        }
    }

    let totalPrice = nights * price;
    if (discount > 0) {
        totalPrice -= (totalPrice * discount);
    }

    if (feedback === "positive") {
        totalPrice += (totalPrice * 0.25);
    } else {
        totalPrice -= (totalPrice * 0.10);
    }

    console.log(`${totalPrice.toFixed(2)}`);
}

tripPrice(["14", "apartment", "positive"]);
tripPrice(["30", "president apartment", "negative"]);