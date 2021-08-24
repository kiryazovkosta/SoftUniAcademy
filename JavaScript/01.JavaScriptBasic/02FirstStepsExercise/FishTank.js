function solve(input) {
    let length = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);
    let percentage = Number(input[3]);

    let volume = (length * width * height) * 0.001;
    volume = volume - (volume * (percentage / 100));
    console.log(volume);
}

solve(["85","75","47","17"]);
solve(["105","77","89","18.5"]);