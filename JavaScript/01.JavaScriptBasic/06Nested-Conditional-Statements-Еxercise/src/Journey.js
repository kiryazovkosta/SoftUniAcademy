function trip(params) {
    let budget = Number(params[0]);
    let season = params[1];

    let destination = "";
    let tripType = "";
    let tripPrice = 0.0;

    if (budget <= 100) {
        destination = "Bulgaria";
        if (season === "summer") {
            tripType = "Camp";
            tripPrice = budget * 0.3;
        } else if (season === "winter") {
            tripType = "Hotel";
            tripPrice = budget * 0.7;
        }
    } else if (budget > 100 && budget <= 1000) {
        destination = "Balkans";
        if (season === "summer") {
            tripType = "Camp";
            tripPrice = budget * 0.4;
        } else if (season === "winter") {
            tripType = "Hotel";
            tripPrice = budget * 0.8;
        }
    } else if (budget > 1000) {
        destination = "Europe";
        tripType = "Hotel";
        tripPrice = budget * 0.9;
    }

    console.log(`Somewhere in ${destination}`);
    console.log(`${tripType} - ${tripPrice.toFixed(2)}`);
}

trip(["1500", "summer"])