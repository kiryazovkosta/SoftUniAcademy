function attachEventsListeners() {
    Array.from(document.querySelectorAll('input[type="button"]'))
        .forEach(el => el.addEventListener('click', setTime));
    
    function setTime(ev){
        let textElement = ev.target.previousElementSibling;
        let type = textElement.id;
        let value = Number(textElement.value);
        let seconds = 0;
        let convertTo = {
            'days': function() {
                seconds = value * 24 * 60 * 60;
            },
            'hours': function() {
                seconds = value * 60 * 60;
            },
            'minutes': function() {
                seconds = value * 60;
            },
            'seconds': function() {
                seconds = value;
            }
        }

        convertTo[type]();
        document.getElementById('seconds').value = seconds;
        let minutes = seconds / 60;
        document.getElementById('minutes').value = minutes;
        let hours = minutes / 60;
        document.getElementById('hours').value = hours;
        let days = hours / 24;
        document.getElementById('days').value = days;
    }
}