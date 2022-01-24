function sumTable() {
    let rows = document.querySelectorAll('table tr');
    let total = 0;
    for (let i = 1; i < rows.length - 1; i++) {
        const element = rows[i].lastElementChild;
        total += Number(element.textContent);
    }

    let sum = document.querySelector('td#sum');
    sum.textContent = total;
}