function neighbors(matrix) {
    let counter = 0;
    for (let rowIndex = 0; rowIndex < matrix.length; rowIndex++) {
        let rowLength = matrix[rowIndex].length;
        console.log(rowLength);
        for (let colIndex = 0; colIndex < rowLength; colIndex++) {
            const element = matrix[rowIndex][colIndex];
            let rightNeighbor = undefined;
            let bottomNeughbor = undefined;
            if (colIndex + 1 < rowLength) {
                rightNeighbor = matrix[rowIndex][colIndex + 1];
                if (element == rightNeighbor) {
                    counter++;
                }
            }

            if (rowIndex + 1 < matrix.length) {
                bottomNeughbor = matrix[rowIndex + 1][colIndex];
                if (element == bottomNeughbor) {
                    counter++;
                }
            }

            console.log(element + ' => [' + rightNeighbor + ':' + bottomNeughbor + ']');
        }
    }

    console.log(counter);
    return counter;
}

neighbors(
    [
        ['2', '3', '4', '7', '0'],
        ['4', '0', '5', '3', '4'],
        ['2', '3', '5', '4', '2'],
        ['9', '8', '7', '5', '4']
    ]
);

// neighbors(
//     [
//         ['test', 'yes', 'yo', 'ho'],
//         ['well', 'done', 'yo', '6'],
//         ['not', 'done', 'yet', '5']
//     ]
// );