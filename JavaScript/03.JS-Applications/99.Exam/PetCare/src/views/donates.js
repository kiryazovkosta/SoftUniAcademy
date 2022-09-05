import * as donatesService from './../services/donate.js';

export async function donatePage(ctx) {
    const petId = ctx.params.id;
    await donatesService.create({petId});
    console.log
    ctx.page.redirect(`/details/${petId}`);
}