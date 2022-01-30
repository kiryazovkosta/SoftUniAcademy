function create(words) {
   let root = document.getElementById('content');
   //let data = JSON.parse(words);
   //words = data.split(', ');
   for (const word of words) {
      let pElement = document.createElement('p');
      pElement.textContent = word;
      pElement.style.display = 'none';
      let divElement = document.createElement('div');
      divElement.appendChild(pElement);
      divElement.addEventListener('click', function(event){
         let childPElement = event.currentTarget.querySelector('p');
         childPElement.style.display = 'inline';
      });

      root.appendChild(divElement);
   }
}