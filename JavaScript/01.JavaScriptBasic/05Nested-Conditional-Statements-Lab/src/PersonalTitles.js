function title(input) {
    let age = Number(input[0]);
    let gender = input[1];
    if (gender === "m") {
        if (age >= 16) {
            console.log("Mr.");
        } else {
            console.log("Master");
        }
    } else if (gender === "f") {
        if (age >= 16) {
            console.log("Ms.");
        } else {
            console.log("Miss");
        }
    }
}

title(["12", "f"]);
title(["17", "m"]);
title(["25", "f"]);
title(["13.5", "m"]);