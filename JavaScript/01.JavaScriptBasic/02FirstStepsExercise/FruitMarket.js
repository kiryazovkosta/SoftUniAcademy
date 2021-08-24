function solve(input) {
    let yagodiPrice = Number(input[0]);
    let banani = Number(input[1]);
    let portokali = Number(input[2]);
    let malini = Number(input[3]);
    let yagodi = Number(input[4]);
    
    let maliniPrice = yagodiPrice / 2;
    let portokaliPrice = maliniPrice - (maliniPrice * 0.4);
    let bananiPrice = maliniPrice - (maliniPrice * 0.8); 
    let sum = (yagodiPrice * yagodi) + (malini * maliniPrice) + (portokali * portokaliPrice) + (banani * bananiPrice);
    console.log(sum);
}

solve(["48",
"10",
"3.3",
"6.5",
"1.7"]);

solve(["63.5",
"3.57",
"6.35",
"8.15",
"2.5"]);