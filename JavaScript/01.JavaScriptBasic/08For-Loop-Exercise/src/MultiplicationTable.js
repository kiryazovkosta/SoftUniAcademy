function multiplication(params) {
    let number = Number(params[0]);
    for (let index = 1; index <= 10; index++) {
        const element = index;
        console.log(`${element} * ${number} = ${element * number}`);
    }
}

multiplication(["5"]);