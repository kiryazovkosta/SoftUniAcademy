import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as petsService from './../services/pets.js';
import * as donateService from './../services/donate.js';

const detailsTemplate = (pet, onDelete, onDonate) => html`
<section id="detailsPage">
<div class="details">
    <div class="animalPic">
        <img src="${pet.image}">
    </div>
    <div>
        <div class="animalInfo">
            <h1>Name: ${pet.name}</h1>
            <h3>Breed: ${pet.breed}</h3>
            <h4>Age: ${pet.age}</h4>
            <h4>Weight: ${pet.weight}</h4>
            <h4 class="donation">Donation: ${pet.total * 100}$</h4>
        </div>
        <!-- if there is no registered user, do not display div-->
        ${pet.isLogged ? 
            html`${pet.isOwner ? 
                html`
                    <div class="actionBtn">
                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                    <a href="javascript:void(0)" class="remove" @click=${onDelete}>Delete</a>
                    </div>` 
                : 
                html`${pet.isDonated == 1 ? nothing : html`<div class="actionBtn"><a href="/donate/${pet._id}" class="donate">Donate</a></div>`}`
            }` : nothing}
    </div>
</div>
</section>`;

export async  function detailsPage(ctx) {
    const petId = ctx.params.id;
    const [pet, total, hasDonated] = await Promise.all([
        petsService.getById(petId),
        donateService.countAll(petId)
    ]);

    pet.total = total;

    if (ctx.user) {
        pet.isOwner = ctx.user.id == pet._ownerId;
        pet.isLogged = true;
        pet.isDonated = await donateService.count(petId, ctx.user.id);
    }

    ctx.render(detailsTemplate(pet, onDelete));

    async function onDelete() {
        const choise = confirm('Are you sure?');
        if (choise) {
            await petsService.deleteById(pet._id);
            ctx.page.redirect('/');
        }
    }
}