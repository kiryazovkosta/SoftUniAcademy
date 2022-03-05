function solve() {
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');
    const infoElement = document.querySelector('span.info');

    let stopId = {
        name: 'Depot',
        next: 'depot'
      };     

    async function depart() {
        infoElement.textContent = 'Loading...';
        departButton.disabled = true;
        arriveButton.disabled = false;

        const url = `http://localhost:3030/jsonstore/bus/schedule/${stopId.next}`;
        const response = await fetch(url);
        stopId = await response.json();
        
        infoElement.textContent = `Next stop ${stopId.name}`;
    }

    function arrive() {
        departButton.disabled = false;
        arriveButton.disabled = true;
        infoElement.textContent = `Arriving at ${stopId.name}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();