function toJson(input) {
    let output = [];
    let properties = [];
    for (let i = 0; i < input.length; i++) {
        if (i == 0) {
            [...properties] = input[i].split('|').filter(n => n.length > 0).map(n => n.trim());
        } else {
            let [...data] = input[i].split('|').filter(n => n.length > 0).map(n => n.trim());;
            data[1] = Number((Number(data[1]).toFixed(2)));
            data[2] = Number((Number(data[2]).toFixed(2)));

            let obj = {};
            let iter = 0;
            for (const prop of properties) {
                obj[prop] = data[iter++];
            }

            output.push(obj);
        }
    }

    return JSON.stringify(output);
}

console.log(toJson(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));