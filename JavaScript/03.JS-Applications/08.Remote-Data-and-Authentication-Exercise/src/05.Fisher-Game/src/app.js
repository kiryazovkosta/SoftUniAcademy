let userData = null

window.addEventListener("DOMContentLoaded", ready);

async function ready() {
    userData = JSON.parse(localStorage.getItem('fisher_user'));
    if (userData == null) {
        document.getElementById('user').style.display = 'none';
    } else {
        console.log(userData);
        document.getElementById('guest').style.display = 'none';
        document.querySelector('span').textContent = userData.email;
    }
}

async function doLogout() {
    console.log('logout');
    const url = 'http://localhost:3030/users/logout';
    try {
        const req = await fetch(url, {
            headers: {
                'X-Authorization': userData.accessToken,
            }
        });
        if (!req.ok) {
            const err = await req.json();
            throw new Error(err.message);
        }

        localStorage.clear();
        location.href = 'index.html';
    } catch (error) {
        alert(error.message);
    }
}