function printNumbers(params) {
    let n = Number(params[0]);
    for (let index = n; index >= 1; index--){
        console.log(index);
    }
}

printNumbers(["20"]);