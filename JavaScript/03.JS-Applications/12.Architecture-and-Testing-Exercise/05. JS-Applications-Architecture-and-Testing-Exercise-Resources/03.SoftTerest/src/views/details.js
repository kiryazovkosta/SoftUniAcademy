import { deleteIdea, getById } from "../api/data.js";

const section = document.getElementById('detailsPage');

export async function showDetails(context, id) {
    const idea = await getById(id);
    context.showSection(section);

    const user = JSON.parse(localStorage.getItem('user'));
    const isOwner = user && user._id == idea._ownerId;

    section.innerHTML = createIdeaHTML(idea, isOwner);
    if (isOwner) {
        section.querySelector('#deleteBtn').addEventListener('click', async (event) => {
            event.preventDefault();
            const choise = confirm('Delete?');
            if (choise) {
                await deleteIdea(id);
                context.goTo('/catalog');
            }
        });
    }
}

function createIdeaHTML(idea, isOwner) {
    let html = `
    <img class="det-img" src="${idea.img}" />
    <div class="desc">
        <h2 class="display-5">${idea.title}</h2>
        <p class="infoType">Description:</p>
        <p class="idea-description">${idea.description}</p>
    </div>`;

    
    if (isOwner) {
        html += `
        <div class="text-center">
            <a data-id="${idea._id}" class="btn detb" href="/delete">Delete</a>
        </div>`
    }

    return html;
}