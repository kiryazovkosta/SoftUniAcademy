function same(number){
    let areSame = true;
    let sum = 0;
    let firstDigit = undefined;
    while (number > 0) {
        let digit = number % 10;
        if (firstDigit === undefined) {
            firstDigit = digit;
        } else {
            if (digit != firstDigit) {
                areSame = false;
            }
        }
        sum += digit;
        number = Math.floor(number / 10);
    }

    console.log(areSame);
    console.log(sum);
}

same(2222222);
same(1234);