function figureArea(input) {
    let figure = input[0];
    let area = undefined;
    switch (figure) {
        case "square":
            let side = Number(input[1]);
            area = side * side;
            break;

        case "rectangle":
            let a = Number(input[1]);
            let b = Number(input[2]);
            area = a * b;
            break;

        case "circle":
            let radius = Number(input[1]);
            area = Math.PI * Math.pow(radius, 2);
            break;

        case "triangle":
            let base = Number(input[1]);
            let height = Number(input[2]);
            area = (base * height) / 2;
            break;
    
        default:
            break;
    }

    console.log(area.toFixed(3));
}

figureArea(["square", "5"]);