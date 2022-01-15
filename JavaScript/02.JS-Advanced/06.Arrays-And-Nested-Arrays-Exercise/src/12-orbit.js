function populate(input) {
    let width = input[0];
    let height = input[1];
    let x = input[2];
    let y = input[3];

    let matrix = [];
    for (let i = 0; i < width; i++) {
        matrix.push([]);
    }

    for (let row = 0; row < width; row++) {
        for (let col = 0; col < height; col++) {
            matrix[row][col] = Math.max(Math.abs(row - x), Math.abs(col - y)) + 1;
        }
    }

    console.log(matrix.map(row => row.join(" ")).join("\n"));
}

populate([4, 4, 0, 0]);
console.log('---');
populate([5, 5, 2, 2]);
console.log('---');