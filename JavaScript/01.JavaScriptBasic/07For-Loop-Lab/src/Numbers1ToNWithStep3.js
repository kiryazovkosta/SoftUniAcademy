function printNumbers(params) {
    let number = Number(params[0]);
    for(let i = 1; i <= number; i+=3) {
        console.log(i);
    }
}

printNumbers(["15"]);