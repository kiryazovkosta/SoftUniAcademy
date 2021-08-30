function printNumbers() {
    for(let index = 1; index <= 1000; index++) {
        if (index % 10 === 7) {
            console.log(index);
        }
    }
}

printNumbers();