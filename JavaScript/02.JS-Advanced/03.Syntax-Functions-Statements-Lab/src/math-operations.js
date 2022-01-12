function math(a, b, operation) {
    let result;
    switch (operation) {
        case '+':result = a + b;break;
        case '-':result = a - b;break;
        case '*':result = a * b; break;
        case '/': result = a / b; break;
        case '%': result = a % b; break;
        case '**': result = a ** b; break;
    }

    console.log(result)
}

math(5, 6, '+');
math(3, 5.5, '*');
math(2, 3, '**');