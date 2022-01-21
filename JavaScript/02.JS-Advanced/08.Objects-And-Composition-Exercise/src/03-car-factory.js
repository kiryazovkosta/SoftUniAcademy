function factory(input) {
    let car = {};
    car.model = input.model;
    if (input.power <= 90) {
        car.engine = { power: 90, volume: 1800 };
    } else if (input.power <= 120) {
        car.engine = { power: 120, volume: 2400 };
    } else {
        car.engine = { power: 200, volume: 3500 };
    }

    car.carriage = { type: input.carriage, color: input.color };

    let wheelsize = input.wheelsize;
    if (wheelsize % 2 == 0) {
        wheelsize--;
    }

    car.wheels = new Array(4).fill(wheelsize);
    return car;
}

console.log(factory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));
console.log("======");
console.log(factory({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));