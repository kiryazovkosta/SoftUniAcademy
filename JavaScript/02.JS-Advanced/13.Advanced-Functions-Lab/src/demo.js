function solve() {
    let button = document.getElementById('sort-button');
    button.addEventListener('click', sortElements);

    function sortElements(ev) {
        let elements = [...document.querySelectorAll('li')].sort((a, b) => Number(a.textContent) - Number(b.textContent));
        let ulElement = document.querySelector('ul');
        // while (ulElement.firstChild) {
        //     ulElement.firstChild.remove();
        // }
        elements.forEach(e => ulElement.appendChild(e));
    }
}