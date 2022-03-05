function attachEvents() {
    const locationElement = document.getElementById('location');
    const forecastElement = document.getElementById('forecast');
    const currentElement = document.getElementById('current');
    const currentLabelElement = currentElement.querySelector('div.label');
    const upcomingElement = document.getElementById('upcoming');
    const upcomingLabelElement = upcomingElement.querySelector('div.label');

    const submitElement = document.getElementById('submit');
    submitElement.addEventListener('click', getForecaster);

    async function getForecaster() {
        try {

            forecastElement.replaceChildren();

            const code = await getLocationCode(locationElement.value);
            const [today, upcoming] = await Promise.all([
                getTodayForecaster(code),
                getUpcomingForecaster(code)
            ]);

            currentElement.replaceChildren();
            currentLabelElement.textContent = 'Current conditions';
            currentElement.appendChild(currentLabelElement);
            currentElement.appendChild(await createToday(today));

            upcomingElement.replaceChildren();
            upcomingElement.appendChild(upcomingLabelElement);
            upcomingElement.appendChild(await createUpcoming(upcoming));

            forecastElement.appendChild(currentElement);
            forecastElement.appendChild(upcomingElement);
            forecastElement.style.display = 'block';

        } catch (error) {
            currentLabelElement.textContent = 'Error';
            currentElement.replaceChildren();
            currentElement.appendChild(currentLabelElement);
            forecastElement.appendChild(currentElement);
            forecastElement.style.display = 'block';
        }
    }
}

async function getLocationCode(name) {
    const url = 'http://localhost:3030/jsonstore/forecaster/locations';
    const response = await fetch(url);
    const locations = await response.json();
    return locations.find(loc => loc.name == name).code;
}

async function getTodayForecaster(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/today/' + code;
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

async function getUpcomingForecaster(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/' + code;
    const response = await fetch(url);
    const data = await response.json();
    return data;
}

async function getIcon(type) {
    const icons = {
        'Sunny': '&#x2600;',
        'Partly sunny': '&#x26C5;',
        'Overcast': '&#x2601;',
        'Rain': '&#x2614;',
        'Degrees': '&#176;',
        'Default': type
    }

    return (icons[type] || icons['Default']);
}

async function createToday(today) {
    let forecastersDivElement = document.createElement('div');
    forecastersDivElement.classList.add('forecasts');

    let forecatersMainSpan = document.createElement('span');
    forecatersMainSpan.classList.add('condition');
    forecatersMainSpan.classList.add('symbol');
    forecatersMainSpan.innerHTML = await getIcon(today.forecast.condition);

    let forecatersDataSpan= document.createElement('span');
    forecatersDataSpan.classList.add('condition');

    let forecatersDataCitySpan= document.createElement('span');
    forecatersDataCitySpan.classList.add('forecast-data');
    forecatersDataCitySpan.innerHTML = `${today.name}`;

    let forecatersDataTempSpan= document.createElement('span');
    forecatersDataTempSpan.classList.add('forecast-data');
    forecatersDataTempSpan.innerHTML = `${today.forecast.low}${await getIcon('Degrees')}/${today.forecast.high}${await getIcon('Degrees')}`;
    
    let forecatersDataConditionSpan= document.createElement('span');
    forecatersDataConditionSpan.classList.add('forecast-data');
    forecatersDataConditionSpan.innerHTML = `${today.forecast.condition}`;
    
    forecatersDataSpan.appendChild(forecatersDataCitySpan);
    forecatersDataSpan.appendChild(forecatersDataTempSpan);
    forecatersDataSpan.appendChild(forecatersDataConditionSpan);

    forecastersDivElement.appendChild(forecatersMainSpan);
    forecastersDivElement.appendChild(forecatersDataSpan);

    return forecastersDivElement;
}

async function createUpcoming(upcoming) {
    let divElement = document.createElement('div');
    divElement.classList.add('forecast-info');

    for (const forecast of upcoming.forecast) {
        let spanElement = document.createElement('span');
        spanElement.classList.add('upcoming');

        let subSpanElement = document.createElement('span');
        subSpanElement.classList.add('symbol');
        subSpanElement.innerHTML = await getIcon(forecast.condition);

        let subSpanElement2 = document.createElement('span');
        subSpanElement2.classList.add('forecast-data');
        subSpanElement2.innerHTML = `${forecast.low}${await getIcon('Degrees')}/${forecast.high}${await getIcon('Degrees')}`;

        let subSpanElement3 = document.createElement('span');
        subSpanElement3.classList.add('forecast-data');
        subSpanElement3.innerHTML = `${forecast.condition}`;

        spanElement.appendChild(subSpanElement);
        spanElement.appendChild(subSpanElement2);
        spanElement.appendChild(subSpanElement3);
        divElement.appendChild(spanElement);
    }

    return divElement;
}


attachEvents();