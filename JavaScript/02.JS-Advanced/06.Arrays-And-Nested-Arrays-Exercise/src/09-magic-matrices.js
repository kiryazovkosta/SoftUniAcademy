function magic(matrix) {

    function calcColSum(i) {
        let currentRowSum = 0;
        for (let j = 0; j < matrix.length; j++) {
            const element = matrix[j][i];
            currentRowSum += element;
        }
        return currentRowSum;
    }

    function caclRowSum(i) {
        let currentRowSum = 0;

        // Rows
        for (let j = 0; j < matrix.length; j++) {
            const element = matrix[i][j];
            currentRowSum += element;
        }
        return currentRowSum;
    }

    let areEquals = true;
    let sum = undefined;
    for (let i = 0; i < matrix.length; i++) {
        let currentRowSum = caclRowSum(i);

        if (sum === undefined) {
            sum = currentRowSum;
        } else {
            if (sum !== currentRowSum) {
                areEquals = false;
                break;
            }
        }

        // Cols
        currentRowSum = calcColSum(i);

        if (sum !== currentRowSum) {
            areEquals = false;
            break;
        }
    }

    return areEquals;
}

magic([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );
   magic([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]   
   );
   magic([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]   
   );