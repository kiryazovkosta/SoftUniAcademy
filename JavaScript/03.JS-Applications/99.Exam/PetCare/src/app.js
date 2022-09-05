import page from '../node_modules/page/page.mjs';

import { addSession } from './middlewares/session.js';
import { addRender } from './middlewares/render.js';

import { homePage } from './views/home.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { logoutPage } from './views/logout.js';
import { donatePage } from './views/donates.js'


page(addSession);
page(addRender);
page('/', homePage);
page('/catalog', catalogPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/register', registerPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/donate/:id', donatePage);

page.start();