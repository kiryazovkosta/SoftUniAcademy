function attack(matrix){
    let numbers = [];
    for (let rowIndex = 0; rowIndex < matrix.length; rowIndex++) {
        let data = matrix[rowIndex].split(' ').map(n => Number(n));
        numbers[rowIndex] = data;
    }

    let coordinates = [];
    let primary = 0;
    let secondary = 0;
    let x = 0;
    let y = numbers.length - 1;
    while (x < numbers.length && y >= 0) {
        primary += numbers[x][x];
        coordinates.push(''+x+x);
        secondary += numbers[numbers.length -1 - y][y];
        coordinates.push(''+ (numbers.length -1 - y) + y);
        x++;
        y--;
    } 

    if (primary === secondary) {
        for (let rowIndex = 0; rowIndex < numbers.length; rowIndex++) {
            for (let colIndex = 0; colIndex < numbers.length; colIndex++) {
                const coordinate = '' + rowIndex + colIndex;
                if(coordinates.includes(coordinate) === false) {
                    numbers[rowIndex][colIndex] = primary;
                }
            }
            
        }
    }

    numbers.forEach(row => {
        console.log(row.join(' '));
    });
}

attack(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
);
console.log("----");
attack(['1 1 1',
'1 1 1',
'1 1 0']
);