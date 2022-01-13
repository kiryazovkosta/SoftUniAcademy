function upper(text) {
    const regexp = new RegExp('\\w+', 'g');
    const matches = text.matchAll(regexp);
    let words = [];
    for (const match of matches) {
        words.push(match[0].toUpperCase());
    }

    console.log(words.join(', '));
}

upper('Hi, how are you?');
upper('hello');