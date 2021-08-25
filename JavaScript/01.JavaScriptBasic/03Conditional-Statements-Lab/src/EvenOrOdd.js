function oddOrEven(input) {
    let number = Number(input[0]);
    if (number % 2 === 0) {
        console.log("even");
    } else {
        console.log("odd");
    }
}

oddOrEven(["2"]);
oddOrEven(["3"])
oddOrEven(["25"])
oddOrEven(["1024"]);
oddOrEven(["0"])