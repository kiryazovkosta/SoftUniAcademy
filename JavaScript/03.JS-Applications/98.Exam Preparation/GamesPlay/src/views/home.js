import { html } from '../../node_modules/lit-html/lit-html.js';

const homeTemplate = () => html`<section class="welcome-content">
<article class="welcome-content-text">
    <h1>We Care</h1>
    <h1 class="bold-welcome">Your Pets</h1>
    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.</p>
</article>
<article class="welcome-content-image">
    <img src="./images/header-dog.png" alt="dog">
</article>
</section>`;

const previewTemplate = (game) => html`
<div class="game">
    <div class="image-wrap">
        <img src="${game.imageUrl}">
    </div>
    <h3>${game.title}</h3>
    <div class="rating">
        <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
    </div>
    <div class="data-buttons">
        <a href="/details/${game._id}" class="btn details-btn">Details</a>
    </div>
</div>`;

export async function homePage(ctx) {
    const games = await gameService.getRecent();
    ctx.render(homeTemplate(games));
}