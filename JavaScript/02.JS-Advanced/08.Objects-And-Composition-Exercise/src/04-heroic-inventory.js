function inventory(input) {
    let heroes = [];
    for (const iterator of input) {
        let[name, level, items] = iterator.split(' / ');
        level = Number(level);
        if (items != undefined) {
            items = items.split(', ');
        } else {
            items = [];
        }

        let hero = { name, level, items };
        heroes.push(hero);
    }

    return JSON.stringify(heroes);
}

console.log(inventory(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));
console.log("========");
console.log(inventory(['Jake / 1000 / Gauss, HolidayGrenade']));