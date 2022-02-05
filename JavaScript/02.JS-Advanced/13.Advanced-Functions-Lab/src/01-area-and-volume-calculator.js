function solve(area, vol, input) {
    let output = [];
    let figures = JSON.parse(input);
    for (const figure of figures) {
        let figureArea = area.apply(figure);
        let figureVolume = vol.apply(figure);
        output.push({
            area: figureArea,
            volume: figureVolume,
        });
    }

    return output;
}


solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
);

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};


