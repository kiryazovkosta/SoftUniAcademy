function count(params) {
    let text = params[0];
    let spaceCounter = 0;
    for (let index = 0; index < text.length; index++) {
        const element = text[index];
        if (element === " ") {
            spaceCounter++;
        }
    }

    if (spaceCounter < 10) {
        console.log("The message was sent successfully!");
    } else {
        console.log(`The message is too long to be send! Has ${spaceCounter + 1} words.`);
    }
}

count(["This message has exactly eleven words. One more as it's allowed!"]);