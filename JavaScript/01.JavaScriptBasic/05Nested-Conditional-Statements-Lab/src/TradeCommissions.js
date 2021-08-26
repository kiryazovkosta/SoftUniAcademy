function calculateCommission(input) {
    let town = input[0];
    let sales = Number(input[1]);

    let isValid = true;
    let percentages = 0.0;
    if (town === "Sofia") {
        if (sales > 10000) {
            percentages = 0.12;
        } else if (sales > 1000) {
            percentages = 0.08;
        } else if (sales > 500) {
            percentages = 0.07;
        } else if (sales >= 0) {
            percentages = 0.05;
        } else {
            isValid = false;
            console.log("error");
        }
    } else if (town === "Varna") {
        if (sales > 10000) {
            percentages = 0.13;
        } else if (sales > 1000) {
            percentages = 0.10;
        } else if (sales > 500) {
            percentages = 0.075;
        } else if (sales >= 0) {
            percentages = 0.045;
        } else {
            isValid = false;
            console.log("error");
        }
    } else if (town === "Plovdiv") {
        if (sales > 10000) {
            percentages = 0.145;
        } else if (sales > 1000) {
            percentages = 0.12;
        } else if (sales > 500) {
            percentages = 0.08;
        } else if (sales >= 0) {
            percentages = 0.055;
        } else {
            isValid = false;
            console.log("error");
        }
    }
    else {
        isValid = false;
        console.log("error");
    }

    if (isValid) {
        let commission = sales * percentages;
        console.log(commission.toFixed(2));
    }
}

calculateCommission(["Sofia", "1500"]);
calculateCommission(["Plovdiv", "499.99"]);	
calculateCommission(["Varna", "3874.50"]);		
calculateCommission(["Kaspichan", "-50"]);
