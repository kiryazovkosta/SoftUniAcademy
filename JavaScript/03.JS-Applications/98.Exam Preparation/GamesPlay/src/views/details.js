import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as gameService from '../services/games.js';

const detailsTemplate = (game, onDelete) => html`
<section id="game-details">
<h1>Game Details</h1>
<div class="info-section">

    <div class="game-header">
        <img class="game-img" src="${game.imageUrl}" />
        <h1>${game.title}</h1>
        <span class="levels">MaxLevel: ${game.maxLevel}</span>
        <p class="type">${game.category}</p>
    </div>

    <p class="text">${game.summary}</p>

    ${commentSection}


    ${game.isOwner ? html`<div class="buttons">
        <a href="/edit/${game._id}" class="button">Edit</a>
        <a href="javascript:void(0)" class="button" @click=${onDelete}>Delete</a>
    </div>` : nothing }
    
</div>

${commentFormSection}

</section>`;

export async  function detailsPage(ctx) {
    const gameId = ctx.params.id;
    const game = await gameService.getById(gameId);

    if (ctx.user) {
        game.isOwner = ctx.user.id == game._ownerId;
    }

    ctx.render(detailsTemplate(game, onDelete));

    async function onDelete() {
        const choise = confirm('Are you sure?');
        if (choise) {
            await gameService.deleteById(game._id);
            ctx.page.redirect('/');
        }
    }
}