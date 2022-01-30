function lockedProfile() {
    Array.from(document.querySelectorAll('button')).forEach(b => {
        b.addEventListener('click', function(ev){
            let rootDiv = ev.target.parentElement;
            let locked = rootDiv.querySelector('input[value="lock"]').checked;
            if (locked === false) {
                let hiddenDiv = ev.target.previousElementSibling;
                let display = hiddenDiv.style.display;
                hiddenDiv.style.display = display === 'none' || display === '' ? 'inline' : 'none';
                ev.target.textContent = ev.target.textContent === 'Show more' ? 'Hide it' : 'Show more';
            }
        })
    });
}