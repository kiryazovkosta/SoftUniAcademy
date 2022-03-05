function attachEvents() {
    const postsElement = document.getElementById('posts');
    const btnLoadPosts = document.getElementById('btnLoadPosts');
    const btnViewPost = document.getElementById('btnViewPost');
    const postTitleElement = document.getElementById('post-title');
    const postBodyElement = document.getElementById('post-body');
    const postCommentsElement = document.getElementById('post-comments');

    btnViewPost.disabled = true;
    btnLoadPosts.addEventListener('click', loadPosts);
    btnViewPost.addEventListener('click', viewPost);

    async function loadPosts() {
        Object.values(await getPosts()).forEach(p => {
            const optionElement = document.createElement('option');
            optionElement.value = p.id;
            optionElement.innerHTML = p.title;
            postsElement.appendChild(optionElement);
        });

        btnViewPost.disabled = false;
    }

    async function viewPost() {
        const postId = postsElement.value;
        const [post, comments] = await Promise.all([
            getPostInfo(postId),
            getComments(postId)
        ]);

        setPostInformation(post);
        setPostComments(comments);
    }

    function setPostInformation(post) {
        postTitleElement.textContent = '';
        postBodyElement.innerHTML = '';
        postTitleElement.innerHTML = post.title;
        postBodyElement.textContent = post.body;
    }

    function setPostComments(comments) {
        postCommentsElement.replaceChildren();
        comments.forEach(comment => {
            let liElement = document.createElement('li');
            liElement.textContent = comment.text;
            postCommentsElement.appendChild(liElement);
        });
    }
}

async function getPosts() {
    const url = 'http://localhost:3030/jsonstore/blog/posts';
    const req = await fetch(url);
    return await req.json();
}

async function getPostInfo(postId) {
    const url = `http://localhost:3030/jsonstore/blog/posts/${postId}`;
    const req = await fetch(url);
    return await req.json();
}

async function getComments(postId) {
    const url = 'http://localhost:3030/jsonstore/blog/comments';
    const req = await fetch(url);
    const comments = Object.values(await req.json()).filter(c => c.postId == postId);
    return comments;
}

attachEvents();