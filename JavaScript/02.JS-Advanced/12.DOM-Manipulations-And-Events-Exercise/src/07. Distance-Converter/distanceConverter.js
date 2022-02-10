function attachEventsListeners() {
    const convertUnits = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254,
    }

    let inputDistance = document.getElementById('inputDistance');
    let outputDistance = document.getElementById('outputDistance');
    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');
    let button = document.getElementById('convert');
    button.addEventListener('click', convert);

    function convert(ev) {
        let inputValue = Number(inputDistance.value);
        let inputUnit = inputUnits.value;
        let outputUnit = outputUnits.value;
        let meters = convertToMeters(inputValue, inputUnit);
        let output = convertFromMeters(meters, outputUnit)
        outputDistance.value = output;
    }

    function convertToMeters(value, unit){
        return convertUnits[unit] * value;
    }

    function convertFromMeters(value, unit){
        return value / convertUnits[unit];
    }
}