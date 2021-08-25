function totalTime(input) {
    let firstSeconds = Number(input[0]);
    let secondSeconds = Number(input[1]);
    let thirdSeconds = Number(input[2]);

    let totalSeconds = firstSeconds + secondSeconds + thirdSeconds;

    let minutes = Math.floor(totalSeconds / 60);
    let seconds = totalSeconds % 60;

    if (seconds < 10) {
        console.log(`${minutes}:0${seconds}`);
    } else {
        console.log(`${minutes}:${seconds}`);
    }
}

totalTime(["35","45","44"]);
totalTime(["22", "7", "34"]);
totalTime(["35","45","44"]);
totalTime(["50","50","49"]);
totalTime(["14", "12","10"]);