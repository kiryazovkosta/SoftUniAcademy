function usd2Bgn(input) {
    let usd = Number(input[0]);
    let bgn = usd * 1.79549;
    console.log(bgn);
}

usd2Bgn(['22']);
usd2Bgn(["100"]);
usd2Bgn(["12.5"]);