import { logout } from './../services/user.js'

export function logoutPage(ctx) {
    logout();
    ctx.page.redirect('/');
}