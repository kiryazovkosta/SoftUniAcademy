function preparation(params) {
    let bad = Number(params[0]);
    let badCounter = 0;
    let failed = false;
    let scores = 0;
    let scoresCounter = 0;
    let index = 1;
    let title = params[index];
    let last = "";
    while (title !== "Enough") {
        index++;
        let score = Number(params[index]);

        if (score <= 4.00) {
            badCounter++;
        }

        if (badCounter === bad) {
            failed = true;
            break;
        }

        scoresCounter++;
        scores += score;
        last = title;

        index++;
        title = params[index];
    }

    if (failed) {
        console.log(`You need a break, ${badCounter} poor grades.`);
    } else {
        console.log(`Average score: ${(scores/scoresCounter).toFixed(2)}`);
        console.log(`Number of problems: ${scoresCounter}`);
        console.log(`Last problem: ${last}`);
    }
}

preparation(["2",
"Income",
"3",
"Game Info",
"6",
"Best Player",
"4"]);

preparation(["3",
"Money",
"6",
"Story",
"4",
"Spring Time",
"5",
"Bus",
"6",
"Enough"]);