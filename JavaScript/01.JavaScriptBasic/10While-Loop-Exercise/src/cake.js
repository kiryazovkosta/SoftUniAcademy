function check(params) {
    let tripPrice = Number(params[0]);
    let total = Number(params[1]);

    let daysCounter = 0;
    let spendDaysCounter = 0;
    let index = 2;

    while (true) {
        let operation = params[index];
        index++;
        let sum = Number(params[index]);
        index++;
        daysCounter++;
        if (operation === "save") {
            total += sum;
            spendDaysCounter = 0;
            if (total >= tripPrice) {
                console.log(`You saved the money for ${daysCounter} days.`);
                break;
            }
        } else if (operation === "spend") {
            total -= sum;
            if (total < 0) {
                total = 0;
            }
            spendDaysCounter++;
            if (spendDaysCounter >= 5) {
                console.log(`You can't save the money.`);
                console.log(spendDaysCounter);
                break;
            }
        }
    }
}

check(["2000",
"1000",
"spend",
"1200",
"save",
"2000"]);

check(["110",
"60",
"spend",
"10",
"spend",
"10",
"spend",
"10",
"spend",
"10",
"spend",
"10"]);

check(["250",
"150",
"spend",
"50",
"spend",
"50",
"save",
"100",
"save",
"100"]);