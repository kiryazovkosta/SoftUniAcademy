import { updateAuth, saveUser } from '../auth.js';
import * as api from '../api.js';
import { renderHome } from '../pages/home.js';

const loginSection = document.querySelector('.login');
const loginForm = loginSection.querySelector('form');

loginForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);
    let email = formData.get('email');
    let password = formData.get('password');

    api.login(email, password)
        .then(user => {
            saveUser(user);
            updateAuth();
            loginForm.reset();
            loginSection.style.display = 'none';
            renderHome();
        });
});

export function renderLogin() {
    loginSection.style.display = 'block';
}