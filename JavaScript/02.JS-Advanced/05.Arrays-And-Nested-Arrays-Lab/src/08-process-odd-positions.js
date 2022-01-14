function positions(array) {
    let numbers = array
        .filter((n, i) => i % 2 !== 0)
        .map((n) => n * 2)
        .reverse();
    return numbers;
}

positions([10, 15, 20, 25]);
console.log('-----');
positions([3, 0, 10, 4, 7, 3]);