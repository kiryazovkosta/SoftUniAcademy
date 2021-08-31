function loop() {
    let number = 1;
    while (true) {
        console.log(number++);
        if (number > 100) {
            break;
        }
    }
}

loop();