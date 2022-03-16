import { homePage } from "./home.js";
import { showView, updateNav } from "./util.js";

const section = document.querySelector('#form-login');
const form = section.querySelector('form');

export function loginPage() {
    showView(section);
}

form.addEventListener('submit', onSubmit);

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(form);
    const email = formData.get('email');
    const password = formData.get('password');
    await login(email, password);
    form.reset();
    updateNav();
    homePage();
}

async function login(email, password) {
    try {
        const res = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            header: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });
        if(!res.ok) {
            const error = await res.json();
            throw new Error(error.message);
        }

        const user = await res.json();
        localStorage.setItem('movie-user', JSON.stringify(user));

    } catch (error) {
        alert(error.message);
        throw error;
    }
}