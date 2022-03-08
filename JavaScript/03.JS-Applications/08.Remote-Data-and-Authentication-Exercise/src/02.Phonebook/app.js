function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const phonebookElement = document.getElementById('phonebook');
    const btnLoad = document.getElementById('btnLoad');
    btnLoad.addEventListener('click', () => {
        readContacts();
    });

    const personElement = document.getElementById('person');
    const phoneElement = document.getElementById('phone');
    const btnCreate = document.getElementById('btnCreate');
    btnCreate.addEventListener('click', function() {
        createContact({
            person: personElement.value,
            phone: phoneElement.value
        });

        personElement.value = '',
        phoneElement.value = ''
    });

    function readContacts() {
        fetch(url)
        .then((response) => response.json())
        .then((data) => {
            phonebookElement.replaceChildren();
            Object.values(data).forEach(c => phonebookElement.appendChild(createLiElement(c)));
        })
        .catch((error) => alert(error.message));
    }

    function deleteContact(key) {
        fetch(url + `/${key}`, {
            method: 'DELETE',
        })
        .then((response) => response.json())
        .then((data) => {
            const lis = Array.from(phonebookElement.children);
            phonebookElement.replaceChildren();
            lis.filter(li => li.id != `cnt_${key}`).forEach(c => phonebookElement.appendChild(c));
        })
        .catch((error) => alert(error.message));
    }

    function createContact(contact) {
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json' 
            },
            body: JSON.stringify(contact)
        })
        .then((res) => res.json())
        .then((result) => {
            phonebookElement.appendChild(createLiElement(result));
        })
    }

    function createLiElement(contact) {
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', () => {
            deleteContact(contact._id);
        });

        let liElement = document.createElement('li');
        liElement.textContent = `${contact.person}: ${contact.phone}`;
        liElement.id = `cnt_${contact._id}`;
        liElement.appendChild(deleteButton);
        return liElement;
    }
}


attachEvents();