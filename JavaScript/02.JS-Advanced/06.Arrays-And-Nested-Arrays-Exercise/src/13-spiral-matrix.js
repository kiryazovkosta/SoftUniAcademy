function print(rows, cols) {
    let matrix = [];
    for (let rIndex = 0; rIndex < rows; rIndex++) {
        matrix[rIndex] = [];
        for (let cIndex = 0; cIndex < cols; cIndex++) {
            matrix[rIndex][cIndex] = 0;
        }
    }

    let number = 1;
    fill(matrix, number, 0, rows - 1, 0, cols - 1);

    matrix.forEach(row => {
        console.log(row.join(' '));
    })

    function fill(matrix, number, startRow, endRow, startCol, endCol) {
        for (let colIndex = startCol; colIndex <= endCol; colIndex++) {
            matrix[startRow][colIndex] = number++;
        }

        for (let rowIndex = startRow + 1; rowIndex <= endRow; rowIndex++) {
            matrix[rowIndex][endCol] = number++;
        }

        for (let colIndex = endCol -1; colIndex >= startCol; colIndex--) {
            matrix[endRow][colIndex] = number++;
        }

        for (let rowIndex = endRow - 1; rowIndex > startRow; rowIndex--) {
            matrix[rowIndex][startCol] = number++;
            
        }

        let total = matrix.length * matrix[0].length;
        if (number > total) {
             return;
        } else {
            fill(matrix, number, startRow + 1, endRow - 1, startCol + 1, endCol - 1);
        }
    };
}

print(5, 5);
console.log("----");
print(1, 1);
console.log("----");
print(2, 2);
console.log("----");
print(3, 3);
console.log("----");
print(5 , 2);