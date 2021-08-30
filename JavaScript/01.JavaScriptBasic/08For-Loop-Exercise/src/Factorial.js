function factorial(params) {
    let number = Number(params[0]);
    let sum = 1;
    for (let index = 1; index <= number; index++) {
        sum *= index;
    }

    console.log(sum);
}

factorial(["8"]);