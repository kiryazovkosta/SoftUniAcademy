function sum(params) {
    let number = Number(params[0]);
    let total = 0;
    let index = 1;
    let n = Number(params[index]);
    while (total < number) {
        total += n;
        index++;
        n = Number(params[index]);
    }

    console.log(total);
}

sum(["100",
"10",
"20",
"30",
"40"]);