function previous(year, month, day) {
    let date = new Date(year, month - 1, day);
    date.setDate(date.getDate() - 1);
    let prevYear = date.getFullYear();
    let prevMonth = date.getMonth() + 1;
    let prevDay = date.getDate();
    console.log(`${prevYear}-${prevMonth}-${prevDay}`);
}

previous(2016, 12, 20);
previous(2016, 9, 30);
previous(2016, 10, 1);
previous(2016, 1, 5);
