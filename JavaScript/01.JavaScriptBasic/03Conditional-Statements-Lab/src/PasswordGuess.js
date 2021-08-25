function guessPassword(input) {
    let validPassword = "s3cr3t!P@ssw0rd";
    let userPassword = input[0];
    if (userPassword === validPassword) {
        console.log("Welcome");
    } else {
        console.log("Wrong password!");
    }
}