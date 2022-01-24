function editElement(element, match, replacer) {
    const matcher = new RegExp(match, 'g');
    element.textContent = element.textContent.replace(matcher, replacer);
}