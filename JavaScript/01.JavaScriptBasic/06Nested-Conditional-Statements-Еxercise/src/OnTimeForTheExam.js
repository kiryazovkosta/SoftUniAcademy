function onTimeForTheExam(params) {
    let examHour = Number(params[0]);
    let examMinutes = Number(params[1]);
    let arrivalHour = Number(params[2]);
    let arrivalMinutes = Number(params[3]);
    let beforeOrAfter;
    let deltaMinutes = 0;
    let deltaHours = 0;
    let isOnTime;
 
    let examInMinutes = examHour * 60 + examMinutes;
    let arrivalInMinutes = arrivalHour * 60 + arrivalMinutes;
    deltaMinutes = examInMinutes - arrivalInMinutes;
 
    if (deltaMinutes < 0) {
        beforeOrAfter = "after";
        deltaMinutes *= -1;
        isOnTime = "Late";
    } else {
        beforeOrAfter = "before";
        if (deltaMinutes <= 30) {
            isOnTime = "On time";
        } else {
            isOnTime = "Early";
        }
    }
 
    console.log(isOnTime);
 
    if (deltaMinutes > 0 && deltaMinutes <= 59) {
        console.log(`${deltaMinutes} minutes ${beforeOrAfter} the start`)
    } else if (deltaMinutes > 59) {
        deltaHours = Math.floor(deltaMinutes / 60);
        deltaMinutes = deltaMinutes % 60;
        if (deltaMinutes < 10) {
            console.log(`${deltaHours}:0${deltaMinutes} hours ${beforeOrAfter} the start`);
        } else {
            console.log(`${deltaHours}:${deltaMinutes} hours ${beforeOrAfter} the start`);
        }
    }
}