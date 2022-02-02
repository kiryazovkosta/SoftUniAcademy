function solution(n){
    let init = n;
    function add(number) {
        return init + number;
    }

    return add;
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));

console.log("--------");
let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));
