function solve(params) {
    let startYear = Number(params[0]);
    let endYear = Number(params[1]);
    for (let index = startYear; index <= endYear; index+=4) {
        console.log(index);
    }
}

solve(["1908","1919"]);