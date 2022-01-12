function radar(speed, area) {
    
    let limit  = 0;
    if (area === 'residential') {
        limit = 20;
    } else if (area === 'city') {
        limit = 50;
    } else if (area === 'interstate') {
        limit = 90;
    } else if (area === 'motorway') {
        limit = 130;
    }
    
    if (speed <= limit) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
    else{
        let overTheLimit = speed - limit;
        let status = '';
        if (overTheLimit <= 20) {
            status = 'speeding';
        } else if (overTheLimit <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${overTheLimit} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
}

radar(40, 'city');
radar(21, 'residential');
radar(120, 'interstate');
radar(200, 'motorway');