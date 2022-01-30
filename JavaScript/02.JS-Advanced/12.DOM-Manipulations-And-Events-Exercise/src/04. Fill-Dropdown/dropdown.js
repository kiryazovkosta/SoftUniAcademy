function addItem() {
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue');
    let menu = document.getElementById('menu');

    let optionElement = document.createElement('option');
    optionElement.textContent = textElement.value;
    optionElement.value = valueElement.value;
    menu.appendChild(optionElement);

    textElement.value = '';
    valueElement.value = '';
}