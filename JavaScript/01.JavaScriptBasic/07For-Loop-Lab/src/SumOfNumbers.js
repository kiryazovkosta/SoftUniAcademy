function sum(params) {
    let number = params[0];
    let length = number.length;
    let sum = 0;
    for (let index = 0; index < length; index++) {
        const digit = Number(number[index]);
        sum += digit;
    }

    console.log(`The sum of the digits is:${sum}`);
}

sum(["564891"]);