function addItem() {
    let text = document.getElementById('newItemText').value;
    let ulElement = document.getElementById('items');
    let liElement = document.createElement('li');
    liElement.textContent = text;
    let aElement = document.createElement('a');
    aElement.textContent = '[Delete]';
    aElement.setAttribute('href', '#');
    aElement.addEventListener('click', function(ev) {
        ev.currentTarget.parentElement.remove();
    });
    liElement.appendChild(aElement);
    ulElement.appendChild(liElement);
    document.getElementById('newItemText').value = '';
}