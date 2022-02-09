function validate() {
    let button = document.getElementById('submit');
    button.addEventListener('click', function(ev){
        ev.preventDefault();

        let inputsElements = Array.from(document.getElementsByTagName('input'));
        for (const iterator of inputsElements) {
            console.log(iterator);
            console.log(iterator.id);
        }
    })
}
