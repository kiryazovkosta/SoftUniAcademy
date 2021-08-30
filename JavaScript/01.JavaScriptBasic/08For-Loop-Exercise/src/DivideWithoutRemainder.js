function divideWithoutRemainder(params) {
    let count = Number(params[0]);

    let p1Count = 0;
    let p2Count = 0;
    let p3Count = 0;

    for (let index = 1; index <= count; index++) {
        const element = Number(params[index]);
        if (element % 2 === 0) {
            p1Count++;
        }
        if (element % 3 === 0) {
            p2Count++;
        }
        if (element % 4 === 0) {
            p3Count++;
        }
    }

    console.log(`${((p1Count/count) * 100).toFixed(2)}%`);
    console.log(`${((p2Count/count) * 100).toFixed(2)}%`);
    console.log(`${((p3Count/count) * 100).toFixed(2)}%`);
}

divideWithoutRemainder(["10","680","2","600","200","800","799","199","46","128","65"]);
divideWithoutRemainder(["3","3","6","9"]);
