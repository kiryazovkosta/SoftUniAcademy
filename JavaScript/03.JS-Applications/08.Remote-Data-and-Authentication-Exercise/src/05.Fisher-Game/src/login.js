let userData = null;

window.addEventListener('DOMContentLoaded', ready);

async function ready() {
    userData = JSON.parse(localStorage.getItem('fisher_user'));
    if (userData == null) {
        document.getElementById('user').style.display = 'none';
    } else {
        location.href = 'index.html';
    }

    document.querySelector('form').addEventListener('submit', onLogin);
}

async function onLogin(ev) {
    ev.preventDefault();
    const data = new FormData(ev.target);

    try {
        if ([...data.values()].some(x => x == '')) {
            throw new Error('Populate all input fields')
        }
        const url = 'http://localhost:3030/users/login';
        const request = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                email: data.get('email').trim(),
                password: data.get('password').trim()
            })
        });
        if (!request.ok) {
            const error = await request.json();
            throw new Error(error.message);
        }

        const user = await request.json();
        localStorage.setItem('fisher_user', JSON.stringify(user));

        location.href = "index.html";

    } catch (error) {
        alert(error.message);
    }
};