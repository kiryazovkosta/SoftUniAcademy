function min(params) {
    let value = Number.MAX_SAFE_INTEGER;
    let index = 0;
    let data = params[index];
    while (data !== "Stop") {
        let number = Number(data);
        if (number < value) {
            value = number;
        }

        index++;
        data = params[index];
    }

    console.log(value);
}

min(["45","-20","7","99","Stop"]);