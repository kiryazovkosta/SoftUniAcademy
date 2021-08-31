function canMove(params) {
    let width = Number(params[0]);
    let length = Number(params[1]);
    let height = Number(params[2]);
    let volume = width * length * height;
    let index = 3;
    let data = params[index];
    while (data !== "Done") {
        let boxes = Number(data);
        volume -= boxes;
        if (volume < 0) {
            console.log(`No more free space! You need ${Math.abs(0 - volume)} Cubic meters more.`);
            break;
        }

        index++;
        data = params[index];
    }

    if (volume >= 0) {
        console.log(`${volume} Cubic meters left.`);
    }
}

canMove(["10", 
"10",
"2",
"20",
"20",
"20",
"20",
"122"]);

canMove(["10",
"1",
"2",
"4",
"6",
"Done"]);