async function getRecipes() {
    const request = await fetch('http://localhost:3030/jsonstore/cookbook/recipes');
    const data = await request.json();
    return Object.values(data);
}

async function getReciptById(id) {
    const request = await fetch(`http://localhost:3030/jsonstore/cookbook/details/${id}`);
    const recipt = await request.json();
    return recipt;
}

function createReciptView(recipt) {
    let articleElement = createDomElement('article', { className: 'preview', onclick: displayReciptDetails },
        createDomElement('div', { className: 'title' }, createDomElement('h2', {}, recipt.name)),
        createDomElement('div', { className: 'small' }, createDomElement('img', { src: recipt.img, alt: 'img' }))
    );

    return articleElement;

    async function displayReciptDetails() {
        const rec = await getReciptById(recipt._id);
        articleElement.replaceWith(createReciptDetailedView(rec));
    }
}

function createReciptDetailedView(recipe) {
    const result = createDomElement('article', {},
        createDomElement('h2', {}, recipe.name),
        createDomElement('div', { className: 'band' },
            createDomElement('div', { className: 'thumb' }, createDomElement('img', { src: recipe.img })),
            createDomElement('div', { className: 'ingredients' },
                createDomElement('h3', {}, 'Ingredients:'),
                createDomElement('ul', {}, recipe.ingredients.map(i => createDomElement('li', {}, i))),
            )
        ),
        createDomElement('div', { className: 'description' },
            createDomElement('h3', {}, 'Preparation:'),
            recipe.steps.map(s => createDomElement('p', {}, s))
        ),
    );

    return result;
}


window.onload = async () => {
    const mainElement = document.querySelector('main');
    mainElement.replaceChildren();
    let recipes = await getRecipes();
    recipes.forEach(r => {
        mainElement.appendChild(createReciptView(r));
    })
}

function createDomElement(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}

