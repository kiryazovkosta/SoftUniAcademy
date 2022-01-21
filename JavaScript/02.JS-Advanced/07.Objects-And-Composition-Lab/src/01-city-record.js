function record (name, population, treasury ) {
    const city = {
        name: name,
        population: population,
        treasury: treasury,
    };

    return city;
}

let city = record('Tortuga',7000, 15000);
console.log(city);
