let userData = null;

window.addEventListener('DOMContentLoaded', ready);

async function ready() {
    userData = JSON.parse(localStorage.getItem('fisher_user'));
    if (userData == null) {
        document.getElementById('user').style.display = 'none';
    } else {
        location.href = 'index.html';
    }

    document.querySelector('form').addEventListener('submit', onRegister);
}

async function onRegister(ev) {
    ev.preventDefault();
    const data = new FormData(ev.target);

    try {
        if ([...data.values()].some(x => x == '')) {
            throw new Error('Populate all input fields');
        }

        if (data.get('password') != data.get('rePass')) {
            throw new Error('Passwords missmatch');
        }

        const url = 'http://localhost:3030/users/register';
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

        location.href = "index.html";

    } catch (error) {
        alert(error.message);
    }
};