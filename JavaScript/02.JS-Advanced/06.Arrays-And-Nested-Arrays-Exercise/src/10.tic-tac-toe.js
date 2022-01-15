function game(operations) {
    let board = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    let player = 'X';
    for (let index = 0; index < operations.length; index++) {
        let coordinates = operations[index].split(' ');
        let rowIndex = Number(coordinates[0]);
        let colIndex = Number(coordinates[1]);

        // check position is already taken
        if (board[rowIndex][colIndex] !== false) {
            console.log('This place is already taken. Please choose another!');
        } else {
            let symbol = player;
            board[rowIndex][colIndex] = symbol;

            // checks for winner
            let hasWinner = checkForWinner(board, symbol);
            if (hasWinner) {
                console.log(`Player ${player} wins!`);
                break;
            }

            // checks for empty cells
            let haveEmptyCell = boardHaveEmptyCells(board);
            if (!haveEmptyCell) {
                console.log('The game ended! Nobody wins :(');
                break;
            }

            player = player === 'X' ? 'O' : "X";
        }
        
    }

    board.forEach(row => {
        console.log(row.join('\t'));
    })

    function boardHaveEmptyCells(array) {
        for (let i = 0; i < array.length; i++) {
            for (let j = 0; j < array.length; j++) {
                const element = array[i][j];
                if (element === false) {
                    return true;
                }
            }
            
        }

        return false;
    }

    function checkForWinner(array, symbol){
        // rows
        let hasWinner = false;
        for (let i = 0; i < array.length; i++) {
            hasWinner = true;
            for (let j = 0; j < array.length; j++) {
                const element = array[i][j];
                if (element !== symbol) {
                    hasWinner = false;
                    break;
                }
            }

            if (hasWinner) {
                return hasWinner;
            }
        }

        // cols
        for (let i = 0; i < array.length; i++) {
            hasWinner = true;
            for (let j = 0; j < array.length; j++) {
                const element = array[j][i];
                if (element !== symbol) {
                    hasWinner = false;
                    break;
                }
            }

            if (hasWinner) {
                return hasWinner;
            }
        }

        // main diagonal
        let x = 0;
        hasWinner = true;
        while (x < array.length) {
            const element = array[x][x];
            if (element !== symbol) {
                hasWinner = false;
                break;
            }

            x++;
        }

        if (hasWinner) {
            return hasWinner;
        }

        // secondary diagonal
        let y = array.length - 1;
        hasWinner = true;
        while (y >= 0) {
            const element = array[array.length -1 - y][y];
            if (element !== symbol) {
                hasWinner = false;
                break;
            }

            y--;
        }

        return hasWinner;
    }
}

game(["0 1",
"0 0",
"0 2", 
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]
);

console.log('---');

game(["0 0",
"0 0",
"1 1",
"0 1",
"1 2",
"0 2",
"2 2",
"1 2",
"2 2",
"2 1"]
);

console.log('---');

game(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]
);