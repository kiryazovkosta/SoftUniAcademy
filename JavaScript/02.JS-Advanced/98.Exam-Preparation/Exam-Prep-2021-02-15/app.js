function solution() {
    const addButton = document.querySelector('button');
    const giftInput = document.querySelector('input');
    const ulElements = document.querySelectorAll('.card ul');
    const giftsList = ulElements[0];
    const sentList = ulElements[1];
    const discardList = ulElements[2];

    console.log(giftsList);

    addButton.addEventListener('click', addGift);

    function addGift(ev) {

        let giftLiElement = document.createElement('li');
        giftLiElement.textContent = giftInput.value;
        giftLiElement.className = 'gift';

        let sendButton = document.createElement('button');
        sendButton.id = 'sendButton';
        sendButton.innerText = 'Send';

        let discardButton = document.createElement('button');
        discardButton.id = 'discardButton';
        discardButton.innerText = 'Discard';

        giftLiElement.appendChild(sendButton);
        giftLiElement.appendChild(discardButton);

        giftsList.appendChild(giftLiElement);

        Array.from(giftsList.querySelectorAll('li'))
            .sort( (a,b) => a.textContent.localeCompare(b.textContent))
            .forEach(el => giftsList.appendChild(el));

        giftInput.value = '';

        sendButton.addEventListener('click', send);
        discardButton.addEventListener('click', discard);
    }

    function send(ev) {
        let node = ev.target.parentNode;
        node.lastElementChild.remove();
        node.lastElementChild.remove();
        sentList.appendChild(node);
    }

    function discard(ev) {
        let node = ev.target.parentNode;
        node.lastElementChild.remove();
        node.lastElementChild.remove();
        discardList.appendChild(node);
    }
}