function solve(params) {
    let name = params[0];
    let study = true;
    let index = 1;
    let missing = 0;
    let finish = true;
    let grades = 0;
    while (study) {
        let grade = Number(params[index]);
        
        if (grade < 4.00) {
            missing++;
        }

        if (missing === 2) {
            console.log(`${name} has been excluded at ${index - 1} grade`);
            finish = false;
            break;
        }

        grades += grade;
        
        index++;

        if (index > 12) {
            break;
        }
    }

    if (finish) {
        console.log(`${name} graduated. Average grade: ${(grades/12).toFixed(2)}`);
    }
}

solve(["Gosho", 
"5",
"5.5",
"6",
"5.43",
"5.5",
"6",
"5.55",
"5",
"6",
"6",
"5.43",
"5"]);

solve(["Mimi", 
"5",
"6",
"5",
"6",
"5",
"6",
"6",
"2",
"3"]);