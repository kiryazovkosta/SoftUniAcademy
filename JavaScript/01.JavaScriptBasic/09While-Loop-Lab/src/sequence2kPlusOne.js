function sequence(params) {
    let number = Number(params[0]);
    let iter = 1;
    while (iter <= number) {
        console.log(iter);
        iter = iter * 2 + 1;
    }
}

sequence(["31"]);