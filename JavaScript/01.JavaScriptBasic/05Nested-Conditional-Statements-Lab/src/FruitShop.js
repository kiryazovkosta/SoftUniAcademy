function calculatePrice(input) {
    let product = input[0];
    let day = input[1];
    let quantity = Number(input[2]);

    let isValid = true;
    let price = 0.0;
    switch (day) {
        case 'Monday':
        case 'Tuesday':
        case 'Wednesday':
        case 'Thursday':
        case 'Friday':
            switch (product) {
                case "banana":
                    price = 2.50;
                    break;
                case "apple":
                    price = 1.20;
                    break;
                case "orange":
                    price = 0.85;
                    break;
                case "grapefruit":
                    price = 1.45;
                    break;
                case "kiwi":
                    price = 2.70;
                    break;
                case "pineapple":
                    price = 5.50;
                    break;
                case "grapes":
                    price = 3.85;
                    break;

                default:
                    console.log("error");
                    isValid = false;
                    break;
            }
            break;

        case 'Saturday':
        case 'Sunday':
            switch (product) {
                case "banana":
                    price = 2.70;
                    break;
                case "apple":
                    price = 1.25;
                    break;
                case "orange":
                    price = 0.90;
                    break;
                case "grapefruit":
                    price = 1.60;
                    break;
                case "kiwi":
                    price = 3.00;
                    break;
                case "pineapple":
                    price = 5.60;
                    break;
                case "grapes":
                    price = 4.20;
                    break;

                default:
                    console.log("error");
                    isValid = false;
                    break;
            }
            break;

        default:
            console.log("error");
            isValid = false;
            break;
    }

    if (isValid) {
        let totalPrice = quantity * price;
        console.log(totalPrice.toFixed(2));
    }
}

calculatePrice(["apple", "Tuesday", "2"]);
calculatePrice(["orange", "Sunday", "3"]);
calculatePrice(["kiwi", "Monday", "2.5"]);
calculatePrice(["grapes", "Saturday", "0.5"]);