function balance(params) {
    let data = params[0];
    let accountSum = 0;
    let index = 1;
    while (data !== "NoMoreMoney") {
        let sum = Number(data);
        if (sum < 0) {
            console.log(`Invalid operation!`);
            break;
        }

        console.log(`Increase: ${sum.toFixed(2)}`);
        accountSum += sum;
        data = params[index];
        index++;
    }

    console.log(`Total: ${accountSum.toFixed(2)}`);
}

balance(["5.51", 
"69.42",
"100",
"NoMoreMoney"]);

balance(["120",
"45.55",
"-150"]);