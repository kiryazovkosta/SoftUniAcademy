function trip(params) {
    let destination = params[0];
    let budget = Number(params[1]);

    let savings = 0;
    let index = 1;

    while (destination !== 'End') {
        index++

        while (savings < budget) {
            savings += Number(params[index]);
            index++;
        }

        console.log(`Going to ${destination}!`)
        destination = params[index++];
        budget = Number(params[index]);
        savings = 0;
    }
}

trip(["Greece",
    "1000",
    "200",
    "200",
    "300",
    "100",
    "150",
    "240",
    "Spain",
    "1200",
    "300",
    "500",
    "193",
    "423",
    "End"]);

trip(["France",
    "2000",
    "300",
    "300",
    "200",
    "400",
    "190",
    "258",
    "360",
    "Portugal",
    "1450",
    "400",
    "400",
    "200",
    "300",
    "300",
    "Egypt",
    "1900",
    "1000",
    "280",
    "300",
    "500",
    "End"]);