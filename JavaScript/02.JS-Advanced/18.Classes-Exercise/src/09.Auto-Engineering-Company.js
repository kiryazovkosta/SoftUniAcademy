function solve(input) {
    let company = new Map();
    for (const iterator of input) {
        let [brand, model, quantity] = iterator.split(' | ');
        quantity = Number(quantity);
        if (!company.has(brand)) {
            let data = {};
            data[model] = quantity;
            company.set(brand, data);
        } else {
            if (!company.get(brand).hasOwnProperty(model)) {
                company.get(brand)[model] = quantity;
            } else {
                company.get(brand)[model] += quantity;
            }
        }
    }

    for (const [brand, data] of company.entries()) {
        console.log(brand);
       for (const [model, quantity] of Object.entries(data)) {
           console.log(`###${model} -> ${quantity}`);
       }
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
);