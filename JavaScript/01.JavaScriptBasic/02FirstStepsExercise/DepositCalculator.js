function calculate(input){
    let amount = Number(input[0]);
    let period = Number(input[1]);
    let percentage = Number(input[2]);

    let sum = amount + period * ( (amount * (percentage / 100)) / 12 );

    console.log(sum)
}

calculate(["200", "3", "5.7"]);
calculate(["2350", "6", "7"]);