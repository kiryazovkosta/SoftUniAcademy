function catalogue(input) {
    let output = {};
    for (const iterator of input) {
        let [name, quantity] = iterator.split(' : ');
        quantity = Number(quantity);
        let letter = name[0].toUpperCase();
        if (output[letter] == undefined) {
            output[letter] = [];
        }

        output[letter].push({ name, quantity });
    }

    let products = Object.keys(output).sort((a, b) => a.localeCompare(b));
    for (const product of products) {
        console.log(product);
        for (const iterator of output[product].sort((a, b) => a.name.localeCompare(b.name))) {
            console.log(`  ${iterator.name}: ${iterator.quantity}`);
        }
    }
}

catalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);
console.log("========");
catalogue(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
);