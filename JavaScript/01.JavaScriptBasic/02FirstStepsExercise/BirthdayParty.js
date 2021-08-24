function solve(input) {
    let rent = Number(input[0]);

    let cake = rent * 0.2;
    let drinks = cake - (cake * 0.45);
    let animator = rent / 3;
    let budget = cake + drinks + animator + rent;
    console.log(budget);
}

solve(["2250"]);
solve(["3720"]);