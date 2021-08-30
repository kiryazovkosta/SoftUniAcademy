function divisibleByNine(params) {
    let startNumber = Number(params[0]);
    let endNumber = Number(params[1]);
    let sum = 0;
    let output = "";
    for (let index = startNumber; index <= endNumber; index++) {
        if (index % 9 === 0) {
            sum += index;
            output += index + "\n";
        }
    }

    console.log(`The sum: ${sum}`);
    console.log(output);
}

divisibleByNine(["100", "200"]);