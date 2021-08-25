function shop(input) {
    let trip = Number(input[0]);
    let puzzles = Number(input[1]);
    let toys = Number(input[2]);
    let bears = Number(input[3]);
    let minnions = Number(input[4]);
    let trucks = Number(input[5]);
    
    let puzzlesPrice = puzzles * 2.6;
    let toysPrice = toys * 3;
    let bearsPrice = bears * 4.1;
    let minnionsPrice = minnions * 8.2;
    let trucksPrice = trucks * 2;

    let count = puzzles + toys + bears + minnions + trucks;
    let totalPrice = puzzlesPrice + toysPrice + bearsPrice + minnionsPrice + trucksPrice;

    if (count >= 50) {
        totalPrice = totalPrice - (totalPrice * 0.25);
    }

    totalPrice -= totalPrice * 0.1;
    if (totalPrice >= trip) {
        console.log(`Yes! ${(totalPrice - trip).toFixed(2)} lv left.`);
    } else {
        console.log(`Not enough money! ${(trip - totalPrice).toFixed(2)} lv needed.`);
    }
}

shop(["40.8", "20", "25", "30", "50", "10"]);
shop(["320", "8", "2", "5", "5", "1"]);