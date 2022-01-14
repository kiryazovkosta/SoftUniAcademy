function sum(array) {
    let first = Number(array.shift());
    let last = Number(array.pop());
    console.log(first + last);
}

sum(['20', '30', '40']);
sum(['5', '10']);