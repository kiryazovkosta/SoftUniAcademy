function vowelsSum(params) {
    let text = params[0];
    let length = text.length;
    let sum = 0;
    for (let index = 0; index < length; index++) {
        const element = text[index];
        switch (element) {
            case "a":
                sum += 1;
                break;

            case "e":
                sum += 2;
                break;

            case "i":
                sum += 3;
                break;

            case "o":
                sum += 4;
                break;

            case "u":
                sum += 5;
                break;

            default:
                break;
        }
    }

    console.log(sum);
}

vowelsSum(["beer"]);