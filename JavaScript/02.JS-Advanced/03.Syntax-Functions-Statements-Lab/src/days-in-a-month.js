function daysCount(month, year) {
    const date = new Date(year, month, 0);
    console.log(date.getDate());
}

daysCount(1, 2021);
daysCount(2, 2021);
daysCount(3, 2021);
daysCount(4, 2021);