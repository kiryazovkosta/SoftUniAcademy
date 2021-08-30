function histogram(params) {
    let count = Number(params[0]);

    let p1Count = 0;
    let p2Count = 0;
    let p3Count = 0;
    let p4Count = 0;
    let p5Count = 0;

    for (let index = 1; index <= count; index++) {
        const element = Number(params[index]);
        if (element < 200) {
            p1Count++;
        } else if (element >= 00 && element <= 399) {
            p2Count++;
        } else if (element >= 400 && element <= 599) {
            p3Count++;
        } else if (element >= 600 && element <= 799) {
            p4Count++;
        } else {
            p5Count++
        }
    }

    console.log(`${((p1Count/count) * 100).toFixed(2)}%`);
    console.log(`${((p2Count/count) * 100).toFixed(2)}%`);
    console.log(`${((p3Count/count) * 100).toFixed(2)}%`);
    console.log(`${((p4Count/count) * 100).toFixed(2)}%`);
    console.log(`${((p5Count/count) * 100).toFixed(2)}%`);
}

histogram(["3",
"1",
"2",
"999"]);