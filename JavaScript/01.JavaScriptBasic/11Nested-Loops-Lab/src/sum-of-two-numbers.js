function sum(params) {
    let startElement = Number(params[0]);
    let endElement = Number(params[1]);
    let number = Number(params[2]);

    let counter = 0;
    let isFound = false;
    let numbers = [];
    for (let x = startElement; x <= endElement; x++) {
        for (let y = startElement; y <= endElement; y++) {
            counter++;
            if (x + y === number) {
                isFound = true;
                console.log(`Combination N:${counter} (${x} + ${y} = ${number})`);
                break;
            }
        }

        if (isFound) {
            break;
        }
    }

    if (!isFound) {
        console.log(`${counter} combinations - neither equals ${number}`);
    }
}

sum(["1",
"10",
"5"]);

sum(["23",
"24",
"20"]);