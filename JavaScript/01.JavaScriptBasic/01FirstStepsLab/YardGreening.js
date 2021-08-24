function greening(input) {
    let area = Number(input[0]);
    let total = area * 7.61;
    let discount = total * 0.18;
    let amount = total - discount;
    console.log(`The final price is: ${amount} lv.`);
    console.log(`The discount is: ${discount} lv.`);
}

greening(["150"]);