function minimal(params) {
    let count = Number(params[0]);
    let min = Number.MAX_SAFE_INTEGER;
    for (let index = 1; index <= count; index++) {
        const element = Number(params[index]);
        if (element < min) {
            min = element;
        }
    }

    console.log(min);
}

minimal(["2","100","99"]);
minimal(["3","-10","20","-30"]);	
minimal(["4","45","-20","7","99"]);
minimal(["1","999"]);
minimal(["2","-1","-2"]);