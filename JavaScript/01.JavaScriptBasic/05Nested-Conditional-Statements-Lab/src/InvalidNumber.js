function isValid(input) {
    let number = Number(input[0]);
    let valid = false;
    if ((number >= 100 && number <= 200) || number === 0) {
        valid = true;
    }

    if (!valid) {
        console.log("invalid");
    }
}

isValid(["75"]);
isValid(["150"]);
