function encodeAndDecodeMessages() {
    let buttons = Array.from(document.querySelectorAll('button'));
    let encodeTextElement = buttons[0].previousElementSibling;
    let decodeTextElement = buttons[1].previousElementSibling;
    buttons[0].addEventListener('click', function(ev){
        let output = '';
        for (const char of encodeTextElement.value) {
            output += String.fromCharCode(char.toString().charCodeAt(char) + 1);
        }

        decodeTextElement.value = output;
        encodeTextElement.value = '';
    });
    buttons[1].addEventListener('click', function(ev){
        let output = '';
        for (const char of decodeTextElement.value) {
            output += String.fromCharCode(char.toString().charCodeAt(char) - 1);
        }

        decodeTextElement.value = output;
    });
}