function smallest(input) {
    input.sort((a, b) => a -b);
    let numbers = input.splice(0, 2);
    console.log(numbers.join(' '));
}

smallest([30, 15, 50, 5]);
console.log('------');
smallest([3, 0, 10, 4, 7, 3]);
console.log('------');
smallest([3]);