function solve(n, k) {
    let numbers = [];
    if (n > 0) {
        numbers.push(1);
        for (let i = 1; i < n; i++) {
            let sum = 0;
            for (let j = k; j > 0; j--) {
                const value = numbers[i - j];
                if (value !== undefined) {
                    sum += value;
                }
            }

            numbers.push(sum);
        }

    }

    return numbers;
}

solve(6, 3);
solve(8, 2);