function login(params) {
    let user = params[0];
    let pass = params[1];

    let index = 2;
    let data = params[index++];
    while (data !== pass) {
        data = params[index];
        index++;
    }

    console.log(`Welcome ${user}!`);
}

login(["Nakov",
"1234",
"Pass",
"1324",
"1234"]);

login(["Gosho",
"secret",
"secret"]);