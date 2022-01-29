function addItem() {
    let ulElement = document.querySelector('#items');
    let text = document.querySelector('#newItemText').value;

    let liElement = document.createElement('li');
    liElement.textContent = text;
    ulElement.appendChild(liElement);
    document.querySelector('#newItemText').value = '';
}