function solve() {
    let buttons = document.querySelectorAll('button');
    buttons[0].addEventListener('click', check);
    buttons[1].addEventListener('click', clear);

    let result = document.querySelector('div#check p');
    let table = document.querySelector('table');
    let cells = Array.from(table.querySelectorAll('input[type="number"]'));
    let rows = table.querySelectorAll('tbody tr');

    function check(ev) {

        let matrix = [];

        for (let row of rows) {
            const rowData = Array.from(row.querySelectorAll('input[type="number"]')).map(el => Number(el.value));
            matrix.push(rowData);
        }

        let isSuccess = matrix.flat().filter(el => el >= 1 && el <= matrix.length).length == matrix.length ** 2;
        console.log(isSuccess);
        if (isSuccess) {
            let sum = matrix[0].reduce((a, c) => a + c, 0);
            for (let i = 0; i < matrix.length; i++) {
                let current = matrix[i].reduce((a, c) => a + c, 0);
                console.log(current);
                if (current != sum) {
                    isSuccess = false;
                    break;
                }
            }
    
            if (isSuccess) {
                for (let i = 0; i < matrix.length; i++) {
                    console.log('-------------');
                    let current = 0;
                    for (let j = 0; j < matrix.length; j++) {
                        const element = matrix[j][i];
                        current += element
                    }
                    console.log(current);
                    if (current != sum) {
                        isSuccess = false;
                        break;
                    }
                }
            }
        }

        if (isSuccess) {
            printSuccess();
        } else {
            printError();
        }

    }

    function clear(ev) {
        cells.forEach(el => el.value = '');
        result.textContent = '';
        table.style.border = 'none';
    }

    function printSuccess(){
        table.style.border = '2px solid green';
        result.textContent = "You solve it! Congratulations!"
        result.style.color = 'green';
    }

    function printError() {
        table.style.border = '2px solid red';
        result.textContent = "NOP! You are not done yet..."
        result.style.color = 'red';
    }
}