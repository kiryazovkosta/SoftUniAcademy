function calcDesicion(params) {
    let number = Number(params[0]);
    let counter = 0;
    for (let a = 0; a <= number; a++) {
        for (let b = 0; b <= number; b++) {
            for (let c = 0; c <= number; c++) {
                if (a + b + c === number) {
                    counter++;
                }
            }
        }
    }

    console.log(counter);
}

calcDesicion(["25"]);