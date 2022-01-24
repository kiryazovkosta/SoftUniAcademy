function extractText() {
    let items = document.querySelectorAll('ul#items li');
    let result = document.querySelector('#result');
    let output = [];
    for (const iterator of Array.from(items)) {
        output.push(iterator.textContent);
    }
    result.textContent = output.join('\n');
}