function max(params) {
    let value = Number.MIN_SAFE_INTEGER;
    let index = 0;
    let data = params[index];
    while (data !== "Stop") {
        let number = Number(data);
        if (number > value) {
            value = number;
        }

        index++;
        data = params[index];
    }

    console.log(value);
}

max(["100","99","80","70","Stop"]);
max(["-1","-2","Stop"]);