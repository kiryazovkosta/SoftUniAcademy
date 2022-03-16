import { editPage } from './edit.js';
import { homePage } from './home.js';
import { showView, spinner, getUser } from './util.js';

const section = document.querySelector('#movie-example');

export function detailsPage(id) {
    showView(section);
    displayMovie(id);
}

async function displayMovie(id) {
    section.replaceChildren(spinner());

    const user = getUser();

    const [movie, likes, ownLike] = await Promise.all([
        getMovie(id),
        getLikes(id),
        getOwnLike(id, user)
    ]);

    section.replaceChildren(createMovieCard(movie, user, likes, ownLike));
}

function createMovieCard(movie, user, likes, ownLike) {
    const element = document.createElement('div');
    element.className = 'container';
    element.innerHTML = `
    <div class="row bg-light text-dark">
        <h1>Movie title: ${movie.title}</h1>
        <div class="col-md-8">
            <img class="img-thumbnail" src="${movie.img}" alt="Movie">
        </div>
        <div class="col-md-4 text-center">
            <h3 class="my-3 ">Movie Description</h3>
            <p>${movie.description}</p>
            ${createControls(movie, user, ownLike)}
            <span class="enrolled-span">Liked ${likes}</span>
        </div>
    </div>`;

    const likeBtn = element.querySelector('.like-btn');
    if (likeBtn) {
        likeBtn.addEventListener('click', (e) => likeMovie(e, movie._id));
    }

    const deleteBtn = element.querySelector('.delete-btn');
    if (deleteBtn) {
        deleteBtn.addEventListener('click', (e) => deleteMovie(e, user));
    }

    const editBtn = element.querySelector('.edit-btn');
    if (editBtn) {
        editBtn.addEventListener('click', editMovie);
    }

    return element;
}

function createControls(movie, user, ownLike) {
    const isOwner = user && user._id == movie._ownerId;

    let controls = [];

    if (isOwner) {
        controls.push(`<a data-id="${movie._id}" class="btn btn-danger delete-btn" href="#">Delete</a>`);
        controls.push(`<a data-id="${movie._id}" class="btn btn-warning edit-btn" href="#">Edit</a>`);
    } else if (user && ownLike == false) {
        controls.push('<a class="btn btn-primary like-btn" href="#">Like</a>');
    }
    controls.push();

    return controls.join('');
}

async function getMovie(id) {
    const res = await fetch(`http://localhost:3030/data/movies/${id}`);
    const movie = await res.json();

    return movie;
}

async function getLikes(id) {
    const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
    const likes = await res.json();

    return likes;
}

async function getOwnLike(movieId, user) {
    if (!user) {
        return false;
    } else {
        const userId = user._id;
        const res = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);
        const like = await res.json();

        return like.length > 0;
    }
}

async function likeMovie(e, movieId) {
    e.preventDefault();

    const user = getUser();

    await fetch('http://localhost:3030/data/likes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify({
            movieId
        })
    });

    detailsPage(movieId);
}

async function deleteMovie(e, user) {
    e.preventDefault();
    const id = e.target.dataset.id;

    await fetch(`http://localhost:3030/data/movies/${id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': user.accessToken
        }
    });

    homePage();
}

function editMovie(e) {
    e.preventDefault();
    const id = e.target.dataset.id;
    editPage(id);
}