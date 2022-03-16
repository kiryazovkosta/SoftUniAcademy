import { homePage } from "./home.js";
import { showView, getUser } from "./util.js";

const section = document.querySelector('#add-movie');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function createPage() {
    showView(section);
}

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');
    if (title != '' && description != '' && img != '') {
        await create(title, description, img);
        form.reset();
        homePage();
    }
}

async function create(title, description, img) {
    try {
        const res = await fetch('http://localhost:3030/data/movies', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': getUser().accessToken
            },
            body: JSON.stringify({title, description, img})
        });
    } catch (err) {
        alert(err.message);
        throw err;
    }
}