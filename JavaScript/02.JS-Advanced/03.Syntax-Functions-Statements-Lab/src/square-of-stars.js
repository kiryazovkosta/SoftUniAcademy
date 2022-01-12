function square(size = 5) {
    for (let i = 0; i < size; i++) {
        let line = [];
        for (let j = 0; j < size; j++) {
            line[j] = "*";
        }
        
        console.log(line.join(' '));
    }
}

square(1);
square(2);
square(5);
square(7);
square();