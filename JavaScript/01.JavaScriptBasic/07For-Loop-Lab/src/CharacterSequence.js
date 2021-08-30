function sequence(params) {
    let text = params[0];
    let length = text.length;
    for( let index = 0; index < length; index++) {
        let letter = text[index];
        console.log(letter);
    }
}

sequence(["softuni"]);