function solve() {
    let bin = document.createElement('option');
    bin.value = 'binary';
    bin.textContent = 'Binary';
    document.querySelector('select#selectMenuTo').appendChild(bin);
    let hex = document.createElement('option');
    hex.value = 'hexadecimal';
    hex.textContent = 'Hexadecimal';
    document.querySelector('select#selectMenuTo').appendChild(hex);

    document.querySelector('button').onclick = function(){
        let number = Number(document.getElementById('input').value);
        let to = document.querySelector('select#selectMenuTo').value;
        let result = '';
        if (to === 'binary') {
            result = number.toString(2);
        } else if (to === 'hexadecimal') {
            result = number.toString(16).toUpperCase();
        }

        document.getElementById('result').value = result;
    }
}