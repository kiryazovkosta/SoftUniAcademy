function arrange(n){
    let numbers = [];
    for (const number of n) {
        if (number < 0) {
            numbers.unshift(number);
        } else {
            numbers.push(number);
        }
    }

    console.log(numbers.join('\n'));
}

arrange([7, -2, 8, 9]);
console.log('-------')
arrange([3, -2, 0, -1]);