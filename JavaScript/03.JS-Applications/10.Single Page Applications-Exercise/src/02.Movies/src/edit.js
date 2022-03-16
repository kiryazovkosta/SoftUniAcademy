import { detailsPage } from "./details.js";
import { showView, getUser } from "./util.js";

const section = document.querySelector('#edit-movie');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

const titleElement = section.querySelector('#title');
const descriptionElement = section.querySelector('textarea');
const imgElement = section.querySelector('#imageUrl');

export function editPage(id) {
    populateForm(id);
    showView(section);
}

async function populateForm(id) {
    const movie = await getMovie(id);
    titleElement.value = movie.title;
    descriptionElement.value = movie.description;
    imgElement.value = movie.img;
    form.setAttribute('data-id', id);
}

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');
    editMovie(event.target.dataset.id, {title, description, img});
    detailsPage(event.target.dataset.id);
}

async function getMovie(id) {
    const res = await fetch(`http://localhost:3030/data/movies/${id}`);
    const movie = await res.json();

    return movie;
}

async function editMovie(id, movie) {
    const user = getUser();
    const res = await fetch(`http://localhost:3030/data/movies/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(movie)
    });
}