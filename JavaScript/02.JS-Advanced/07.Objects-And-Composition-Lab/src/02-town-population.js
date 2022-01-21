function calculatePopulation(input) {
    const towns = {};
    for (const town of input) {
        let [name, population] = town.split(' <-> ');
        if (towns[name] == undefined) {
            towns[name] = 0;
        }

        towns[name] += Number(population);
    }

    for (let [name, population] of Object.entries(towns)) {
        console.log(`${name} : ${population}`);
    }
}

calculatePopulation(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);

console.log('======');

calculatePopulation(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']);