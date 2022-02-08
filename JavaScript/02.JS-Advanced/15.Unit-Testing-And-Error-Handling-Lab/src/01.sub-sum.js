function sum(numbers, start, end) {
    if (Array.isArray(numbers) === false) {
        return NaN;
    }

    let startIndex = Math.max(start, 0);
    let endIndex = Math.min(end, numbers.length);

    return numbers.slice(startIndex, endIndex + 1).map(Number).reduce((acc, c)=> acc+c, 0);
}

sum([10, 20, 30, 40, 50, 60], 3, 300);
sum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1);
sum([10, 'twenty', 30, 40], 0, 2);
sum([], 1, 2);
sum('text', 0, 2);