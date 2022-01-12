function gcd(a, b){
    let max;
    let min = a <= b ? a :b;

    for(let i = 1; i <= min; i++) {
        if(a % i == 0 && b % i == 0) {
            max = i;
        }
    }

    console.log(max);
}

gcd(15, 5);
gcd(2154, 458);