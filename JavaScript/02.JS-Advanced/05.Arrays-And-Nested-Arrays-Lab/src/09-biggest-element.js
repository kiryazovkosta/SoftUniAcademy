function biggest(array) {
    let max = Number.MIN_SAFE_INTEGER;
    array.forEach((row) => {
        row.forEach((cell) => {
            let value = Number(cell);
            if (cell > max) {
                max = cell;
            }
        });
    });

    return max;
}

biggest([[20, 50, 10],[8, 33, 145]]);
console.log('-----');
biggest([[3, 5, 7, 12],[-1, 4, 33, 2],[8, 3, 0, 4]]);