async function solution() {
    try {
        const mainElement = document.getElementById('main');
        const articles = await getArticles();
        articles.forEach(a => mainElement.appendChild(createArticle(a)));
    } catch (error) {
        console.log(error);
    }
}

async function getArticles() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';

    const response = await fetch(url);
    const data = await response.json();
    return data;
}

async function getArticleInfo(id) {
    const url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;
    const response = await fetch(url);
    const info = await response.json();
    return info;
}

function createArticle(article) {
    let accordionDivElement = document.createElement('div');
    accordionDivElement.classList.add('accordion');

    const headDivElement = document.createElement('div');
    headDivElement.classList.add('head');
    const headSpanElement = document.createElement('span');
    headSpanElement.textContent = article.title;
    const headButtonElement = document.createElement('button');
    headButtonElement.classList.add('button');
    headButtonElement.id = article._id;
    headButtonElement.innerHTML = 'More';
    headDivElement.appendChild(headSpanElement);
    headDivElement.appendChild(headButtonElement);
    accordionDivElement.appendChild(headDivElement);

    const extraDivElement = document.createElement('div');
    extraDivElement.classList.add('extra');
    const extraPElement = document.createElement('p');
    extraDivElement.appendChild(extraPElement);
    accordionDivElement.appendChild(extraDivElement);

    headButtonElement.addEventListener('click', async function(ev){
        if (ev.target.textContent == 'More') {
            const articleData = await getArticleInfo(ev.target.id);
            extraPElement.textContent = articleData.content;
            extraDivElement.classList.remove('extra');
            ev.target.textContent = 'Less';
        } else {
            extraPElement.textContent = '';
            extraDivElement.classList.add('extra');
            ev.target.textContent = 'More';
        }
    });

    return accordionDivElement;
}

solution();