function greaterNumber(input) {
    let a = Number(input[0]);
    let b = Number(input[1]);
    if (a > b) {
        console.log(a);
    } else {
        console.log(b);
    }
}

greaterNumber(["5", "3"]);
greaterNumber(["10", "10"]);
greaterNumber(["-4", "4"]);
greaterNumber(["3", "5"]);