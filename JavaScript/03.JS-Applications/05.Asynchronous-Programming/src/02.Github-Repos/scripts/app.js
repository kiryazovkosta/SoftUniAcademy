async function loadRepos() {
	let userElement = document.getElementById('username');
	let reposElement = document.getElementById('repos');

	let url = `https://api.github.com/users/${userElement.value}/repos`;

	// const response = await fetch(`https://api.github.com/users/${userElement.value}/repos`);
	// console.log(response);
	// const data = await response.json();
	// console.log(data);

	const displayRepos = (repos) => {
		reposElement.replaceChildren();
		repos.forEach(repo => {
			let liElement = document.createElement('li');
			let anchorElement = document.createElement('a');
			anchorElement.innerText = repo.full_name;
			anchorElement.href = repo.html_url;
			liElement.appendChild(anchorElement);
			reposElement.appendChild(liElement);
		});
	};

	fetch(url)
		.then((response) => response.json())
		.then(displayRepos)
		.catch((error) => console.error(error));
}