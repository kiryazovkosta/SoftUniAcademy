function addMinutes(input) {
    let hours = Number(input[0]);
    let minutes = Number(input[1]);

    minutes += 15;
    if (minutes >= 60) {
        minutes -= 60;
        hours++;
    }

    if (hours > 23) {
        hours = 0;
    }

    console.log(`${hours}:${(minutes + '').padStart(2, '0')}`);
}

addMinutes(["1", "46"]);
addMinutes(["0", "01"]);
addMinutes(["23", "59"]);
addMinutes(["11", "08"]);
addMinutes(["12", "49"]);