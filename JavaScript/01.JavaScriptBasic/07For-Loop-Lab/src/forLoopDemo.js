function forLoop() {
    let array = [1, 2, 3, 4, 5, 6];

    for (let index = 0; index < array.length; index++) {
        console.log(array[index]);
    }

    let a = 1;
    console.log(a);
    console.log(a++);
    console.log(++a);
}

forLoop();