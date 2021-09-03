function giveNames(params) {
    let floorsCount = Number(params[0]);
    let roomsCount = Number(params[1]);
    for (let floorIndex = floorsCount; floorIndex > 0; floorIndex--) {
        let row = "";
        for (let roomIndex = 0; roomIndex < roomsCount; roomIndex++) {
            if (floorIndex < floorsCount) {
                if (floorIndex % 2 !== 0) {
                    row += `A${floorIndex}${roomIndex} `;
                } else {
                    row += `O${floorIndex}${roomIndex} `;
                }
            } else {
                row += `L${floorIndex}${roomIndex} `;
            }
        }

        console.log(row.trimEnd());
    }
}

giveNames(["6", "4"]);
//giveNames(["9", "5"]);