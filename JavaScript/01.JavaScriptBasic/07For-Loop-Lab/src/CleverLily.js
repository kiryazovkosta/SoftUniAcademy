function clever(params) {
    let ages = Number(params[0]);
    let washerPrice = Number(params[1]);
    let toyPrice = Number(params[2]);

    let toys = 0;
    let money = 0;
    let moneyCounter = 1;

    for (let index = 1; index <= ages; index++){
        if (index % 2 !== 0) {
            toys++;
        } else {
            let currentMoney = (moneyCounter * 10) - 1;
            money += currentMoney;
            moneyCounter++;
        }
    }

    let toysMoney = toys * toyPrice;
    money += toysMoney;
    if (money >= washerPrice) {
        console.log(`Yes! ${(money-washerPrice).toFixed(2)}`);
    } else {
        console.log(`No! ${(washerPrice-money).toFixed(2)}`);
    }
}

clever(["10", "170", "6"]);
clever(["21", "1570.98", "3"]);