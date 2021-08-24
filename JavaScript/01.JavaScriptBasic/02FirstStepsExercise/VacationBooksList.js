function solve(input) {
    let totalPages = Number(input[0]);
    let pagesPerHour = Number(input[1]);
    let days = Number(input[2]);

    let totalHours = totalPages / pagesPerHour;
    let hoursPerDay = totalHours / days;
    console.log(hoursPerDay);
}

solve(["212",
"20",
"2"]);

solve(["432",
"15",
"4"]);