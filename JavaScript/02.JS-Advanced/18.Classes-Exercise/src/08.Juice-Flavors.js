function solve(input){
    let bottles = new Set();
    let juices = new Map();
    for (const juice of input) {
        let [name, quantity] = juice.split(' => ');
        if (!juices.has(name)) {
            juices.set(name, 0);
        }

        juices.set(name, juices.get(name) + Number(quantity));
        if (juices.get(name) >= 1000) {
            bottles.add(name)
        }
    }

    for (const bottle of bottles) {
        console.log(bottle + ' => ' + Math.floor(juices.get(bottle)/1000));
    }
}

solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']
);

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);