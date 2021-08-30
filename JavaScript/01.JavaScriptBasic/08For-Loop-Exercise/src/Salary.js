function fine(params) {
    let tabs = Number(params[0]);
    let salary = Number(params[1]);
    for (let index = 0; index < tabs; index++) {
        const element = params[index + 2];
        switch (element) {
            case "Facebook":
                salary -= 150;
                break;

            case "Instagram":
                salary -= 100;
                break;

            case "Reddit":
                salary -= 50;
                break;

            default:
                break;
        }

        if (salary <= 0) {
            console.log("You have lost your salary.");
            break;
        }
    }

    if (salary > 0) {
        console.log(salary);
    }
}

fine(["10",
"750",
"Facebook",
"Dev.bg",
"Instagram",
"Facebook",
"Reddit",
"Facebook",
"Facebook"]);