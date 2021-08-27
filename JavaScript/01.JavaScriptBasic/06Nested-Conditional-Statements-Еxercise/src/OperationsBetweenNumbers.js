function expression(params) {
    let a = Number(params[0]);
    let b = Number(params[1]);
    let operator = params[2];

    let result = 0;
    let type = "";

    if (operator === "+") {
        result = a + b;
        type = result % 2 === 0 ? "even" : "odd";
        console.log(`${a} + ${b} = ${result} - ${type}`);
    } else if (operator === "-") {
        result = a - b;
        type = result % 2 === 0 ? "even" : "odd";
        console.log(`${a} - ${b} = ${result} - ${type}`);
    } else if (operator === "*") {
        result = a * b;
        type = result % 2 === 0 ? "even" : "odd";
        console.log(`${a} * ${b} = ${result} - ${type}`);
    } else if (operator === "/") {
        if (b === 0) {
            console.log(`Cannot divide ${a} by zero`);
        } else {
            result = a / b;
            console.log(`${a} / ${b} = ${result.toFixed(2)}`);
        }
    } else if (operator === "%") {
        if (b === 0) {
            console.log(`Cannot divide ${a} by zero`);
        } else {
            result = a % b;
            console.log(`${a} % ${b} = ${result}`);
        }
    }
}

expression(["10","12","+"]);
expression(["123","12","/"]);
expression(["112","0","/"]);
expression(["10","1","-"]);	
expression(["10","3","%"]);
expression(["10","0","%"]);