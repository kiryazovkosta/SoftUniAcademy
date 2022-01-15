function sums(matrix){
    let primary = 0;
    let secondary = 0;
    let x = 0;
    let y = matrix.length - 1;
    while (x < matrix.length && y >= 0) {
        primary += Number(matrix[x][x]);
        secondary += Number(matrix[matrix.length -1 - y][y]);
        x++;
        y--;
    }

    console.log(`${primary} ${secondary}`);
}

sums([[20, 40],[10, 60]]);
console.log('================');
sums([[3, 5, 17],[-1, 7, 14],[1, -8, 89]]);