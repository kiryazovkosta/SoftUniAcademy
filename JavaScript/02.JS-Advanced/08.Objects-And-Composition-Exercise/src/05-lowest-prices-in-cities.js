function lowestPrices(towns) {
    let products = {};

    for (const iterator of towns) {
        let [name, product, price] = iterator.split(' | ');
        price = Number(price);
        if (products[product] == undefined) {
            products[product] = { price: price, town: name };
        } else {
            if (products[product].price > price) {
                products[product] = { price: price, town: name };
            }
        }
    }

    for (const product in products) {
        console.log(`${product} -> ${products[product].price} (${products[product].town})`)
    }
}

lowestPrices(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);