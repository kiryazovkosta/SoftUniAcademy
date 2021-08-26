function worldRecord(input) {
    let recordTime = Number(input[0]);
    let distance = Number(input[1]);
    let timePerMeter = Number(input[2]);

    let time = distance * timePerMeter;
    let extraTime = (Math.floor(distance / 15)) * 12.5;
    time += extraTime;
    if (time < recordTime) {
        console.log(`Yes, he succeeded! The new world record is ${time.toFixed(2)} seconds.`);
    } else {
        console.log(`No, he failed! He was ${Math.abs(recordTime - time).toFixed(2)} seconds slower.`)
    }
}

worldRecord(["10464", "1500", "20"]);
worldRecord(["55555.67", "3017", "5.03"]);
