function rotate(array, count) {
    for (let i = 1; i <= count; i++) {
        array.unshift(array.pop());
    }

    console.log(array.join(' '));
}

rotate(['1', '2', '3', '4'], 2);
console.log('---');
rotate(['Banana', 'Orange', 'Coconut', 'Apple'], 15);