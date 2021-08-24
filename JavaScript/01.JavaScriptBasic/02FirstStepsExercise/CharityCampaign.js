function solve(input) {
    let days = Number(input[0]);
    let persons = Number(input[1]);
    let cakes = Number(input[2]);
    let gofrets = Number(input[3]);
    let pancakes = Number(input[4]);

    let cakesPrice = cakes * 45;
    let gofretsPrice = gofrets * 5.8;
    let pancakesPrice = pancakes * 3.2;
    let totalPrice = (((cakesPrice + gofretsPrice + pancakesPrice) * persons) * days);
    totalPrice = totalPrice - (totalPrice / 8);
    console.log(totalPrice);
}

solve(["23",
"8",
"14",
"30",
"16"]);

solve(["131",
"5",
"9",
"33",
"46"]);