function buyFood(input) {
    let dogs = Number(input[0]);
    let others = Number(input[1]);
    let dogFoodPrice = dogs * 2.5;
    let othersFoodPrice = others * 4;
    let sum = dogFoodPrice + othersFoodPrice;
    console.log(`${sum} lv.`);
}

buyFood(["13", "9"]);