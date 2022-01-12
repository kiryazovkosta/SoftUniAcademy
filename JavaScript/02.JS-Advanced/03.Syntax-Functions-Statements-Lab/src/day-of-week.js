function dayIndex(day) {
    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday','Sunday'];
    let index = days.indexOf(day);
    if (index >= 0) {
        console.log(index + 1);
    } else {
        console.log("error")
    }
}

dayIndex('Monday');
dayIndex('Friday');
dayIndex('Invalid');
