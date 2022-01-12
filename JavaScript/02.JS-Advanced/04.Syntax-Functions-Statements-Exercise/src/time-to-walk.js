function walk(steps, meters, speed) {
    let distanceInMeters = steps * meters;
    let distanceInKilometers = distanceInMeters / 1000;
    let time = distanceInKilometers / speed;
    let extraMinutes = Math.floor(distanceInMeters / 500) * 60;
    let totalSeconds = time * 3600 + extraMinutes;

    let hours = 0;
    if (totalSeconds >= 3600) {
        hours = totalSeconds / 3600;
        totalSeconds = totalSeconds % 3600;
    }


    let minutes = Math.floor(totalSeconds / 60);
    let seconds = Math.round(totalSeconds % 60);
    console.log(`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`);
}

walk(4000, 0.6, 5);
walk(2564, 0.70, 5.5);