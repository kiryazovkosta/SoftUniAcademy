function largest(a, b, c) {
    let max;
    if (a > b && a > c) {
        max = a;
    } else if (b > a && b > c) {
        max = b;
    } else {
        max = c;
    }

    console.log(`The largest number is ${max}.`);
}

largest(5, -3, 16);
largest(-3, -5, -22.5);