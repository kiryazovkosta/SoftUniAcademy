function focused() {
    let inputs = document.getElementsByTagName('input');
    for (const input of inputs) {
        input.addEventListener('focus', focused);
        input.addEventListener('blur', blured);
    }

    function focused(e){
        e.target.parentElement.classList.add('focused');
    }

    function blured(e) {
        e.target.parentElement.classList.remove('focused');
    }
}