function sum(n, m) {
    let result = 0;
    let start = Number(n);
    let end = Number(m);
    for (let number = start; number <= end; number++) {
        result += number;
    }

    console.log(result);
}

sum('1', '5');
sum(1, 5);
sum(-8, 20);