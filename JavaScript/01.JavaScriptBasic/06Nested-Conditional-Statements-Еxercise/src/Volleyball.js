function volleyball([arg1, arg2, arg3]) {
    let yearType = arg1;
    let holidays = Number(arg2);
    let weekendsHome = Number(arg3);

    let totalGames = 0;
    let gamesSofia = ((2 / 3) * holidays) + (3 / 4) * (48 - weekendsHome);
    let gamesHome = weekendsHome;

    totalGames = gamesHome + gamesSofia;

    if (yearType === 'leap') {
        totalGames *= 1.15;
    }

    console.log(Math.floor(totalGames));
}

volleyball(['leap', '5', '2']);
volleyball(["normal", "3","2"]);