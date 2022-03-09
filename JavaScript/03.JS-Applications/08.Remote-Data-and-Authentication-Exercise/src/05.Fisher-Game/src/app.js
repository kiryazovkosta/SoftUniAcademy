let userData = null;

window.addEventListener("DOMContentLoaded", ready);

async function ready() {
    const addForm = document.querySelector('form#addForm');
    const addButton = addForm.querySelector('button');
    const loadButton = document.querySelector('button.load');

    userData = JSON.parse(localStorage.getItem('fisher_user'));
    if (userData == null) {
        document.getElementById('user').style.display = 'none';
    } else {
        console.log(userData);
        document.getElementById('guest').style.display = 'none';
        document.querySelector('span').textContent = userData.email;
        addButton.disabled = false;
    }

    loadButton.addEventListener('click', onLoad);
    addForm.addEventListener('submit', onAdd);

    await onLoad();
}

async function onLoad() {
    const req = await fetch('http://localhost:3030/data/catches');
    const data = await req.json();

    document.getElementById('catches').replaceChildren(...data.map(createCachesPreview));
}

function createCachesPreview(item) {
    const disabled = userData && userData._id == item._ownerId ? '' : ' disabled';

    const element = document.createElement('div');
    element.classList.add('catch');
    element.innerHTML = 
        `<label>Angler</label>
        <input type="text" class="angler" value="${item.angler}"${disabled}>
        <label>Weight</label>
        <input type="text" class="weight" value="${item.weight}"${disabled}>
        <label>Species</label>
        <input type="text" class="species" value="${item.species}"${disabled}>
        <label>Location</label>
        <input type="text" class="location" value="${item.location}"${disabled}>
        <label>Bait</label>
        <input type="text" class="bait" value="${item.bait}" ${disabled}>
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${item.captureTime}" ${disabled}>`;
        const updateButton = document.createElement('button');
        updateButton.textContent = 'Update';
        updateButton.classList.add('update');
        updateButton.setAttribute('data-id', item._id);
        updateButton.disabled = disabled == '' ? false : true;
        updateButton.addEventListener('click', onUpdate);
        element.appendChild(updateButton);
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.classList.add('delete');
        deleteButton.setAttribute('data-id', item._id);
        deleteButton.disabled = disabled == '' ? false : true;
        deleteButton.addEventListener('click', onDelete);
        element.appendChild(deleteButton);
    return element;
}

async function onUpdate(ev) {
    checkForUser();
    const url = 'http://localhost:3030/data/catches/' + ev.target.getAttribute('data-id');
    try {
        let data = {};
        [...ev.target.parentElement.querySelectorAll('input')].forEach(e => Object.assign(data, {[e.getAttribute('class')]: e.value}));
        const res = await fetch(url, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userData.accessToken,
            },
            body: JSON.stringify(data)
        });
        if (!res.ok) {
            const err = await res.json();
            throw new Error(err.message);
        }
        await onLoad();
    } catch (error) {
        console.log(error.message);
    }
}

async function onDelete(ev) {
    checkForUser();
    const url = 'http://localhost:3030/data/catches/' + ev.target.getAttribute('data-id');
    try {
        const res = await fetch(url, {
            method: 'delete',
            headers: {
                'X-Authorization': userData.accessToken,
            }
        });
        if (!res.ok) {
            const err = await res.json();
            throw new Error(err.message);
        }

        await onLoad();

    } catch (error) {
        alert(error.message);
    }
}

async function onAdd(event) {
    event.preventDefault();
    checkForUser();
    
    const formData = new FormData(event.target);
    try {
        const data = [...formData.entries()].reduce((a, [k, v]) => Object.assign(a, {[k]: v}), {});
        if (Object.values(data).some(x => x == '')) {
            throw new Error('Need to populate all fields');
        }

        const req = await fetch('http://localhost:3030/data/catches', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userData.accessToken,
            },
            body: JSON.stringify(data)
        });
        if (!req.ok) {
            const err = await req.json();
            throw new Error(err.message);
        }

        await onLoad();

    } catch (error) {
        alert(error.message);
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

        localStorage.removeItem('fisher_user');
        location.href = 'index.html';
    } catch (error) {
        alert(error.message);
    }
}

function checkForUser() {
    if (!userData) {
        location.href = 'login.html';
        return;
    }
}
