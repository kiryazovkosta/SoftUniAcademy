const views = [...document.querySelectorAll('.view-section')];
const userElements = [...document.querySelectorAll('.user')];
const guestElements = [...document.querySelectorAll('.guest')];

function hideAll() {
    views.forEach(v => v.style.display = 'none');
}

export function showView(section) {
    hideAll();
    section.style.display = 'block';
}

export function spinner() {
    const element = document.createElement('p');
    element.innerHTML = 'Loading ...';
    return element;
}

export function updateNav() {
    const user = JSON.parse(localStorage.getItem('movie-user'));
    const messageContainer = document.getElementById('welcome-message');
    if (user) {
        messageContainer.textContent = `Welcome ${user.email}`;
        userElements.forEach(e => e.style.display = 'inline-block');
        guestElements.forEach(e => e.style.display = 'none');
    } else {
        messageContainer.textContent = '';
        guestElements.forEach(e => e.style.display = 'inline-block');
        userElements.forEach(e => e.style.display = 'none');
    }
}

export function getUser() {
    const user = JSON.parse(localStorage.getItem('movie-user'));
    return user;
}