function prices(params) {
    let month = params[0];
    let nights = Number(params[1]);

    switch (month) {
        case "May":
        case "October":
            apartmentPrice = 65.00;
            studioPrice = 50.00;
            break;

        case "June":
        case "September":
            apartmentPrice = 68.70;
            studioPrice = 75.20;
            break;

        case "July":
        case "August":
            apartmentPrice = 77.00;
            studioPrice = 76.00;
            break;

        default:
            break;
    }

    if (month === "May" || month === "October") {
        if (nights > 14) {
            studioPrice -= studioPrice * 0.3;
        } else if (nights > 7) {
            studioPrice -= studioPrice * 0.05;
        }
    } else if ((month === "June" || month === "September") && nights > 14) {
        studioPrice -= studioPrice * 0.2;
    }

    if (nights > 14) {
        apartmentPrice -= apartmentPrice * 0.1;
    }

    let studioTotalPrice = nights * studioPrice;
    let apartamentTotalPrice = nights * apartmentPrice;

    console.log(`Apartment: ${apartamentTotalPrice.toFixed(2)} lv.`);
    console.log(`Studio: ${studioTotalPrice.toFixed(2)} lv.`);
}

prices(["May", "15"]);
prices(["June", "14"]);
prices(["August", "20"]);
