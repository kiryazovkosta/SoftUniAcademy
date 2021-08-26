function solve(input) {
    let distance = Number(input[0]);
    let from = input[1];
    let to = input[2];

    if (from === "m") {
        distance *= 1000;
    } else if (from === "cm") {
        distance *= 10;
    } else {
        distance *= 1;
    }

    let output = distance;
    if (to === "m") {
        output /= 1000;
    } else if (to === "cm") {
        output /= 10;
    } else {
        output /= 1;
    }

    console.log(output.toFixed(3));
}

solve(["12","mm","m"]);
solve(["150","m","cm"]);
solve(["45","cm","mm"]);