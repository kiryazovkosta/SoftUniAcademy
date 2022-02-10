function validate() {
    let email = document.getElementById('email');
    email.addEventListener('change', function (ev) {
        if (!/\w+\@\w+\.\w+/.test(ev.target.value)) {
            ev.target.classList.add('error');
        } else {
            ev.target.classList.remove('error');
        }
    })
}