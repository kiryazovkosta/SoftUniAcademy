function deleteByEmail() {
    let search = document.querySelector('input[name="email"]').value;
    let tdElements = Array.from(document.querySelectorAll('table#customers td:last-child'));
    let tdElement = tdElements.find(td => td.textContent === search);
    if (tdElement) {
        tdElement.parentElement.remove();
        document.getElementById('result').textContent = 'Deleted.';
    } else {
        document.getElementById('result').textContent = 'Not found.';
    }
}