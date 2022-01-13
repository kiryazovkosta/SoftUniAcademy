function cooking(n, oper1, oper2, oper3, oper4, oper5) {

    let chop = (n) => n / 2;
    let dice = function(n) {
        return Math.sqrt(n);
    }

    let number = n;
    let operators = [oper1, oper2, oper3, oper4, oper5];
    for (let index = 0; index < operators.length; index++) {
        let result;
        const operator = operators[index];
        switch(operator){
            case 'chop': 
                result = chop(number); 
                break;

            case 'dice': 
                result = dice(number); 
                break;

            case 'spice': 
                result = number + 1; 
                break;

            case 'bake': 
                result = number * 3; 
                break;

            case 'fillet': 
                result = number - (number * 0.2);
                break;

            default: break;
        }

        number = result;
        console.log(number);
    }
}

cooking('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet');