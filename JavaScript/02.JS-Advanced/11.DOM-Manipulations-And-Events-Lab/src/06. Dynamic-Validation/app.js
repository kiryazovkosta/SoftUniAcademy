function validate() {
    let input = document.getElementById('email');
    input.addEventListener('change', function(event){
        let regex = new RegExp('^[a-z]+@[a-z]+\.[a-z]{2,3}$')
        let text = event.currentTarget.value;
        if(regex.test(text)) {
            input.className = '';
        } else {
            input.className = 'error';
        }
    })
}