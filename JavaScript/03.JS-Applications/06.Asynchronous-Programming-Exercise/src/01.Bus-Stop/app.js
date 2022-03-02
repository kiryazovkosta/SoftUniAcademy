function getInfo() {
    let submitElement = document.getElementById('submit');
    let stopNameElement = document.getElementById('stopName');
    let busesElement = document.getElementById('buses');

    const stopIdElement = document.getElementById('stopId');
    let url = `http://localhost:3030/jsonstore/bus/businfo/${stopIdElement.value}`;

    submitElement.disabled = true;
    stopNameElement.textContent = 'Loading...';
    busesElement.replaceChildren();

    const displayBusInfo = (stopInfo) => {
        stopNameElement.textContent = stopInfo.name;
        for( const [busId, time] of Object.entries(stopInfo.buses)) {
            let liElement = document.createElement('li');
            liElement.textContent = `Bus ${busId} arrives in ${time} minutes`;
            busesElement.appendChild(liElement);
        }
    };

    const displayErrorInfo = () => {
        stopNameElement.textContent = 'Error';
    }

    fetch(url)
        .then((response) => response.json())
        .then(displayBusInfo)
        .catch(displayErrorInfo);

    stopIdElement.value = '';
    submitElement.disabled = false;
}