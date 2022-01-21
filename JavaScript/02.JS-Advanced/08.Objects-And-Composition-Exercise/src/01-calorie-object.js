function calorie(elements) {
    let names = elements.filter((x, i) => {
        return i % 2 == 0;
    });
    let calories = elements.filter((x,i) => {
        return i % 2 != 0
    }).map(x => Number(x));

    let result = {};
    let index = 0;
    for (const name of names) {
        result[name] = calories[index++];
    }

    console.log(result);
}

calorie(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
console.log("======");
calorie(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);