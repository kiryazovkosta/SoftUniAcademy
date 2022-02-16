window.addEventListener('load', solution);

function solution() {
  let inputElements = Array.from(document.querySelectorAll('div#form input'));
  let labelElements = Array.from(document.querySelectorAll('div#form label'));
  
  let submitButton = inputElements.pop();
  let editButton = document.getElementById('editBTN')
  let continueButton = document.getElementById('continueBTN');

  let previewUlElement = document.getElementById('infoPreview');

  submitButton.addEventListener('click', submit);
  editButton.addEventListener('click', edit);
  continueButton.addEventListener('click', cont);

  let blockDiv = document.getElementById('block');

  function submit(ev) {
    if (inputElements[0].value !== '' && inputElements[1].value !== '') {
      for (let i = 0; i < labelElements.length; i++) {
        let previewLiElement = document.createElement('li');
        previewLiElement.textContent = `${labelElements[i].textContent} ${inputElements[i].value}`;
        previewUlElement.appendChild(previewLiElement);
      }

      submitButton.disabled = true;
      editButton.disabled = false;
      continueButton.disabled = false;
      inputElements.forEach(el => el.value = '');

    }
  }

  function edit(ev) {
    let liElements = Array.from(previewUlElement.querySelectorAll('li'));
    for (let i = 0; i < inputElements.length; i++) {
      inputElements[i].value = liElements[i].textContent.split(': ')[1];
    }

    previewUlElement.innerHTML = '';

    submitButton.disabled = false;
    editButton.disabled = true;
    continueButton.disabled = true;
  }

  function cont(ev) {
    blockDiv.innerHTML = '';
    let h3Element = document.createElement('h3');
    h3Element.textContent = 'Thank you for your reservation!';
    blockDiv.appendChild(h3Element);
  }

}
