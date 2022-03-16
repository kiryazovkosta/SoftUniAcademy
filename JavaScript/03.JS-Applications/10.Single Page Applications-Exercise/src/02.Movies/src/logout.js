import { homePage } from "./home.js";
import { updateNav } from "./util.js";

export function logoutPage() {
    localStorage.removeItem('movie-user');
    updateNav();
    homePage();
}