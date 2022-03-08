const url = 'http://localhost:3030/jsonstore/collections/books';

let book_id = undefined;

window.onload = async function() {
    const tableBooks = document.querySelector('table tbody');
    const loadBooks = document.getElementById('loadBooks');
    loadBooks.addEventListener('click', displayBooks);

    async function displayBooks() {
        tableBooks.replaceChildren();
        const books = await getBooks();
        for (const [key, val] of Object.entries(books)) {
            tableBooks.appendChild(displayBookRow(key, val));
        }
    }

    const formElement = document.querySelector('form');
    formElement.addEventListener('submit', async function (ev) {
            ev.preventDefault();
            console.log(ev);
            const data = new FormData(formElement);
            const book = {
                author: data.get('author'),
                title: data.get('title')
            };
            const buttonText = ev.currentTarget.querySelector('button').textContent;
            try {
                if (buttonText == 'Submit') {
                    await createBook(book);
                    await displayBooks();
                } else {
                    await updateBook(book_id, book);
                    document.querySelector('form h3').textContent = 'Form';
                    document.querySelector('form button').textContent = 'Submit';
                    book_id = undefined;
                }
                document.querySelector('input[name="title"]').value = '';
                document.querySelector('input[name="author"]').value = '';
            } catch (error) {
                alert(error.message);
            }
        });
}

function displayBookRow(key, val) {
    const tr = document.createElement('tr');
    const tdTitle = document.createElement('td');
    tdTitle.textContent = val.title;
    const tdAuthor = document.createElement('td');
    tdAuthor.textContent = val.author;
    const tdButtons = document.createElement('td');
    const editButton = document.createElement('button');
    editButton.textContent = 'Edit';
    editButton.addEventListener('click', function(ev) {
        document.querySelector('input[name="title"]').value = tdTitle.textContent;
        document.querySelector('input[name="author"]').value = tdAuthor.textContent;
        document.querySelector('form h3').textContent = 'EditForm';
        document.querySelector('form button').textContent = 'Save';
        book_id = key;
    });
    const deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', async function(ev) {
        try {
            await deleteBook(key);
            tr.remove();
        } catch (error) {
            alert(error.message);
        }
    });
    tdButtons.appendChild(editButton);
    tdButtons.appendChild(deleteButton);
    tr.appendChild(tdTitle);
    tr.appendChild(tdAuthor);
    tr.appendChild(tdButtons);

    return tr;
}

async function getBooks() {
    const req = await fetch(url);
    const books = await req.json();
    return books;
}

async function createBook(book) {
    const req = await fetch(url, {
        method: 'post',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(book)
    });
    const result = await req.json();
    return result;
}

async function updateBook(id, book) {
    const req = await fetch(url + `/${id}`, {
        method: 'put',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(book)
    });
    const result = await req.json();
    return result;
}

async function deleteBook(id) {
    const req = await fetch(url + `${id}`, {
        method: 'delete'
    });
    const book = await req.json();
    return book;
}