function check(params) {
    let favority = params[0];
    let index = 1;
    let data = params[index];
    let isFound = false;
    let booksCounter = 0;
    while (data !== "No More Books") {
        if (data === favority) {
            isFound = true;
            break;
        }

        booksCounter++;
        index++;
        data = params[index];
    }

    if (isFound) {
        console.log(`You checked ${booksCounter} books and found it.`);
    } else {
        console.log(`The book you search is not here!`);
        console.log(`You checked ${booksCounter} books.`);
    }
}

check(["The Spot",
"Hunger Games",
"Harry Potter",
"Torronto",
"Spotify",
"No More Books"]);

check(["Troy",
"Stronger",
"Life Style",
"Troy"]);