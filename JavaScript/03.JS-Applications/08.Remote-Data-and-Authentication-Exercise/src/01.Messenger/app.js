const url = 'http://localhost:3030/jsonstore/messenger';

function attachEvents() {
    const messagesElement = document.getElementById('messages');
    const authorElement = document.querySelector('input[name="author"]');
    const contentElement = document.querySelector('input[name="content"]');

    const submitButton = document.getElementById('submit');
    const refreshButton = document.getElementById('refresh');

    submitButton.addEventListener('click', async () => {
        const message = {
            author: authorElement.value.trim(),
            content: contentElement.value.trim(),
        };
        try {
            const response = await create(message);
            authorElement.value = '';
            contentElement.value = '';
            alert('Success');
        } catch (error) {
            alert(error)
        }
    });

    refreshButton.addEventListener('click', async () => {
        messagesElement.value = (await read()).map(msg => `${msg.author}: ${msg.content}`).join('\n');
    })
}

async function create(message) {
    const response = await fetch(url, {
        method: 'POST',
        headers: {

        },
        body: JSON.stringify(message)
    })

    return await response.json();
}

async function read() {
    const response = await fetch(url);
    const messages = await response.json();
    return Object.values(messages);
}

attachEvents();