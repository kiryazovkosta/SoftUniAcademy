function extract(numbers) {
    let output = [];
    let previous = Number.MIN_SAFE_INTEGER;  
    for (let i = 0; i < numbers.length; i++) {
        const number = Number(numbers[i]);
        if (number >= previous) {
            output.push(number);
            previous = number;
        }
    }

    return output;
}

extract([1, 3, 8, 4, 10, 12, 3, 2, 24]);