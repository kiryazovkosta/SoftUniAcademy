function printNumbers(params) {
    let number = Number(params[0]);
    for (let index = 0; index <= number; index++) {
        if (index % 2 === 0) {
            console.log(Math.pow(2, index));
        }
    }
}

printNumbers(["4"]);