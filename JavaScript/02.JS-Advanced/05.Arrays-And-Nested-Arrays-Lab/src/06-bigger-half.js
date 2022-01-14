function bigger(input) {
    input.sort((a, b) => a - b);
    let middle = Math.floor(input.length / 2);
    let numbers = input.slice(middle);
    return numbers;
}

bigger([4, 7, 2, 5]);
bigger([3, 19, 14, 7, 2, 19, 6]);