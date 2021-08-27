function chooseOutfit(params) {
    let degrees = Number(params[0]);
    let period = params[1];

    let outfit = "";

    switch (period) {
        case "Morning":
            if (degrees >= 10 && degrees <= 18) {
                outfit = "Sweatshirt and Sneakers";
            }  else if (degrees > 18 && degrees <= 24) {
                outfit = "Shirt and Moccasins";
            } else {
                outfit = "T-Shirt and Sandals";
            }
            break;

        case "Afternoon":
            if (degrees >= 10 && degrees <= 18) {
                outfit = "Shirt and Moccasins";
            } else if (degrees > 18 && degrees <= 24) {
                outfit = "T-Shirt and Sandals";
            } else {
                outfit = "Swim Suit and Barefoot";
            }
            break;

        case "Evening":
            outfit = "Shirt and Moccasins";
            break;

        default:
            break;
    }

    console.log(`It's ${degrees} degrees, get your ${outfit}.`);
}

chooseOutfit(["22", "Afternoon"])