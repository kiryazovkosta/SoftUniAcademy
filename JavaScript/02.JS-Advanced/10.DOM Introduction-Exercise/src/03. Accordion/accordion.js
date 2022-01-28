function toggle() {
    let button = document.querySelector('span.button');
    button.textContent = button.textContent == 'Less' ? 'More' : 'Less';
    let text = document.querySelector('div#extra');
    let style = text.style.display;
    if (style === '' || style === 'none') {
        text.style.display = 'block';
    } else {
        text.style.display = 'none';
    }
}