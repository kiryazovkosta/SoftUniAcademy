function lockedProfile() {
    getUsers();
}

function getUsers(main) {
    const mainElement = document.getElementById('main');
    mainElement.replaceChildren();
    
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    fetch(url).then((response) => {
        if (response.ok) {
            return response.json();
        }
        throw new Error('Something went wrong');
    })
        .then((responseJson) => {
            Object.values(responseJson)
                .forEach((u, i) => mainElement.appendChild(createProfileCard(u, i)));
        })
        .catch((error) => {
            console.log(error);
        });
}

function createProfileCard(user, index) {
    console.log(user);
    console.log(index);

    const profileElement = document.createElement('div');
    profileElement.classList.add('profile');
    profileElement.innerHTML = `<img src="./iconProfile2.png" class="userIcon" />
    <label>Lock</label>
    <input type="radio" name="user${index}Locked" value="lock" checked>
    <label>Unlock</label>
    <input type="radio" name="user${index}Locked" value="unlock"><br>
    <hr>
    <label>Username</label>
    <input type="text" name="user${index}Username" value="${user.username}" disabled readonly />
    <div class="hiddenInfo">
        <hr>
        <label>Email:</label>
        <input type="email" name="user${index}Email" value="${user.email}" disabled readonly />
        <label>Age:</label>
        <input type="email" name="user${index}Age" value="${user.age}" disabled readonly />
    </div>`;

    const button = document.createElement('button');
    button.textContent = `Show more`;
    button.addEventListener('click', () => {
        const locked = profileElement.querySelector('input[type="radio"]').checked;
        if (!locked) {
            if (button.textContent == 'Show more') {
                Array.from(profileElement.querySelectorAll('div.hiddenInfo label')).forEach(el => el.style.display = 'block');
                Array.from(profileElement.querySelectorAll('div.hiddenInfo input')).forEach(el => el.style.display = 'block');
               button.innerText = 'Hide it';
            } else {
                Array.from(profileElement.querySelectorAll('div.hiddenInfo label')).forEach(el => el.style.display = 'none');
                Array.from(profileElement.querySelectorAll('div.hiddenInfo input')).forEach(el => el.style.display = 'none');
                button.innerText = 'Show more';
            }
        }
    });
    profileElement.appendChild(button);

    return profileElement;
}